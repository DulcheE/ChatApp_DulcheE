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
            this.panelUpperLeft = new System.Windows.Forms.Panel();
            this.labelAppName = new System.Windows.Forms.Label();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.panelUpperRight = new System.Windows.Forms.Panel();
            this.buttonMinimize = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.panel_Content = new System.Windows.Forms.Panel();
            this.content_Connexion1 = new TestProjectForm.UserCompenent.Content_Connexion();
            this.content_Connected1 = new TestProjectForm.UserCompenent.Content_Connected();
            this.tableLayoutPanel_HeadContent.SuspendLayout();
            this.tableLayoutPanel_Head.SuspendLayout();
            this.panelUpperLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.panelUpperRight.SuspendLayout();
            this.panel_Content.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_HeadContent
            // 
            this.tableLayoutPanel_HeadContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1579F));
            this.tableLayoutPanel_HeadContent.Controls.Add(this.tableLayoutPanel_Head, 0, 0);
            this.tableLayoutPanel_HeadContent.Controls.Add(this.panel_Content, 0, 1);
            this.tableLayoutPanel_HeadContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_HeadContent.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_HeadContent.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel_HeadContent.Name = "tableLayoutPanel_HeadContent";
            this.tableLayoutPanel_HeadContent.RowCount = 2;
            this.tableLayoutPanel_HeadContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel_HeadContent.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_HeadContent.Size = new System.Drawing.Size(1579, 783);
            this.tableLayoutPanel_HeadContent.TabIndex = 1;
            // 
            // tableLayoutPanel_Head
            // 
            this.tableLayoutPanel_Head.ColumnCount = 3;
            this.tableLayoutPanel_Head.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel_Head.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel_Head.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel_Head.Controls.Add(this.panelUpperLeft, 0, 0);
            this.tableLayoutPanel_Head.Controls.Add(this.panelUpperRight, 2, 0);
            this.tableLayoutPanel_Head.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Head.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_Head.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel_Head.Name = "tableLayoutPanel_Head";
            this.tableLayoutPanel_Head.RowCount = 1;
            this.tableLayoutPanel_Head.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel_Head.Size = new System.Drawing.Size(1579, 49);
            this.tableLayoutPanel_Head.TabIndex = 2;
            // 
            // panelUpperLeft
            // 
            this.panelUpperLeft.BackColor = System.Drawing.SystemColors.Control;
            this.panelUpperLeft.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelUpperLeft.BackgroundImage")));
            this.panelUpperLeft.Controls.Add(this.labelAppName);
            this.panelUpperLeft.Controls.Add(this.pictureBoxIcon);
            this.panelUpperLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUpperLeft.Location = new System.Drawing.Point(0, 0);
            this.panelUpperLeft.Margin = new System.Windows.Forms.Padding(0);
            this.panelUpperLeft.Name = "panelUpperLeft";
            this.panelUpperLeft.Size = new System.Drawing.Size(315, 49);
            this.panelUpperLeft.TabIndex = 3;
            this.panelUpperLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelBorder_MouseDown);
            this.panelUpperLeft.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelBorder_MouseMove);
            this.panelUpperLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelBorder_MouseUp);
            // 
            // labelAppName
            // 
            this.labelAppName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelAppName.AutoSize = true;
            this.labelAppName.BackColor = System.Drawing.Color.Transparent;
            this.labelAppName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAppName.Location = new System.Drawing.Point(57, 11);
            this.labelAppName.Margin = new System.Windows.Forms.Padding(0);
            this.labelAppName.Name = "labelAppName";
            this.labelAppName.Size = new System.Drawing.Size(178, 29);
            this.labelAppName.TabIndex = 3;
            this.labelAppName.Text = "The Otter Chat";
            this.labelAppName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelAppName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelBorder_MouseDown);
            this.labelAppName.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelBorder_MouseMove);
            this.labelAppName.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelBorder_MouseUp);
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBoxIcon.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxIcon.Image")));
            this.pictureBoxIcon.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxIcon.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.Size = new System.Drawing.Size(53, 49);
            this.pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxIcon.TabIndex = 2;
            this.pictureBoxIcon.TabStop = false;
            this.pictureBoxIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelBorder_MouseDown);
            this.pictureBoxIcon.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelBorder_MouseMove);
            this.pictureBoxIcon.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelBorder_MouseUp);
            // 
            // panelUpperRight
            // 
            this.panelUpperRight.BackColor = System.Drawing.SystemColors.Control;
            this.panelUpperRight.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelUpperRight.BackgroundImage")));
            this.panelUpperRight.Controls.Add(this.buttonMinimize);
            this.panelUpperRight.Controls.Add(this.buttonExit);
            this.panelUpperRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUpperRight.Location = new System.Drawing.Point(1262, 0);
            this.panelUpperRight.Margin = new System.Windows.Forms.Padding(0);
            this.panelUpperRight.Name = "panelUpperRight";
            this.panelUpperRight.Size = new System.Drawing.Size(317, 49);
            this.panelUpperRight.TabIndex = 4;
            this.panelUpperRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelBorder_MouseDown);
            this.panelUpperRight.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelBorder_MouseMove);
            this.panelUpperRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelBorder_MouseUp);
            // 
            // buttonMinimize
            // 
            this.buttonMinimize.BackColor = System.Drawing.SystemColors.GrayText;
            this.buttonMinimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonMinimize.FlatAppearance.BorderSize = 0;
            this.buttonMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMinimize.Location = new System.Drawing.Point(211, 0);
            this.buttonMinimize.Margin = new System.Windows.Forms.Padding(0);
            this.buttonMinimize.Name = "buttonMinimize";
            this.buttonMinimize.Size = new System.Drawing.Size(53, 49);
            this.buttonMinimize.TabIndex = 1;
            this.buttonMinimize.Text = "_";
            this.buttonMinimize.UseVisualStyleBackColor = false;
            this.buttonMinimize.Click += new System.EventHandler(this.buttonMinimize_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.SystemColors.GrayText;
            this.buttonExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonExit.FlatAppearance.BorderSize = 0;
            this.buttonExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Tomato;
            this.buttonExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.Location = new System.Drawing.Point(264, 0);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(0);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(53, 49);
            this.buttonExit.TabIndex = 0;
            this.buttonExit.Text = "x";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // panel_Content
            // 
            this.panel_Content.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.panel_Content.Controls.Add(this.content_Connexion1);
            this.panel_Content.Controls.Add(this.content_Connected1);
            this.panel_Content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Content.Location = new System.Drawing.Point(0, 49);
            this.panel_Content.Margin = new System.Windows.Forms.Padding(0);
            this.panel_Content.Name = "panel_Content";
            this.panel_Content.Size = new System.Drawing.Size(1579, 734);
            this.panel_Content.TabIndex = 0;
            // 
            // content_Connexion1
            // 
            this.content_Connexion1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.content_Connexion1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.content_Connexion1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.content_Connexion1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.content_Connexion1.Location = new System.Drawing.Point(0, 0);
            this.content_Connexion1.Margin = new System.Windows.Forms.Padding(4);
            this.content_Connexion1.Name = "content_Connexion1";
            this.content_Connexion1.Size = new System.Drawing.Size(1579, 734);
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
            this.content_Connected1.Margin = new System.Windows.Forms.Padding(4);
            this.content_Connected1.Name = "content_Connected1";
            this.content_Connected1.Size = new System.Drawing.Size(1579, 734);
            this.content_Connected1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.ClientSize = new System.Drawing.Size(1579, 783);
            this.Controls.Add(this.tableLayoutPanel_HeadContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.MediumSpringGreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel_HeadContent.ResumeLayout(false);
            this.tableLayoutPanel_Head.ResumeLayout(false);
            this.panelUpperLeft.ResumeLayout(false);
            this.panelUpperLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.panelUpperRight.ResumeLayout(false);
            this.panel_Content.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_HeadContent;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Head;
        private System.Windows.Forms.Panel panel_Content;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonMinimize;
        private System.Windows.Forms.Panel panelUpperLeft;
        private System.Windows.Forms.Panel panelUpperRight;
        private System.Windows.Forms.Label labelAppName;
        private Content_Connexion content_Connexion1;
        private Content_Connected content_Connected1;

        public readonly DebugLog DebugLog = new DebugLog();
    }
}

