using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Communication;
using Communication.Models;

namespace ServerSide
{
    class Database
    {
        public static readonly string BasePath = "../../../../database/server/";


        public class UserService
        {
            public static readonly string UserBasePath = "user/";


            public static Dictionary<string, User> getAll()
            {
                Dictionary<string, User> users = new Dictionary<string, User>();

                string[] dirs_name;

                try
                {
                    dirs_name = Directory.GetDirectories(BasePath + UserBasePath);
                }
                catch(DirectoryNotFoundException)
                {
                    //we don't find the directory, thus the database should be empty
                    return users;
                }

                foreach(string dir_name in dirs_name)
                {
                    string username = File.ReadAllLines(dir_name + "/username.txt")[0];
                    string password = File.ReadAllLines(dir_name + "/password.txt")[0];
                    string email = File.ReadAllLines(dir_name + "/email.txt")[0];

                    users.Add(username, new User(username, password, email));
                }


                return users;
            }



            public static User getByUsername(string _username)
            {
                string[] dirs_name;

                try
                {
                    dirs_name = Directory.GetDirectories(BasePath + UserBasePath);
                }
                catch (DirectoryNotFoundException)
                {
                    //we don't find the directory, thus the database should be empty
                    throw new DataNotFoundException("User with the username `" + _username + "` was not found !");
                }

                foreach (string dir_name in dirs_name)
                {
                    if(dir_name.EndsWith("/" + _username))
                    {

                        //we found our User
                        string username = File.ReadAllLines(dir_name + "/username.txt")[0];
                        string password = File.ReadAllLines(dir_name + "/password.txt")[0];
                        string email = File.ReadAllLines(dir_name + "/email.txt")[0];

                        return new User(username, password, email);
                    }
                }


                throw new DataNotFoundException("User with the username `" + _username + "` was not found !");
            }



            public static User add(string username, string password, string email)
            {
                //On cherche si un user avec le meme username existe deja
                string[] dirs_name;

                try
                {
                    dirs_name = Directory.GetDirectories(BasePath + UserBasePath);
                }
                catch (DirectoryNotFoundException)
                {
                    //we don't find the directory, thus the database should be empty
                    dirs_name = new string[0];
                }

                foreach (string dir_name in dirs_name)
                {
                    if (dir_name.EndsWith("/" + username))
                    {
                        //si oui, alors on ne cree pas de nouveau username et on renvoie null
                        throw new NoUniqueException("User with the name `" + username + "` already exist !");
                    }
                }

                Directory.CreateDirectory(BasePath + UserBasePath + username);

                //On rajoute le nouveau user
                File.WriteAllText(BasePath + UserBasePath + username + "/username.txt", username);
                File.WriteAllText(BasePath + UserBasePath + username + "/password.txt", password);
                File.WriteAllText(BasePath + UserBasePath + username + "/email.txt", email);


                return getByUsername(username);
            }



            public static User add(Communication.SignIn inscription)
            {
                return add(inscription.Username, inscription.Password, inscription.Email);
            }

        }


        public class TopicService
        {
            public static readonly string TopicBasePath = "topic/";
            
            private static int globalPort = 57535;




            public static void InitPort()
            {

                string[] dirs_name;

                try
                {
                    dirs_name = Directory.GetDirectories(BasePath + TopicBasePath);
                }
                catch (DirectoryNotFoundException)
                {
                    //we don't find the directory, thus the database should be empty
                    return;
                }

                foreach (string dir_name in dirs_name)
                {
                    string topic_name = File.ReadAllLines(dir_name + "/topic_name.txt")[0];

                    File.WriteAllText(BasePath + TopicBasePath + topic_name + "/port.txt", globalPort.ToString());
                    globalPort++;
                }
            }

            public static void ClearPort()
            {
                string[] dirs_name;

                try
                {
                    dirs_name = Directory.GetDirectories(BasePath + TopicBasePath);
                }
                catch (DirectoryNotFoundException)
                {
                    //we don't find the directory, thus the database should be empty
                    return;
                }

                foreach (string dir_name in dirs_name)
                {
                    File.WriteAllText(dir_name + "testfile.txt", "je suis un test");
                    string topic_name = File.ReadAllLines(dir_name + "/topic_name.txt")[0];

                    File.Delete(BasePath + TopicBasePath + topic_name + "/port.txt");
                }
            }


            public static Dictionary<string, Topic> getAll()
            {
                Dictionary<string, Topic> topics = new Dictionary<string, Topic>();

                string[] dirs_name;

                try
                {
                    dirs_name = Directory.GetDirectories(BasePath + TopicBasePath);
                }
                catch (DirectoryNotFoundException)
                {
                    //we don't find the directory, thus the database should be empty
                    return topics;
                }

                foreach (string dir_name in dirs_name)
                {
                    string topic_name = File.ReadAllLines(dir_name + "/topic_name.txt")[0];
                    string owner = File.ReadAllLines(dir_name + "/owner.txt")[0];
                    string password = "";
                    if (File.ReadAllLines(dir_name + "/password.txt").Length > 0)
                         password = File.ReadAllLines(dir_name + "/password.txt")[0];

                    int port = int.Parse(File.ReadAllLines(dir_name + "/port.txt")[0]);

                    topics.Add(topic_name, new Topic(topic_name, UserService.getByUsername(owner), password, port));
                }


                return topics;
            }



            public static Topic getByTopic_name(string _topic_name)
            {
                string[] dirs_name;

                try
                {
                    dirs_name = Directory.GetDirectories(BasePath + TopicBasePath);
                }
                catch (DirectoryNotFoundException)
                {
                    //we don't find the directory, thus the database should be empty
                    throw new DataNotFoundException("Topic with the name `" + _topic_name + "` was not found !");
                }

                foreach (string dir_name in dirs_name)
                {
                    if (dir_name.EndsWith("/" + _topic_name))
                    {

                        //we found our User
                        string topic_name = File.ReadAllLines(dir_name + "/topic_name.txt")[0];
                        string owner = File.ReadAllLines(dir_name + "/owner.txt")[0];
                        string password = "";
                        if (File.ReadAllLines(dir_name + "/password.txt").Length > 0)
                            password = File.ReadAllLines(dir_name + "/password.txt")[0];

                        int port = int.Parse(File.ReadAllLines(dir_name + "/port.txt")[0]);

                        return new Topic(topic_name, UserService.getByUsername(owner), password, port);
                    }
                }


                throw new DataNotFoundException("Topic with the name `" + _topic_name + "` was not found !");
            }


            public static Dictionary<string, Topic> getByUser(User user)
            {
                Dictionary<string, Topic> topics = new Dictionary<string, Topic>();

                string[] dirs_name;

                try
                {
                    dirs_name = Directory.GetDirectories(BasePath + TopicBasePath);
                }
                catch (DirectoryNotFoundException)
                {
                    //we don't find the directory, thus the database should be empty
                    return topics;
                }

                foreach (string dir_name in dirs_name)
                {
                    if (File.Exists(dir_name + "/Join/" + user.Username + ".txt"))
                    {
                        string topic_name = File.ReadAllLines(dir_name + "/topic_name.txt")[0];
                        string owner = File.ReadAllLines(dir_name + "/owner.txt")[0];
                        string password = "";
                        if (File.ReadAllLines(dir_name + "/password.txt").Length > 0)
                            password = File.ReadAllLines(dir_name + "/password.txt")[0];

                        int port = int.Parse(File.ReadAllLines(dir_name + "/port.txt")[0]);

                        topics.Add(topic_name, new Topic(topic_name, UserService.getByUsername(owner), password, port));
                    }
                }


                return topics;
            }


            public static Dictionary<string, Topic> getByOwner(User user)
            {
                Dictionary<string, Topic> topics = new Dictionary<string, Topic>();

                string[] dirs_name;

                try
                {
                    dirs_name = Directory.GetDirectories(BasePath + TopicBasePath);
                }
                catch (DirectoryNotFoundException)
                {
                    //we don't find the directory, thus the database should be empty
                    return topics;
                }

                foreach (string dir_name in dirs_name)
                {
                    string owner = File.ReadAllLines(dir_name + "/owner.txt")[0];
                    if (owner.Equals(user.Username))
                    {
                        string topic_name = File.ReadAllLines(dir_name + "/topic_name.txt")[0];
                        string password = "";
                        if (File.ReadAllLines(dir_name + "/password.txt").Length > 0)
                            password = File.ReadAllLines(dir_name + "/password.txt")[0];

                        int port = int.Parse(File.ReadAllLines(dir_name + "/port.txt")[0]);

                        topics.Add(topic_name, new Topic(topic_name, UserService.getByUsername(owner), password, port));
                    }
                }


                return topics;
            }



            public static Topic add(string topic_name, User owner, string password)
            {
                //On cherche si un user avec le meme username existe deja
                string[] dirs_name;

                try
                {
                    dirs_name = Directory.GetDirectories(BasePath + TopicBasePath);
                }
                catch (DirectoryNotFoundException)
                {
                    //we don't find the directory, thus the database should be empty
                    dirs_name = new string[0];
                }

                foreach (string dir_name in dirs_name)
                {
                    if (dir_name.EndsWith("/" + topic_name))
                    {
                        //si oui, alors on ne cree pas de nouveau username et on renvoie null
                        throw new NoUniqueException("Topic with the name `" + topic_name + "` already exist !");
                    }
                }

                Directory.CreateDirectory(BasePath + TopicBasePath + topic_name);
                Directory.CreateDirectory(BasePath + TopicBasePath + topic_name + "/Join");
                Directory.CreateDirectory(BasePath + TopicBasePath + topic_name + "/Messages");

                //On rajoute le nouveau user
                File.WriteAllText(BasePath + TopicBasePath + topic_name + "/topic_name.txt", topic_name);
                File.WriteAllText(BasePath + TopicBasePath + topic_name + "/owner.txt", owner.Username);
                File.WriteAllText(BasePath + TopicBasePath + topic_name + "/password.txt", password);
                File.WriteAllText(BasePath + TopicBasePath + topic_name + "/port.txt", globalPort.ToString());

                globalPort++;

                File.WriteAllText(BasePath + TopicBasePath + topic_name + "/Join/" + owner.Username + ".txt", owner.Username);


                return getByTopic_name(topic_name);
            }


            public static Topic add(Communication.Creation creation)
            {
                return add(creation.Topic_name, creation.Owner, creation.Password);
            }



            public static bool delete(Topic _topic)
            {
                if (_topic == null)
                    return false;


                Topic topic = TopicService.getByTopic_name(_topic.Topic_name);


                if (Directory.Exists(BasePath + TopicBasePath + topic.Topic_name))
                {
                    Directory.Delete(BasePath + TopicBasePath + topic.Topic_name, true);
                    return true;
                }

                throw new DataNotFoundException("The Topic `" + topic.Topic_name + "` don't exist !");
            }


            public static bool delete(Delete d)
            {
                return delete(d.Topic);
            }



            public static bool join(User _user, string _topic_name, string password)
            {
                if (_user == null)
                    return false;


                User user = UserService.getByUsername(_user.Username);
                Topic topic = TopicService.getByTopic_name(_topic_name);

                string[] files_name;

                try
                {
                    files_name = Directory.GetFiles(BasePath + TopicBasePath + topic.Topic_name + "/Join/", user.Username + ".txt");
                }
                catch (DirectoryNotFoundException)
                {
                    //we don't find the directory, thus the database should be empty
                    files_name = new string[0];
                }

                foreach (string file_name in files_name)
                {
                    if (file_name.EndsWith("/" + user.Username + ".txt"))
                    {
                        //si oui, alors l'user est deja dans le topic et on renvoie un exception
                        throw new UserAlreadyInTopicException("The User `" + user.Username + "` is already in the Topic `" + topic.Topic_name + "` !");
                    }
                }

                File.WriteAllText(BasePath + TopicBasePath + topic.Topic_name + "/Join/" + user.Username + ".txt", user.Username);


                return true;
            }


            public static bool join(Communication.Join _join)
            {
                return join(_join.User, _join.Topic_name , _join.Password);
            }



            public static bool leave(User _user, Topic _topic)
            {
                if (_user == null || _topic == null)
                    return false;


                User user = UserService.getByUsername(_user.Username);
                Topic topic = TopicService.getByTopic_name(_topic.Topic_name);

                
                if(File.Exists(BasePath + TopicBasePath + topic.Topic_name + "/Join/" + user.Username + ".txt"))
                {
                    File.Delete(BasePath + TopicBasePath + topic.Topic_name + "/Join/" + user.Username + ".txt");
                    return true;
                }

                throw new UserNotInTopicException("The User `" + user.Username + "` is not in the Topic `" + topic.Topic_name + "` thus can't leave it !");
            }


            public static bool leave(Leave l)
            {
                return leave(l.User, l.Topic);
            }

        }


        public class MessageService
        {
            public static readonly string MessagePrivateBasePath = "message_private/";


            public static Dictionary<long, Message> getAllByTopic(Topic topic)
            {
                Dictionary<long, Message> messages = new Dictionary<long, Message>();

                string[] dirs_name;

                try
                {
                    dirs_name = Directory.GetDirectories(BasePath + TopicService.TopicBasePath + topic.Topic_name + "/Messages");
                }
                catch (DirectoryNotFoundException)
                {
                    //we don't find the directory, thus the database should be empty
                    return messages;
                }

                foreach (string dir_name in dirs_name)
                {
                    Entity source = null;
                    if (File.Exists(dir_name + "/username.txt"))
                        source = UserService.getByUsername(File.ReadAllLines(dir_name + "/username.txt")[0]);
                    if (File.Exists(dir_name + "/topic_name.txt"))
                        source = TopicService.getByTopic_name(File.ReadAllLines(dir_name + "/topic_name.txt")[0]);

                    if(source != null)
                    {
                        DateTime upload_date = new DateTime(long.Parse(File.ReadAllLines(dir_name + "/upload_date.txt")[0]));
                        string content = File.ReadAllText(dir_name + "/content.txt");

                        messages.Add(upload_date.Ticks, new Message(source, upload_date, content));
                    }
                }


                return messages;
            }


            public static Dictionary<long, Message> getAllByUser(User source, User Dest)
            {
                Dictionary<long, Message> messages = new Dictionary<long, Message>();

                /*string[] dirs_name;

                try
                {
                    dirs_name = Directory.GetDirectories(BasePath + TopicBasePath + topic.Topic_name + "/Messages");
                }
                catch (DirectoryNotFoundException e)
                {
                    //we don't find the directory, thus the database should be empty
                    return messages;
                }

                foreach (string dir_name in dirs_name)
                {
                    Entity source = null;
                    if (File.Exists(dir_name + "/username.txt"))
                        source = UserService.getByUsername(File.ReadAllLines(dir_name + "/username.txt")[0]);
                    if (File.Exists(dir_name + "/topic_name.txt"))
                        source = TopicService.getByTopic_name(File.ReadAllLines(dir_name + "/topic_name.txt")[0]);

                    if (source != null)
                    {
                        DateTime upload_date = new DateTime(int.Parse(File.ReadAllLines(dir_name + "/upload_date.txt")[0]));
                        string content = File.ReadAllText(dir_name + "/content.txt");

                        messages.Add(upload_date.ToString(), new Message(source, upload_date, content));
                    }
                }*/


                return messages;
            }



            public static Message addToTopic(Topic topic, Entity source, string content)
            {
                DateTime upload_date = DateTime.Now;

                if(source.GetType() == typeof(Topic) && ((Topic)source).Topic_name != topic.Topic_name)
                    throw new Exception("The Topic `" + ((Topic)source).Topic_name + "` can't send Message to the Topic `" + topic.Topic_name + "` !");
                //Create proper InvalidAccessException

                Directory.CreateDirectory(BasePath + TopicService.TopicBasePath + topic.Topic_name + "/Messages/" + upload_date.Ticks);

                //On rajoute le nouveau message
                switch (source)
                {
                    case User user:
                        File.WriteAllText(BasePath + TopicService.TopicBasePath + topic.Topic_name + "/Messages/" + upload_date.Ticks + "/username.txt", user.Username);

                        break;


                    case Topic topic2:
                        File.WriteAllText(BasePath + TopicService.TopicBasePath + topic.Topic_name + "/Messages/" + upload_date.Ticks + "/topic_name.txt", topic.Topic_name);
                        
                        break;

                }

                File.WriteAllText(BasePath + TopicService.TopicBasePath + topic.Topic_name + "/Messages/" + upload_date.Ticks + "/upload_date.txt", upload_date.Ticks.ToString());
                File.WriteAllText(BasePath + TopicService.TopicBasePath + topic.Topic_name + "/Messages/" + upload_date.Ticks + "/content.txt", content);


                return new Message(source, upload_date, content);
            }



            public static Message addToUser(User user, Entity source, string content)
            {
                DateTime upload_date = DateTime.Now;

                /*if (source.GetType() == typeof(Topic) && ((Topic)source).Topic_name != topic.Topic_name)
                    throw new Exception("The Topic `" + ((Topic)source).Topic_name + "` can't send Message to the Topic `" + topic.Topic_name + "` !");
                //Create proper InvalidAccessException

                Directory.CreateDirectory(BasePath + TopicBasePath + topic.Topic_name + "/Messages" + upload_date.ToString());

                //On rajoute le nouveau message
                switch (source)
                {
                    case User user:
                        File.WriteAllText(BasePath + TopicBasePath + topic.Topic_name + "/Messages" + upload_date.ToString() + "/username.txt", user.Username);

                        break;


                    case Topic topic2:
                        File.WriteAllText(BasePath + TopicBasePath + topic.Topic_name + "/Messages" + upload_date.ToString() + "/topic_name.txt", topic.Topic_name);

                        break;

                }

                File.WriteAllText(BasePath + TopicBasePath + topic.Topic_name + "/Messages" + upload_date.ToString() + "/upload_date.txt", upload_date.Ticks.ToString());
                File.WriteAllText(BasePath + TopicBasePath + topic.Topic_name + "/Messages" + upload_date.ToString() + "/content.txt", content);
                */

                return new Message(source, upload_date, content);
            }



            public static Message add(Communication.SendMessage message)
            {
                switch (message.Dest)
                {
                    case User user:

                        return addToUser(user, message.Source, message.Content);


                    case Topic topic:

                        return addToTopic(topic, message.Source, message.Content);


                    default:

                        throw new Exception("The Type of the Entity must be an User or a Topic !");

                }
            }

        }

    }

}
