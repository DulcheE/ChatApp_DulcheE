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

        private void Content_Connexion_Load(object sender, EventArgs e)
        {
            this.textBoxConUsername.Init();
            this.textBoxConPassword.Init();
            this.textBoxInsUsername.Init();
            this.textBoxInsPassword.Init();
            this.textBoxInsEmail.Init();
        }

        private void textBoxCon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.buttonLogIn.PerformClick();
            }
        }

        private void textBoxIns_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.buttonSignIn.PerformClick();
            }
        }
    }
}
