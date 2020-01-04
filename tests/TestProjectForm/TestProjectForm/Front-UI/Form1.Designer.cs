using TestProjectForm.UserCompenent;

namespace TestProjectForm
{
    partial class Form1
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tableLayoutPanel_HeadContent = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel_Head = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel_Content = new System.Windows.Forms.Panel();
            this.content_Connexion1 = new TestProjectForm.UserCompenent.Content_Connexion();
            this.content_Connected1 = new TestProjectForm.UserCompenent.Content_Connected();
            this.tableLayoutPanel_HeadContent.SuspendLayout();
            this.tableLayoutPanel_Head.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel_Content.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_HeadContent
            // 
            this.tableLayoutPanel_HeadContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1184F));
            this.tableLayoutPanel_HeadContent.Controls.Add(this.tableLayoutPanel_Head, 0, 0);
            this.tableLayoutPanel_HeadContent.Controls.Add(this.panel_Content, 0, 1);
            this.tableLayoutPanel_HeadContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_HeadContent.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_HeadContent.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel_HeadContent.Name = "tableLayoutPanel_HeadContent";
            this.tableLayoutPanel_HeadContent.RowCount = 2;
            this.tableLayoutPanel_HeadContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel_HeadContent.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_HeadContent.Size = new System.Drawing.Size(1184, 636);
            this.tableLayoutPanel_HeadContent.TabIndex = 1;
            // 
            // tableLayoutPanel_Head
            // 
            this.tableLayoutPanel_Head.ColumnCount = 3;
            this.tableLayoutPanel_Head.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel_Head.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel_Head.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel_Head.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel_Head.Controls.Add(this.panel5, 2, 0);
            this.tableLayoutPanel_Head.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Head.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_Head.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel_Head.Name = "tableLayoutPanel_Head";
            this.tableLayoutPanel_Head.RowCount = 1;
            this.tableLayoutPanel_Head.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel_Head.Size = new System.Drawing.Size(1184, 40);
            this.tableLayoutPanel_Head.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel4.BackgroundImage")));
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(236, 40);
            this.panel4.TabIndex = 3;
            this.panel4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelBorder_MouseDown);
            this.panel4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelBorder_MouseMove);
            this.panel4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelBorder_MouseUp);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "The Otter Chat";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelBorder_MouseDown);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelBorder_MouseMove);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelBorder_MouseUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelBorder_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelBorder_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelBorder_MouseUp);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.Control;
            this.panel5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel5.BackgroundImage")));
            this.panel5.Controls.Add(this.button2);
            this.panel5.Controls.Add(this.button1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(946, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(238, 40);
            this.panel5.TabIndex = 4;
            this.panel5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelBorder_MouseDown);
            this.panel5.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelBorder_MouseMove);
            this.panel5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelBorder_MouseUp);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.GrayText;
            this.button2.Dock = System.Windows.Forms.DockStyle.Right;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(158, 0);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 40);
            this.button2.TabIndex = 1;
            this.button2.Text = "_";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GrayText;
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Tomato;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(198, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "x";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel_Content
            // 
            this.panel_Content.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.panel_Content.Controls.Add(this.content_Connexion1);
            this.panel_Content.Controls.Add(this.content_Connected1);
            this.panel_Content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Content.Location = new System.Drawing.Point(0, 40);
            this.panel_Content.Margin = new System.Windows.Forms.Padding(0);
            this.panel_Content.Name = "panel_Content";
            this.panel_Content.Size = new System.Drawing.Size(1184, 596);
            this.panel_Content.TabIndex = 0;
            // 
            // content_Connexion1
            // 
            this.content_Connexion1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.content_Connexion1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.content_Connexion1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.content_Connexion1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.content_Connexion1.Location = new System.Drawing.Point(0, 0);
            this.content_Connexion1.Name = "content_Connexion1";
            this.content_Connexion1.Size = new System.Drawing.Size(1184, 596);
            this.content_Connexion1.TabIndex = 0;
            this.content_Connexion1.Load += new System.EventHandler(this.content_Connexion1_Load);
            // 
            // content_Connected1
            // 
            this.content_Connected1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.content_Connected1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.content_Connected1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.content_Connected1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.content_Connected1.Location = new System.Drawing.Point(0, 0);
            this.content_Connected1.Name = "content_Connected1";
            this.content_Connected1.Size = new System.Drawing.Size(1184, 596);
            this.content_Connected1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.ClientSize = new System.Drawing.Size(1184, 636);
            this.Controls.Add(this.tableLayoutPanel_HeadContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.MediumSpringGreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel_HeadContent.ResumeLayout(false);
            this.tableLayoutPanel_Head.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel_Content.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_HeadContent;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Head;
        private System.Windows.Forms.Panel panel_Content;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private Content_Connexion content_Connexion1;
        private Content_Connected content_Connected1;
    }
}

