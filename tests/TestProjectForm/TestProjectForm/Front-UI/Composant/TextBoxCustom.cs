using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestProjectForm.Composant
{
    public partial class TextBoxCustom : System.Windows.Forms.TextBox
    {
        public TextBoxCustom()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        protected bool IsOnPlaceHolder = false;

        protected void OnGotFocusCustom(object sender, EventArgs e)
        {
            if (this.IsOnPlaceHolder)
            {
                this.IsOnPlaceHolder = false;

                this.Text = "";
                this.ForeColor = this._saveForeColor;
            }
        }


        protected void OnLostFocusCustom(object sender, EventArgs e)
        {
            if (this.Text.Trim(' ') == string.Empty)
            {
                this.Text = this.PlaceHolder;
                this._saveForeColor = this.ForeColor;
                this.ForeColor = this.PlaceHolderColor;

                this.IsOnPlaceHolder = true;
            }
        }


        public void Init()
        {

            if (this.Text.Trim(' ') == string.Empty)
            {
                this.Text = this.PlaceHolder;
                this._saveForeColor = this.ForeColor;
                this.ForeColor = this.PlaceHolderColor;

                this.IsOnPlaceHolder = true;
            }
        }

    }
}
