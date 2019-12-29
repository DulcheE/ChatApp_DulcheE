using Communication.Models;
using Communication;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Front_Console;

namespace ClientSide
{
    public class Client
    {
        public readonly string hostname;
        private int port;
        private TcpClient comm;

        private ClientListener clientListener;
        private MenuManager IOThread;

        public User User;
        public Dictionary<string, ClientTopic> TopicsPublic;

        public Client(string hostname, int port)
        {
            this.hostname = hostname;
            this.port = port;

            this.TopicsPublic = new Dictionary<string, ClientTopic>();
        }




        public void Start()
        {

            try
            {
                this.comm = new TcpClient(hostname, port);
                ConsoleManager.TrackWriteLine(ConsoleColor.Green, "[" + Thread.CurrentThread.Name + "] Connection established with " + this.comm.Client.RemoteEndPoint);

                this.clientListener = new ClientListener(this.comm, this);
                Thread t = new Thread(this.clientListener.HandlingConnection);
                t.Name = "ClientListener";
                t.Start();


                this.IOThread = new MenuManager(this, this.comm);
                this.IOThread.Start();
            }
            catch(SocketException e)
            {
                ConsoleManager.TrackWriteLine(ConsoleColor.Red, "[" + Thread.CurrentThread.Name + "] Impossible to connect to the server :\n" + e.Message);
            }

        }




        public ClientTopic CreateClientTopic(Topic topic)
        {
            ClientTopic ct = new ClientTopic(this, topic);
            this.TopicsPublic.Add(ct.Topic.Topic_name, ct);

            return ct;
        }




        public void KillClient()
        {
            this.clientListener.Terminate();
            this.clientListener = null;

            this.IOThread.Terminate();
            this.IOThread = null;

            foreach(KeyValuePair<string, ClientTopic> clientTopic in this.TopicsPublic)
            {
                clientTopic.Value.KillThread();
            }
        }
    }
 
}
