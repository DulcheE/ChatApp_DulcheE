using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestProjectForm
{
    public partial class DebugLog : Form
    {
        public DebugLog()
        {
            InitializeComponent();
        }




        public void PrintDebug(Color color, string message)
        {
            this.Console.ForeColor = color;
            this.Console.Text += message + "\n";
        }
    }
}
