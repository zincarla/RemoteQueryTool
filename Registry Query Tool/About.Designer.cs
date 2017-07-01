namespace Remote_Query_Tool
{
    partial class About
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
            this.CopyInfoLabel = new System.Windows.Forms.Label();
            this.OKButton = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.CopyButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // CopyInfoLabel
            // 
            this.CopyInfoLabel.AutoSize = true;
            this.CopyInfoLabel.Location = new System.Drawing.Point(-2, 0);
            this.CopyInfoLabel.Name = "CopyInfoLabel";
            this.CopyInfoLabel.Size = new System.Drawing.Size(263, 91);
            this.CopyInfoLabel.TabIndex = 0;
            this.CopyInfoLabel.Text = "Remote Query Tool (VERSION)\r\n\r\nMade by: Matthew Thompson\r\n\r\nDescription:\r\n       " +
    "This program is designed to allow administrators to\r\nperform remote queries agai" +
    "nst multiple computers.";
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(234, 94);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 22);
            this.OKButton.TabIndex = 1;
            this.OKButton.Text = "Ok";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Image = global::Remote_Query_Tool.Properties.Resources.QA;
            this.pictureBox.Location = new System.Drawing.Point(259, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(48, 48);
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            // 
            // CopyButton
            // 
            this.CopyButton.Location = new System.Drawing.Point(7, 94);
            this.CopyButton.Name = "CopyButton";
            this.CopyButton.Size = new System.Drawing.Size(107, 23);
            this.CopyButton.TabIndex = 3;
            this.CopyButton.Text = "Copyright/Liscense";
            this.CopyButton.UseVisualStyleBackColor = true;
            this.CopyButton.Click += new System.EventHandler(this.CopyButton_Click);
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 117);
            this.Controls.Add(this.CopyButton);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CopyInfoLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(325, 156);
            this.MinimumSize = new System.Drawing.Size(325, 156);
            this.Name = "About";
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CopyInfoLabel;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button CopyButton;
    }
}