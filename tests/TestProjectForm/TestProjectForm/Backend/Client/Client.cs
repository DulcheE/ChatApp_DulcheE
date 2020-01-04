using Communication.Models;
using Communication;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using TestProjectForm;

namespace ClientSide
{
    /// <summary>
    /// Connect to the Server and start the UI menu
    /// </summary>
    public partial class Client
    {
        public readonly DebugLog DebugLog;

        public readonly string hostname;
        private int _port;
        private TcpClient _comm;

        private User _User;
        private Dictionary<string, ClientTopic> _Topics;

        public User User => this._User;
        public Dictionary<string, ClientTopic> Topics => _Topics;

        public Client(string hostname, int port, DebugLog DebugLog)
        {
            this.hostname = hostname;
            this._port = port;
            this.DebugLog = DebugLog;

            this._Topics = new Dictionary<string, ClientTopic>();

            ResponseEvent.DebugLog = this.DebugLog;
        }



        /// <summary>
        /// Connect to the Server and start a new Thread to listen to the stream, then start the UI menu
        /// </summary>
        public void Start()
        {

            try
            {
                this._comm = new TcpClient(hostname, _port);
                this.DebugLog.PrintDebug(System.Drawing.Color.Yellow, "[" + Thread.CurrentThread.Name + "] Connection established with " + this._comm.Client.RemoteEndPoint);

                Thread t = new Thread(this.Listener);
                t.Name = "ClientListener";
                t.Start();
            }
            catch(SocketException e)
            {
                this.DebugLog.PrintDebug(System.Drawing.Color.Red, "[" + Thread.CurrentThread.Name + "] Impossible to connect to the server :\n" + e.Message);
            }

        }



        /// <summary>
        /// Create new ClientTopic
        /// </summary>
        /// <param name="topic">The topic attached to the new ClientTopic</param>
        /// <returns></returns>
        public ClientTopic CreateClientTopic(Topic topic)
        {
            ClientTopic ct = new ClientTopic(this, topic);
            this.Topics.Add(ct.Topic.Topic_name, ct);

            return ct;
        }


        public void Connection(string username, string password)
        {

            ClientCommunication request = new LogIn(username, password);
            Net.SendClientCommunication(_comm.GetStream(), request);

            ResponseEvent.MyResponseEvent += new ResponseEvent(request, (response) =>
            {

                switch (response)
                {
                    case bool b:

                        if (b)
                            this.DebugLog.PrintDebug(System.Drawing.Color.Green, "I'm connected as " + username);

                        break;

                    case CommunicationException ce:

                        this.DebugLog.PrintDebug(System.Drawing.Color.Red, ce.Message);

                        break;
                }

            }).OnResponse;
        }



        /// <summary>
        /// Attach the client to a User and its Topics
        /// </summary>
        /// <param name="i">The Initializer containing the User and its Topics</param>
        public void Init(Initializer i)
        {
            this._User = i.User;
            this._Topics = new Dictionary<string, ClientTopic>();

            foreach (KeyValuePair<string, Topic> topic in i.TopicsPublic)
            {
                this.CreateClientTopic(topic.Value);
            }
        }


        /// <summary>
        /// Dettach the client to a User and terminate all the ClientTopic Threads
        /// </summary>
        public void Disconnect()
        {
            this._User = null;

            foreach (KeyValuePair<string, ClientTopic> clientTopic in this.Topics)
            {
                clientTopic.Value.Terminate();
            }
        }


        /// <summary>
        /// Stop the client and termnate all Threads
        /// </summary>
        public void KillClient()
        {
            this.Terminate();

            foreach(KeyValuePair<string, ClientTopic> clientTopic in this.Topics)
            {
                clientTopic.Value.Terminate();
            }
        }
    }
 
}
