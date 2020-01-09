namespace TestProjectForm
{
    partial class DebugLog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Console = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // Console
            // 
            this.Console.AutoScroll = true;
            this.Console.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Console.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Console.Location = new System.Drawing.Point(0, 0);
            this.Console.Name = "Console";
            this.Console.Size = new System.Drawing.Size(1067, 554);
            this.Console.TabIndex = 1;
            this.Console.Resize += new System.EventHandler(this.Console_Resize);
            // 
            // DebugLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.Console);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "DebugLog";
            this.ShowIcon = false;
            this.Text = "DebugLog";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel Console;
    }
}