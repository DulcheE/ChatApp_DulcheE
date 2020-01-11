


namespace TestProjectForm.UserCompenent
{
    partial class Content_Connected
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
            this.tableLayoutPanel_Content = new System.Windows.Forms.TableLayoutPanel();
            this.panelTopic = new System.Windows.Forms.Panel();
            this.panel_topic_list = new System.Windows.Forms.Panel();
            this.Topic_State_Frame = new TestProjectForm.UserCompenent.Topic_State_Frame();
            this.Profile_Frame = new TestProjectForm.Profile_Frame();
            this.panelContent = new System.Windows.Forms.Panel();
            this.profile = new TestProjectForm.UserCompenent.Profile();
            this.panelUser = new System.Windows.Forms.Panel();
            this.tableLayoutPanel_Content.SuspendLayout();
            this.panelTopic.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_Content
            // 
            this.tableLayoutPanel_Content.ColumnCount = 3;
            this.tableLayoutPanel_Content.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel_Content.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel_Content.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel_Content.Controls.Add(this.panelTopic, 0, 0);
            this.tableLayoutPanel_Content.Controls.Add(this.panelContent, 1, 0);
            this.tableLayoutPanel_Content.Controls.Add(this.panelUser, 2, 0);
            this.tableLayoutPanel_Content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Content.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_Content.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel_Content.Name = "tableLayoutPanel_Content";
            this.tableLayoutPanel_Content.RowCount = 1;
            this.tableLayoutPanel_Content.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 596F));
            this.tableLayoutPanel_Content.Size = new System.Drawing.Size(1184, 596);
            this.tableLayoutPanel_Content.TabIndex = 2;
            // 
            // panelTopic
            // 
            this.panelTopic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.panelTopic.Controls.Add(this.panel_topic_list);
            this.panelTopic.Controls.Add(this.Topic_State_Frame);
            this.panelTopic.Controls.Add(this.Profile_Frame);
            this.panelTopic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTopic.Location = new System.Drawing.Point(0, 0);
            this.panelTopic.Margin = new System.Windows.Forms.Padding(0);
            this.panelTopic.Name = "panelTopic";
            this.panelTopic.Size = new System.Drawing.Size(236, 596);
            this.panelTopic.TabIndex = 0;
            // 
            // panel_topic_list
            // 
            this.panel_topic_list.AutoScroll = true;
            this.panel_topic_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_topic_list.Location = new System.Drawing.Point(0, 77);
            this.panel_topic_list.Margin = new System.Windows.Forms.Padding(0);
            this.panel_topic_list.Name = "panel_topic_list";
            this.panel_topic_list.Size = new System.Drawing.Size(236, 442);
            this.panel_topic_list.TabIndex = 10;
            // 
            // Topic_State_Frame
            // 
            this.Topic_State_Frame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.Topic_State_Frame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Topic_State_Frame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Topic_State_Frame.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Topic_State_Frame.Location = new System.Drawing.Point(0, 519);
            this.Topic_State_Frame.Margin = new System.Windows.Forms.Padding(4);
            this.Topic_State_Frame.Name = "Topic_State_Frame";
            this.Topic_State_Frame.Size = new System.Drawing.Size(236, 77);
            this.Topic_State_Frame.TabIndex = 9;
            this.Topic_State_Frame.Load += new System.EventHandler(this.Topic_State_Frame_Load);
            // 
            // Profile_Frame
            // 
            this.Profile_Frame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.Profile_Frame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Profile_Frame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Profile_Frame.Dock = System.Windows.Forms.DockStyle.Top;
            this.Profile_Frame.Location = new System.Drawing.Point(0, 0);
            this.Profile_Frame.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Profile_Frame.Name = "Profile_Frame";
            this.Profile_Frame.Size = new System.Drawing.Size(236, 77);
            this.Profile_Frame.TabIndex = 8;
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.panelContent.Controls.Add(this.profile);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(236, 0);
            this.panelContent.Margin = new System.Windows.Forms.Padding(0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(710, 596);
            this.panelContent.TabIndex = 1;
            // 
            // profile
            // 
            this.profile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.profile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.profile.Location = new System.Drawing.Point(0, 0);
            this.profile.Margin = new System.Windows.Forms.Padding(0);
            this.profile.Name = "profile";
            this.profile.Size = new System.Drawing.Size(710, 596);
            this.profile.TabIndex = 0;
            this.profile.Load += new System.EventHandler(this.profile_Load);
            // 
            // panelUser
            // 
            this.panelUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.panelUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUser.Location = new System.Drawing.Point(946, 0);
            this.panelUser.Margin = new System.Windows.Forms.Padding(0);
            this.panelUser.Name = "panelUser";
            this.panelUser.Size = new System.Drawing.Size(238, 596);
            this.panelUser.TabIndex = 2;
            // 
            // Content_Connected
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tableLayoutPanel_Content);
            this.Name = "Content_Connected";
            this.Size = new System.Drawing.Size(1184, 596);
            this.tableLayoutPanel_Content.ResumeLayout(false);
            this.panelTopic.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Content;
        private System.Windows.Forms.Panel panelTopic;
        public System.Windows.Forms.Panel panelContent;
        public System.Windows.Forms.Panel panelUser;
        public Profile_Frame Profile_Frame;
        public System.Windows.Forms.Panel panel_topic_list;
        public Topic_State_Frame Topic_State_Frame;
        private UserCompenent.Profile profile;
    }
}
