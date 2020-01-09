using Communication.Models;
using Communication;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using TestProjectForm;
using System.Windows.Forms;

namespace ClientSide
{
    /// <summary>
    /// Connect to the Server and start the UI menu
    /// </summary>
    public partial class Client
    {
        public readonly Form1 Form;

        public readonly string hostname;
        private int _port;
        private TcpClient _comm;

        private User _User;
        private Dictionary<string, ClientTopic> _Topics;

        public User User => this._User;
        public Dictionary<string, ClientTopic> Topics => _Topics;

        public Client(string hostname, int port, Form1 Form)
        {
            this.hostname = hostname;
            this._port = port;
            this.Form = Form;

            this._Topics = new Dictionary<string, ClientTopic>();

            ResponseEvent.DebugLog = this.Form.DebugLog;
        }



        /// <summary>
        /// Connect to the Server and start a new Thread to listen to the stream, then start the UI menu
        /// </summary>
        public void Start()
        {

            try
            {
                this._comm = new TcpClient(hostname, _port);
                string thread_name = Thread.CurrentThread.Name;
                this.Form.DebugLog.Invoke(new MethodInvoker(delegate {
                    this.Form.DebugLog.PrintDebug(System.Drawing.Color.Green, "[" + thread_name + "] Connection established with " + this._comm.Client.RemoteEndPoint);
                }) );

                Thread t = new Thread(this.Listener);
                t.Name = "ClientListener";
                t.Start();
            }
            catch(SocketException e)
            {
                string thread_name = Thread.CurrentThread.Name;
                this.Form.DebugLog.Invoke(new MethodInvoker(delegate {
                    this.Form.DebugLog.PrintDebug(System.Drawing.Color.Red, "[" + thread_name + "] Impossible to connect to the server :\n" + e.Message);
                }) );

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
            this.Form.DebugLog.Invoke(new MethodInvoker(delegate {
                this.Form.DebugLog.PrintDebug(System.Drawing.Color.White, "Trying to connect as " + username + ":" + password);
            }));

            ClientCommunication request = new LogIn(username, password);
            Net.SendClientCommunication(this._comm.GetStream(), request);

            ResponseEvent.MyResponseEvent += new ResponseEvent(request, (response) =>
            {

                switch (response)
                {
                    case bool b:

                        if (b)
                        {
                            this.Form.DebugLog.Invoke(new MethodInvoker(delegate {
                                this.Form.DebugLog.PrintDebug(System.Drawing.Color.Green, "I'm connected as " + username);
                            }));

                            this.Form.Connect();
                        }

                        break;


                    case CommunicationException ce:

                        this.Form.DebugLog.Invoke(new MethodInvoker(delegate {
                            this.Form.DebugLog.PrintDebug(System.Drawing.Color.Red, ce.Message);
                        }) );

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
