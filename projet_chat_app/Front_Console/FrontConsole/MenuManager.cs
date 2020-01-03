using Communication;
using Communication.Models;
using ClientSide;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Front_Console
{
    class MenuManager
    {

        private Client _client;
        private TcpClient _comm;

        private bool terminated = false;


        public void Terminate()
        {
            this.terminated = true;

            ConsoleManager.TrackWriteLine(ConsoleColor.Yellow, "[" + Thread.CurrentThread.Name + "] KILLING THREAD I/O ");

            ResponseEvent.WriteBufferResponse(null);
        }




        public MenuManager(Client client, TcpClient comm)
        {
            this._client = client;
            this._comm = comm;
        }




        public void Start()
        {
            HomeMenu();

            while (!terminated)
            {
                ConsoleManager.TrackWriteLine(ConsoleColor.White, "[" + Thread.CurrentThread.Name + "] Waiting Response...");
                Response r = ResponseEvent.ReadBufferResponse();


                ResponseEvent.SendResponseEvent(this._client, r);
            }
        }


        public void HomeMenu()
        {
            List<string> choices = new List<string>();

            if (_client.User == null)
            {
                choices.Add("Log In");
                choices.Add("Sign in");
            }
            else
            {
                choices.Add("Disconnect");
                choices.Add("Join a new Topic");
                choices.Add("Create a new Topic");

                choices.Add("Select a Topic" + " ->");

                choices.Add("Select a User" + " ->");

            }

            choices.Add("<- Exit");

            ChoiceSelection.Choice choice = new ChoiceSelection.Choice("Welcome to the Home Menu, what do you want to do ?", choices);

            int menu = ChoiceSelection.GetChoice(choice, (this._client.User == null) ? null : this._client.User.Username, null);

            if (_client.User == null)
            {

                switch (menu)
                {
                    case 0:

                        Console.Clear();
                        ConsoleManager.PrintTrack();

                        string username = ConsoleManager.Read("Please enter your username : ");


                        Console.Clear();
                        ConsoleManager.PrintTrack();

                        string password = ConsoleManager.Read("Username = " + username + "\nPlease enter your password : ");


                        //On cherche à ce login
                        ClientCommunication request = new LogIn(username, password);
                        Net.SendClientCommunication(_comm.GetStream(), request);

                        ResponseEvent.MyResponseEvent += new ResponseEvent(request, (response) =>
                        {

                            switch (response)
                            {
                                case bool b:

                                    if (b)
                                        ConsoleManager.TrackWriteLine(ConsoleColor.Green, "I'm connected as " + username);

                                    break;

                                case CommunicationException ce:

                                    ConsoleManager.TrackWriteLine(ConsoleColor.Red, ce.Message);

                                    break;
                            }

                            HomeMenu();

                        }).OnResponse;


                        break;


                    case 1:

                        Console.Clear();
                        ConsoleManager.PrintTrack();

                        username = ConsoleManager.Read("Please enter a username : ");


                        Console.Clear();
                        ConsoleManager.PrintTrack();

                        password = ConsoleManager.Read("Username = " + username + "\nPlease enter a password : ");


                        Console.Clear();
                        ConsoleManager.PrintTrack();

                        string email = ConsoleManager.Read("Username = " + username + "\nPassword = " + password + "\nPlease enter a email : ");


                        //On cherche à créer un User
                        request = new SignIn(username, password, email);
                        Net.SendClientCommunication(this._comm.GetStream(), request);

                        ResponseEvent.MyResponseEvent += new ResponseEvent(request, (response) =>
                        {

                            switch (response)
                            {
                                case Success success:
                                    //Si la réponse est Success, alors la création s'est bien effectué
                                    ConsoleManager.TrackWriteLine(ConsoleColor.Green, success.ToString());
                                    break;
                                case CommunicationException error:
                                    ConsoleManager.TrackWriteLine(ConsoleColor.Red, error.Message);
                                    break;
                                default:
                                    ConsoleManager.TrackWriteLine(ConsoleColor.Red, "Error while creating new User : " + response);
                                    break;
                            }

                            HomeMenu();

                        }).OnResponse;


                        break;



                    case 2:

                        this._client.KillClient();

                        break;

                }

            }
            else
            {

                switch (menu)
                {
                    case 0:

                        this._client.Disconnect();

                        this.HomeMenu();

                        break;


                    case 1:

                        Console.Clear();
                        ConsoleManager.PrintTrack();

                        string topic_name = ConsoleManager.Read("Please enter the name of the Topic : ");


                        Console.Clear();
                        ConsoleManager.PrintTrack();

                        string password = ConsoleManager.Read("Topic name = " + topic_name + "\nPlease enter the password of the Topic : ");


                        //We tried to join the first Topic found
                        ClientCommunication request = new Join(_client.User, topic_name, password);
                        Net.SendClientCommunication(_comm.GetStream(), request);
                        ResponseEvent.MyResponseEvent += new ResponseEvent(request, (response) =>
                        {

                            //On écoute la réponse

                            switch (response)
                            {
                                case Topic t:

                                    //Si la réponse est bien un Topic, alors le join s'est bien effectué
                                    ConsoleManager.TrackWriteLine(ConsoleColor.Green, "Connection to the Topic `" + t.Topic_name + "` ! ");

                                    break;


                                case CommunicationException error:

                                    ConsoleManager.TrackWriteLine(ConsoleColor.Red, error.Message);

                                    break;


                                default:

                                    ConsoleManager.TrackWriteLine(ConsoleColor.Red, "Error while joining Topic : " + response);

                                    break;
                            }

                            HomeMenu();

                        }).OnResponse;


                        break;


                    case 2:

                        Console.Clear();
                        ConsoleManager.PrintTrack();

                        topic_name = ConsoleManager.Read("Please enter the name of the new Topic : ");


                        Console.Clear();
                        ConsoleManager.PrintTrack();

                        password = ConsoleManager.Read("Topic name = " + topic_name + "\nPlease enter the password of the new Topic : ");


                        //We tried to create the Topic
                        request = new Creation(topic_name, _client.User, password);
                        Net.SendClientCommunication(_comm.GetStream(), request);
                        ResponseEvent.MyResponseEvent += new ResponseEvent(request, (response) =>
                        {

                            //On écoute la réponse

                            switch (response)
                            {
                                case Topic topic:

                                    ConsoleManager.TrackWriteLine(ConsoleColor.Green, "New Topic `" + topic.Topic_name + "` created !");

                                    break;


                                case CommunicationException error:

                                    ConsoleManager.TrackWriteLine(ConsoleColor.Red, error.Message);

                                    break;


                                default:

                                    ConsoleManager.TrackWriteLine(ConsoleColor.Red, "Error while creating Topic : " + response);

                                    break;
                            }

                            HomeMenu();

                        }).OnResponse;

                        break;


                    case 3:

                        SelectTopicMenu();

                        break;


                    case 4:

                        request = new AskConnectUser(this._client.User);
                        Net.SendClientCommunication(this._comm.GetStream(), request);

                        ResponseEvent.MyResponseEvent += new ResponseEvent(request, (response) =>
                        {

                            switch (response)
                            {
                                case List<string> users_names:

                                    SelectClientMenu(users_names);

                                    break;


                                case NoUserConnectedException e:

                                    ConsoleManager.TrackWriteLine(ConsoleColor.Red, e.Message);

                                    HomeMenu();

                                    break;


                                default:

                                    ConsoleManager.TrackWriteLine(ConsoleColor.Red, "Error while acquiring all connected Users " + response);

                                    break;

                            }

                        }).OnResponse;

                        break;


                    case 5:

                        this._client.KillClient();

                        break;

                }

            }
        }


        private void SelectTopicMenu()
        {
            if (this._client.User == null)
            {
                HomeMenu();
                return;
            }

            List<string> choices = new List<string>();
            Dictionary<int, string> topics_names = new Dictionary<int, string>();
            int i = 0;

            foreach (KeyValuePair<string, ClientTopic> topic in _client.Topics)
            {
                if (topic.Value.Topic.Owner.Username == this._client.User.Username)
                {
                    choices.Add("*" + topic.Key + " ->");
                }
                else
                {
                    choices.Add(topic.Key + " ->");
                }
                topics_names.Add(i++, topic.Key);
            }

            choices.Add("<- Go back to the Home Menu");

            ChoiceSelection.Choice choice = new ChoiceSelection.Choice("In which Topic do you want to post a message :", choices);

            int menu = ChoiceSelection.GetChoice(choice, (this._client.User == null) ? null : this._client.User.Username, null);


            if (menu == this._client.Topics.Count)
            {

                HomeMenu();

            }
            else
            {
                TopicMenu(topics_names[menu]);
            }

        }


        private void SelectClientMenu(List<string> users_names)
        {
            if (this._client.User == null)
            {
                HomeMenu();
                return;
            }

            List<string> choices = new List<string>();
            Dictionary<int, string> users_index = new Dictionary<int, string>();
            int i = 0;

            foreach (string user_name in users_names)
            {

                choices.Add(user_name + " ->");
                users_index.Add(i++, user_name);
            }

            choices.Add("<- Go back to the Home Menu");

            ChoiceSelection.Choice choice = new ChoiceSelection.Choice("To which User do you want to send a private message :", choices);

            int menu = ChoiceSelection.GetChoice(choice, (this._client.User == null) ? null : this._client.User.Username, null);


            if (menu == users_index.Count)
            {

                HomeMenu();

            }
            else
            {
                User user = new User(users_index[menu], "", "");


                //On envoie un message au serveur

                Console.Clear();
                ConsoleManager.PrintTrack();


                string message = ConsoleManager.Read("\nPlease, you can now enter messages to be sent to the User `" + user.Username + "` :");
                
                ConsoleManager.TrackWriteLine(ConsoleColor.White, "Sending message to the server...\n");

                ClientCommunication request = new SendMessage(this._client.User, user, message);
                Net.SendClientCommunication(this._comm.GetStream(), request);

                HomeMenu();
            }

        }

        private void TopicMenu(string TopicName)
        {
            if(this._client.User == null)
            {
                HomeMenu();
                return;
            }

            List<string> choices = new List<string>();

            if(this._client.Topics[TopicName].Topic.Owner.Username == this._client.User.Username)
                choices.Add("Delete the Topic");
            else
                choices.Add("Leave the Topic");

            choices.Add("Post a message in the Topic");

            choices.Add("<- Go back to the Select Topic Menu");

            ChoiceSelection.Choice choice = new ChoiceSelection.Choice("What do you want to do in the topic :", choices);

            int menu = ChoiceSelection.GetChoice(choice, (this._client.User == null) ? null : this._client.User.Username, TopicName);



            switch (menu)
            {
                case 0:

                    if (this._client.Topics[TopicName].Topic.Owner.Username == this._client.User.Username)
                    {

                        Console.Clear();
                        ConsoleManager.PrintTrack();

                        string password = ConsoleManager.Read("Please enter the password of the Topic : ");

                        //We tried to delete the Topic
                        this._client.Topics[TopicName].DeleteTopic(password, (response) =>
                        {

                            //On écoute la réponse

                            switch (response)
                            {
                                case Success s:

                                    ConsoleManager.TrackWriteLine(ConsoleColor.Green, s.ToString());

                                    break;


                                case CommunicationException error:

                                    ConsoleManager.TrackWriteLine(ConsoleColor.Red, error.Message);

                                    break;


                                default:

                                    ConsoleManager.TrackWriteLine(ConsoleColor.Red, "Error while deleting Topic : " + response);

                                    break;
                            }

                            HomeMenu();

                        });

                    }
                    else
                    {

                        //We tried to leave the Topic
                        this._client.Topics[TopicName].LeaveTopic( (response) =>
                        {

                            //On écoute la réponse

                            switch (response)
                            {
                                case Success s:

                                    ConsoleManager.TrackWriteLine(ConsoleColor.Green, s.ToString());

                                    break;


                                case CommunicationException error:

                                    ConsoleManager.TrackWriteLine(ConsoleColor.Red, error.Message);

                                    break;


                                default:

                                    ConsoleManager.TrackWriteLine(ConsoleColor.Red, "Error while leaving Topic : " + response);

                                    break;
                            }

                            HomeMenu();

                        });

                    }

                    break;


                case 1:

                    //On envoie un message au ServerTopicListener
                        
                    string message = ConsoleManager.Read("\nPlease, you can now enter messages to be sent to the Topic `" + TopicName + "` :");

                    ConsoleManager.TrackWriteLine(ConsoleColor.White, "Sending message to the server...\n");
                    _client.Topics[TopicName].SendingMessage(message, (response) =>
                    {

                        ConsoleManager.TrackWriteLine(ConsoleColor.Cyan, "MESSAGE RESPONSE :");
                        switch (response)
                        {
                            case Success s:
                                ConsoleManager.TrackWriteLine(ConsoleColor.Gray, "I received my own message from the server");

                                break;


                            case CommunicationException ce:
                                ConsoleManager.TrackWriteLine(ConsoleColor.Red, ce.Message);

                                break;

                        }

                        TopicMenu(TopicName);

                    });


                    break;



                case 2:

                    SelectTopicMenu();

                    break;

            }

        }

    }
}
