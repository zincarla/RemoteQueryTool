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
    /// <summary>
    /// Simple pop-up form to request a machine name
    /// </summary>
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

        //If the hint is in the box, clears it
        private void ComputerName_Enter(object sender, EventArgs e)
        {
            if (ComputerName.Text == "<Insert Computer Name or IP>"){
                ComputerName.Text = "";
            }
        }

        //If blank, sets text to a hint
        private void ComputerName_Leave(object sender, EventArgs e)
        {
            if (ComputerName.Text == "")
            {
                ComputerName.Text = "<Insert Computer Name or IP>";
            }
        }

        //Close form if click with ok result
        private void OKButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        //Close form if clicked with cancel result
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
