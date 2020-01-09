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



        private List<Label> _ConsoleLines = new List<Label>();
        public void PrintDebug(Color color, string message)
        {
            Label ConsoleNewLine = new System.Windows.Forms.Label();

            ConsoleNewLine.AutoSize = true;
            ConsoleNewLine.Dock = System.Windows.Forms.DockStyle.Top;
            ConsoleNewLine.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ConsoleNewLine.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);

            ConsoleNewLine.ForeColor = color;
            ConsoleNewLine.Text += message + "\n";
            ConsoleNewLine.MaximumSize = new Size(this.Console.Size.Width - ConsoleNewLine.Margin.Right - 10, 0);

            this.Console.Controls.Add(ConsoleNewLine);
            this._ConsoleLines.Add(ConsoleNewLine);

            ConsoleNewLine.BringToFront();
        }

        private void Console_Resize(object sender, EventArgs e)
        {
            foreach(Label Line in this._ConsoleLines)
            {
                Line.MaximumSize = new Size(this.Console.Size.Width - Line.Margin.Right - 10, 0);
            }
        }
    }
}
