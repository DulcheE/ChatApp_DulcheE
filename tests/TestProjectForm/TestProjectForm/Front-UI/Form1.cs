using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestProjectForm.UserCompenent;

namespace TestProjectForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_Content_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.ActiveForm.Close();
        }

        int beginMouse_forBorder_X = 0;
        int beginMouse_forBorder_Y = 0;
        bool isMouseDown_forBorder = false;
        private void panelBorder_MouseDown(object sender, MouseEventArgs e)
        {
            if (!isMouseDown_forBorder)
            {
                beginMouse_forBorder_X = Form1.MousePosition.X;
                beginMouse_forBorder_Y = Form1.MousePosition.Y;
            }


            isMouseDown_forBorder = true;
        }

        private void panelBorder_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown_forBorder = false;
        }

        private void panelBorder_MouseMove(object sender, MouseEventArgs e)
        {
            if(isMouseDown_forBorder)
            {
                this.SetDesktopLocation(Form1.ActiveForm.Location.X + Form1.MousePosition.X - beginMouse_forBorder_X, Form1.ActiveForm.Location.Y + Form1.MousePosition.Y - beginMouse_forBorder_Y);

                beginMouse_forBorder_X = Form1.MousePosition.X;
                beginMouse_forBorder_Y = Form1.MousePosition.Y;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        int beginMouse_splitter_X = 0;
        bool isMouseDown_splitter = false;
        private void Splitter1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!isMouseDown_splitter)
            {
                beginMouse_splitter_X = Form1.MousePosition.X;
            }


            isMouseDown_splitter = true;
        }

        private void Splitter1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown_splitter = false;
        }

        private void Splitter1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown_splitter)
            {
                this.SetDesktopLocation(Form1.ActiveForm.Location.X + Form1.MousePosition.X - beginMouse_splitter_X, Form1.ActiveForm.Location.Y);

                beginMouse_splitter_X = Form1.MousePosition.X;
            }
        }
    }
}
