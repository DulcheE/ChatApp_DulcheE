using System;
using System.Collections.Generic;
using System.Text;

using Communication.Models;
using Communication;
using System.Net.Sockets;
using System.Threading;
using static ServerSide.Database;
using static ServerSide.Security;

namespace ServerSide
{
    class ServerClientListener
    {
        private Server _server;
        private TcpClient _connection;

        private static Dictionary<string, TcpClient> _DestPrive = new Dictionary<string, TcpClient>();
        private User _User;

        private bool _execution = true;


        public void Terminate()
        {
            this._execution = false;

            this._connection.GetStream().Close();
            this._connection.Close();

            ServerEvents.MessageSender -= this.OnMessageSended;
        }

        public ServerClientListener(Server server, TcpClient connection)
        {
            this._server = server;
            this._connection = connection;

            ServerEvents.MessageSender += this.OnMessageSended;
        }


        public void HandlingConnection()
        {
            try
            {
                while (_execution)
                {
                    Console.WriteLine("Wainting Communication...\n");
                    ClientCommunication request = Net.RecieveClientCommunication(this._connection.GetStream());
                    Console.WriteLine("New Communication recieved !\n");

                    //On gère la ressource et on continue d'écouter
                    HandlingRequest(request);
                }
            }
            catch (System.IO.IOException e)
            {
                if (this._User != null)
                    _DestPrive.Remove(this._User.Username);

                Console.WriteLine("The connection to the client has ended !");
                Console.WriteLine(e.Message);
            }
            catch(System.Runtime.Serialization.SerializationException e)
            {
                if (this._User != null)
                    _DestPrive.Remove(this._User.Username);

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
                Net.SendServerCommunication(this._connection.GetStream(), new Response(request, e));
            }

            Console.WriteLine("]\n");
        }


        private void HandlingAskUser(AskConnectUser ask)
        {

            List<string> users = new List<string>();
            foreach(KeyValuePair<string,TcpClient> client in _DestPrive)
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


            Net.SendServerCommunication(_connection.GetStream(), new Response(ask, users));

        }

        private void HandlingMessage(SendMessage m)
        {
            switch (m.Dest)
            {
                case User uDest:

                    Security.TestUser((User)m.Source, this._User);

                    Net.SendServerCommunication( _DestPrive[(uDest).Username].GetStream(), new ApprouvedMessage(MessageService.addToUser(uDest, m.Source, m.Content)) );

                    break;


                default:

                    ServerEvents.OnSendMessage(this, m);

                    break;
            }
            
        }


        private void HandlingLogIn(LogIn li)
        {
            Console.WriteLine(li);

            User user = Database.UserService.getByUsername(li.Username);
            user.Password = li.Password;

            Security.TestUser(user);


            this._User = user;

            UserService.setCookie(ref this._User);


            Console.WriteLine("Login succeed !\nCookie is : {0}\n", this._User.Cookie);

            if (_DestPrive.ContainsKey(this._User.Username))
                _DestPrive[this._User.Username] = this._connection;
            else
                _DestPrive.Add(this._User.Username, this._connection);

            Initializer init = new Initializer(TopicService.getByUser(this._User), new Dictionary<string, Topic>(), this._User);

            Net.SendServerCommunication(this._connection.GetStream(), new Response(li, init));

        }


        private void HandlingSignIn(SignIn si)
        {
            Console.WriteLine(si);


            User new_user = Database.UserService.add(si);

            Console.WriteLine("New User `" + new_user.Username + "` created !\n");
            Net.SendServerCommunication(this._connection.GetStream(), new Response(si, new Success("New User `" + new_user.Username + " created !")));
        }


        private void HandlingJoin(Join j)
        {
            Console.WriteLine(j);

            TopicService.join(j);

            Console.WriteLine("User " + j.User.Username + " join the Topic " + j.Topic_name + " !\n");


            Topic topic = TopicService.getByTopic_name(j.Topic_name);

            Net.SendServerCommunication(this._connection.GetStream(), new Response(j, topic));

            this._server.serverTopics[topic.Topic_name].SendMessageToClients("The User `" + j.User.Username + "` join the topic !");
        }


        private void HandlingLeave(Leave l)
        {
            Console.WriteLine(l);

        }


        private void HandlingCreation(Creation c)
        {
            Console.WriteLine(c);

            Topic new_topic = TopicService.add(c);
            if (new_topic == null)
            {
                Console.WriteLine("Failed to create new Topic !\n");
                Net.SendServerCommunication(this._connection.GetStream(), new Response(c, new Error(new Exception("Failed to create new Topic !"))));
            }
            else
            {
                Console.WriteLine("New Topic `" + new_topic.Topic_name + "` created !\n");
                Net.SendServerCommunication(this._connection.GetStream(), new Response(c, new_topic));


                Console.WriteLine("Creating new TopicServer for `" + new_topic.Topic_name + "` !\n");
                ServerTopic topicServer = new ServerTopic(new_topic);
                this._server.serverTopics.Add(new_topic.Topic_name, topicServer);
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
                    Net.SendServerCommunication(_connection.GetStream(), new Response(m, null));
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
