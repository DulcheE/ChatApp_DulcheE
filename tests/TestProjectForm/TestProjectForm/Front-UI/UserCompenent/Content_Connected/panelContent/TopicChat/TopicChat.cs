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
using Communication;

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
        private Topic _topic;

        private ClientTopic _clientTopic => this._client.Topics[this._topic.Topic_name];

        public void Init(Client client, Topic topic)
        {
            this._client = client;
            this._topic = topic;

            this.labelTopicName.Text = this._topic.Topic_name;
            this.labelTopicOwner.Text = this._topic.Owner.Username;

            if (this._client.User.Username == this._topic.Owner.Username)
                this.labelTopicOwner.ForeColor = Color.LightGreen;

            this.panelContent.Scroll += new ScrollEventHandler((sender, e) =>
            {
                this.panelContent.VerticalScroll.Value = e.NewValue;
            });
        }



        private List<MessageChat> messages = new List<MessageChat>();
        public void AddMessage(Communication.Models.Message message)
        {
            this.panelContent.SuspendLayout();

            bool ScrollBottom = false;
            if (this.panelContent.VerticalScroll.Value >= this.panelContent.VerticalScroll.Maximum - this.panelContent.Height)
                ScrollBottom = true;

            switch (message.Source)
            {
                case User user:


                    if(this._client.User.Username == user.Username)
                    {
                        MyMessageChat mmc = new MyMessageChat();

                        mmc.Dock = DockStyle.Top;

                        mmc.labelDate.Text = message.Upload_date.ToString();
                        mmc.labelMessage.Text = message.Content;

                        this._client.Form.Invoke(new MethodInvoker(delegate
                        {
                            this.panelContent.Controls.Add(mmc);
                        }));

                        mmc.BringToFront();

                        this.messages.Add(mmc);
                    }
                    else
                    {
                        UserMessageChat umc = new UserMessageChat();

                        umc.Dock = DockStyle.Top;

                        umc.labelDate.Text = message.Upload_date.ToString();
                        umc.labelUsername.Text = user.Username;
                        umc.labelMessage.Text = message.Content;

                        this._client.Form.Invoke(new MethodInvoker(delegate
                        {
                            this.panelContent.Controls.Add(umc);
                        }));


                        umc.BringToFront();

                        this.messages.Add(umc);
                    }

                    break;


                case Topic topic:

                    break;

            }
            this.panelContent.ResumeLayout();

            if (ScrollBottom)
            {
                this.panelContent.VerticalScroll.Value = this.panelContent.VerticalScroll.Maximum;
                this.panelContent.VerticalScroll.Value = this.panelContent.VerticalScroll.Maximum;
            }

        }

        private void buttonChat_Click(object sender, EventArgs e)
        {

            this._client.Form.DebugLog.PrintDebug(Color.White, "Sending message to the server...\n");

            this._clientTopic.SendingMessage(this.textBoxChat.Text, (response) =>
            {

                switch (response)
                {
                    case Success s:
                        this._client.Form.DebugLog.Invoke(new MethodInvoker(delegate
                        {
                            this._client.Form.DebugLog.PrintDebug(Color.Gray, "I received my own message from the server");
                        }));

                        break;


                    case CommunicationException ce:
                        this._client.Form.DebugLog.Invoke(new MethodInvoker(delegate
                        {
                            this._client.Form.DebugLog.PrintDebug(Color.Red, ce.Message);
                        }));

                        break;

                }

            });

            this.textBoxChat.Text = string.Empty;

        }
    }
}
