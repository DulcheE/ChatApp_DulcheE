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
                ConsoleManager.TrackWriteLine(ConsoleColor.Yellow, "[" + Thread.CurrentThread.Name + "] KILLING THREAD ClientListener " + this.User.Username);

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
                    ConsoleManager.TrackWriteLine(ConsoleColor.White, "[" + Thread.CurrentThread.Name + "] Wainting Communication...\n");
                    ServerCommunication communication = Net.RecieveServerCommunication(this._comm.GetStream());

                    //On gère la ressource et on continue d'écouter
                    HandlingServerCommunication(communication);
                }
            }
            catch (System.IO.IOException e)
            {
                ConsoleManager.TrackWriteLine(ConsoleColor.DarkRed, "[" + Thread.CurrentThread.Name + "] The connection to the server has ended !");
                ConsoleManager.TrackWriteLine(ConsoleColor.DarkRed, e.Message);

                KillClient();
            }
            catch (System.Runtime.Serialization.SerializationException e)
            {
                ConsoleManager.TrackWriteLine(ConsoleColor.DarkRed, "[" + Thread.CurrentThread.Name + "] The connection to the server has ended !");
                ConsoleManager.TrackWriteLine(ConsoleColor.DarkRed, e.Message);

                KillClient();
            }
        }



        /// <summary>
        /// Handle new Communication
        /// </summary>
        /// <param name="communication">ServerCommunication received from the Server</param>
        private void HandlingServerCommunication(ServerCommunication communication)
        {
            ConsoleManager.TrackWriteLine(ConsoleColor.White, "[" + Thread.CurrentThread.Name + "] Communication recieve :\n[");

            switch (communication)
            {
                case Response r:

                    this.HandlingResponse(r);

                    break;


                case ApprouvedMessage am:

                    this.HandlingApprouvedMessage(am);

                    break;


                default:

                    ConsoleManager.TrackWriteLine(ConsoleColor.DarkRed, "[" + Thread.CurrentThread.Name + "] Type of Communication unknown");

                    break;

            }

            ConsoleManager.TrackWriteLine(ConsoleColor.White, "]\n");
        }


        private void HandlingResponse(Response response)
        {
            ResponseEvent.WriteBufferResponse(response);
        }


        private void HandlingApprouvedMessage(ApprouvedMessage am)
        {
            string str = "[" + Thread.CurrentThread.Name + "] Private message : [\n" + am.message.ToString() + "\n]";
            ConsoleManager.TrackWriteLine(ConsoleColor.Magenta, str);
        }

    }
}
