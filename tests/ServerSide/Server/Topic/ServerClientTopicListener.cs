using Communication;
using Communication.Models;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using static ServerSide.Database;

namespace ServerSide
{
    class ServerClientTopicListener
    {
        private Topic _topic;
        private User _user;

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




        public ServerClientTopicListener(Topic topic, TcpClient connection, ServerTopic topicServer)
        {
            this._topic = topic;
            this._user = null;

            this._connection = connection;
            this._serverSource = topicServer;
        }


        ~ServerClientTopicListener()
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

                    //On gère la ressource et on continue d'écouter
                    if (request is Identification)
                        HandlingIdentification( (Identification)request);
                    else if (this._user != null)
                        HandlingRequest(request);
                    else
                    {
                        Net.SendServerCommunication(this._connection.GetStream(), new Response(request, new SecurityException("Identify yourself to the ServerTopicListener first !")));
                    }
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

        private void HandlingRequest(ClientCommunication request)
        {
            Console.WriteLine("[TopicListener `" + this._topic.Topic_name + "`] Communication recieve :");
            Console.WriteLine("[TopicListener `" + this._topic.Topic_name + "`] [");

            try
            {
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
            }
            catch(CommunicationException ce)
            {
                Console.WriteLine("Sending CommunicationException in Response :\n" + ce.Message);
                Net.SendServerCommunication(this._connection.GetStream(), new Response(request, ce));
            }

            Console.WriteLine("[TopicListener `" + this._topic.Topic_name + "`] ]");
        }

        private void HandlingMessage(SendMessage m)
        {
            Security.TestUser((User)m.Source, this._user);

            Response r = new Response(m, MessageService.add(m));
            _serverSource.eventSender.OnSendMessageIntopic(this, r);
        }

        private void HandlingLeave(Leave l)
        {
            Security.TestUser(l.User, this._user);

            _serverSource.SendMessageToClients("User `" + this._user.Username + "` leave the topic !");

            Net.SendServerCommunication(this._connection.GetStream(), new Response(l, new Success("Au revoir, vous quittez le topic")) );

            TopicService.leave(l);

            this._serverSource.serverTopicListeners.Remove(this._connection);

            this.Terminate();
        }

        private void HandlingDelete(Delete d)
        {
            //Test if i'm connected as the owner
            Security.TestUser(d.Owner, this._user);

            //Test if the owner is really the owner of the topic
            //Security.TestOwner(d.Owner, d.Topic);

            TopicService.delete(this._topic);
            Net.SendServerCommunication(this._connection.GetStream(), new Response(d, new Success("Delete of topic success")));

            this._serverSource.KillThreads();
        }

        private void HandlingIdentification(Identification i)
        {
            if (this._topic.Topic_name.Equals(i.topic_name))
            {
                this._user = i.user;

                _serverSource.eventSender.TopicSender += this.OnMessageSendedTopic;
                Net.SendServerCommunication(this._connection.GetStream(), new Response(i, MessageService.getAllByTopic(this._topic)));
            }
            else
            {
                Net.SendServerCommunication(this._connection.GetStream(), new Response(i, new SecurityException("Failure to identified to the ServerTopicListener !")));
            }

        }

        public void OnMessageSendedTopic(Object source, Response r)
        {

            try
            {
                if (r != null && r.Content is Message)
                {
                    Net.SendServerCommunication(this._connection.GetStream(), r);
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
