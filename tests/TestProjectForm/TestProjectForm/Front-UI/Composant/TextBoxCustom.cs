using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectForm.Front_UI.Composant
{
    public partial class TextBoxCustom : Component
    {
        public TextBoxCustom()
        {
            InitializeComponent();
        }

        public TextBoxCustom(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private string _Placeholder;
        public string Placeholder
        {
            get
            {
                return this._Placeholder;
            }
            set
            {
                this._Placeholder = value;
            }
        }

        private bool isOnPlaceholder = false;
        public void textBox1_GotFocus(object sender, System.EventArgs e)
        {
            if (this.isOnPlaceholder)
                this.textBox.Text = "";
        }


        public void textBox1_LostFocus(object sender, System.EventArgs e)
        {
            if (this.textBox.Text.Length == 0)
            {
                this.isOnPlaceholder = true;
                this.textBox.Text = this.Placeholder;
            }
        }
    }
}
