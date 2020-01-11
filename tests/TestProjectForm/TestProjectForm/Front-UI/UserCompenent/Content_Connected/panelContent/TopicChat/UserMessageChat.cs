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
    public partial class UserMessageChat : UserControl, TopicChat.MessageChat
    {
        public UserMessageChat()
        {
            InitializeComponent();
        }

        private void UserMessageChat_Load(object sender, EventArgs e)
        {
            this.labelMessage.MaximumSize = new System.Drawing.Size(this.panelContent.Size.Width - this.Margin.Left - this.Margin.Right - this.panelContent.Padding.Left - this.panelContent.Padding.Right, 0);
        }
    }
}
