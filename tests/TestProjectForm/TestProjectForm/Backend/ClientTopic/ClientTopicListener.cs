using Communication;
using Communication.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Threading;

namespace ClientSide
{
    public partial class ClientTopic
    {
        private bool terminate = false;


        public void Terminate()
        {
            this.terminate = true;
            string thread_name = Thread.CurrentThread.Name;
            this._client.Form.DebugLog.Invoke(new System.Windows.Forms.MethodInvoker(delegate {
                this._client.Form.DebugLog.PrintDebug(System.Drawing.Color.Yellow, "[" + thread_name + "] KILLING THREAD ClientTopicListener " + this.Topic.Topic_name);
            }) );

            if (this._comm.Connected)
            {
                this._comm.GetStream().Close();
                this._comm.Close();
            }
        }


        public void Listener()
        {
            try
            {
                //We identify ourself to the ServerTopicListener
                Net.SendClientCommunication(this._comm.GetStream(), new Identification(this._client.User, this.Topic.Topic_name));

                while (!terminate)
                {
                    string thread_name = Thread.CurrentThread.Name;
                    this._client.Form.DebugLog.Invoke(new System.Windows.Forms.MethodInvoker(delegate {
                        this._client.Form.DebugLog.PrintDebug(System.Drawing.Color.White, "[" + thread_name + "]  Wainting Communication...\n");
                    }));
                    ServerCommunication communication = Net.RecieveServerCommunication(this._comm.GetStream());

                    HandlingCommunication(communication);
                }
            }
            catch (System.IO.IOException e)
            {
                string thread_name = Thread.CurrentThread.Name;
                this._client.Form.DebugLog.Invoke(new System.Windows.Forms.MethodInvoker(delegate {
                    this._client.Form.DebugLog.PrintDebug(System.Drawing.Color.DarkRed, "[" + thread_name + "] The connection to the server has ended !");
                }));
                this._client.Form.DebugLog.Invoke(new System.Windows.Forms.MethodInvoker(delegate {
                    this._client.Form.DebugLog.PrintDebug(System.Drawing.Color.DarkRed, e.Message);
                }));
            }
            catch (System.Runtime.Serialization.SerializationException e)
            {
                string thread_name = Thread.CurrentThread.Name;
                this._client.Form.DebugLog.Invoke(new System.Windows.Forms.MethodInvoker(delegate {
                    this._client.Form.DebugLog.PrintDebug(System.Drawing.Color.DarkRed, "[" + thread_name + "] The connection to the server has ended !");
                }));
                this._client.Form.DebugLog.Invoke(new System.Windows.Forms.MethodInvoker(delegate {
                     this._client.Form.DebugLog.PrintDebug(System.Drawing.Color.DarkRed, e.Message);
                }));
            }
            finally
            {
                if (this._client.Topics.ContainsKey(this.Topic.Topic_name))
                {
                    this._client.Topics.Remove(this.Topic.Topic_name);
                }
            }

        }




        private void HandlingCommunication(Communication.CommunicationStream communication)
        {
            string thread_name = Thread.CurrentThread.Name;
            this._client.Form.DebugLog.Invoke(new System.Windows.Forms.MethodInvoker(delegate {
                this._client.Form.DebugLog.PrintDebug(System.Drawing.Color.White, "[" + thread_name + "] Communication recieve :\n[");
            }));

            switch (communication)
            {
                case Response r:

                    this.HandlingResponse(r);

                    break;


                default:

                    this._client.Form.DebugLog.Invoke(new System.Windows.Forms.MethodInvoker(delegate {
                        this._client.Form.DebugLog.PrintDebug(System.Drawing.Color.DarkRed, "[" + thread_name + "] Type of Communication unknown");
                    }));

                    break;

            }

            this._client.Form.DebugLog.Invoke(new System.Windows.Forms.MethodInvoker(delegate {
                this._client.Form.DebugLog.PrintDebug(System.Drawing.Color.White, "]\n");
            }) );
        }


        private void HandlingResponse(Response response)
        {

            ResponseEvent.WriteBufferResponse(response);

            switch (response.Request)
            {
                case SendMessage m:

                    this.HandlingMessage(response.Content);

                    break;


                case Identification i:

                    if(response.Content is Dictionary<long, Message>)
                    {
                        HandlingTopicMessages((Dictionary<long, Message>)response.Content);
                    }
                        

                    break;

            }
        }


        private void HandlingMessage(object response)
        {

            switch (response)
            {
                case Message m:
                    printMessage(m);

                    break;
            }
        }

        private void HandlingTopicMessages(Dictionary<long, Message> topicMessages) { 
        

            foreach(KeyValuePair<long, Message> message in topicMessages)
            {
                this._client.Form.content_Connected1.topicChats[this.Topic.Topic_name].AddMessage(this._client, message.Value);

                printMessage(message.Value);
            }

        }


        private void printMessage(Message message)
        {
            string thread_name = Thread.CurrentThread.Name;
            if (message.Source is Topic)
                this._client.Form.DebugLog.Invoke(new System.Windows.Forms.MethodInvoker(delegate {
                    this._client.Form.DebugLog.PrintDebug(System.Drawing.Color.DarkGray, "[" + thread_name + "] " + message.ToString());
                }));
            else
                this._client.Form.DebugLog.Invoke(new System.Windows.Forms.MethodInvoker(delegate {
                    this._client.Form.DebugLog.PrintDebug(System.Drawing.Color.Magenta, "[" + thread_name + "] " + message.ToString());
                }));
        }


    }
}
