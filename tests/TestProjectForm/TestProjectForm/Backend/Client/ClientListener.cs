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
    //Listener part
    public partial class Client
    {
        private bool terminate = false;


        /// <summary>
        /// Stop the Thread listening to the Server and close the connection
        /// </summary>
        public void Terminate()
        {
            this.terminate = true;

            if(this.User != null)
            {
                string thread_name = Thread.CurrentThread.Name;
                this.Form.DebugLog.Invoke(new MethodInvoker(delegate {
                    this.Form.DebugLog.PrintDebug(System.Drawing.Color.Yellow, "[" + thread_name + "] KILLING THREAD ClientListener " + this.User.Username);
                }) );
            }

            if (this._comm.Connected)
            {
                this._comm.GetStream().Close();
                this._comm.Close();
            }
        }


        /// <summary>
        /// Listen any ServerCommunication from the connection to the server
        /// </summary>
        public void Listener()
        {
            try
            {
                while (!terminate)
                {
                    string thread_name = Thread.CurrentThread.Name;
                    this.Form.DebugLog.Invoke(new MethodInvoker(delegate {
                            this.Form.DebugLog.PrintDebug(System.Drawing.Color.White, "[" + thread_name + "] Wainting Communication...\n");
                    }) );
                    ServerCommunication communication = Net.RecieveServerCommunication(this._comm.GetStream());

                    //On gère la ressource et on continue d'écouter
                    HandlingServerCommunication(communication);
                }
            }
            catch (System.IO.IOException e)
            {
                string thread_name = Thread.CurrentThread.Name;
                this.Form.DebugLog.Invoke(new MethodInvoker(delegate {
                    this.Form.DebugLog.PrintDebug(System.Drawing.Color.DarkRed, "[" + thread_name + "] The connection to the server has ended !");
                }) );
                this.Form.DebugLog.Invoke(new MethodInvoker(delegate {
                    this.Form.DebugLog.PrintDebug(System.Drawing.Color.DarkRed, e.Message);
                }) );

                KillClient();
            }
            catch (System.Runtime.Serialization.SerializationException e)
            {
                string thread_name = Thread.CurrentThread.Name;
                this.Form.DebugLog.Invoke(new MethodInvoker(delegate {
                    this.Form.DebugLog.PrintDebug(System.Drawing.Color.DarkRed, "[" + thread_name + "] The connection to the server has ended !");
                }) );
                this.Form.DebugLog.Invoke(new MethodInvoker(delegate {
                        this.Form.DebugLog.PrintDebug(System.Drawing.Color.DarkRed, e.Message);
                }) );

                KillClient();
            }
        }



        /// <summary>
        /// Handle new Communication
        /// </summary>
        /// <param name="communication">ServerCommunication received from the Server</param>
        private void HandlingServerCommunication(ServerCommunication communication)
        {
            string thread_name = Thread.CurrentThread.Name;
            this.Form.DebugLog.Invoke(new MethodInvoker(delegate {
                this.Form.DebugLog.PrintDebug(System.Drawing.Color.White, "[" + thread_name + "] Communication recieve :\n[");
            }) );

            switch (communication)
            {
                case Response r:

                    this.HandlingResponse(r);

                    break;


                case ApprouvedMessage am:

                    this.HandlingApprouvedMessage(am);

                    break;


                default:

                    this.Form.DebugLog.Invoke(new MethodInvoker(delegate {
                        this.Form.DebugLog.PrintDebug(System.Drawing.Color.DarkRed, "[" + thread_name + "] Type of Communication unknown");
                    }) );

                    break;

            }

            this.Form.DebugLog.Invoke(new MethodInvoker(delegate {
                this.Form.DebugLog.PrintDebug(System.Drawing.Color.White, "]\n");
            }) );
        }


        private void HandlingResponse(Response response)
        {
            ResponseEvent.WriteBufferResponse(response);
        }


        private void HandlingApprouvedMessage(ApprouvedMessage am)
        {
            string thread_name = Thread.CurrentThread.Name;
            string str = "[" + thread_name + "] Private message : [\n" + am.message.ToString() + "\n]";
            this.Form.DebugLog.Invoke(new MethodInvoker(delegate {
                this.Form.DebugLog.PrintDebug(System.Drawing.Color.Magenta, str);
            }) );
        }

    }
}
