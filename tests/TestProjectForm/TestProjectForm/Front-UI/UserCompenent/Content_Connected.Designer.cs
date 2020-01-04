


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
            components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;


            this.tableLayoutPanel_Content = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_topic_list = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.topic_State_Frame1 = new TestProjectForm.UserCompenent.Topic_State_Frame();
            this.profile_Frame1 = new TestProjectForm.Profile_Frame();
            this.tableLayoutPanel_Content.SuspendLayout();
            this.panel1.SuspendLayout();


            // 
            // tableLayoutPanel_Content
            // 
            this.tableLayoutPanel_Content.ColumnCount = 3;
            this.tableLayoutPanel_Content.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel_Content.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel_Content.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel_Content.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel_Content.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel_Content.Controls.Add(this.panel3, 2, 0);
            this.tableLayoutPanel_Content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Content.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_Content.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel_Content.Name = "tableLayoutPanel_Content";
            this.tableLayoutPanel_Content.RowCount = 1;
            this.tableLayoutPanel_Content.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_Content.Size = new System.Drawing.Size(1184, 596);
            this.tableLayoutPanel_Content.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.panel1.Controls.Add(this.panel_topic_list);
            this.panel1.Controls.Add(this.topic_State_Frame1);
            this.panel1.Controls.Add(this.profile_Frame1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(236, 596);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(236, 40);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(710, 596);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(946, 40);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(238, 596);
            this.panel3.TabIndex = 2;
            // 
            // topic_State_Frame1
            // 
            this.topic_State_Frame1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.topic_State_Frame1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.topic_State_Frame1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.topic_State_Frame1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.topic_State_Frame1.Location = new System.Drawing.Point(0, 519);
            this.topic_State_Frame1.Name = "topic_State_Frame1";
            this.topic_State_Frame1.Size = new System.Drawing.Size(236, 77);
            this.topic_State_Frame1.TabIndex = 9;
            // 
            // profile_Frame1
            // 
            this.profile_Frame1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.profile_Frame1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.profile_Frame1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.profile_Frame1.Dock = System.Windows.Forms.DockStyle.Top;
            this.profile_Frame1.Location = new System.Drawing.Point(0, 0);
            this.profile_Frame1.Name = "profile_Frame1";
            this.profile_Frame1.Size = new System.Drawing.Size(236, 77);
            this.profile_Frame1.TabIndex = 8;

            //
            // this Content_Connected
            //
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tableLayoutPanel_Content);
            this.Name = "Content_Connected";
            this.Size = new System.Drawing.Size(1184, 596);
            this.Load += new System.EventHandler(this.Content_Connected_Load);
            this.ResumeLayout(false);



            this.tableLayoutPanel_Content.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Content;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private Profile_Frame profile_Frame1;
        private System.Windows.Forms.Panel panel_topic_list;
        private Topic_State_Frame topic_State_Frame1;
    }
}
