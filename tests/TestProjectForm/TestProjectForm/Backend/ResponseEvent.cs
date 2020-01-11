using Communication;
using Communication.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TestProjectForm;

namespace ClientSide
{
    class ResponseEvent
    {
        private static Form1 _Form;

        public static Form1 Form
        {
            set
            {
                if (_Form == null)
                    _Form = value;
            }
        }

        public delegate void ResponseHandler(Client source, Response received);

        public static event ResponseHandler MyResponseEvent;

        private static List<Response> BufferResponse = new List<Response>();
        private static Semaphore sem = new Semaphore(0, 1000);

        public static void WriteBufferResponse(Response r)
        {
            string thread_name = Thread.CurrentThread.Name;
            _Form.DebugLog.Invoke(new System.Windows.Forms.MethodInvoker(delegate
            {
                _Form.DebugLog.PrintDebug(System.Drawing.Color.Cyan, "[" + thread_name + "] Writting in the buffer...");
            }));
            if (r != null)
                BufferResponse.Add(r);
            sem.Release();
        }

        public static Response ReadBufferResponse()
        {
            sem.WaitOne();
            string thread_name = Thread.CurrentThread.Name;
            _Form.DebugLog.Invoke(new System.Windows.Forms.MethodInvoker(delegate
            {
                _Form.DebugLog.PrintDebug(System.Drawing.Color.Cyan, "[" + thread_name + "] Read in the buffer...");
            }) );
            Response r = BufferResponse[0];
            BufferResponse.RemoveAt(0);

            return r;
        }


        Communication.CommunicationStream request;
        Action<object> callback;




        public ResponseEvent(Communication.CommunicationStream request, Action<object> callback)
        {
            this.request = request;
            this.callback = callback;
        }


        public static void SendResponseEvent(Client source, Response received)
        {
            if (MyResponseEvent != null)
            {
                MyResponseEvent(source, received);
            }
        }


        public void OnResponse(Client source, Response received)
        {
            if (this.request.Equals(received.Request))
            {
                MyResponseEvent -= this.OnResponse;

                _Form.DebugLog.Invoke(new System.Windows.Forms.MethodInvoker(delegate
                {
                    _Form.DebugLog.PrintDebug(System.Drawing.Color.Cyan, received.Content.GetType().ToString());
                }) );

                if (!(received.Request is LogIn) && received.Content is ClientCredentialsInvalidException)
                {
                    _Form.DebugLog.Invoke(new System.Windows.Forms.MethodInvoker(delegate
                    {
                        _Form.DebugLog.PrintDebug(System.Drawing.Color.Red, ((ClientCredentialsInvalidException)received.Content).Message);
                    }) );

                    source.Disconnect();
                }

                switch (received.Request)
                {
                    case LogIn li:
                        _Form.DebugLog.Invoke(new System.Windows.Forms.MethodInvoker(delegate
                        {
                            _Form.DebugLog.PrintDebug(System.Drawing.Color.White, "Type of Communication is LogIn\n");
                        }));

                        OnResponseToLogIn(source, received);

                        break;


                    case SignIn si:
                        _Form.DebugLog.Invoke(new System.Windows.Forms.MethodInvoker(delegate
                        {
                            _Form.DebugLog.PrintDebug(System.Drawing.Color.White, "Type of Communication is SignIn\n");
                        }));

                        OnResponseToSignIn(source, received);

                        break;


                    case Join j:
                        _Form.DebugLog.Invoke(new System.Windows.Forms.MethodInvoker(delegate
                        {
                            _Form.DebugLog.PrintDebug(System.Drawing.Color.White, "Type of Communication is Join\n");
                        }));

                        OnResponseToJoin(source, received);

                        break;


                    case Leave l:
                        _Form.DebugLog.Invoke(new System.Windows.Forms.MethodInvoker(delegate
                        {
                            _Form.DebugLog.PrintDebug(System.Drawing.Color.White, "Type of Communication is Leave\n");
                        }));

                        OnResponseToLeave(source, received);

                        break;


                    case Creation c:
                        _Form.DebugLog.Invoke(new System.Windows.Forms.MethodInvoker(delegate
                        {
                            _Form.DebugLog.PrintDebug(System.Drawing.Color.White, "Type of Communication is Creation\n");
                        }));

                        OnResponseToCreation(source, received);

                        break;


                    case Delete d:
                        _Form.DebugLog.Invoke(new System.Windows.Forms.MethodInvoker(delegate
                        {
                            _Form.DebugLog.PrintDebug(System.Drawing.Color.White, "Type of Communication is Delete\n");
                        }));

                        OnResponseToDelete(source, received);

                        break;


                    case AskConnectUser acu:
                        _Form.DebugLog.Invoke(new System.Windows.Forms.MethodInvoker(delegate
                        {
                            _Form.DebugLog.PrintDebug(System.Drawing.Color.White, "Type of Communication is AskConnectUser\n");
                        }));

                        callback(received.Content);

                        break;


                    case Identification i:
                        _Form.DebugLog.Invoke(new System.Windows.Forms.MethodInvoker(delegate
                        {
                            _Form.DebugLog.PrintDebug(System.Drawing.Color.White, "Type of Communication is Identification\n");
                        }));

                        OnResponseToIdentification(source, received);

                        break;


                    default:
                        _Form.DebugLog.Invoke(new System.Windows.Forms.MethodInvoker(delegate
                        {
                            _Form.DebugLog.PrintDebug(System.Drawing.Color.DarkRed, "Type of Communication is unknown\n");
                        }));

                        this.callback(received.Content);

                        break;

                }

            }
        }



        //Default event for the LogIn
        //Return true if success
        //Return CommunicationException if an error occur
        private void OnResponseToLogIn(Client source, Response response)
        {

            //On écoute la réponse
            switch (response.Content)
            {
                case Initializer init:

                    //Si la réponse est bien un Initializer, alors le login s'est bien effectué
                    source.Init(init);


                    callback(true);

                    return;


                case CommunicationException error:

                    callback(error);

                    return;


                default:

                    _Form.DebugLog.Invoke(new System.Windows.Forms.MethodInvoker(delegate
                    {
                        _Form.DebugLog.PrintDebug(System.Drawing.Color.Red, "Error while login in : " + response.Content);
                    }));

                    break;

            }

            this.callback(response.Content);

        }



        private void OnResponseToSignIn(Client source, Response response)
        {
            this.callback(response.Content);
        }



        private void OnResponseToJoin(Client source, Response response)
        {
            if(response.Content is Topic)
            {
                source.CreateClientTopic((Topic)response.Content);
            }

            this.callback(response.Content);
        }



        //Default event for the Leave
        //Return Success if success
        //Return CommunicationException if an error occur
        private void OnResponseToLeave(Client source, Response response)
        {

            Console.WriteLine("Received response to the Leave");
            //On écoute la réponse
            switch (response.Content)
            {
                case Success s:

                    //We tried to kill the thread, he may be already terminated when the server close the connection
                    if(source.Topics.ContainsKey(((Leave)response.Request).Topic.Topic_name))
                        source.Topics[((Leave)response.Request).Topic.Topic_name].Terminate();

                    callback(s);

                    return;


                case CommunicationException error:

                    callback(error);

                    return;


                default:

                    _Form.DebugLog.Invoke(new System.Windows.Forms.MethodInvoker(delegate
                    {
                        _Form.DebugLog.PrintDebug(System.Drawing.Color.Red, "Error while leaving the Topic : " + response);
                    }));

                    break;

            }

            this.callback(response.Content);
        }



        //Default event for the Creation
        //Return the new Topic if success
        //Return CommunicationException if an error occur
        private void OnResponseToCreation(Client source, Response response)
        {


            //On écoute la réponse
            switch (response.Content)
            {
                case Topic new_topic:

                    source.CreateClientTopic((Topic)response.Content);

                    callback(new_topic);

                    return;


                case CommunicationException error:

                    callback(error);

                    return;


                default:

                    _Form.DebugLog.Invoke(new System.Windows.Forms.MethodInvoker(delegate
                    {
                        _Form.DebugLog.PrintDebug(System.Drawing.Color.Red, "Error while creating new Topic : " + response);
                    }));

                    break;

            }

            this.callback(response.Content);
        }



        //Default event for the Delete
        //Return Success if success
        //Return CommunicationException if an error occur
        private void OnResponseToDelete(Client source, Response response)
        {


            //On écoute la réponse
            switch (response.Content)
            {
                case Success s:

                    //We tried to kill the thread, he may be already terminated when the server close the connection
                    if (source.Topics.ContainsKey(((Delete)response.Request).Topic.Topic_name))
                        source.Topics[((Delete)response.Request).Topic.Topic_name].Terminate();

                    callback(s);

                    return;


                case CommunicationException error:

                    callback(error);

                    return;


                default:

                    _Form.DebugLog.Invoke(new System.Windows.Forms.MethodInvoker(delegate
                    {
                        _Form.DebugLog.PrintDebug(System.Drawing.Color.Red, "Error while deleting the Topic : " + response);
                    }));

                    break;

            }

            this.callback(response.Content);
        }



        //Default event for the Identification
        //Return Success if success
        //Return CommunicationException if an error occur
        private void OnResponseToIdentification(Client source, Response response)
        {


            //On écoute la réponse
            switch (response.Content)
            {
                case Success s:

                    callback(s);

                    return;


                case CommunicationException error:

                    callback(error);

                    return;


                default:

                    _Form.DebugLog.Invoke(new System.Windows.Forms.MethodInvoker(delegate
                    {
                        _Form.DebugLog.PrintDebug(System.Drawing.Color.Red, "Error while Identification to the Topic : " + response);
                    }));

                    break;

            }

            this.callback(response.Content);
        }
    }
}
