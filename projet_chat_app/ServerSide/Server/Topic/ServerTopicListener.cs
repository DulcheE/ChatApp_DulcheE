using Communication;
using Communication.Models;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using static ServerSide.Database;

namespace ServerSide
{
    class ServerTopicListener
    {
        private Topic _topic;
        private TcpClient _connection;
        private ServerTopic _serverSource;

        private bool _execution = true;


        public void Terminate()
        {
            this._execution = false;
            this._serverSource.eventSender.TopicSender -= this.OnMessageSendedTopic;

            this._connection.GetStream().Close();
            this._connection.Close();
        }




        public ServerTopicListener(Topic topic, TcpClient connection, ServerTopic topicServer )
        {
            this._topic = topic;
            this._connection = connection;
            this._serverSource = topicServer;

            if(_serverSource != null)
            {
                _serverSource.eventSender.TopicSender += this.OnMessageSendedTopic;
                Net.SendServerCommunication(connection.GetStream(), new TopicMessages(MessageService.getAllByTopic(topic)));
            }
            else
            {
                Console.WriteLine("[TopicListener `" + this._topic.Topic_name + "`] Error no server source detected");
            }
        }


        ~ServerTopicListener()
        {
            if (this._serverSource != null)
            {
                _serverSource.eventSender.TopicSender -= this.OnMessageSendedTopic;
            }
        }

        public void HandlingConnection()
        {
            try
            {
                while (_execution)
                {
                    Console.WriteLine("[TopicListener `" + this._topic.Topic_name + "`] Wainting Communication...\n");
                    ClientCommunication request = Net.RecieveClientCommunication(this._connection.GetStream());

                    //On créer un nouveau thread qui gère la ressource et on continue d'écouter
                    HandlingRequest(request);
                }
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine("[TopicListener `" + this._topic.Topic_name + "`] The connection to the client has ended !");
                Console.WriteLine(e.Message);
            }
            catch (System.InvalidOperationException e)
            {
                Console.WriteLine("[TopicListener `" + this._topic.Topic_name + "`] The connection to the client has ended !");
                Console.WriteLine(e.Message);
            }
            catch (System.Runtime.Serialization.SerializationException e)
            {
                Console.WriteLine("[TopicListener `" + this._topic.Topic_name + "`] The connection to the client has ended !");
                Console.WriteLine(e.Message);
            }

        }

        private void HandlingRequest(Communication.CommunicationStream request)
        {
            Console.WriteLine("[TopicListener `" + this._topic.Topic_name + "`] Communication recieve :");
            Console.WriteLine("[TopicListener `" + this._topic.Topic_name + "`] [");

            switch (request)
            {
                case SendMessage m:
                    Console.WriteLine("[TopicListener `" + this._topic.Topic_name + "`] Type of Communication is Message");
                    Console.WriteLine("[TopicListener `" + this._topic.Topic_name + "`]");
                    Console.WriteLine("[TopicListener `" + this._topic.Topic_name + "`] " + m);

                    HandlingMessage(m);

                    break;


                case Leave l:
                    Console.WriteLine("[TopicListener `" + this._topic.Topic_name + "`] Type of Communication is Leave");
                    Console.WriteLine("[TopicListener `" + this._topic.Topic_name + "`]");
                    Console.WriteLine("[TopicListener `" + this._topic.Topic_name + "`] " + l);

                    HandlingLeave(l);

                    break;


                case Delete d:
                    Console.WriteLine("[TopicListener `" + this._topic.Topic_name + "`] Type of Communication is Delete");
                    Console.WriteLine("[TopicListener `" + this._topic.Topic_name + "`]");
                    Console.WriteLine("[TopicListener `" + this._topic.Topic_name + "`] " + d);

                    HandlingDelete(d);

                    break;
            }


            Console.WriteLine("[TopicListener `" + this._topic.Topic_name + "`] ]");
        }

        private void HandlingMessage(SendMessage m)
        {
            Response r = new Response(m, MessageService.add(m));
            _serverSource.eventSender.OnSendMessageIntopic(this, r);
        }

        private void HandlingLeave(Leave l)
        {
            Net.SendServerCommunication(this._connection.GetStream(), new Response(l, new Success("Au revoir vous quittez le topic")) );

            Database.TopicService.leave(l);

            this._serverSource.serverTopicListeners.Remove(this._connection);

            this.Terminate();
        }

        private void HandlingDelete(Delete dl)
        {
            if(dl.Owner.Username == dl.Topic.Owner.Username)
            {
                Database.TopicService.delete(this._topic);
                Net.SendServerCommunication(this._connection.GetStream(), new Response(dl, new Success("delete of topic success\n")));

                this._serverSource.KillThreads();
            }
            else
            {
                Net.SendServerCommunication(this._connection.GetStream(), new Response(dl, new UserNotOwnerOfTopicException("The User `" + dl.Owner.Username + "` is not the owner of the Topic `" + dl.Topic.Topic_name + "` !")));
            }
        }

        public void OnMessageSendedTopic(Object source, Response r)
        {

            try
            {
                if (r != null && r.Content is Message)
                {
                    Net.SendServerCommunication(_connection.GetStream(), r);
                }
                else
                {
                    Console.WriteLine("[TopicListener `" + this._topic.Topic_name + "`] Error");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("[TopicListener `" + this._topic.Topic_name + "`] " + e.Message);
            };
        }

    }
}
