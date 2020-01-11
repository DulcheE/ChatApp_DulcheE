using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientSide;
using Communication.Models;

namespace TestProjectForm.UserCompenent
{
    public partial class Content_Connected : UserControl
    {

        private Client _client;

        private List<Topic_Frame> Topic_Frames = new List<Topic_Frame>();



        public Content_Connected()
        {
            InitializeComponent();
        }

        private void profile_Load(object sender, EventArgs e)
        {
            this.profile.labelEmail.Text = this._client.User.Email;
            this.profile.labelUsername.Text = this._client.User.Username;
        }



        public Dictionary<string, Topic_Frame> topicFrames = new Dictionary<string, Topic_Frame>();
        public Dictionary<string, TopicChat> topicChats = new Dictionary<string, TopicChat>();
        public void Init(Client client)
        {
            this._client = client;

            this.Profile_Frame.ChangeText(this._client.User.Username);

            Topic_Frame.NoOneSelected += (sender, e) =>
            {
                this.panelContent.SuspendLayout();
                this.panelContent.Controls.Clear();
                this.panelContent.Controls.Add(this.profile);
                this.panelContent.ResumeLayout();
            };

            this._client.FormUpToDate.ReleaseMutex();
        }


        public void AddTopicFrame(Topic topic)
        {
            TopicChat topicChat = new TopicChat();

            topicChat.labelTopicName.Text = topic.Topic_name;
            topicChat.labelTopicOwner.Text = topic.Owner.Username;

            if (this._client.User.Username == topic.Owner.Username)
                topicChat.labelTopicOwner.ForeColor = Color.LightGreen;

            this.topicChats.Add(topic.Topic_name, topicChat);


            Topic_Frame tf = new Topic_Frame();
            tf.Dock = System.Windows.Forms.DockStyle.Top;
            tf.Topic = topic.Topic_name;

            tf.Selection += (sender, e) =>
            {
                this.panelContent.SuspendLayout();
                this.panelContent.Controls.Clear();
                this.panelContent.Controls.Add(topicChat);
                this.panelContent.ResumeLayout();
            };

            this.panel_topic_list.Invoke(new MethodInvoker( delegate
            {
                this.panel_topic_list.Controls.Add(tf);
            }));

            topicFrames.Add(topic.Topic_name, tf);
            Topic_Frames.Add(tf);

            tf.Invoke(new MethodInvoker(delegate
            {
                tf.BringToFront();
            }));
        }

    }
}
