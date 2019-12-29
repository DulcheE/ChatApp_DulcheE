using Communication;
using Communication.Models;
using Front_Console;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ClientSide
{
    public class ClientTopic
    {
        private TcpClient comm;

        private Client client;
        public readonly Topic Topic;

        private ClientTopicListener clientTopicListener;


        public ClientTopic(Client client, Topic topic)
        {
            this.client = client;
            this.Topic = topic;

            try
            {
                this.comm = new TcpClient(client.hostname, Topic.Port);
                ConsoleManager.TrackWriteLine(ConsoleColor.Green, "[" + Thread.CurrentThread.Name + "] Connection created to `" + client.hostname + "` on port `" + Topic.Port + "` !");

                this.clientTopicListener = new ClientTopicListener(this.comm, this.client, this.Topic);

                Thread t = new Thread(this.clientTopicListener.HandlingConnection);
                t.Name = "TopicListener `" + this.Topic.Topic_name + "`";
                t.Start();
            }
            catch (SocketException e)
            {
                ConsoleManager.TrackWriteLine(ConsoleColor.Red, "[" + Thread.CurrentThread.Name + "] Impossible to connect to the server :\n" + e.Message);
            }
        }



        public void SendingMessage(string content, Action<object> callback)
        {
            SendMessage m = new SendMessage(this.client.User, this.Topic, content);
            Net.SendClientCommunication(this.comm.GetStream(), m);

            ResponseEvent.MyResponseEvent += new ResponseEvent(m, callback).OnResponse;
        }

        public void LeaveTopic(Action<object> callback)
        {
            Leave l = new Leave(this.client.User, this.Topic);
            Net.SendClientCommunication(this.comm.GetStream(), l);

            ResponseEvent.MyResponseEvent += new ResponseEvent(l, callback).OnResponse;
        }

        public void DeleteTopic(string password, Action<object> callback)
        {
            Delete d = new Delete(this.client.User, this.Topic, password);
            Net.SendClientCommunication(this.comm.GetStream(), d);

            ResponseEvent.MyResponseEvent += new ResponseEvent(d, callback).OnResponse;
        }




        public void KillThread()
        {
            this.client.TopicsPublic.Remove(this.Topic.Topic_name);
            this.clientTopicListener.Terminate();
        }


    }
}
