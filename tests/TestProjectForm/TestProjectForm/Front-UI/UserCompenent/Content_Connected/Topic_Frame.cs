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

        private void Topic_Frame_Load(object sender, EventArgs e)
        {
            this.Selection += new EventHandler(ChangeSelected);
        }


        private bool isSelected = false;
        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            if (!isSelected)
            {
                this.panel1.BackColor = Color.FromArgb(110, 110, 110);
            }
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            if (!isSelected)
                this.panel1.BackColor = Color.FromArgb(90, 90, 90);
        }


        public void ChangeSelected(object sender, EventArgs e)
        {
            if (this.isSelected)
            {
                foreach (Topic_Frame tf in Topic_Frames)
                {
                    if (tf.isSelected)
                    {
                        tf.isSelected = false;
                        tf.panel1.BackColor = Color.FromArgb(90, 90, 90);
                        tf.label1.ForeColor = Color.FromArgb(150, 150, 150);
                        tf.Topic_name.ForeColor = Color.FromArgb(150, 150, 150);
                    }
                }

                Topic_Frame.InvokeNoOneSelected(sender, e);
            }
            else
            {
                foreach (Topic_Frame tf in Topic_Frames)
                {
                    if (tf.isSelected)
                    {
                        tf.isSelected = false;
                        tf.panel1.BackColor = Color.FromArgb(90, 90, 90);
                        tf.label1.ForeColor = Color.FromArgb(150, 150, 150);
                        tf.Topic_name.ForeColor = Color.FromArgb(150, 150, 150);
                    }
                }

                Topic_Frame_Selected = this;
                this.isSelected = true;
                this.panel1.BackColor = Color.FromArgb(130, 130, 130);
                this.label1.ForeColor = Color.FromArgb(200, 200, 200);
                this.Topic_name.ForeColor = Color.FromArgb(200, 200, 200);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            OnSelection(null);
        }




        public event EventHandler Selection;

        public void OnSelection(EventArgs e)
        {
            if (this.Selection != null)
            {
                this.Selection?.Invoke(this, e);
            }
        }


        public void InvokeSelection(object toInvoke, EventArgs e)
        {
            if (this.Selection != null)
            {
                this.Selection?.Invoke(toInvoke, e);
            }
        }


        public static event EventHandler NoOneSelected;


        public static void InvokeNoOneSelected(object toInvoke, EventArgs e)
        {
            if (Topic_Frame.NoOneSelected != null)
            {
                Topic_Frame.NoOneSelected?.Invoke(toInvoke, e);
            }
        }
    }
}
