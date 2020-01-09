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
    public partial class Content_Connexion : UserControl
    {
        public Content_Connexion()
        {
            InitializeComponent();
        }


        public void Add_button1_Click(Action<object, EventArgs> eventOnClick)
        {
            this.button1.Click += new System.EventHandler(eventOnClick);
        }


        public void Remove_button1_Click(Action<object, EventArgs> eventOnClick)
        {
            this.button1.Click -= new System.EventHandler(eventOnClick);
        }

        private void Content_Connexion_Load(object sender, EventArgs e)
        {
            this._textBoxConUsername.Init();
            this._textBoxConPassword.Init();
            this._textBoxInsUsername.Init();
            this._textBoxInsPassword.Init();
            this._textBoxInsEmail.Init();
        }
    }
}
