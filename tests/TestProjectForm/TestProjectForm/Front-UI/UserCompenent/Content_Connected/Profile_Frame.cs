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
    public partial class Profile_Frame : UserControl
    {
        public Profile_Frame()
        {
            InitializeComponent();
        }




        public void ChangeText(string text)
        {
            this.label1.Text = text;
        }
    }
}
