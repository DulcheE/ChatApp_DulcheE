using Communication.Models;
using System;
using System.Collections.Generic;

namespace Communication
{

    [Serializable]
    public abstract class ClientCommunication : CommunicationStream
    {
        public ClientCommunication() : base() { }
    }



    //Communication for an entity to send a message to another entity
    [Serializable]
    public class SendMessage : ClientCommunication
    {
        private readonly Entity _Source;
        private readonly Entity _Dest;
        private readonly string _Content;

        public Entity Source => this._Source;
        public Entity Dest => this._Dest;
        public string Content
        {
            get
            {
                return this._Content;
            }
        }
        public SendMessage(Entity Source, Entity Dest, string Content) : base()
        {
            this._Source = Source;
            this._Dest = Dest;
            this._Content = Content;
        }


        public override string ToString()
        {

            string str = "";



            switch (Source)
            {
                case User Source_user:
                    str += "User `" + Source_user.Username + "`";
                    break;
                case Topic Source_topic:
                    str += "Topic `" + Source_topic.Topic_name + "`";
                    break;
            }

            str += "\nSend message to the ";

            switch (Dest)
            {
                case User Dest_user:
                    str += "User `" + Dest_user.Username + "`";
                    break;
                case Topic Dest_topic:
                    str += "Topic `" + Dest_topic.Topic_name + "`";
                    break;
            }

            str += "\nContent :\n`" + Content + "`";


            return str;
        }

        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case SendMessage m:

                    if (m.creation_date.Ticks == this.creation_date.Ticks && m.ToString().Equals(this.ToString()))
                        return true;

                    return false;


                default:

                    return false;

            }
        }

    }


    //Communication for a user to login to the server
    [Serializable]
    public class LogIn : ClientCommunication
    {
        private string _Username;
        private string _Password;

        public string Username => this._Username;
        public string Password => this._Password;

        public LogIn(string Username, string Password) : base()
        {
            this._Username = Username;
            this._Password = Password;
        }


        override public string ToString() => "Attempt to connect :\nUsername : `" + Username + "`\nPassword : `" + Password + "`";


        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case LogIn li:

                    if (li.creation_date.Ticks == this.creation_date.Ticks && li.ToString().Equals(this.ToString()))
                        return true;

                    return false;


                default:

                    return false;

            }
        }
    }


    //Communication for adding a new user to the database
    [Serializable]
    public class SignIn : ClientCommunication
    {
        private string _Username;
        private string _Password;
        private string _Email;

        public string Username => this._Username;
        public string Password => this._Password;
        public string Email => this._Email;

        public SignIn(string Username, string Password, string Email) : base()
        {
            this._Username = Username;
            this._Password = Password;
            this._Email = Email;
        }


        public override string ToString() => "Attempt to create a new user :\nUsername : `" + Username + "`\nPassword : `" + Password + "\nEmail : `" + Email + "`";


        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case SignIn si:

                    if (si.creation_date.Ticks == this.creation_date.Ticks && si.ToString().Equals(this.ToString()))
                        return true;

                    return false;


                default:

                    return false;

            }
        }
    }


    //Communication for a User to join a Topic
    [Serializable]
    public class Join : ClientCommunication
    {
        private User _User;
        private string _Topic_name;
        private string _Password;

        public User User => this._User;
        public string Topic_name => this._Topic_name;
        public string Password => this._Password;

        public Join(User User, string Topic_name, string Password) : base()
        {
            this._User = User;
            this._Topic_name = Topic_name;
            this._Password = Password;
        }


        public override string ToString()
        {
            if (this.User == null)
                return "User must be not null !";
            if (this.Topic_name == null)
                return "Topic must be not null !";


            string str = "Attempt for the User `" + this.User.Username + "` to join the Topic `" + this.Topic_name + "`\nPassword : `" + this.Password + "`";

            return str;
        }


        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case Join j:

                    if (j.creation_date.Ticks == this.creation_date.Ticks && j.ToString().Equals(this.ToString()))
                        return true;

                    return false;


                default:

                    return false;

            }
        }

    }


    //Communication for User to leave a topic
    [Serializable]
    public class Leave : ClientCommunication
    {
        private User _User;
        private Topic _Topic;

        public User User => this._User;
        public Topic Topic => this._Topic;

        public Leave(User User, Topic Topic) : base()
        {
            this._User = User;
            this._Topic = Topic;
        }


        public override string ToString()
        {
            if (User == null)
                return "User must be not null !";
            if (Topic == null)
                return "Topic must be not null !";


            string str = "Attempt for the User `" + User.Username + "` to leave the Topic `" + Topic.Topic_name + "`";

            return str;
        }


        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case Leave l:

                    if (l.creation_date.Ticks == this.creation_date.Ticks && l.ToString().Equals(this.ToString()))
                        return true;

                    return false;


                default:

                    return false;

            }
        }

    }


    //Communication for a User to add a new Topic to the database
    [Serializable]
    public class Creation : ClientCommunication
    {
        private string _Topic_name;
        private User _Owner;
        private string _Password;

        public string Topic_name => this._Topic_name;
        public User Owner => this._Owner;
        public string Password => this._Password;

        public Creation(string Topic_name, User Owner, string Password) : base()
        {
            this._Topic_name = Topic_name;
            this._Owner = Owner;
            this._Password = Password;
        }


        public override string ToString()
        {
            if (Owner == null)
                return "User must be not null !";


            string str = "Attempt for the User `" + Owner.Username + "` to create the Topic `" + Topic_name + "`\nPassword : `" + Password + "`";

            return str;
        }


        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case Creation c:

                    if (c.creation_date.Ticks == this.creation_date.Ticks && c.ToString().Equals(this.ToString()))
                        return true;

                    return false;


                default:

                    return false;

            }
        }

    }


    //Communication for a User to delete a Topic from the database
    [Serializable]
    public class Delete : ClientCommunication
    {
        private User _Owner;
        private Topic _Topic;

        public User Owner => this._Owner;
        public Topic Topic => this._Topic;

        public Delete(User Owner, Topic Topic) : base()
        {
            this._Topic = Topic;
            this._Owner = Owner;
        }


        public override string ToString()
        {
            if (Owner == null)
                return "User must be not null !";
            if (Topic == null)
                return "Topic must be not null !";


            string str = "Attempt for the User `" + Owner.Username + "` to delete the Topic `" + Topic.Topic_name + "`";

            return str;
        }


        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case Delete d:

                    if (d.creation_date.Ticks == this.creation_date.Ticks && d.ToString().Equals(this.ToString()))
                        return true;

                    return false;


                default:

                    return false;

            }
        }

    }


    [Serializable]
    public class AskConnectUser : ClientCommunication
    {
        private List<User> users;
        private User _asker;
        public List<User> userConnected => users;
        public User asker => _asker;

        public AskConnectUser(User asker) : base()
        {
            _asker = asker;
        }


        public override string ToString() => "Attempt for the User `" + _asker.Username + "` to get all the other Users connected";



        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case AskConnectUser acu:

                    if (acu.creation_date.Ticks == this.creation_date.Ticks && acu.ToString().Equals(this.ToString()))
                        return true;

                    return false;


                default:

                    return false;

            }
        }


    }


    [Serializable]
    public class Identification : ClientCommunication
    {
        private User _user;
        private string _topic_name;

        public User user => _user;
        public string topic_name => _topic_name;


        public Identification(User user, string topic_name) : base()
        {
            this._user = user;
            this._topic_name = topic_name;
        }


        public override string ToString() => "Attempt for the User `" + user.Username + "` to identify itself to the Topic `" + topic_name + "`";



        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case Identification i:

                    if (i.creation_date.Ticks == this.creation_date.Ticks && i.ToString().Equals(this.ToString()))
                        return true;

                    return false;


                default:

                    return false;

            }
        }

    }

}
