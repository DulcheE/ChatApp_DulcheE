namespace TestProjectForm.Front_UI.UserCompenent.Content_Connected.panelContent
{
    partial class Profile
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
            this.panelUsername = new System.Windows.Forms.Panel();
            this.tableLayoutPanelUsername = new System.Windows.Forms.TableLayoutPanel();
            this.labelUsername = new System.Windows.Forms.Label();
            this.separator = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.labelEmail = new System.Windows.Forms.Label();
            this.panelEmail = new System.Windows.Forms.Panel();
            this.labelDescEmail = new System.Windows.Forms.Label();
            this.panelUsername.SuspendLayout();
            this.tableLayoutPanelUsername.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.panelEmail.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelUsername
            // 
            this.panelUsername.Controls.Add(this.tableLayoutPanelUsername);
            this.panelUsername.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUsername.Location = new System.Drawing.Point(0, 0);
            this.panelUsername.Name = "panelUsername";
            this.panelUsername.Size = new System.Drawing.Size(710, 150);
            this.panelUsername.TabIndex = 0;
            // 
            // tableLayoutPanelUsername
            // 
            this.tableLayoutPanelUsername.ColumnCount = 1;
            this.tableLayoutPanelUsername.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelUsername.Controls.Add(this.labelUsername, 0, 1);
            this.tableLayoutPanelUsername.Controls.Add(this.separator, 0, 2);
            this.tableLayoutPanelUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelUsername.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelUsername.Name = "tableLayoutPanelUsername";
            this.tableLayoutPanelUsername.RowCount = 3;
            this.tableLayoutPanelUsername.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.89743F));
            this.tableLayoutPanelUsername.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64.10257F));
            this.tableLayoutPanelUsername.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanelUsername.Size = new System.Drawing.Size(710, 150);
            this.tableLayoutPanelUsername.TabIndex = 0;
            // 
            // labelUsername
            // 
            this.labelUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelUsername.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsername.Location = new System.Drawing.Point(0, 53);
            this.labelUsername.Margin = new System.Windows.Forms.Padding(0);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(710, 95);
            this.labelUsername.TabIndex = 0;
            this.labelUsername.Text = "Username";
            this.labelUsername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.panelContent.Controls.Add(this.panelEmail);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 150);
            this.panelContent.Margin = new System.Windows.Forms.Padding(0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(100, 50, 100, 0);
            this.panelContent.Size = new System.Drawing.Size(710, 446);
            this.panelContent.TabIndex = 1;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelEmail.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmail.Location = new System.Drawing.Point(96, 0);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(75, 28);
            this.labelEmail.TabIndex = 0;
            this.labelEmail.Text = "Email";
            // 
            // panelEmail
            // 
            this.panelEmail.Controls.Add(this.labelEmail);
            this.panelEmail.Controls.Add(this.labelDescEmail);
            this.panelEmail.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEmail.Location = new System.Drawing.Point(100, 50);
            this.panelEmail.Name = "panelEmail";
            this.panelEmail.Size = new System.Drawing.Size(510, 100);
            this.panelEmail.TabIndex = 1;
            // 
            // labelDescEmail
            // 
            this.labelDescEmail.AutoSize = true;
            this.labelDescEmail.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelDescEmail.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescEmail.Location = new System.Drawing.Point(0, 0);
            this.labelDescEmail.Name = "labelDescEmail";
            this.labelDescEmail.Size = new System.Drawing.Size(96, 28);
            this.labelDescEmail.TabIndex = 1;
            this.labelDescEmail.Text = "Email : ";
            // 
            // Profile
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelUsername);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Profile";
            this.Size = new System.Drawing.Size(710, 596);
            this.panelUsername.ResumeLayout(false);
            this.tableLayoutPanelUsername.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.panelEmail.ResumeLayout(false);
            this.panelEmail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelUsername;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelUsername;
        public System.Windows.Forms.Panel panelContent;
        public System.Windows.Forms.Label labelUsername;
        public System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label separator;
        private System.Windows.Forms.Panel panelEmail;
        private System.Windows.Forms.Label labelDescEmail;
    }
}
