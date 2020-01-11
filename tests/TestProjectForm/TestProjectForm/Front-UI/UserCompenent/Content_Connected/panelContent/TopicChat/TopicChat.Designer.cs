namespace TestProjectForm
{
    partial class TopicChat
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelDescTopic = new System.Windows.Forms.Panel();
            this.labelTopicOwner = new System.Windows.Forms.Label();
            this.labelTopicName = new System.Windows.Forms.Label();
            this.panelChat = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxChat = new System.Windows.Forms.TextBox();
            this.buttonChat = new System.Windows.Forms.Button();
            this.panelContent = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelDescTopic.SuspendLayout();
            this.panelChat.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panelDescTopic, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelChat, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panelContent, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(710, 596);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelDescTopic
            // 
            this.panelDescTopic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.panelDescTopic.Controls.Add(this.labelTopicOwner);
            this.panelDescTopic.Controls.Add(this.labelTopicName);
            this.panelDescTopic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDescTopic.Location = new System.Drawing.Point(0, 0);
            this.panelDescTopic.Margin = new System.Windows.Forms.Padding(0);
            this.panelDescTopic.Name = "panelDescTopic";
            this.panelDescTopic.Size = new System.Drawing.Size(710, 59);
            this.panelDescTopic.TabIndex = 0;
            // 
            // labelTopicOwner
            // 
            this.labelTopicOwner.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelTopicOwner.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTopicOwner.Location = new System.Drawing.Point(364, 0);
            this.labelTopicOwner.Name = "labelTopicOwner";
            this.labelTopicOwner.Size = new System.Drawing.Size(346, 59);
            this.labelTopicOwner.TabIndex = 1;
            this.labelTopicOwner.Text = "Owner";
            this.labelTopicOwner.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelTopicName
            // 
            this.labelTopicName.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelTopicName.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTopicName.Location = new System.Drawing.Point(0, 0);
            this.labelTopicName.Margin = new System.Windows.Forms.Padding(0);
            this.labelTopicName.Name = "labelTopicName";
            this.labelTopicName.Size = new System.Drawing.Size(356, 59);
            this.labelTopicName.TabIndex = 0;
            this.labelTopicName.Text = "TopicName";
            this.labelTopicName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelChat
            // 
            this.panelChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.panelChat.Controls.Add(this.tableLayoutPanel2);
            this.panelChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChat.Location = new System.Drawing.Point(0, 506);
            this.panelChat.Margin = new System.Windows.Forms.Padding(0);
            this.panelChat.Name = "panelChat";
            this.panelChat.Padding = new System.Windows.Forms.Padding(15);
            this.panelChat.Size = new System.Drawing.Size(710, 90);
            this.panelChat.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 89.28571F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.71428F));
            this.tableLayoutPanel2.Controls.Add(this.textBoxChat, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonChat, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(15, 15);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(680, 60);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // textBoxChat
            // 
            this.textBoxChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.textBoxChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxChat.Location = new System.Drawing.Point(0, 0);
            this.textBoxChat.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxChat.Multiline = true;
            this.textBoxChat.Name = "textBoxChat";
            this.textBoxChat.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxChat.Size = new System.Drawing.Size(607, 60);
            this.textBoxChat.TabIndex = 0;
            this.textBoxChat.TabStop = false;
            // 
            // buttonChat
            // 
            this.buttonChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonChat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonChat.Font = new System.Drawing.Font("Myriad Hebrew", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonChat.Location = new System.Drawing.Point(607, 0);
            this.buttonChat.Margin = new System.Windows.Forms.Padding(0);
            this.buttonChat.Name = "buttonChat";
            this.buttonChat.Size = new System.Drawing.Size(73, 60);
            this.buttonChat.TabIndex = 1;
            this.buttonChat.Text = ">";
            this.buttonChat.UseVisualStyleBackColor = true;
            // 
            // panelContent
            // 
            this.panelContent.AutoScroll = true;
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(3, 62);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(704, 441);
            this.panelContent.TabIndex = 2;
            // 
            // TopicChat
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "TopicChat";
            this.Size = new System.Drawing.Size(710, 596);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelDescTopic.ResumeLayout(false);
            this.panelChat.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelDescTopic;
        public System.Windows.Forms.Label labelTopicName;
        public System.Windows.Forms.Label labelTopicOwner;
        private System.Windows.Forms.Panel panelChat;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public System.Windows.Forms.Button buttonChat;
        public System.Windows.Forms.TextBox textBoxChat;
        public System.Windows.Forms.Panel panelContent;
    }
}
