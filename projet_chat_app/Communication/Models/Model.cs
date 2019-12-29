using System;
using System.Collections.Generic;
using System.Text;

namespace Communication.Models
{
    [Serializable]
    public class User : Entity
    {
        private string _Username;
        private string _Password;
        private string _Email;

        public string Username => _Username;
        public string Password
        {
            get => _Password;
            set
            {
                this._Password = value;
            }
        }
        public string Email
        {
            get => _Email;
            set
            {
                this._Email = value;
            }
        }


        public User(string Username, string Password, string Email)
        {
            this._Username = Username;
            this._Password = Password;
            this._Email = Email;
        }

        public User(SignIn inscription)
        {
            this._Username = inscription.Username;
            this._Password = inscription.Password;
            this._Email = inscription.Email;
        }

    }


    [Serializable]
    public class Topic : Entity
    {
        private int _Port;

        private string _Topic_name;
        private User _Owner;
        private string _Password;

        public string Topic_name => _Topic_name;
        public int Port => _Port;
        
        public User Owner
        {
            get => _Owner;
            set
            {
                this._Owner = value;
            }
        }
        public string Password
        {
            get => _Password;
            set
            {
                this._Password = value;
            }
        }


        public Topic(string Topic_name, User Owner, string Password, int Port)
        {
            this._Topic_name = Topic_name;
            this._Owner = Owner;
            this._Password = Password;
            this._Port = Port;
        }


        public Topic(Creation creation, int Port)
        {
            this._Topic_name = creation.Topic_name;
            this._Owner = creation.Owner;
            this._Password = creation.Password;

            this._Port = Port;
        }

    }


    [Serializable]
    public abstract class Entity
    {

    }


    [Serializable]
    public class Initializer
    {
        public readonly Dictionary<string, Topic> TopicsPublic;
        public readonly Dictionary<string, Topic> TopicsPrivate;
        public readonly User User;


        public Initializer(Dictionary<string, Topic> TopicsPublic, Dictionary<string, Topic> TopicsPrivate, User User)
        {
            this.TopicsPublic = new Dictionary<string, Topic>(TopicsPublic);
            this.TopicsPrivate = new Dictionary<string, Topic>(TopicsPrivate);
            this.User = User;
        }
    }




    [Serializable]
    public class Message
    {
        public readonly Entity Source;
        public readonly DateTime Upload_date;
        public readonly string Content;


        public Message(Entity Source, DateTime Upload_date, string Content) {
            this.Source = Source;
            this.Upload_date = Upload_date;
            this.Content = Content;
        }


        public override string ToString()
        {

            string str = "";



            switch (Source)
            {
                case User Source_user:
                    str += Source_user.Username + "\n";
                    break;
            }

            str += Upload_date.ToString() + "\n";

            str += "[\n" + Content + "\n]";


            return str;
        }
    }

}
