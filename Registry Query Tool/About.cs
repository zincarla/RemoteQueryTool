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
            label1.Text = label1.Text.Replace("VERSION", vers); //"Remote Query Tool ("+vers+")\r\n\r\nMade by: Matthew Thompson\r\nMade for: Marine Corps Recruiting Command\r\n\r\nDescription:\r\n       This program was designed to do varied tasks for the MCRC.";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CopyingForm CF = new CopyingForm();
            CF.ShowDialog();
        }

        private void About_Load(object sender, EventArgs e)
        {

        }
    }
}
