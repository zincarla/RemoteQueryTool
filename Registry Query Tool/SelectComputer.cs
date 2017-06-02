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
    public partial class SelectComputer : Form
    {

        public SelectComputer(string init)
        {
            InitializeComponent();
            if (init != "")
            {
                ComputerName.Text = init;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (ComputerName.Text == "<Insert Computer Name or IP>"){
                ComputerName.Text = "";
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (ComputerName.Text == "")
            {
                ComputerName.Text = "<Insert Computer Name or IP>";
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
