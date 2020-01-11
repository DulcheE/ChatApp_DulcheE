namespace TestProjectForm.UserCompenent
{ 
    partial class ContentAddTopic
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
            this.panelCaption = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelCaption = new System.Windows.Forms.Label();
            this.separator = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.tableLayoutPanelForm = new System.Windows.Forms.TableLayoutPanel();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.textBoxCustomTopicName = new TestProjectForm.Composant.TextBoxCustom();
            this.textBoxCustomTopicPassword = new TestProjectForm.Composant.TextBoxCustom();
            this.panelCaption.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.tableLayoutPanelForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCaption
            // 
            this.panelCaption.Controls.Add(this.tableLayoutPanel1);
            this.panelCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCaption.Location = new System.Drawing.Point(0, 0);
            this.panelCaption.Name = "panelCaption";
            this.panelCaption.Size = new System.Drawing.Size(710, 150);
            this.panelCaption.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.labelCaption, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.separator, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.89743F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64.10257F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(710, 150);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelCaption
            // 
            this.labelCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCaption.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCaption.Location = new System.Drawing.Point(0, 53);
            this.labelCaption.Margin = new System.Windows.Forms.Padding(0);
            this.labelCaption.Name = "labelCaption";
            this.labelCaption.Size = new System.Drawing.Size(710, 95);
            this.labelCaption.TabIndex = 0;
            this.labelCaption.Text = "Caption";
            this.labelCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // separator
            // 
            this.separator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.separator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.separator.Location = new System.Drawing.Point(150, 148);
            this.separator.Margin = new System.Windows.Forms.Padding(150, 0, 150, 0);
            this.separator.Name = "separator";
            this.separator.Size = new System.Drawing.Size(410, 2);
            this.separator.TabIndex = 1;
            // 
            // panelContent
            // 
            this.panelContent.AutoScroll = true;
            this.panelContent.Controls.Add(this.tableLayoutPanelForm);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 150);
            this.panelContent.Margin = new System.Windows.Forms.Padding(0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(100, 50, 100, 0);
            this.panelContent.Size = new System.Drawing.Size(710, 446);
            this.panelContent.TabIndex = 1;
            // 
            // tableLayoutPanelForm
            // 
            this.tableLayoutPanelForm.AutoSize = true;
            this.tableLayoutPanelForm.ColumnCount = 1;
            this.tableLayoutPanelForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelForm.Controls.Add(this.textBoxCustomTopicName, 0, 0);
            this.tableLayoutPanelForm.Controls.Add(this.textBoxCustomTopicPassword, 0, 2);
            this.tableLayoutPanelForm.Controls.Add(this.buttonSubmit, 0, 4);
            this.tableLayoutPanelForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelForm.Location = new System.Drawing.Point(100, 50);
            this.tableLayoutPanelForm.Name = "tableLayoutPanelForm";
            this.tableLayoutPanelForm.RowCount = 5;
            this.tableLayoutPanelForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelForm.Size = new System.Drawing.Size(510, 169);
            this.tableLayoutPanelForm.TabIndex = 0;
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.AutoSize = true;
            this.buttonSubmit.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSubmit.Location = new System.Drawing.Point(175, 127);
            this.buttonSubmit.Margin = new System.Windows.Forms.Padding(175, 3, 175, 3);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(160, 39);
            this.buttonSubmit.TabIndex = 2;
            this.buttonSubmit.Text = "Ok";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            // 
            // textBoxCustomTopicName
            // 
            this.textBoxCustomTopicName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.textBoxCustomTopicName.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxCustomTopicName.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCustomTopicName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.textBoxCustomTopicName.Location = new System.Drawing.Point(150, 3);
            this.textBoxCustomTopicName.Margin = new System.Windows.Forms.Padding(150, 3, 150, 3);
            this.textBoxCustomTopicName.Name = "textBoxCustomTopicName";
            this.textBoxCustomTopicName.PlaceHolder = "Topic name";
            this.textBoxCustomTopicName.PlaceHolderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.textBoxCustomTopicName.Size = new System.Drawing.Size(210, 36);
            this.textBoxCustomTopicName.TabIndex = 0;
            this.textBoxCustomTopicName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // textBoxCustomTopicPassword
            // 
            this.textBoxCustomTopicPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.textBoxCustomTopicPassword.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxCustomTopicPassword.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCustomTopicPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.textBoxCustomTopicPassword.Location = new System.Drawing.Point(150, 65);
            this.textBoxCustomTopicPassword.Margin = new System.Windows.Forms.Padding(150, 3, 150, 3);
            this.textBoxCustomTopicPassword.Name = "textBoxCustomTopicPassword";
            this.textBoxCustomTopicPassword.PlaceHolder = "Topic password";
            this.textBoxCustomTopicPassword.PlaceHolderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.textBoxCustomTopicPassword.Size = new System.Drawing.Size(210, 36);
            this.textBoxCustomTopicPassword.TabIndex = 1;
            this.textBoxCustomTopicPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // ContentAddTopic
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelCaption);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ContentAddTopic";
            this.Size = new System.Drawing.Size(710, 596);
            this.Load += new System.EventHandler(this.ContentAddTopic_Load);
            this.panelCaption.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.tableLayoutPanelForm.ResumeLayout(false);
            this.tableLayoutPanelForm.PerformLayout();
            this.ResumeLayout(false);

        }

    #endregion

    private System.Windows.Forms.Panel panelCaption;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label separator;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelForm;
        public Composant.TextBoxCustom textBoxCustomTopicName;
        public Composant.TextBoxCustom textBoxCustomTopicPassword;
        public System.Windows.Forms.Button buttonSubmit;
        public System.Windows.Forms.Label labelCaption;
    }
}
