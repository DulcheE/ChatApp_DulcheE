using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Communication
{
    public class Net
    {
        public static void SendClientCommunication(Stream s, ClientCommunication msg)
        {
            Send(s, msg);
        }

        public static ClientCommunication RecieveClientCommunication(Stream s)
        {
            return (ClientCommunication)Recieve(s);
        }


        public static void SendServerCommunication(Stream s, ServerCommunication msg)
        {
            Send(s, msg);
        }

        public static ServerCommunication RecieveServerCommunication(Stream s)
        {
            return (ServerCommunication)Recieve(s);
        }


        public static void Send(Stream s, Object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(s, obj);
        }

        public static Object Recieve(Stream s)
        {
            BinaryFormatter bf = new BinaryFormatter();
            return bf.Deserialize(s);
        }


    }
}
