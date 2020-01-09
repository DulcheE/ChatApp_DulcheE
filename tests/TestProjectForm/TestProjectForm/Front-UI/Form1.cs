using System;
using System.Threading;
using System.Windows.Forms;
using ClientSide;

namespace TestProjectForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private Client _client;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.DebugLog.Show();

            this._client = new Client("127.0.0.1", 8976, this);
            Thread.CurrentThread.Name = "I/O";
            this._client.Start();

        }



        private void buttonExit_Click(object sender, EventArgs e)
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

        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void content_Connexion1_Load(object sender, EventArgs e)
        {

            this.content_Connexion1.Add_button1_Click((sender_click, e_click) =>
            {
                this._client.Connection(this.content_Connexion1.textBoxConUsername, this.content_Connexion1.textBoxConPassword);
            });
        }


        public void Connect()
        {
            if(this.content_Connexion1.Visible && !this.content_Connected1.Visible)
            {
                this.SuspendLayout();
                this.content_Connexion1.Hide();
                this.content_Connected1.Show();
                this.ResumeLayout();
            }
        }
    }
}
