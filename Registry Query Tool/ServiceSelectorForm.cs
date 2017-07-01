using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Windows.Forms;

namespace Remote_Query_Tool
{
    /// <summary>
    /// Remotely connects to a computer to pull available services to query
    /// </summary>
    public partial class ServiceSelectorForm : Form
    {
        public string SelectedDisplayName = "";
        public string SelectedServiceName = "";
        string Computer = "";
        public ServiceSelectorForm(string computer)
        {
            InitializeComponent();
            Computer = computer;
            this.Text = "Service Selector : " + Computer;
            loadList();
        }

        private void setCompButton_Click(object sender, EventArgs e)
        {
            SelectComputer SC = new SelectComputer(Computer);
            if (SC.ShowDialog() == DialogResult.OK)
            {
                Computer = SC.ComputerName.Text;
                this.Text = "Service Selector : " + Computer;
                loadList();
            }
        }

        private void loadList()
        {
            serviceList.Items.Clear();
            try
            {
                ServiceController[] Services = ServiceController.GetServices(Computer);
                foreach (ServiceController Service in Services)
                {
                    ListViewItem LVI = new ListViewItem(Service.DisplayName);
                    LVI.SubItems.Add(Service.ServiceName);
                    serviceList.Items.Add(LVI);
                }
            }
            catch
            {
                MessageBox.Show("Thre was an error retrieving services from "+Computer+". Please click \"Refresh\" and try again or select another computer. This is likely due to permissions, or machine connectivity.");
                serviceList.Items.Clear();
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            loadList();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (serviceList.SelectedItems.Count >= 1)
            {
                this.SelectedDisplayName = serviceList.SelectedItems[0].Text;
                this.SelectedServiceName = serviceList.SelectedItems[0].SubItems[1].Text;
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
