using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Communication.Models;
using ClientSide;

namespace TestProjectForm
{
    public partial class TopicChat : UserControl
    {

        public interface MessageChat { }

        public TopicChat()
        {
            InitializeComponent();
        }



        private Client _client;
        private List<MessageChat> messages = new List<MessageChat>();
        public void AddMessage(Client client, Communication.Models.Message message)
        {
            this._client = client;


            this.panelContent.SuspendLayout();

            switch (message.Source)
            {
                case User user:

                    if(this._client.User.Username == user.Username)
                    {
                        MyMessageChat mc = new MyMessageChat();

                        mc.Dock = DockStyle.Top;

                        mc.labelDate.Text = message.Upload_date.ToString();
                        mc.labelMessage.Text = message.Content;

                        this.panelContent.Controls.Add(mc);
                        mc.BringToFront();

                        this.messages.Add(mc);
                    }
                    else
                    {
                        UserMessageChat mc = new UserMessageChat();

                        mc.Dock = DockStyle.Top;

                        mc.labelDate.Text = message.Upload_date.ToString();
                        mc.labelUsername.Text = user.Username;
                        mc.labelMessage.Text = message.Content;

                        this.panelContent.Controls.Add(mc);
                        mc.BringToFront();

                        this.messages.Add(mc);
                    }

                    break;


                case Topic topic:

                    break;

            }

            this.panelContent.ResumeLayout();

        }
    }
}
