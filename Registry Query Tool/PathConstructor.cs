using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Net.NetworkInformation;
using System.Threading;

namespace Remote_Query_Tool
{
    /// <summary>
    /// This form provides a GUI for a user to select a registry key path/value
    /// </summary>
    public partial class PathConstructor : Form
    {
        RegistryHive RH;
        string Computer = "";
        public PathConstructor(RegistryHive rh, string computer)
        {
            InitializeComponent();
            RH = rh;
            if (RH == RegistryHive.CurrentUser)
            {
                Tree.Nodes.Add("HKEY_CURRENT_USER");
            }
            else if (RH == RegistryHive.Users)
            {
                Tree.Nodes.Add("HKEY_USERS");
            }
            else if (RH == RegistryHive.LocalMachine)
            {
                Tree.Nodes.Add("HKEY_LOCAL_MACHINE");
            }
            Computer = computer;
            this.Text = "Key Constructor : " + Computer;
            Tree.Nodes[0].Tag = new NodeInfo("", false, true);
            splitContainer1_Panel2_Resize("", new EventArgs());
            Load(Tree.Nodes[0], false);
        }

        public string constructPath(TreeNode TN)
        {
            string toReturn = "";

            bool con = true;
            TreeNode Current = TN;
            if (TN.Tag == null || TN.Tag.ToString() != "")
            {
                toReturn = TN.Text;
                while (con)
                {
                    if (Current.Parent != null && Current.Parent.Tag != Tree.Nodes[0].Tag)
                    {
                        toReturn = Current.Parent.Text + "\\" + toReturn;
                        Current = Current.Parent;
                    }
                    else
                    {
                        con = false;
                    }
                }
            }

            return toReturn;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectComputer SC = new SelectComputer(Computer);
            if (SC.ShowDialog() == DialogResult.OK)
            {

                Computer = SC.ComputerName.Text;
                this.Text = "Key Constructor : " + Computer;
            }
        }

        private void Tree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (((NodeInfo)e.Node.Tag).isKey == false)
            {
                string Err = "";
                try
                {
                    string nodePath = ((NodeInfo)e.Node.Tag).Path; //constructnodePath(e.Node);
                    #region Ping
                    //Sets up the ping codes
                    Ping pingSender = new Ping();
                    PingOptions options = new PingOptions();
                    options.DontFragment = true;
                    string data = "MatthewThompsonIsTheGreatestEver";
                    byte[] buffer = Encoding.ASCII.GetBytes(data);
                    int timeout = 120;
                    #endregion
                    PingReply reply = null;
                    try
                    {
                        reply = pingSender.Send(Computer, timeout, buffer, options);
                    }
                    catch (Exception err)
                    {
                        Err = err.Message;
                    }
                    if (reply != null && reply.Status == IPStatus.Success && Err == "")
                    {
                        try
                        {
                            Computer = Computer.Trim();
                            RegistryKey RK = RegistryKey.OpenRemoteBaseKey(RH, Computer);
                            if (nodePath != "")
                            {
                                RK = RK.OpenSubKey(nodePath);
                            }

                            string[] NewNodes = RK.GetValueNames();
                            int index = 0;
                            KeyList.Items.Clear();
                            ListViewItem NewKey;
                            while (index != NewNodes.Length)
                            {
                                NewKey = new ListViewItem(NewNodes[index]);

                                NewKey.Tag = new NodeInfo(nodePath + "\\" + NewNodes[index], true, false);

                                if (NewKey.Text == "")
                                {
                                    NewKey.Text = "(NULL)";
                                }

                                string value = "";

                                try
                                {
                                    RegistryValueKind RVK = RK.GetValueKind(NewNodes[index]);
                                    if (RVK == RegistryValueKind.String || RVK == RegistryValueKind.Unknown || RVK == RegistryValueKind.ExpandString || RVK == RegistryValueKind.MultiString)
                                    {
                                        if (RVK == RegistryValueKind.String || RVK == RegistryValueKind.MultiString || RVK == RegistryValueKind.ExpandString)
                                        {
                                            value = "[Sring(s)] ";
                                        }
                                        else if (RVK == RegistryValueKind.Unknown)
                                        {
                                            value = "[UNKNOWN] " + RK.GetValue(NewNodes[index]).ToString();
                                        }
                                        value += RK.GetValue(NewNodes[index]).ToString();
                                    }
                                    else if (RVK == RegistryValueKind.DWord)
                                    {
                                        value = "[DWord] " + ((Int32)RK.GetValue(NewNodes[index])).ToString();
                                    }
                                    else if (RVK == RegistryValueKind.QWord)
                                    {
                                        value = "[QWord] " + ((Int64)RK.GetValue(NewNodes[index])).ToString();
                                    }
                                    else if (RVK == RegistryValueKind.Binary)
                                    {
                                        byte[] MYBA = (byte[])RK.GetValue(NewNodes[index]);
                                        if (MYBA.Length > 250)
                                        {
                                            Array.Resize<byte>(ref MYBA, 250);
                                        }
                                        value = "[BINARY] " + ASCIIEncoding.UTF8.GetString(MYBA);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    value = "Error while retrieving.";
                                }

                                if (value.Length > 258)
                                {
                                    value.Remove(258);
                                }
                                NewKey.SubItems.Add(value);
                                NewKey.ImageIndex = 0;

                                KeyList.Items.Add(NewKey);
                                index++;
                            }

                        }
                        catch (Exception err)
                        {
                            Err = err.Message.ToString();
                        }
                    }
                }
                catch (Exception err)
                {
                    Err = err.Message;
                }
                if (Err != "")
                {
                    MessageBox.Show(Err);
                }
            }


            path.Text = ((NodeInfo)e.Node.Tag).Path;
        }

        private void splitContainer1_Panel2_Resize(object sender, EventArgs e)
        {
            path.Location = new Point(setCompButton.Location.X + setCompButton.Width, path.Location.Y);
            path.Width = splitContainer1.Panel2.Width - setCompButton.Width - OKButton.Width - CancelButton.Width;
        }

        private void Nodes_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            path.Text = ((NodeInfo)e.Node.Tag).Path;
        }

        private void KeyList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (KeyList.SelectedItems.Count > 0)
            {
                path.Text = ((NodeInfo)KeyList.SelectedItems[0].Tag).Path;
            }
        }

        private void Tree_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (((NodeInfo)e.Node.Tag).needsLoading == true)
            {
                Load(e.Node, false);
            }

            int pos = 0;
            while (pos < e.Node.Nodes.Count)
            {
                Load(e.Node.Nodes[pos], true);

                pos++;
            }
        }

        public void Load(TreeNode TN, bool isPreLoad)
        {
            if (((NodeInfo)TN.Tag).isKey == false && ((NodeInfo)TN.Tag).needsLoading == true)
            {
                string Err = "";
                try
                {
                    string paths = ((NodeInfo)TN.Tag).Path; //constructPath(TN);
                    #region Ping
                    //Sets up the ping codes
                    Ping pingSender = new Ping();
                    PingOptions options = new PingOptions();
                    options.DontFragment = true;
                    string data = "MatthewThompsonIsTheGreatestEver";
                    byte[] buffer = Encoding.ASCII.GetBytes(data);
                    int timeout = 120;
                    #endregion
                    PingReply reply = null;
                    try
                    {
                        reply = pingSender.Send(Computer, timeout, buffer, options);
                    }
                    catch (Exception err)
                    {
                        Err = err.Message;
                    }
                    if (reply != null && reply.Status == IPStatus.Success && Err == "")
                    {
                        try
                        {
                            Computer = Computer.Trim();
                            RegistryKey RK = RegistryKey.OpenRemoteBaseKey(RH, Computer);
                            if (paths != "")
                            {
                                RK = RK.OpenSubKey(paths/*[pos]*/);
                            }
                            if (isPreLoad)
                            {
                                if (RK.SubKeyCount > 0)
                                {
                                    TN.Nodes.Add(new TreeNode("Loading..."));
                                }
                                else
                                {
                                    TN.Tag = new NodeInfo(((NodeInfo)TN.Tag).Path, ((NodeInfo)TN.Tag).isKey, false);
                                }
                            }
                            else
                            {
                                int KeyCount=RK.SubKeyCount;
                                string[] NewNodes = RK.GetSubKeyNames();
                                
                                Tree.BeginUpdate();
                                
                                TN.Nodes.Clear();
                                TreeNode[] NewTreeNodes = new TreeNode[NewNodes.Length];
                                int index = 0;
                                while (index != NewNodes.Length)
                                {

                                    NewTreeNodes[index] = new TreeNode(NewNodes[index]);
                                    NewTreeNodes[index].StateImageIndex = 1;
                                    if (paths != "")
                                    {
                                        NewTreeNodes[index].Tag = new NodeInfo(paths + "\\" + NewNodes[index], false, true);
                                    }
                                    else
                                    {
                                        NewTreeNodes[index].Tag = new NodeInfo(NewNodes[index], false, true);
                                    }
                                    if (NewTreeNodes[index].Text == "")
                                    {
                                        NewTreeNodes[index].Text = "(NULL)";
                                    }
                                    index++;
                                }
                                
                                TN.Nodes.AddRange(NewTreeNodes);
                                Tree.EndUpdate();
                                
                            }
                        }
                        catch (Exception err)
                        {
                            Err = err.Message.ToString();
                        }
                    }
                }
                catch (Exception err)
                {
                    Err = err.Message;
                }
                if (Err != "")
                {
                    MessageBox.Show(Err, "An error occured");
                }
                else
                {
                    if (isPreLoad == false)
                    {
                        TN.Tag = new NodeInfo(((NodeInfo)TN.Tag).Path, ((NodeInfo)TN.Tag).isKey, false);
                    }
                }
            }
        }
    }
    public struct ObjectLoadInfo
    {
        public TreeNode TN;
        public bool isP;
        public ObjectLoadInfo(TreeNode tn, bool isp)
        {
            TN = tn;
            isP = isp;
        }
    }
    public struct NodeInfo
    {
        public string Path;
        public bool isKey;
        public bool needsLoading;
        public NodeInfo(string path, bool iskey, bool needsloading)
        {
            Path = path;
            isKey = iskey;
            needsLoading = needsloading;
        }
    }
}
