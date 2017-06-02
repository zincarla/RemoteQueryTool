namespace Remote_Query_Tool
{
    partial class SelectComputer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectComputer));
            this.OKButton = new System.Windows.Forms.Button();
            this.ComputerName = new System.Windows.Forms.TextBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(0, 20);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 0;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // ComputerName
            // 
            this.ComputerName.Dock = System.Windows.Forms.DockStyle.Top;
            this.ComputerName.Location = new System.Drawing.Point(0, 0);
            this.ComputerName.Name = "ComputerName";
            this.ComputerName.Size = new System.Drawing.Size(284, 20);
            this.ComputerName.TabIndex = 1;
            this.ComputerName.Text = "<Insert Computer Name or IP>";
            this.ComputerName.Leave += new System.EventHandler(this.textBox1_Leave);
            this.ComputerName.Enter += new System.EventHandler(this.textBox1_Enter);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(208, 21);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SelectComputer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 44);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ComputerName);
            this.Controls.Add(this.OKButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(300, 82);
            this.MinimumSize = new System.Drawing.Size(300, 82);
            this.Name = "SelectComputer";
            this.Text = "SelectComputer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelButton;
        public System.Windows.Forms.TextBox ComputerName;
    }
}