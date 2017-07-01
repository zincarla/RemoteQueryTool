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
using System.Resources;
using System.Xml.Serialization;

namespace Remote_Query_Tool
{
    //Main form
    public partial class RQT : Form
    {
        #region Variables and init
        BackgroundWorker MainBW = new BackgroundWorker();
        public bool stopWorkers = false;
        queryType QueryType = queryType.Program;
        bool CurrentlyWorking = false;
        int WorkerIndex = 0;
        string FilePath = "";//Location of the Layout file
        bool FinishedReads = false;
        BackgroundWorker[] BackgroundWorkers = new BackgroundWorker[0];
        BackgroundWorker ComputerThread = new BackgroundWorker();
        List<string[]> ToWriteBuffer = new List<string[]>();
        bool LockToWriteBuffer = false;
        List<string> ComputerBuffer = new List<string>();
        bool LockComputerBuffer = false;
        const string PingData = "MatthewThompsonIsTheGreatestEver";
        const int PingTimeout = 1000;

        #region RegistryQueryInfo
        string KeyPath;
        string KeyName;
        string FullKeyPath;
        RegistryHive KeyHive;
        #endregion

        public RQT()
        {
            InitializeComponent();
            splitContainer1_Panel2_Resize(this, new EventArgs());//Replace the layout in panel2
        }
        #endregion

        #region Button/Menu codes
        #region Sets Input
        //This set the input file's location
        private void inputLocationButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.CheckFileExists = true;
            OFD.Multiselect = false;
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                inputTB.Text = OFD.FileName;
            }
        }
        #endregion
        #region Sets Output
        //This set the output file's location
        private void outputLocationButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog SFD = new SaveFileDialog();
            SFD.Filter = "CSV (MS-DOS)|*.csv|Text (Tab Delimeted)|*.txt|XML (Excel compatible)|*.xml";
            SFD.DefaultExt = ".txt";
            if (SFD.ShowDialog() == DialogResult.OK)
            {
                outputTB.Text = SFD.FileName;
            }
        }
        #endregion
        #region Exit program button
        private void exitProgramButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion
        #region currentComputerText
        delegate void DeleSA(string[] str);
        delegate void DeleS(string str);
        delegate void DeleSI(string str, int n);
        public void currentComputerText(string ComputerName, int index)
        {
            if (this.InvokeRequired == true)
            {
                DeleSI D = new DeleSI(currentComputerText);
                this.Invoke(D, new object[2] { ComputerName, index });
            }
            else
            {
                computerList.Items[index].Text = ComputerName;
            }
        }
        #endregion
        #region cancelButton_click
        private void cancelButton_Click(object sender, EventArgs e)
        {
            ForceCancel();
        }
        #endregion
        #region ForceCancel
        delegate void Dele();
        delegate int IndexDelegate();
        public void ForceCancel()
        {
            if (this.InvokeRequired == true)
            {
                Dele D = new Dele(ForceCancel);
                this.Invoke(D);
            }
            else
            {
                stopWorkers = true;
            }
        }
        #endregion
        #region SetWorkingStatus
        delegate void DeleB(bool BoolValue);
        public void SetWorkingStatus(bool isWorking)
        {
            if (this.InvokeRequired == true)
            {
                DeleB D = new DeleB(SetWorkingStatus);
                this.Invoke(D, new object[1] { isWorking });
            }
            else
            {
                CurrentlyWorking = isWorking;
            }
        }
        #endregion
        #region Open Output File
        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists(outputTB.Text))
            {
                System.Diagnostics.Process.Start(outputTB.Text);
            }
            else
            {
                MessageBox.Show("You have not selected an output file, or the output file does not exist.");
            }
        }
        #endregion
        #region go buttons
        #region Registry Query
        //This starts the query loop
        private void goButton_Click(object sender, EventArgs e)
        {
            if (canPerfromNewQuery(queryType.Registry))
            {
                Disable();
                QueryType = queryType.Registry;
                MainBW = new BackgroundWorker();
                MainBW.DoWork += new DoWorkEventHandler(BWMain_DoWork);
                stopWorkers = false;
                CurrentlyWorking = true;
                MainBW.RunWorkerAsync();
            }
        }
        #endregion

        #region Program/Services Query
        private void goButton2_Click(object sender, EventArgs e)
        {
            if (canPerfromNewQuery(queryType.Program))
            {
                Disable();
                QueryType = queryType.Program;
                MainBW = new BackgroundWorker();
                MainBW.DoWork += new DoWorkEventHandler(BWMain_DoWork);
                stopWorkers = false;
                CurrentlyWorking = true;
                MainBW.RunWorkerAsync();
            }
        }
        #endregion

        #region Commands
        private void goButton3_Click(object sender, EventArgs e)
        {
            if (canPerfromNewQuery(queryType.Commands))
            {
                Disable();
                QueryType = queryType.Commands;
                MainBW = new BackgroundWorker();
                MainBW.DoWork += new DoWorkEventHandler(BWMain_DoWork);
                stopWorkers = false;
                CurrentlyWorking = true;
                MainBW.RunWorkerAsync();
            }
        }
        #endregion
        #endregion

        private void PathContructButton_Click(object sender, EventArgs e)
        {
            RegistryHive RH = RegistryHive.CurrentUser;
            if (usersRB.Checked == true)
            {
                RH = RegistryHive.Users;
            }
            else if (localMachineRB.Checked == true)
            {
                RH = RegistryHive.LocalMachine;
            }
            else if (currentUserRB.Checked == true)
            {
                RH = RegistryHive.CurrentUser;
            }
            SelectComputer SC = new SelectComputer(pcName.Text);
            if (SC.ShowDialog() == DialogResult.OK)
            {
                PathConstructor PC = new PathConstructor(RH, SC.ComputerName.Text);
                if (PC.ShowDialog() == DialogResult.OK)
                {
                    keyPathTB.Text = PC.path.Text;
                }
            }
        }

        private void serviceSelectHelpButton_Click(object sender, EventArgs e)
        {
            SelectComputer SC = new SelectComputer(pcName.Text);
            if (SC.ShowDialog() == DialogResult.OK)
            {
                ServiceSelectorForm PC = new ServiceSelectorForm(SC.ComputerName.Text);
                if (PC.ShowDialog() == DialogResult.OK)
                {
                    if (serviceDisplayNameRB.Checked)
                    {
                        toSearchFor.Text = PC.SelectedDisplayName;
                    }
                    else
                    {
                        toSearchFor.Text = PC.SelectedServiceName;
                    }
                }
            }
        }

        #region ToolStrip Menu
        private void saveSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FilePath != "")
            {
                bool pass = false;
                if (File.Exists(FilePath))
                {
                    if (MessageBox.Show("Are you sure you want to rewrite this file?", "Are you sure?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        pass = true;
                    }
                }
                else
                {
                    pass = true;
                }
                if (pass == true)
                {
                    SaveOptions(FilePath);
                }
            }
            else
            {
                SaveFileDialog SFD = new SaveFileDialog();
                SFD.Filter = "RQT Options (*.rqt) | *.rqt";
                if (SFD.ShowDialog() == DialogResult.OK)
                {
                    FilePath = SFD.FileName;
                    SaveOptions(FilePath);
                }
            }
        }

        private void loadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog OFD = new OpenFileDialog();
                OFD.Filter = "RQT Options (*.rqt) | *.rqt";
                if (OFD.ShowDialog() == DialogResult.OK)
                {
                    LoadOptions(OFD.FileName);
                }
            }
            catch (Exception EXC)
            {
                MessageBox.Show("Load Failed\r\n" + EXC.Message, "Load Failed");
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog SFD = new SaveFileDialog();
            SFD.Filter = "RQT Options (*.rqt) | *.rqt";
            if (SFD.ShowDialog() == DialogResult.OK)
            {
                SaveOptions(SFD.FileName);
            }
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            About AB = new About();
            AB.ShowDialog();
        }
        #endregion
        #endregion

        #region Polish (Uneeded, but nice)
        #region CmdLine Polishing
        private void CmdLine_Enter(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(TextBox))
            {
                TextBox SenderBox = (TextBox)sender;
                if (SenderBox.Text == "<Type a command, ignored otherwise>")
                {
                    SenderBox.Text = "";
                }
            }
        }

        private void CmdLine_Leave(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(TextBox))
            {
                TextBox SenderBox = (TextBox)sender;
                if (SenderBox.Text == "")
                {
                    SenderBox.Text = "<Type a command, ignored otherwise>";
                }
            }
        }
        #endregion

        #region TextBox Polishing
        private void toSearchFor_Enter(object sender, EventArgs e)
        {
            if (toSearchFor.Text == "<Name of process or service>")
            {
                toSearchFor.Text = "";
            }
        }

        private void toSearchFor_Leave(object sender, EventArgs e)
        {
            if (toSearchFor.Text == "")
            {
                toSearchFor.Text = "<Name of process or service>";
            }
        }

        private void pcName_Enter(object sender, EventArgs e)
        {
            if (pcName.Text == "<Insert Computer Name or IP>"&&pcName.ReadOnly == false)
            {
                pcName.Text = "";
            }
        }

        private void pcName_Leave(object sender, EventArgs e)
        {
            if (pcName.Text == "")
            {
                pcName.Text = "<Insert Computer Name or IP>";
            }
        }

        private void keyPathTB_Leave(object sender, EventArgs e)
        {
            if (keyPathTB.Text == "")
            {
                keyPathTB.Text = "<Insert a key path>";
            }
        }

        private void keyPathTB_Enter(object sender, EventArgs e)
        {
            if (keyPathTB.Text == "<Insert a key path>")
            {
                keyPathTB.Text = "";
            }
        }
        #endregion

        #region Radio Button Polishing
        private void onePcQuery_CheckedChanged(object sender, EventArgs e)
        {
            pcName.ReadOnly = multipleQueries.Checked;
            inputLocationButton.Enabled = multipleQueries.Checked;
        }

        private void ServicesRB_CheckedChanged(object sender, EventArgs e)
        {
            restartCheckBox.Enabled = ServicesRB.Checked && !MultipleRB.Checked;
            serviceSelectHelpButton.Enabled = ServicesRB.Checked && !MultipleRB.Checked;
        }
        #endregion
        #endregion

        #region can perform query function (Checks pretty much anything that can ruin a new query)
        public enum queryType { Registry, Program, Commands };
        public bool canPerfromNewQuery(queryType TypeOfQuery)
        {
            if (CurrentlyWorking == false)
            {
                if (outputTB.Text != "<Output File>")//This is for bug prevention, It makes sure that Input and Output files have been selected
                {
                    if (multipleQueries.Checked == true && inputTB.Text == "<Input File>")
                    {
                        MessageBox.Show("Please make sure that you have selected an input file to read from");
                    }
                    else
                    {
                        if (singleQuery.Checked == true && pcName.Text == "<Insert Computer Name or IP>")
                        {
                            MessageBox.Show("Please make sure that you have entered a computer name or IP.");
                        }
                        else
                        {
                            if (TypeOfQuery == queryType.Registry)
                            {
                                if (keyPathTB.Text == "<Insert a key path>")
                                {
                                    MessageBox.Show("Please make sure that you have entered the path of the key to query.");
                                }
                                else
                                {
                                    return true;
                                }
                            }
                            else if (TypeOfQuery == queryType.Program)
                            {
                                if (toSearchFor.Text == "<Name of process or service>" && SingleRB.Checked == true || toSearchFor.Text == "" && SingleRB.Checked == true)
                                {
                                    MessageBox.Show("Please make sure you have entered the name of the process/service that you are looking for.");
                                }
                                else
                                {
                                    return true;
                                }
                            }
                            else if (TypeOfQuery == queryType.Commands)
                            {
                                //If any command line has a command
                                if (CmdLine1.Text != "<Type a command, ignored otherwise>" ||
                                    CmdLine2.Text != "<Type a command, ignored otherwise>" ||
                                    CmdLine3.Text != "<Type a command, ignored otherwise>" ||
                                    CmdLine4.Text != "<Type a command, ignored otherwise>" ||
                                    CmdLine5.Text != "<Type a command, ignored otherwise>")
                                {
                                    return true;
                                }
                                else
                                {
                                    MessageBox.Show("Please make sure you have entered in at least one command.");
                                }
                            }//TODO: For any new query type, add another else if, and confirm that everything is setup for use
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please make sure that you have selected an output file to write to.");
                }
            }
            else
            {
                MessageBox.Show("You are already running a query! Please wait for your first query to end before starting another.");
            }
            return false;
        }
        #endregion

        #region Background workers of the queries
        
        public void SetUpThreads()
        {
            if (this.InvokeRequired == true)
            {
                Dele D = new Dele(SetUpThreads);
                this.Invoke(D);
            }
            else
            {
                computerList.Items.Clear();//Clears the list view
                int compos = 0;
                while (compos != Convert.ToInt32(simultaneousQ.Value))
                {
                    computerList.Items.Add("");//Initializes only enough rows for each thread to have a row
                    compos++;
                }
                FinishedReads = false;
                BackgroundWorkers = new BackgroundWorker[Convert.ToInt32(simultaneousQ.Value)];

                if (QueryType == queryType.Registry)
                {
                    #region Sets Hive Location
                    ///Set hive based on radio buttons
                    RegistryHive RH = RegistryHive.CurrentUser;
                    if (usersRB.Checked == true)
                    {
                        KeyHive = RegistryHive.Users;
                        FullKeyPath = "HKEY_USERS\\" + keyPathTB.Text;
                    }
                    else if (localMachineRB.Checked == true)
                    {
                        KeyHive = RegistryHive.LocalMachine;
                        FullKeyPath = "HKEY_LOCAL_MACHINE\\" + keyPathTB.Text;
                    }
                    else if (currentUserRB.Checked == true)
                    {
                        KeyHive = RegistryHive.CurrentUser;
                        FullKeyPath = "HKEY_CURRENT_USER\\" + keyPathTB.Text;
                    }
                    #endregion
                    #region SetKey
                    //Split the keyname from the path Example
                    //KeyName = WindowTitle
                    //FullPath = HKLM\Software\Notepad\WindowTitle
                    //KeyPath = HKLM\Software\Notepad
                    string[] keyPathA = keyPathTB.Text.Split(new string[1] { "\\" }, StringSplitOptions.None);
                    KeyName = keyPathA[keyPathA.Length - 1];
                    KeyPath = "";
                    for (int I = 0; I < keyPathA.Length-1; I++)
                    {
                        if (I - 1 != keyPathA.Length-1)
                        {
                            KeyPath += keyPathA[I] + "\\";
                        }
                        else
                        {
                            KeyPath += keyPathA[I];
                        }
                    }
                    #endregion
                }

                //Start buffer before worker threads to prevent delay
                ComputerThread = new BackgroundWorker();//Start the ComputerThread (Reads computers into a buffer)
                ComputerThread.DoWork += new DoWorkEventHandler(BWReadComputers_DoWork);
                ComputerThread.RunWorkerAsync();

                for (int I=0; I<BackgroundWorkers.Length; I++)
                {
                    BackgroundWorkers[I] = new BackgroundWorker();
                    BackgroundWorkers[I].DoWork += new DoWorkEventHandler(BWQuery_DoWork);
                    BackgroundWorkers[I].WorkerSupportsCancellation = true;
                }

                /*
                int pos = 0;
                if (QueryType == queryType.Program)
                {
                    while (pos != BackgroundWorkers.Length)
                    {
                        BackgroundWorkers[pos] = new BackgroundWorker();
                        BackgroundWorkers[pos].DoWork += new DoWorkEventHandler(BWProgram_DoWork);
                        BackgroundWorkers[pos].WorkerSupportsCancellation = true;
                        pos++;
                    }
                }
                else if (QueryType == queryType.Registry)
                {
                    while (pos != BackgroundWorkers.Length)
                    {
                        BackgroundWorkers[pos] = new BackgroundWorker();
                        BackgroundWorkers[pos].DoWork += new DoWorkEventHandler(BWRegistry_DoWork);
                        BackgroundWorkers[pos].WorkerSupportsCancellation = true;
                        pos++;
                    }
                }
                else if (QueryType == queryType.Commands)
                {
                    while (pos != BackgroundWorkers.Length)
                    {
                        BackgroundWorkers[pos] = new BackgroundWorker();
                        BackgroundWorkers[pos].DoWork += new DoWorkEventHandler(BWCommands_DoWork);
                        BackgroundWorkers[pos].WorkerSupportsCancellation = true;
                        pos++;
                    }
                }*/
                //TODO Add any other query type here, following the examples above

                for (int I = 0; I < BackgroundWorkers.Length; I++)
                {
                    BackgroundWorkers[I].RunWorkerAsync();//Start all the created threads
                }
            }
        }

        void BWQuery_DoWork(object sender, DoWorkEventArgs e)
        {
            #region Ping Setup
            //Sets up the ping codes
            Ping pingSender = new Ping();
            PingOptions pingOptions = new PingOptions() { DontFragment = true };
            byte[] pingData = Encoding.ASCII.GetBytes(PingData);
            #endregion
            int Index = ClaimIndex();
            while (stopWorkers == false&&!(FinishedReads == true && ComputerBuffer.Count == 0))
            {
                string Computer = RetrieveFromComputerBuffer();
                if (Computer != "N/A" && Computer != null)
                {
                    try
                    {
                        currentComputerText(Computer + ": Pinging", Index);
                        #region Ping
                        PingReply reply = null;
                        try
                        {
                            for (int I = 0; I < 4; I++)
                            {
                                reply = pingSender.Send(Computer, PingTimeout, pingData, pingOptions);//Ping to see if online
                                if (reply != null && reply.Status == IPStatus.Success)
                                {
                                    break;
                                }
                            }
                        }
                        catch (Exception err)
                        {
                            AddToBuffer(new string[3] { Computer, "Ping Failed", err.Message });
                            reply = null;
                        }
                        #endregion
                        if (reply != null && reply.Status == IPStatus.Success)
                        {
                            if (QueryType == queryType.Program)
                            {
                                QueryProgram(Computer, Index);
                            }
                            else if (QueryType == queryType.Registry)
                            {
                                QueryRegistry(Computer, Index);
                            }
                            else if (QueryType == queryType.Commands)
                            {
                                QueryCommands(Computer, Index);
                            }
                            //TODO: If new QueryType is added, then add another else if, like above
                        }
                        else if (reply != null)
                        {
                            AddToBuffer(new string[3] { Computer, "Ping Failed", reply.Status.ToString() });//Ping failed
                        }
                        IncrementProgress();

                    }
                    catch (Exception Unexpected)
                    {
                        AddToBuffer(new string[3] { (Computer != null ? Computer : "NULL?"), "UNEXPECTED ERROR", Unexpected.Message });
                    }
                }
                else
                {
                    currentComputerText("Waiting for buffer", Index);
                    Thread.Sleep(250);
                }
            }
            currentComputerText("Thread Closed", Index);
            ReleiveIndex();
        }

        void QueryProgram(string Computer, int Index)
        {
            if (ServicesRB.Checked == true)//Service query
            {
                ServiceController[] Services = ServiceController.GetServices(Computer);
                if (SingleRB.Checked == true)//Query against 1 service
                {
                    int pos = 0;
                    bool found = false;
                    while (pos < Services.Length)//Search through all services
                    {
                        if ( serviceDisplayNameRB.Checked && Services[pos].DisplayName == toSearchFor.Text || 
                            serviceSystemNameRB.Checked && Services[pos].ServiceName == toSearchFor.Text)//for the service to find
                        {
                            found = true;
                            string Status = Services[pos].Status.ToString();
                            if (restartCheckBox.Checked && Services[pos].CanStop)//If restart requested
                            {
                                //Restart service here
                                try
                                {
                                    if (Services[pos].Status != ServiceControllerStatus.Stopped)
                                    {
                                        currentComputerText(Computer + ": Stopping Service", Index);
                                        Status += "/Stop";
                                        Services[pos].Stop();
                                    }
                                    try
                                    {
                                        Services[pos].WaitForStatus(ServiceControllerStatus.Stopped, new TimeSpan(0, 2, 0));
                                        try
                                        {
                                            Status += "/Start";
                                            Services[pos].Start();
                                            Services[pos].WaitForStatus(ServiceControllerStatus.Running, new TimeSpan(0, 2, 0));
                                            Status += "/Finished";
                                        }
                                        catch (Exception)
                                        {
                                            Status += "/Fail";
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        Status = "/Fail";
                                    }
                                }
                                catch (Exception) { Status += "/Fail"; }
                            }
                            AddToBuffer(new string[3] { Computer, toSearchFor.Text, Status });
                            break;
                        }

                        pos++;
                    }
                    if (found == false)//Occurs if service is not found
                    {
                        AddToBuffer(new string[3] { Computer, toSearchFor.Text, "Not installed" });
                    }
                }
                else if (MultipleRB.Checked == true)//Query to list services
                {
                    int pos = 0;
                    while (pos < Services.Length)
                    {
                        AddToBuffer(new string[4] { Computer, Services[pos].DisplayName, Services[pos].ServiceName, Services[pos].Status.ToString() });
                        pos++;
                    }
                }
            }
            else if (ProcessRB.Checked == true)//Query process
            {
                if (SingleRB.Checked == true)//Only look for one process
                {
                    Process[] Processes = Process.GetProcessesByName(toSearchFor.Text, Computer);
                    if (Processes.Length > 0)
                    {
                        AddToBuffer(new string[3] { Computer, toSearchFor.Text, "Running" });
                    }
                    else
                    {
                        AddToBuffer(new string[3] { Computer, toSearchFor.Text, "Off" });
                    }
                }
                else if (MultipleRB.Checked == true)//List processes
                {
                    Process[] Processes = Process.GetProcesses(Computer);
                    int pos = 0;
                    while (pos != Processes.Length)
                    {
                        AddToBuffer(new string[3] { Computer, Processes[pos].ProcessName, Processes[pos].StartTime.ToString() });
                        pos++;
                    }
                }
            }
        }

        void QueryRegistry(string Computer, int Index)
        {
            try
            {
                RegistryKey RK = RegistryKey.OpenRemoteBaseKey(KeyHive, Computer.Trim());
                string value = RK.OpenSubKey(KeyPath, RegistryKeyPermissionCheck.ReadSubTree, System.Security.AccessControl.RegistryRights.ReadKey).GetValue(KeyName).ToString();
                RK.Close();
                if (existsRB.Checked == true)//check only for existance
                {
                    AddToBuffer(new string[3] { Computer, FullKeyPath, "True"});
                }
                else if (valueRB.Checked == true)//Value check
                {
                    if (value == valueTB.Text)//Compare values
                    {
                        AddToBuffer(new string[3] { Computer, FullKeyPath, "True" });
                    }
                    else
                    {
                        AddToBuffer(new string[3] { Computer, FullKeyPath, "False" });
                    }
                }
                else if (outputRB.Checked == true)//Output value
                {
                    AddToBuffer(new string[3] { Computer, FullKeyPath, value });
                }
            }
            catch (ArgumentException)
            {

                if (existsRB.Checked == true)
                {
                    AddToBuffer(new string[3] { Computer, FullKeyPath, "False" });
                }
                else
                {
                    AddToBuffer(new string[3] { Computer, FullKeyPath, "Key Not Found" });
                }
            }
            catch (NullReferenceException)
            {

                if (existsRB.Checked == true)
                {
                    AddToBuffer(new string[3] { Computer, FullKeyPath, "False" });
                }
                else
                {
                    AddToBuffer(new string[3] { Computer, FullKeyPath, "Key Not Found" });
                }
            }
        }

        void QueryCommands(string Computer, int Index)
        {
            //Start info (hidden from view, redirected everything)
            System.Diagnostics.ProcessStartInfo consoleInfo = new System.Diagnostics.ProcessStartInfo("cmd.exe");
            consoleInfo.RedirectStandardInput = true;
            consoleInfo.RedirectStandardOutput = true;
            consoleInfo.RedirectStandardError = true;
            consoleInfo.UseShellExecute = false;
            consoleInfo.CreateNoWindow = true;
            consoleInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            //Start the console instance using the previously set startinfo
            System.Diagnostics.Process console = System.Diagnostics.Process.Start(consoleInfo);


            Thread.Sleep(100);
            while (console.StandardOutput.Peek() != -1)
            {
                console.StandardOutput.Read();
                //console.StandardOutput.ReadLine();
            }
            //Turn off echo to clean up some mess
            if (echoOffBox.Checked)
            {
                console.StandardInput.WriteLine("@echo off");
            }
            //Set %machine% to help user remote
            console.StandardInput.WriteLine("set machine=" + Computer);

            string Output = "";
            string Error = "";

            #region Write commands sequentially
            if (CmdLine1.Text != "<Type a command, ignored otherwise>" && CmdLine1.Text != "")
            {
                console.StandardInput.WriteLine(CmdLine1.Text);
            }
            if (CmdLine2.Text != "<Type a command, ignored otherwise>" && CmdLine2.Text != "")
            {
                console.StandardInput.WriteLine(CmdLine2.Text);
            }
            if (CmdLine3.Text != "<Type a command, ignored otherwise>" && CmdLine3.Text != "")
            {
                console.StandardInput.WriteLine(CmdLine3.Text);
            }
            if (CmdLine4.Text != "<Type a command, ignored otherwise>" && CmdLine4.Text != "")
            {
                console.StandardInput.WriteLine(CmdLine4.Text);
            }
            if (CmdLine5.Text != "<Type a command, ignored otherwise>" && CmdLine5.Text != "")
            {
                console.StandardInput.WriteLine(CmdLine5.Text);
            }
            #endregion

            console.StandardInput.WriteLine("exit");
            currentComputerText(Computer + ": Waiting for command to finish", Index);
            console.WaitForExit(120000);

            if (console.HasExited)
            {
                Output = console.StandardOutput.ReadToEnd().Trim();
                Error = console.StandardError.ReadToEnd().Trim();

                //MachineInputOutputError
                AddToBuffer(new string[3] { Computer, Output, Error });
            }
            else
            {
                AddToBuffer(new string[3] { Computer, "Failed to close properly", "Failed to close properly" });
            }

            console.Close();
            console.Dispose();
        }

        /// <summary>
        /// Initializes writing/reading buffers, and calls SetUpThreads, then, writes entries into a log.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void BWMain_DoWork(object sender, DoWorkEventArgs e)
        {
            DateTime StartTime = DateTime.Now;
            try
            {
                ClearBuffer();
                SetUpThreads();

                IDataSaver IDS;
                string[] pathsplit = outputTB.Text.ToLower().Split(new string[1] { "." }, StringSplitOptions.RemoveEmptyEntries);
                string ext = pathsplit[pathsplit.Length - 1];
                if (ext == "xml")
                {
                    IDS = new XMLSaver();
                }
                else if (ext == "csv")
                {
                    IDS = new CSVSaver();
                }
                else
                {
                    IDS = new TabDelimitedSaver();
                }
                if (QueryType == queryType.Registry)
                {
                    if (outputRB.Checked == true)
                    {
                        IDS.Init(outputTB.Text, new string[3] { "Machine", "Searching for", "Value" });
                        //AddToBuffer("Machine" + "\t" + "Searching for" + "\t" + "Value");
                    }
                    else if (existsRB.Checked == true)
                    {
                        IDS.Init(outputTB.Text, new string[3] { "Machine", "Searching for", "Key Exists" });
                        //AddToBuffer("Machine" + "\t" + "Searching for" + "\t" + "Key Exists");
                    }
                    else if (valueRB.Checked == true)
                    {
                        IDS.Init(outputTB.Text, new string[3] { "Machine", "Searching for", "Value=" + valueTB.Text });
                        //AddToBuffer("Machine" + "\t" + "Searching for" + "\t" + "Value=" + valueTB.Text);
                    }
                }
                else if (QueryType == queryType.Program)
                {
                    if (MultipleRB.Checked == false)
                    {
                        //AddToBuffer("Machine" + "\t" + "Searching for" + "\t" + "Value");
                        IDS.Init(outputTB.Text, new string[3] { "Machine", "Searching for", "Value" });
                    }
                    else if (ProcessRB.Checked == true)
                    {
                        if (SingleRB.Checked == true)
                        {
                            IDS.Init(outputTB.Text, new string[3] { "Machine", "Process to Find", "Found" });
                        }
                        else if (MultipleRB.Checked == true)
                        {
                            IDS.Init(outputTB.Text, new string[3] { "Machine", "Processes", "" });
                        }
                    }
                    else if (ServicesRB.Checked == true)
                    {
                        if (SingleRB.Checked == true)
                        {
                            IDS.Init(outputTB.Text, new string[3] { "Machine", "Service to Find", "Status" });
                        }
                        else if (MultipleRB.Checked == true)
                        {
                            IDS.Init(outputTB.Text, new string[4] { "Machine", "Service Display Names", "Service System Names", "Status" });
                        }
                    }
                }
                else if (QueryType == queryType.Commands)
                {
                    IDS.Init(outputTB.Text, new string[3] { "Machine", "Output", "Error" });
                }//TODO: For any new query types, add another else if and init IDS
                //bool hasWritten = false;
                //using (StreamWriter SW = new StreamWriter(outputTB.Text, false))
                //{
                Thread.Sleep(2000);
                while (ToWriteBuffer.Count > 0 || WorkerIndex > 0 )//|| hasWritten == false
                {
                    string[] ToWrite = RetrieveFromBuffer();
                    if (ToWrite != null)
                    {
                        //SW.WriteLine(ToWrite);
                        //
                        //string[] TWArray = ToWrite.Split(new string[1] { "\r\n" }, StringSplitOptions.None);
                        //foreach (string st in TWArray)
                        //{
                        //    IDS.Write(st.Split(new string[1] { "\t" }, StringSplitOptions.None));
                        //}

                        IDS.Write(ToWrite);

                        //hasWritten = true;
                    }
                    else
                    {
                        Thread.Sleep(700);
                    }
                    SetInfoLabel((DateTime.Now - StartTime).ToString("hh\\:mm\\:ss"));
                }
                if (stopWorkers == true)
                {
                    //SW.WriteLine("Worker Cancelled"+"\t" + "Worker Cancelled" + "\t" + "Worker Cancelled");
                    IDS.Write(new string[3] { "Worker Cancelled", "Worker Cancelled", "Worker Cancelled" });
                }
                //}
                IDS.Finish();
            }
            catch (IOException)
            {
                AddToBuffer(null);//Lock Buffer
                SetWorkingStatus(false);
                MessageBox.Show("Either the input file, or the output file is currently in use.");
                Enable();
            }
            SetWorkingStatus(false);
            Enable();
            currentComputerText("Finished!", 0);
            int pos = 1;
            while (pos != computerList.Items.Count)
            {
                currentComputerText("", pos);
                pos++;
            }
            SetInfoLabel((DateTime.Now - StartTime).ToString("hh\\:mm\\:ss"));
        }

        /// <summary>
        /// Reads the computers into a buffer for use in other threads.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void BWReadComputers_DoWork(object sender, DoWorkEventArgs e)
        {
            ClearComputerBuffer();
            if (singleQuery.Checked == true)
            {
                EditMaxProgress(1);
                AddToComputerBuffer(pcName.Text.Trim());
                FinishedReads = true;
            }
            else if (multipleQueries.Checked == true)
            {
                try
                {
                    using (StreamReader SR = new StreamReader(inputTB.Text))
                    {
                        int max = 0;
                        while (SR.EndOfStream == false)
                        {
                            SR.ReadLine();
                            max++;
                        }
                        SR.BaseStream.Seek(0, SeekOrigin.Begin);
                        EditMaxProgress(max);
                        while (SR.EndOfStream == false && stopWorkers == false)
                        {
                            if (ComputerBuffer.Count < 20)
                            {
                                AddToComputerBuffer(SR.ReadLine().Trim());
                            }
                            else
                            {
                                Thread.Sleep(500);
                            }
                        }
                    }
                    FinishedReads = true;
                }
                catch (IOException)
                {
                    AddToBuffer(null);//LockBuffer
                    SetWorkingStatus(false);
                    MessageBox.Show("Either the input file, or the output file is currently in use.");
                    Enable();
                }
            }
        }
        #endregion

        #region Cross-threaded function used with background threads
        #region WorkerIndex funcitons
        public void ReleiveIndex()
        {
            WorkerIndex -= 1;
        }

        public int ClaimIndex()
        {
            int ToReturn = WorkerIndex;
            WorkerIndex++;
            return ToReturn;
        }
        #endregion

        #region WriteBufferControl
        
        public void AddToBuffer(string[] Entry)
        {
            if (Entry == null)
            {
                LockToWriteBuffer = true;
            }
            else if (LockToWriteBuffer == false)
            {
                lock (ToWriteBuffer)
                {
                    ToWriteBuffer.Add(Entry);
                }
            }
        }

        public string[] RetrieveFromBuffer()
        {
            if (ToWriteBuffer.Count > 0)
            {
                string[] toReturn;
                lock (ToWriteBuffer)
                {
                    toReturn = ToWriteBuffer[0];
                    ToWriteBuffer.RemoveAt(0);
                }
                return toReturn;
            }
            else
            {
                return null;
            }
        }

        public void ClearBuffer()
        {
            lock (ToWriteBuffer)
            {
                ToWriteBuffer = new List<string[]>();
                LockToWriteBuffer = false;
            }
        }
        #endregion

        #region ComputerBufferControl
        public void AddToComputerBuffer(string Line)
        {
            if (Line == "LockBuffer")
            {
                LockComputerBuffer = true;
            }
            else if (LockComputerBuffer == false)
            {
                lock (ComputerBuffer)//Prevent race issues
                {
                    ComputerBuffer.Add(Line);
                }
            }
        }
        public string RetrieveFromComputerBuffer()
        {
            try
            {
                if (ComputerBuffer.Count > 0)
                {
                    string toReturn;
                    lock (ComputerBuffer)//Prevent race issues
                    {
                        toReturn = ComputerBuffer[0];
                        ComputerBuffer.RemoveAt(0);
                    }
                    return toReturn;
                }
                else
                {
                    return "N/A";
                }
            }
            catch (Exception ex)
            {
                return "N/A";
            }
        }

        public void ClearComputerBuffer()
        {
            lock (ComputerBuffer)
            {
                ComputerBuffer = new List<string>();
                LockComputerBuffer = false;
            }
        }
        #endregion

        #region SetInfoLabel
        public void SetInfoLabel(string Text)
        {
            if (this.InvokeRequired == true)
            {
                DeleS D = new DeleS(SetInfoLabel);
                this.Invoke(D, new object[1] { Text });
            }
            else
            {
                infoLabel.Text = Text;
            }
        }
        #endregion

        #region progress bar codes
        public void IncrementProgress()
        {
            if (this.InvokeRequired == true)
            {
                Dele D = new Dele(IncrementProgress);
                this.Invoke(D);
            }
            else
            {
                if (progressBar.Value != progressBar.Maximum)
                {
                    progressBar.Value += 1;
                }
            }
        }
        delegate void DeleI(int interger);
        public void EditMaxProgress(int NewMax)
        {
            if (this.InvokeRequired == true)
            {
                DeleI D = new DeleI(EditMaxProgress);
                this.Invoke(D, new object[1] { NewMax });
            }
            else
            {
                progressBar.Minimum = 0;
                progressBar.Value = 0;
                progressBar.Maximum = NewMax;
            }
        }
        #endregion

        #region Disable/Enable
        public void Disable()
        {
            if (this.InvokeRequired == true)
            {
                Dele D = new Dele(Disable);
                this.Invoke(D);
            }
            else
            {
                foreach (Control C in this.Controls)
                {
                    if (C != splitContainer1)//To allow the cancel button to remain active
                    {
                        C.Enabled = false;
                    }
                }

                foreach (Control C in this.splitContainer1.Panel1.Controls)
                {
                    C.Enabled = false;
                }

                foreach (Control C in this.splitContainer1.Panel2.Controls)
                {
                    if (C != infoLabel)
                    {
                        C.Enabled = false;
                    }
                }

                foreach (Control C in tabPage1.Controls)
                {
                    C.Enabled = false;
                }
                foreach (Control C in tabPage2.Controls)
                {
                    C.Enabled = false;
                }
                foreach (Control C in tabPage3.Controls)
                {
                    C.Enabled = false;
                }
                cancelButton.Enabled = true;//To allow cancel
            }
        }
        public void Enable()
        {
            if (this.InvokeRequired == true)
            {
                Dele D = new Dele(Enable);
                this.Invoke(D);
            }
            else
            {
                foreach (Control C in this.Controls)
                {
                    C.Enabled = true;
                }
                foreach (Control C in this.splitContainer1.Panel1.Controls)
                {
                    C.Enabled = true;
                }

                foreach (Control C in this.splitContainer1.Panel2.Controls)
                {
                    C.Enabled = true;
                }
                foreach (Control C in tabPage1.Controls)
                {
                    C.Enabled = true;
                }
                foreach (Control C in tabPage2.Controls)
                {
                    C.Enabled = true;
                }
                foreach (Control C in tabPage3.Controls)
                {
                    C.Enabled = true;
                }
                cancelButton.Enabled = false;
                onePcQuery_CheckedChanged(this, new EventArgs());//Ensure that onepc is enabled/disabled correctly
                ServicesRB_CheckedChanged(this, new EventArgs());//Ensure that "and restart" is enabled/disabled correctly
            }
        }
        #endregion
        #endregion

        #region Resize Code
        private void splitContainer1_Panel2_Resize(object sender, EventArgs e)
        {
            exitProgramButton.Location = new Point(splitContainer1.Panel2.Width - exitProgramButton.Width, splitContainer1.Panel2.Height - exitProgramButton.Height);
            computerList.Width = splitContainer1.Panel2.Width;
            computerList.Height = splitContainer1.Panel2.Height - exitProgramButton.Height - cancelButton.Height;
            button1.Location = new Point(0, computerList.Height);
            cancelButton.Location = new Point(computerList.Width - cancelButton.Width, computerList.Height);
            progressBar.Location = new Point(button1.Width, computerList.Height + 1);
            progressBar.Width = cancelButton.Location.X - progressBar.Location.X;
            infoLabel.Location = new Point(progressBar.Location.X, progressBar.Location.Y + progressBar.Height + 1);
            computerList.Columns[0].Width = computerList.Width - 4;
        }

        private void splitContainer1_Panel1_Resize(object sender, EventArgs e)
        {
            tabControl.Height = splitContainer1.Panel1.Height - tabControl.Location.Y;
        }
        #endregion

        #region Load/Save Options
        public void SaveOptions(string Path)
        {
            try
            {
                if (File.Exists(Path))
                {
                    File.Delete(Path);
                }
                Stream FileStream = new FileStream(Path, FileMode.Create);
                XmlSerializer OptionSerializer = new XmlSerializer(typeof(Options));
                Options CurrentSettings = new Options()
                {
                    singleQueryChecked = singleQuery.Checked,
                    multipleQueriesChecked = multipleQueries.Checked,
                    pcNameText = pcName.Text,
                    inputTBText = inputTB.Text,
                    outputTBText = outputTB.Text,
                    simultaneousQValue = simultaneousQ.Value,
                    currentUserRBChecked = currentUserRB.Checked,
                    localMachineRBChecked = localMachineRB.Checked,
                    usersRBChecked = usersRB.Checked,
                    keyPathTBText = keyPathTB.Text,
                    existsRBChecked = existsRB.Checked,
                    valueRBChecked = valueRB.Checked,
                    outputRBChecked = outputRB.Checked,
                    valueTBText = valueTB.Text,
                    ProcessRBChecked = ProcessRB.Checked,
                    ServicesRBChecked = ServicesRB.Checked,
                    SingleRBChecked = SingleRB.Checked,
                    MultipleRBChecked = MultipleRB.Checked,
                    toSearchForText = toSearchFor.Text,
                    restartCheckBoxChecked = restartCheckBox.Checked,
                    CmdLine1Text = CmdLine1.Text,
                    CmdLine2Text = CmdLine2.Text,
                    CmdLine3Text = CmdLine3.Text,
                    CmdLine4Text = CmdLine4.Text,
                    CmdLine5Text = CmdLine5.Text,
                    echoOffBoxChecked = echoOffBox.Checked,
                    ServiceDisplayNameChecked = serviceDisplayNameRB.Checked,
                    ServiceSystemNameChecked = serviceSystemNameRB.Checked
                };
                OptionSerializer.Serialize(FileStream, CurrentSettings);
                FileStream.Close();
            }
            catch (Exception EXC)
            {
                MessageBox.Show("Save Failed:\r\n" + EXC.Message, "Load Failed");
            }
        }

        public void LoadOptions(string Path)
        {
            try
            {
                Stream File = new FileStream(Path, FileMode.Open);
                XmlSerializer OptionSerializer = new XmlSerializer(typeof(Options));
                Options LoadedOptions = (Options)OptionSerializer.Deserialize(File);
                File.Close();
                singleQuery.Checked = LoadedOptions.singleQueryChecked;
                multipleQueries.Checked = LoadedOptions.multipleQueriesChecked;
                pcName.Text = LoadedOptions.pcNameText;
                inputTB.Text = LoadedOptions.inputTBText;
                outputTB.Text = LoadedOptions.outputTBText;
                simultaneousQ.Value = LoadedOptions.simultaneousQValue;
                currentUserRB.Checked = LoadedOptions.currentUserRBChecked;
                localMachineRB.Checked = LoadedOptions.localMachineRBChecked;
                usersRB.Checked = LoadedOptions.usersRBChecked;
                keyPathTB.Text = LoadedOptions.keyPathTBText;
                existsRB.Checked = LoadedOptions.existsRBChecked;
                valueRB.Checked = LoadedOptions.valueRBChecked;
                outputRB.Checked = LoadedOptions.outputRBChecked;
                valueTB.Text = LoadedOptions.valueTBText;
                ProcessRB.Checked = LoadedOptions.ProcessRBChecked;
                ServicesRB.Checked = LoadedOptions.ServicesRBChecked;
                SingleRB.Checked = LoadedOptions.SingleRBChecked;
                MultipleRB.Checked = LoadedOptions.MultipleRBChecked;
                toSearchFor.Text = LoadedOptions.toSearchForText;
                restartCheckBox.Checked = LoadedOptions.restartCheckBoxChecked;
                CmdLine1.Text = LoadedOptions.CmdLine1Text;
                CmdLine2.Text = LoadedOptions.CmdLine2Text;
                CmdLine3.Text = LoadedOptions.CmdLine3Text;
                CmdLine4.Text = LoadedOptions.CmdLine4Text;
                CmdLine5.Text = LoadedOptions.CmdLine5Text;
                echoOffBox.Checked = LoadedOptions.echoOffBoxChecked;
                serviceDisplayNameRB.Checked = LoadedOptions.ServiceDisplayNameChecked;
                serviceSystemNameRB.Checked = LoadedOptions.ServiceSystemNameChecked;
                FilePath = Path;//Set the file path
            }
            catch (Exception EXC)
            {
                MessageBox.Show("Load Failed:\r\n" + EXC.Message, "Load Failed");
            }
        }
        #endregion

        #region FormClosing (Close Confirmation)
        private void RQT_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CurrentlyWorking&&MessageBox.Show("Are you sure? (If you are preforming any operations, they will be terminated. This could cause problems.)", "Are you sure?", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }
        #endregion
    }
}
