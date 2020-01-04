using System;
using System.Collections.Generic;
using System.Text;
using Communication.Models;

namespace Communication
{

    public interface ICommunication
    {

        string ToString();

    }

    [Serializable]
    public abstract class CommunicationStream : ICommunication
    {
        protected readonly DateTime creation_date;


        public CommunicationStream()
        {
            this.creation_date = DateTime.Now;
        }
    }

}
