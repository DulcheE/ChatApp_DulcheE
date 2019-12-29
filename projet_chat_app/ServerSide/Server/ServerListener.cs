using System;
using System.Collections.Generic;
using System.Text;

using Communication.Models;
using Communication;
using System.Net.Sockets;
using System.Threading;
using static ServerSide.Database;

namespace ServerSide
{
    class ServerListener
    {
        private TcpClient connection;

        private static Dictionary<string, TcpClient> DestPrive = new Dictionary<string, TcpClient>();
        private User User;

        private bool _execution = true;


        public void Terminate()
        {
            this._execution = false;

            this.connection.GetStream().Close();
            this.connection.Close();

            ServerEvents.MessageSender -= this.OnMessageSended;
        }

        public ServerListener(TcpClient connection)
        {
            this.connection = connection;

            ServerEvents.MessageSender += this.OnMessageSended;
        }


        public void HandlingConnection()
        {
            try
            {
                while (_execution)
                {
                    Console.WriteLine("Wainting Communication...\n");
                    ClientCommunication request = Net.RecieveClientCommunication(this.connection.GetStream());

                    //On créer un nouveau thread qui gère la ressource et on continue d'écouter
                    HandlingRequest(request);
                }
            }
            catch (System.IO.IOException e)
            {
                if (this.User != null)
                    DestPrive.Remove(this.User.Username);

                Console.WriteLine("The connection to the client has ended !");
                Console.WriteLine(e.Message);
            }
            catch(System.Runtime.Serialization.SerializationException e)
            {
                if (this.User != null)
                    DestPrive.Remove(this.User.Username);

                Console.WriteLine("The connection to the client has ended !");
                Console.WriteLine(e.Message);
            }
        }




        private void HandlingRequest(ClientCommunication request)
        {
            Console.WriteLine("Communication recieve :\n[");

            try
            {
                switch (request)
                {

                    case SendMessage m:
                        Console.WriteLine("Type of Communication is Message\n");

                        HandlingMessage(m);

                        break;


                    case LogIn li:
                        Console.WriteLine("Type of Communication is LogIn\n");

                        HandlingLogIn(li);

                        break;


                    case SignIn si:
                        Console.WriteLine("Type of Communication is SignIn\n");

                        HandlingSignIn(si);

                        break;


                    case Join j:
                        Console.WriteLine("Type of Communication is Join\n");

                        HandlingJoin(j);

                        break;


                    case Leave l:
                        Console.WriteLine("Type of Communication is Leave\n");

                        HandlingLeave(l);

                        break;


                    case Creation c:
                        Console.WriteLine("Type of Communication is Creation\n");

                        HandlingCreation(c);

                        break;


                    case Delete d:
                        Console.WriteLine("Type of Communication is Delete\n");

                        HandlingDelete(d);

                        break;

                    case AskConnectUser acu:
                        Console.WriteLine("type of Communication is ask user \n");

                        HandlingAskUser(acu);

                        break;


                    default:
                        Console.WriteLine("Type of Communication unknown");

                        HandlingDefault(request);

                        break;

                }

            }
            catch (CommunicationException e)
            {
                Console.WriteLine(e.Message);
                Net.SendServerCommunication(this.connection.GetStream(), new Response(request, e));
            }

            Console.WriteLine("]\n");
        }


        private void HandlingAskUser(AskConnectUser ask)
        {

            List<string> users = new List<string>();
            foreach(KeyValuePair<string,TcpClient> client in DestPrive)
            {
                if (client.Key.Equals(ask.asker.Username) == false)
                {
                    users.Add(client.Key);
                }
            }

            if (users.Count <= 0)
            {
                throw new NoUserConnectedException("No other user are connected !");
            }


            Net.SendServerCommunication(connection.GetStream(), new Response(ask, users));

        }

        private void HandlingMessage(SendMessage m)
        {

            if (m.Dest is User)
            {
                Net.SendClientCommunication(DestPrive[((User)m.Dest).Username].GetStream(), m);
            }
            else
            {
                ServerEvents.OnSendMessage(this, m);
            }
            
        }


        private void HandlingLogIn(LogIn li)
        {
            Console.WriteLine(li);


            this.User = Database.UserService.getByUsername(li.Username);

            if (this.User.Password != li.Password)
            {
                throw new InvalidCredentialsException("Wrong password for the User `" + li.Username + "` !");
            }


            Console.WriteLine("Login succeed !\n");

            DestPrive.Add(this.User.Username, this.connection);

            Initializer init = new Initializer(TopicService.getByUser(this.User), new Dictionary<string, Topic>(), this.User);

            Net.SendServerCommunication(this.connection.GetStream(), new Response(li, init));

        }


        private void HandlingSignIn(SignIn si)
        {
            Console.WriteLine(si);


            User new_user = Database.UserService.add(si);

            Console.WriteLine("New User `" + new_user.Username + " created !\n");
            Net.SendServerCommunication(this.connection.GetStream(), new Response(si, new Success("New User `" + new_user.Username + " created !")));
        }


        private void HandlingJoin(Join j)
        {
            Console.WriteLine(j);

            if (Database.TopicService.join(j))
            {
                Console.WriteLine("User " + j.User.Username + " join the Topic " + j.Topic_name + " !\n");
                //TopicEventManager.topics[j.Topic.Topic_name].TopicSender += this.OnMessageSended;
                Console.WriteLine("sending response about joining topic");

                Topic topic = TopicService.getByTopic_name(j.Topic_name);

                Net.SendServerCommunication(this.connection.GetStream(), new Response(j, topic));
            }
            else
            {
                Console.WriteLine("Failed to join the topic !\n");
                Net.SendServerCommunication(this.connection.GetStream(), new Response(j, new Error(new Exception("Failed to join the topic !"))));
            }

        }


        private void HandlingLeave(Leave l)
        {
            Console.WriteLine(l);

        }


        private void HandlingCreation(Creation c)
        {
            Console.WriteLine(c);

            Topic new_topic = Database.TopicService.add(c);
            if (new_topic == null)
            {
                Console.WriteLine("Failed to create new Topic !\n");
                Net.SendServerCommunication(this.connection.GetStream(), new Response(c, new Error(new Exception("Failed to create new Topic !"))));
            }
            else
            {
                Console.WriteLine("New Topic `" + new_topic.Topic_name + "` created !\n");
                Net.SendServerCommunication(this.connection.GetStream(), new Response(c, new_topic));


                Console.WriteLine("Creating new TopicServer for `" + new_topic.Topic_name + "` !\n");
                ServerTopic topicServer = new ServerTopic(new_topic);
                new Thread(topicServer.start).Start();
            }

        }


        private void HandlingDelete(Delete d)
        {
            Console.WriteLine(d);

        }


        private void HandlingDefault(Object o)
        {
            Console.WriteLine(o);

        }




        public void OnMessageSended(Object source, SendMessage m)
        {

            Console.WriteLine("entrez OnMessageSended");

            try
            {
                Console.WriteLine("entrez dans le try");
                if (m != null)
                {
                    Console.WriteLine("appel de send com");
                    Net.SendServerCommunication(connection.GetStream(), new Response(m, null));
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            catch
            {
                Console.WriteLine("error catches");
            };
        }

    }
}
