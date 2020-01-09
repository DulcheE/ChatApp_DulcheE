using System;
using Communication;
using System.Collections.Generic;
using System.Text;

namespace ServerSide
{
    class ServerTopicEvent
    {
        public delegate void MessageTopicHandler(object source, Response r);

        public event MessageTopicHandler TopicSender;

        public void OnSendMessageIntopic(Object source, Response r)
        {
            if (TopicSender!=null)
            {
                TopicSender(source, r);
            }
        }
    }

}
