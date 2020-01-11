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
    public partial class ContentAddTopic : UserControl
    {
        public ContentAddTopic()
        {
            InitializeComponent();
        }

        private void ContentAddTopic_Load(object sender, EventArgs e)
        {
            this.textBoxCustomTopicName.Init();
            this.textBoxCustomTopicPassword.Init();
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.buttonSubmit.PerformClick();
            }
        }
    }
}
