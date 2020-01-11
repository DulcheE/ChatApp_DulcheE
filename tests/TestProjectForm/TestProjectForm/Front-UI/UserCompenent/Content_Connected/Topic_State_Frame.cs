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
using Communication;

namespace TestProjectForm.UserCompenent
{
    public partial class Topic_State_Frame : UserControl
    {
        public Topic_State_Frame()
        {
            InitializeComponent();
        }

        private EventHandler _previousClickMethode;
        public void buttonRemove_Init(Client client, ClientTopic ct)
        {
            this.buttonRemove.BackgroundImage = global::TestProjectForm.Properties.Resources.RemoveTopic_2;
            this.buttonRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonRemove.FlatAppearance.BorderSize = 0;
            this.buttonRemove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.buttonRemove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.buttonRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRemove.UseVisualStyleBackColor = true;

            if(_previousClickMethode != null)
                this.buttonRemove.Click -= _previousClickMethode;


            if (client.User.Username == ct.Topic.Owner.Username)
            {

                this._previousClickMethode = (sender, e) =>
                {
                    string message = "Are you sure you want to delete this topic ?";
                    string caption = "Deleting Topic `" + ct.Topic.Topic_name + "`";

                    DialogResult result = MessageBox.Show(message, caption,
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question);

                    // If the yes button was pressed ...
                    if (result == DialogResult.Yes)
                    {
                        ct.DeleteTopic(ct.Topic.Password, (response) =>
                        {

                            //On écoute la réponse

                            switch (response)
                            {
                                case Success s:

                                    client.Form.Invoke(new MethodInvoker(delegate
                                    {
                                        client.Form.DebugLog.PrintDebug(Color.Green, s.ToString());


                                        client.Form.content_Connected1.panel_topic_list.SuspendLayout();

                                        client.Form.content_Connected1.panel_topic_list.Controls.Remove(client.Form.content_Connected1.topicFrames[ct.Topic.Topic_name]);
                                        client.Form.content_Connected1.topicFrames.Remove(ct.Topic.Topic_name);

                                        client.Form.content_Connected1.panel_topic_list.ResumeLayout();

                                    }));

                                    break;


                                case CommunicationException error:

                                    client.Form.DebugLog.Invoke(new MethodInvoker(delegate
                                    {
                                        client.Form.DebugLog.PrintDebug(Color.Red, error.Message);
                                    }));

                                    break;


                                default:

                                    client.Form.DebugLog.Invoke(new MethodInvoker(delegate
                                    {
                                        client.Form.DebugLog.PrintDebug(Color.Red, "Error while deleting Topic : " + response);
                                    }));

                                    break;
                            }

                        });

                    }
                };


                this.buttonRemove.Click += this._previousClickMethode;

            }
            else
            {
                this._previousClickMethode = (sender, e) =>
                {
                    string message = "Are you sure you want to leave this topic ?";
                    string caption = "Leaving Topic `" + ct.Topic.Topic_name + "`";

                    DialogResult result = MessageBox.Show(message, caption,
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question);

                    // If the no button was pressed ...
                    if (result == DialogResult.Yes)
                    {
                        //We tried to leave the Topic
                        ct.LeaveTopic((response) =>
                        {

                            //On écoute la réponse

                            switch (response)
                            {
                                case Success s:

                                    client.Form.Invoke(new MethodInvoker(delegate
                                    {
                                        client.Form.DebugLog.PrintDebug(Color.Green, s.ToString());


                                        client.Form.content_Connected1.panel_topic_list.SuspendLayout();

                                        client.Form.content_Connected1.panel_topic_list.Controls.Remove(client.Form.content_Connected1.topicFrames[ct.Topic.Topic_name]);
                                        client.Form.content_Connected1.topicFrames.Remove(ct.Topic.Topic_name);

                                        client.Form.content_Connected1.panel_topic_list.ResumeLayout();

                                    }));

                                    break;


                                case CommunicationException error:

                                    client.Form.DebugLog.Invoke(new MethodInvoker(delegate
                                    {
                                        client.Form.DebugLog.PrintDebug(Color.Red, error.Message);
                                    }));

                                    break;


                                default:

                                    client.Form.DebugLog.Invoke(new MethodInvoker(delegate
                                    {
                                        client.Form.DebugLog.PrintDebug(Color.Red, "Error while leaving Topic : " + response);
                                    }));

                                    break;
                            }

                        });
                    }
                };


                this.buttonRemove.Click += this._previousClickMethode;
            }

        }
    }
}
