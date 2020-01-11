namespace TestProjectForm
{
    partial class MyMessageChat
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
            this.panelDesc = new System.Windows.Forms.Panel();
            this.labelDate = new System.Windows.Forms.Label();
            this.panelContentMarge = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.labelMessage = new System.Windows.Forms.Label();
            this.panelDesc.SuspendLayout();
            this.panelContentMarge.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDesc
            // 
            this.panelDesc.AutoSize = true;
            this.panelDesc.Controls.Add(this.labelDate);
            this.panelDesc.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDesc.Location = new System.Drawing.Point(0, 0);
            this.panelDesc.Name = "panelDesc";
            this.panelDesc.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.panelDesc.Size = new System.Drawing.Size(772, 17);
            this.panelDesc.TabIndex = 0;
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDate.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelDate.Location = new System.Drawing.Point(7, 0);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(38, 17);
            this.labelDate.TabIndex = 0;
            this.labelDate.Text = "Date";
            this.labelDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panelContentMarge
            // 
            this.panelContentMarge.AutoSize = true;
            this.panelContentMarge.BackColor = System.Drawing.Color.Transparent;
            this.panelContentMarge.Controls.Add(this.panelContent);
            this.panelContentMarge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContentMarge.Location = new System.Drawing.Point(0, 17);
            this.panelContentMarge.Margin = new System.Windows.Forms.Padding(0);
            this.panelContentMarge.Name = "panelContentMarge";
            this.panelContentMarge.Padding = new System.Windows.Forms.Padding(10, 2, 100, 10);
            this.panelContentMarge.Size = new System.Drawing.Size(772, 236);
            this.panelContentMarge.TabIndex = 1;
            // 
            // panelContent
            // 
            this.panelContent.AutoSize = true;
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(150)))));
            this.panelContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelContent.Controls.Add(this.labelMessage);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(10, 2);
            this.panelContent.Margin = new System.Windows.Forms.Padding(0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(662, 224);
            this.panelContent.TabIndex = 0;
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMessage.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMessage.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.labelMessage.Location = new System.Drawing.Point(0, 0);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(127, 21);
            this.labelMessage.TabIndex = 0;
            this.labelMessage.Text = "labelMessage";
            // 
            // MyMessageChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panelContentMarge);
            this.Controls.Add(this.panelDesc);
            this.Name = "MyMessageChat";
            this.Size = new System.Drawing.Size(772, 253);
            this.Load += new System.EventHandler(this.MyMessageChat_Load);
            this.panelDesc.ResumeLayout(false);
            this.panelDesc.PerformLayout();
            this.panelContentMarge.ResumeLayout(false);
            this.panelContentMarge.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelDesc;
        private System.Windows.Forms.Panel panelContentMarge;
        private System.Windows.Forms.Panel panelContent;
        public System.Windows.Forms.Label labelMessage;
        public System.Windows.Forms.Label labelDate;
    }
}
