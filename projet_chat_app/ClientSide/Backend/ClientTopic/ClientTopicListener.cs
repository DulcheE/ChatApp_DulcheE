using Communication;
using Communication.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using Front_Console;

namespace ClientSide
{
    public partial class ClientTopic
    {
        private bool terminate = false;


        public void Terminate()
        {
            this.terminate = true;
            ConsoleManager.TrackWriteLine(ConsoleColor.Yellow, "[" + Thread.CurrentThread.Name + "] KILLING THREAD ClientTopicListener " + this.Topic.Topic_name);

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
                    ConsoleManager.TrackWriteLine(ConsoleColor.White, "[" + Thread.CurrentThread.Name + "]  Wainting Communication...\n");
                    ServerCommunication communication = Net.RecieveServerCommunication(this._comm.GetStream());

                    HandlingCommunication(communication);
                }
            }
            catch (System.IO.IOException e)
            {
                ConsoleManager.TrackWriteLine(ConsoleColor.DarkRed, "[" + Thread.CurrentThread.Name + "] The connection to the server has ended !");
                ConsoleManager.TrackWriteLine(ConsoleColor.DarkRed, e.Message);
            }
            catch(System.Runtime.Serialization.SerializationException e)
            {
                ConsoleManager.TrackWriteLine(ConsoleColor.DarkRed, "[" + Thread.CurrentThread.Name + "] The connection to the server has ended !");
                ConsoleManager.TrackWriteLine(ConsoleColor.DarkRed, e.Message);
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
            ConsoleManager.TrackWriteLine(ConsoleColor.White, "[" + Thread.CurrentThread.Name + "] Communication recieve :\n[");

            switch (communication)
            {
                case Response r:

                    this.HandlingResponse(r);

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
                printMessage(message.Value);
            }

        }


        private void printMessage(Message message)
        {
            if (message.Source is Topic)
                ConsoleManager.TrackWriteLine(ConsoleColor.DarkGray, "[" + Thread.CurrentThread.Name + "] " + message.ToString());
            else
                ConsoleManager.TrackWriteLine(ConsoleColor.Magenta, "[" + Thread.CurrentThread.Name + "] " + message.ToString());
        }


    }
}
