using Communication.Models;
using Communication;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using static ServerSide.Database;

namespace ServerSide
{
    class Server
    {
        private int port;

        private List<ServerListener> _serverListeners;
        public Dictionary<string, ServerTopic> _serverTopics;

        public Server(int port)
        {
            this.port = port;
            this._serverListeners = new List<ServerListener>();
            this._serverTopics = new Dictionary<string, ServerTopic>();

            TopicService.InitPort();
        }



        public void start()
        {
            TcpListener _listener = new TcpListener(new System.Net.IPAddress(new byte[] { 127, 0, 0, 1 }), port);
            _listener.Start();

            Console.WriteLine("lauching server");

            Dictionary<string, Topic> topics = TopicService.getAll();

            foreach(KeyValuePair<string, Topic> topic in topics)
            {
                ServerTopic topicServer = new ServerTopic(topic.Value);
                this._serverTopics.Add(topic.Key, topicServer);
                new Thread(topicServer.start).Start();
            }

            while (true)
            {
                TcpClient connection = _listener.AcceptTcpClient();

                Console.WriteLine("connection etablie avec : " + connection.Client.RemoteEndPoint);
                ServerListener listener = new ServerListener(this, connection);
                this._serverListeners.Add(listener);

                new Thread(listener.HandlingConnection).Start();
            }

        }


        public void messageToTopic(Topic topic, string message)
        {
            this._serverTopics[topic.Topic_name].SendMessageToClients(message);
        }




        public void KillServer()
        {

            foreach (ServerListener sl in this._serverListeners)
            {
                sl.Terminate();
            }
            this._serverListeners.Clear();

            foreach (KeyValuePair<string, ServerTopic> sp in this._serverTopics)
            {
                sp.Value.KillThreads();
            }
            this._serverTopics.Clear();


            TopicService.ClearPort();
        }

    }
}
