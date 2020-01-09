using Communication.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Communication
{

    [Serializable]
    public abstract class ServerCommunication : CommunicationStream
    {
        public ServerCommunication() : base() { }
    }


    [Serializable]
    public class Success : ServerCommunication
    {
        private readonly string message;

        public Success(string message) : base()
        {
            this.message = message;
        }


        public override string ToString() => this.message;


        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case Success s:

                    if (s.creation_date.Ticks == this.creation_date.Ticks && s.message.Equals(this.message))
                        return true;


                    return false;


                default:

                    return false;

            }
        }
    }


    [Serializable]
    public class Error : ServerCommunication
    {
        private readonly Exception e;

        public Error(Exception e) : base()
        {
            this.e = e;
        }


        public override string ToString() => e.Message;


        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case Error e:

                    if (e.creation_date.Ticks == this.creation_date.Ticks && e.ToString().Equals(this.e.ToString()))
                        return true;


                    return false;


                default:

                    return false;

            }
        }

    }


    //Communication for a User to delete a Topic from the database
    [Serializable]
    public class Response : ServerCommunication
    {
        private ClientCommunication _Request;
        private object _Content;

        public ClientCommunication Request => this._Request;
        public object Content => this._Content;

        public Response(ClientCommunication Request, object Content) : base()
        {
            this._Request = Request;
            this._Content = Content;
        }


        public override string ToString()
        {
            return "Response to the request : [\n" + this.Request.ToString() + "\n]\nContent : [\n" + this.Content + "\n]";
        }


        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case Response r:

                    if (r.creation_date.Ticks == this.creation_date.Ticks && r.ToString().Equals(this.ToString()))
                        return true;

                    return false;


                default:

                    return false;

            }
        }

    }


    [Serializable]
    public class ApprouvedMessage : ServerCommunication
    {
        public Message message;

        public ApprouvedMessage(Message message) : base()
        {
            this.message = message;
        }



        public override string ToString()
        {
            return this.message.ToString();
        }
    }

}
