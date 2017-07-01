using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.ServiceProcess;
using System.Diagnostics;
using System.Threading;
using System.Deployment;
using System.Reflection;

namespace Remote_Query_Tool
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            string vers = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            CopyInfoLabel.Text = CopyInfoLabel.Text.Replace("VERSION", vers);
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
            CopyingForm CF = new CopyingForm();
            CF.ShowDialog();
        }
    }
}
