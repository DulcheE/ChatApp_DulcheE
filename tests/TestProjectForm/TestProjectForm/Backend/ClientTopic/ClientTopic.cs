using Communication;
using Communication.Models;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

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
                string thread_name = Thread.CurrentThread.Name;
                this._client.Form.DebugLog.Invoke(new MethodInvoker(delegate {
                    this._client.Form.DebugLog.PrintDebug(System.Drawing.Color.Green, "[" + thread_name + "] Connection created to `" + client.hostname + "` on port `" + Topic.Port + "` !");
                }) );

                this._client.Form.content_Connected1.AddTopicFrame(this.Topic);

                Thread t = new Thread(this.Listener);
                t.Name = "TopicListener `" + this.Topic.Topic_name + "`";
                t.Start();
            }
            catch (SocketException e)
            {
                string thread_name = Thread.CurrentThread.Name;
                this._client.Form.DebugLog.Invoke(new MethodInvoker(delegate {
                    this._client.Form.DebugLog.PrintDebug(System.Drawing.Color.Red, "[" + thread_name + "] Impossible to connect to the server :\n" + e.Message);
                }) );
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
