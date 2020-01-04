using Communication;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerSide
{
    class ServerEvents
    {
        public delegate void MessageSenderHandler(object source, SendMessage m);

        public static event MessageSenderHandler MessageSender;

        public static void OnSendMessage(Object source, SendMessage m)
        {
            if (MessageSender != null)
            {
                MessageSender(source, m);
            }
        }
    }
}
