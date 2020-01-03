using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestProjectForm
{
    public partial class Topic_Frame : UserControl
    {
        public string Topic
        {
            get
            {
                return this.Topic_name.Text;
            }
            set
            {
                this.Topic_name.Text = value;
            }
        }

        private static List<Topic_Frame> Topic_Frames = new List<Topic_Frame>();
        private static Topic_Frame Topic_Frame_Selected;

        public Topic_Frame()
        {
            Topic_Frames.Add(this);
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }


        private bool panel1_isSelected = false;
        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            if (!panel1_isSelected)
            {
                this.panel1.BackColor = Color.FromArgb(110, 110, 110);
            }
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            if (!panel1_isSelected)
                this.panel1.BackColor = Color.FromArgb(90, 90, 90);
        }


        public static void ChangeSelected()
        {
            foreach(Topic_Frame tf in Topic_Frames)
            {
                tf.panel1_isSelected = false;
                tf.panel1.BackColor = Color.FromArgb(90, 90, 90);
                tf.label1.ForeColor = Color.FromArgb(150, 150, 150);
                tf.Topic_name.ForeColor = Color.FromArgb(150, 150, 150);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ChangeSelected();
            Topic_Frame_Selected = this;
            this.panel1_isSelected = true;
            this.panel1.BackColor = Color.FromArgb(130, 130, 130);
            this.label1.ForeColor = Color.FromArgb(200, 200, 200);
            this.Topic_name.ForeColor = Color.FromArgb(200, 200, 200);
        }
    }
}
