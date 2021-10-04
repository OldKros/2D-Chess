
namespace _2D_Chess
{
    partial class LogForm
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
            this.rtfLog = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtfLog
            // 
            this.rtfLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtfLog.Location = new System.Drawing.Point(0, 0);
            this.rtfLog.Name = "rtfLog";
            this.rtfLog.ReadOnly = true;
            this.rtfLog.Size = new System.Drawing.Size(584, 415);
            this.rtfLog.TabIndex = 0;
            this.rtfLog.Text = "";
            // 
            // Log
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 415);
            this.Controls.Add(this.rtfLog);
            this.MinimumSize = new System.Drawing.Size(600, 450);
            this.Name = "Log";
            this.Text = "Log";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtfLog;
    }
}