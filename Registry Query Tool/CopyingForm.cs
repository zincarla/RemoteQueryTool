using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Remote_Query_Tool
{
    public partial class CopyingForm : Form
    {
        public CopyingForm()
        {
            InitializeComponent();
            copyInfo.Text = global::Remote_Query_Tool.Properties.Resources.COPYING;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
