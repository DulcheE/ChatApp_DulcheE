using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestProjectForm.UserCompenent
{
    public partial class Content_Connected : UserControl
    {
        public Content_Connected()
        {
            InitializeComponent();
        }


        private List<Topic_Frame> Topic_Frames = new List<Topic_Frame>();
        public void Content_Connected_Load(object sender, EventArgs e)
        {
            int num_Topic_Frame = 20;

            for (int i = 0; i < num_Topic_Frame;)
            {
                Topic_Frame tf = new Topic_Frame();
                tf.Dock = System.Windows.Forms.DockStyle.Top;
                tf.Topic = "Topic #" + ++i;

                this.panel_topic_list.Controls.Add(tf);

                Topic_Frames.Add(tf);
            }

            for (int i = Topic_Frames.Count - 1; i >= 0; i--)
            {
                Topic_Frames[i].SendToBack();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
