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

    /// <summary>
    /// Handle new client connecting to the server and create a new ServerClientListener for each to listen to the TcpClient stream
    /// </summary>
    class Server
    {
        private int _port;

        private List<ServerClientListener> _serverListeners;
        private Dictionary<string, ServerTopic> _serverTopics;


        public Dictionary<string, ServerTopic> serverTopics => _serverTopics;

        private bool terminated = false;



        /// <summary>
        /// Instantiate new Server
        /// </summary>
        /// <param name="port">The port the TcpListener will listen to after Start</param>
        public Server(int port)
        {
            this._port = port;
            this._serverListeners = new List<ServerClientListener>();
            this._serverTopics = new Dictionary<string, ServerTopic>();

            TopicService.InitPort();
        }


        /// <summary>
        /// Create the TcpLister listening at the IP adress 127.0.0.1 and at the port choose at the initilisation of the server.
        /// Create all TopicServer for each Topic in the database.
        /// Then listen for new TcpClient and give it to a new ServerClientListener.
        /// </summary>
        public void Start()
        {
            TcpListener _listener = new TcpListener(new System.Net.IPAddress(new byte[] { 127, 0, 0, 1 }), _port);
            _listener.Start();

            Console.WriteLine("lauching server");

            Dictionary<string, Topic> topics = TopicService.getAll();

            foreach(KeyValuePair<string, Topic> topic in topics)
            {
                ServerTopic topicServer = new ServerTopic(topic.Value);
                this._serverTopics.Add(topic.Key, topicServer);
                new Thread(topicServer.start).Start();
            }

            while (!terminated)
            {
                TcpClient connection = _listener.AcceptTcpClient();

                Console.WriteLine("connection etablie avec : " + connection.Client.RemoteEndPoint);
                ServerClientListener listener = new ServerClientListener(this, connection);
                this._serverListeners.Add(listener);

                new Thread(listener.HandlingConnection).Start();
            }

        }



        /// <summary>
        /// Terminate all Threads for each ServerClientListener and all ServerTopic and stop listening for new TcpClient
        /// </summary>
        public void KillServer()
        {
            terminated = true;

            foreach (ServerClientListener sl in this._serverListeners)
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
