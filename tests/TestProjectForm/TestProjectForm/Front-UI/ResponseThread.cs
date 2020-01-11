using ClientSide;
using Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectForm
{
    class ResponseThread
    {
        private bool _terminate = false;
        private Client _client;




        public ResponseThread(Client client) => this._client = client;


        public void Terminate()
        {
            this._terminate = true;
        }

        public void Start()
        {
            while (!_terminate)
            {
                Response response = ResponseEvent.ReadBufferResponse();


                ResponseEvent.SendResponseEvent(this._client, response);
            }
        }
    }
}
