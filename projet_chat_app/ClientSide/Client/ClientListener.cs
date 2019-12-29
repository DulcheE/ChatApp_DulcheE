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
    class ClientListener
    {
        private TcpClient connection;
        private Client client;

        private bool terminate = false;


        public void Terminate()
        {
            this.terminate = true;

            if(this.client.User != null)
                ConsoleManager.TrackWriteLine(ConsoleColor.Yellow, "[" + Thread.CurrentThread.Name + "] KILLING THREAD ClientListener " + this.client.User.Username);

            this.connection.GetStream().Close();
            this.connection.Close();
        }



        public ClientListener(TcpClient connection, Client client)
        {
            this.connection = connection;
            this.client = client;
        }


        public void HandlingConnection()
        {
            try
            {
                while (!terminate)
                {
                    ConsoleManager.TrackWriteLine(ConsoleColor.White, "[" + Thread.CurrentThread.Name + "] Wainting Communication...\n");
                    ServerCommunication communication = Net.RecieveServerCommunication(this.connection.GetStream());

                    //On créer un nouveau thread qui gère la ressource et on continue d'écouter
                    HandlingCommunication(communication);
                }
            }
            catch (System.IO.IOException e)
            {
                ConsoleManager.TrackWriteLine(ConsoleColor.DarkRed, "[" + Thread.CurrentThread.Name + "] The connection to the server has ended !");
                ConsoleManager.TrackWriteLine(ConsoleColor.DarkRed, e.Message);
            }
            catch (System.Runtime.Serialization.SerializationException e)
            {
                ConsoleManager.TrackWriteLine(ConsoleColor.DarkRed, "[" + Thread.CurrentThread.Name + "] The connection to the server has ended !");
                ConsoleManager.TrackWriteLine(ConsoleColor.DarkRed, e.Message);
            }
        }




        private void HandlingCommunication(Communication.CommunicationStream communication)
        {
            ConsoleManager.TrackWriteLine(ConsoleColor.White, "[" + Thread.CurrentThread.Name + "] Communication recieve :\n[");

            switch (communication)
            {
                case Response r:

                    this.HandlingResponse(r);

                    break;


                case SendMessage m:

                    this.HandlingSendMessage(m);

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


        private void HandlingSendMessage(SendMessage m)
        {
            string str = "[" + Thread.CurrentThread.Name + "] The User `" + ((User)m.Source).Username + "` send you the folowing message : \n[\n" + m.Content + "\n]";
            ConsoleManager.TrackWriteLine(ConsoleColor.Magenta, str);
        }

    }
}
