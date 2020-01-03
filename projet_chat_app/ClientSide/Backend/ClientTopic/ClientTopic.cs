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
    public partial class ClientTopic
    {
        private TcpClient _comm;

        private Client _client;
        public readonly Topic Topic;


        public ClientTopic(Client client, Topic topic)
        {
            this._client = client;
            this.Topic = topic;

            try
            {
                this._comm = new TcpClient(client.hostname, Topic.Port);
                ConsoleManager.TrackWriteLine(ConsoleColor.Green, "[" + Thread.CurrentThread.Name + "] Connection created to `" + client.hostname + "` on port `" + Topic.Port + "` !");


                Thread t = new Thread(this.Listener);
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
            SendMessage m = new SendMessage(this._client.User, this.Topic, content);
            Net.SendClientCommunication(this._comm.GetStream(), m);

            ResponseEvent.MyResponseEvent += new ResponseEvent(m, callback).OnResponse;
        }

        public void LeaveTopic(Action<object> callback)
        {
            Leave l = new Leave(this._client.User, this.Topic);
            Net.SendClientCommunication(this._comm.GetStream(), l);

            ResponseEvent.MyResponseEvent += new ResponseEvent(l, callback).OnResponse;
        }

        public void DeleteTopic(string password, Action<object> callback)
        {
            this.Topic.Password = password;
            Delete d = new Delete(this._client.User, this.Topic);
            Net.SendClientCommunication(this._comm.GetStream(), d);

            ResponseEvent.MyResponseEvent += new ResponseEvent(d, callback).OnResponse;
        }


    }
}
