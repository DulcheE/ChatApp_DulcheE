namespace TestProjectForm.Composant
{
    partial class TextBoxCustom
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            this.GotFocus += new System.EventHandler(OnGotFocusCustom);
            this.LostFocus += new System.EventHandler(OnLostFocusCustom);
        }

        #endregion
        protected string _PlaceHolder;
        public string PlaceHolder
        {
            get => this._PlaceHolder;
            set => this._PlaceHolder = value;
        }

        public override string Text
        {
            get
            {
                if (this.IsOnPlaceHolder)
                {
                    return " ";
                }
                else
                {
                    return base.Text;
                }
            }
            set => base.Text = value;
        }


        protected System.Drawing.Color _PlaceHolderColor;
        public System.Drawing.Color PlaceHolderColor
        {
            get
            {
                return this._PlaceHolderColor;
            }

            set
            {
                this._PlaceHolderColor = value;

                if (this.IsOnPlaceHolder)
                    base.ForeColor = value;
            }
        }

        protected System.Drawing.Color _saveForeColor;
        public override System.Drawing.Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                if (this.IsOnPlaceHolder)
                {
                    this._saveForeColor = value;
                }
                else
                {
                    base.ForeColor = value;
                }
            }
        }

    }
}
