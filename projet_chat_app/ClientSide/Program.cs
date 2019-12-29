using System;
using System.Threading;

namespace ClientSide
{
    class Program
    {
        public static bool terminated = false;


        static void Main(string[] args)
        {

            Thread.CurrentThread.Name = "I/O";
            Client c = new Client("127.0.0.1", 8976);
            c.Start();

        }
    }
}
