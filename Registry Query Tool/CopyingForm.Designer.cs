namespace Remote_Query_Tool
{
    partial class CopyingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CopyingForm));
            this.copyInfo = new System.Windows.Forms.RichTextBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // copyInfo
            // 
            this.copyInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.copyInfo.Location = new System.Drawing.Point(0, 0);
            this.copyInfo.Name = "copyInfo";
            this.copyInfo.Size = new System.Drawing.Size(284, 239);
            this.copyInfo.TabIndex = 0;
            this.copyInfo.Text = "";
            // 
            // closeButton
            // 
            this.closeButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.closeButton.Location = new System.Drawing.Point(0, 239);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(284, 23);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // CopyingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.copyInfo);
            this.Controls.Add(this.closeButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CopyingForm";
            this.Text = "Copyright";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox copyInfo;
        private System.Windows.Forms.Button closeButton;
    }
}