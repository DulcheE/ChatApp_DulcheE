using Communication;
using Communication.Models;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using static ServerSide.Database;

namespace ServerSide
{
    class ServerTopic
    {
        private Topic _topic;

        private ServerTopicEvent Event;

        public Dictionary<TcpClient, ServerClientTopicListener> serverTopicListeners;
        private bool _execute = true;

        public void KillThreads()
        {
            Console.WriteLine("Attempt to kill all the Thread of the ServerTopicListener of the Topic `" + this._topic.Topic_name + "` !");
            _execute = false;

            foreach (KeyValuePair<TcpClient, ServerClientTopicListener> stl in serverTopicListeners)
            {
                stl.Value.Terminate();
            }

            this.serverTopicListeners.Clear();
        }


        public ServerTopicEvent eventSender => Event;


        public ServerTopic(Topic topic)
        {
            this._topic = topic;
            this.Event = new ServerTopicEvent();
            this.serverTopicListeners = new Dictionary<TcpClient, ServerClientTopicListener>();
        }




        public void start()
        {
            TcpListener _listener = new TcpListener(new System.Net.IPAddress(new byte[] { 127, 0, 0, 1 }), _topic.Port);
            _listener.Start();

            Console.WriteLine("[TopicServer `" + this._topic.Topic_name + "`] Creation du thread\n");

            while (_execute)
            {
                Console.WriteLine("[TopicServer `" + this._topic.Topic_name + "`] En attente de message au port: " + _topic.Port);
                TcpClient connection = _listener.AcceptTcpClient();

                Console.WriteLine("[TopicServer `" + this._topic.Topic_name + "`] Connection etablie avec : " + connection.Client.RemoteEndPoint + "`\n");
                ServerClientTopicListener topicListener = new ServerClientTopicListener(_topic, connection, this);
                this.serverTopicListeners.Add(connection, topicListener);

                new Thread(topicListener.HandlingConnection).Start();
            }
        }




        public void SendMessageToClients(string message)
        {
            this.eventSender.OnSendMessageIntopic(this, new Response(new SendMessage(this._topic, this._topic, message), MessageService.addToTopic(this._topic, this._topic, message)));
        }

    }
}
