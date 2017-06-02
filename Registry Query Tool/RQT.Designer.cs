namespace Remote_Query_Tool
{
    partial class RQT
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RQT));
            this.button1 = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.computerList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.exitProgramButton = new System.Windows.Forms.Button();
            this.inputTB = new System.Windows.Forms.TextBox();
            this.singleQuery = new System.Windows.Forms.RadioButton();
            this.outputTB = new System.Windows.Forms.TextBox();
            this.multipleQueries = new System.Windows.Forms.RadioButton();
            this.inputLocationButton = new System.Windows.Forms.Button();
            this.pcName = new System.Windows.Forms.TextBox();
            this.outputLocationButton = new System.Windows.Forms.Button();
            this.simultaneousQ = new System.Windows.Forms.NumericUpDown();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.PathContructButton = new System.Windows.Forms.Button();
            this.keyPathTB = new System.Windows.Forms.TextBox();
            this.RB1Panel = new System.Windows.Forms.Panel();
            this.usersRB = new System.Windows.Forms.RadioButton();
            this.localMachineRB = new System.Windows.Forms.RadioButton();
            this.currentUserRB = new System.Windows.Forms.RadioButton();
            this.goButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.valueTB = new System.Windows.Forms.TextBox();
            this.outputRB = new System.Windows.Forms.RadioButton();
            this.valueRB = new System.Windows.Forms.RadioButton();
            this.existsRB = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.goButton2 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.serviceSelectHelpButton = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.serviceSystemNameRB = new System.Windows.Forms.RadioButton();
            this.serviceDisplayNameRB = new System.Windows.Forms.RadioButton();
            this.restartCheckBox = new System.Windows.Forms.CheckBox();
            this.toSearchFor = new System.Windows.Forms.TextBox();
            this.MultipleRB = new System.Windows.Forms.RadioButton();
            this.SingleRB = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ServicesRB = new System.Windows.Forms.RadioButton();
            this.ProcessRB = new System.Windows.Forms.RadioButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.echoOffBox = new System.Windows.Forms.CheckBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.CmdLine5 = new System.Windows.Forms.TextBox();
            this.CmdLine4 = new System.Windows.Forms.TextBox();
            this.CmdLine3 = new System.Windows.Forms.TextBox();
            this.CmdLine2 = new System.Windows.Forms.TextBox();
            this.CmdLine1 = new System.Windows.Forms.TextBox();
            this.goButton3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.infoLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.simultaneousQ)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.RB1Panel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 85);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 20);
            this.button1.TabIndex = 17;
            this.button1.Text = "Open Output File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Enabled = false;
            this.cancelButton.Location = new System.Drawing.Point(216, 85);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 20);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // computerList
            // 
            this.computerList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.computerList.GridLines = true;
            this.computerList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.computerList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.computerList.Location = new System.Drawing.Point(0, 0);
            this.computerList.MultiSelect = false;
            this.computerList.Name = "computerList";
            this.computerList.Size = new System.Drawing.Size(289, 79);
            this.computerList.TabIndex = 0;
            this.computerList.UseCompatibleStateImageBehavior = false;
            this.computerList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Computer Name";
            this.columnHeader1.Width = 211;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(101, 85);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(109, 18);
            this.progressBar.TabIndex = 18;
            // 
            // exitProgramButton
            // 
            this.exitProgramButton.Location = new System.Drawing.Point(216, 107);
            this.exitProgramButton.Name = "exitProgramButton";
            this.exitProgramButton.Size = new System.Drawing.Size(75, 25);
            this.exitProgramButton.TabIndex = 12;
            this.exitProgramButton.Text = "Exit";
            this.exitProgramButton.UseVisualStyleBackColor = true;
            this.exitProgramButton.Click += new System.EventHandler(this.exitProgramButton_Click);
            // 
            // inputTB
            // 
            this.inputTB.Location = new System.Drawing.Point(24, 59);
            this.inputTB.Name = "inputTB";
            this.inputTB.ReadOnly = true;
            this.inputTB.Size = new System.Drawing.Size(182, 20);
            this.inputTB.TabIndex = 0;
            this.inputTB.Text = "<Input File>";
            // 
            // singleQuery
            // 
            this.singleQuery.AutoSize = true;
            this.singleQuery.Location = new System.Drawing.Point(6, 4);
            this.singleQuery.Name = "singleQuery";
            this.singleQuery.Size = new System.Drawing.Size(173, 17);
            this.singleQuery.TabIndex = 4;
            this.singleQuery.Text = "Perform query on one computer";
            this.singleQuery.UseVisualStyleBackColor = true;
            // 
            // outputTB
            // 
            this.outputTB.Location = new System.Drawing.Point(3, 95);
            this.outputTB.Name = "outputTB";
            this.outputTB.ReadOnly = true;
            this.outputTB.Size = new System.Drawing.Size(203, 20);
            this.outputTB.TabIndex = 1;
            this.outputTB.Text = "<Output File>";
            // 
            // multipleQueries
            // 
            this.multipleQueries.AutoSize = true;
            this.multipleQueries.Checked = true;
            this.multipleQueries.Location = new System.Drawing.Point(6, 40);
            this.multipleQueries.Name = "multipleQueries";
            this.multipleQueries.Size = new System.Drawing.Size(193, 17);
            this.multipleQueries.TabIndex = 5;
            this.multipleQueries.TabStop = true;
            this.multipleQueries.Text = "Perform query on a list of computers";
            this.multipleQueries.UseVisualStyleBackColor = true;
            this.multipleQueries.CheckedChanged += new System.EventHandler(this.onePcQuery_CheckedChanged);
            // 
            // inputLocationButton
            // 
            this.inputLocationButton.Location = new System.Drawing.Point(210, 59);
            this.inputLocationButton.Name = "inputLocationButton";
            this.inputLocationButton.Size = new System.Drawing.Size(65, 20);
            this.inputLocationButton.TabIndex = 2;
            this.inputLocationButton.Text = "Browse";
            this.inputLocationButton.UseVisualStyleBackColor = true;
            this.inputLocationButton.Click += new System.EventHandler(this.inputLocationButton_Click);
            // 
            // pcName
            // 
            this.pcName.Location = new System.Drawing.Point(24, 21);
            this.pcName.Name = "pcName";
            this.pcName.ReadOnly = true;
            this.pcName.Size = new System.Drawing.Size(250, 20);
            this.pcName.TabIndex = 6;
            this.pcName.Text = "<Insert Computer Name or IP>";
            this.pcName.Enter += new System.EventHandler(this.pcName_Enter);
            this.pcName.Leave += new System.EventHandler(this.pcName_Leave);
            // 
            // outputLocationButton
            // 
            this.outputLocationButton.Location = new System.Drawing.Point(210, 95);
            this.outputLocationButton.Name = "outputLocationButton";
            this.outputLocationButton.Size = new System.Drawing.Size(65, 20);
            this.outputLocationButton.TabIndex = 3;
            this.outputLocationButton.Text = "Browse";
            this.outputLocationButton.UseVisualStyleBackColor = true;
            this.outputLocationButton.Click += new System.EventHandler(this.outputLocationButton_Click);
            // 
            // simultaneousQ
            // 
            this.simultaneousQ.Location = new System.Drawing.Point(116, 117);
            this.simultaneousQ.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.simultaneousQ.Name = "simultaneousQ";
            this.simultaneousQ.Size = new System.Drawing.Size(158, 20);
            this.simultaneousQ.TabIndex = 7;
            this.simultaneousQ.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Location = new System.Drawing.Point(2, 140);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(300, 220);
            this.tabControl.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.PathContructButton);
            this.tabPage1.Controls.Add(this.keyPathTB);
            this.tabPage1.Controls.Add(this.RB1Panel);
            this.tabPage1.Controls.Add(this.goButton);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(292, 194);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Registry Query";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // PathContructButton
            // 
            this.PathContructButton.Location = new System.Drawing.Point(214, 75);
            this.PathContructButton.Name = "PathContructButton";
            this.PathContructButton.Size = new System.Drawing.Size(75, 20);
            this.PathContructButton.TabIndex = 15;
            this.PathContructButton.Text = "Help Me";
            this.PathContructButton.UseVisualStyleBackColor = true;
            this.PathContructButton.Click += new System.EventHandler(this.PathContructButton_Click);
            // 
            // keyPathTB
            // 
            this.keyPathTB.Location = new System.Drawing.Point(3, 75);
            this.keyPathTB.Name = "keyPathTB";
            this.keyPathTB.Size = new System.Drawing.Size(206, 20);
            this.keyPathTB.TabIndex = 12;
            this.keyPathTB.Text = "<Insert a key path>";
            this.keyPathTB.Enter += new System.EventHandler(this.keyPathTB_Enter);
            this.keyPathTB.Leave += new System.EventHandler(this.keyPathTB_Leave);
            // 
            // RB1Panel
            // 
            this.RB1Panel.Controls.Add(this.usersRB);
            this.RB1Panel.Controls.Add(this.localMachineRB);
            this.RB1Panel.Controls.Add(this.currentUserRB);
            this.RB1Panel.Location = new System.Drawing.Point(3, 2);
            this.RB1Panel.Name = "RB1Panel";
            this.RB1Panel.Size = new System.Drawing.Size(287, 73);
            this.RB1Panel.TabIndex = 11;
            // 
            // usersRB
            // 
            this.usersRB.AutoSize = true;
            this.usersRB.Location = new System.Drawing.Point(3, 49);
            this.usersRB.Name = "usersRB";
            this.usersRB.Size = new System.Drawing.Size(97, 17);
            this.usersRB.TabIndex = 2;
            this.usersRB.Text = "HKEY_USERS";
            this.usersRB.UseVisualStyleBackColor = true;
            // 
            // localMachineRB
            // 
            this.localMachineRB.AutoSize = true;
            this.localMachineRB.Location = new System.Drawing.Point(3, 26);
            this.localMachineRB.Name = "localMachineRB";
            this.localMachineRB.Size = new System.Drawing.Size(149, 17);
            this.localMachineRB.TabIndex = 1;
            this.localMachineRB.Text = "HKEY_LOCAL_MACHINE";
            this.localMachineRB.UseVisualStyleBackColor = true;
            // 
            // currentUserRB
            // 
            this.currentUserRB.AutoSize = true;
            this.currentUserRB.Checked = true;
            this.currentUserRB.Location = new System.Drawing.Point(3, 3);
            this.currentUserRB.Name = "currentUserRB";
            this.currentUserRB.Size = new System.Drawing.Size(149, 17);
            this.currentUserRB.TabIndex = 0;
            this.currentUserRB.TabStop = true;
            this.currentUserRB.Text = "HKEY_CURRENT_USER";
            this.currentUserRB.UseVisualStyleBackColor = true;
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(254, 169);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(33, 20);
            this.goButton.TabIndex = 14;
            this.goButton.Text = "Go";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.valueTB);
            this.panel1.Controls.Add(this.outputRB);
            this.panel1.Controls.Add(this.valueRB);
            this.panel1.Controls.Add(this.existsRB);
            this.panel1.Location = new System.Drawing.Point(3, 96);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(287, 73);
            this.panel1.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(268, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "?";
            // 
            // valueTB
            // 
            this.valueTB.Location = new System.Drawing.Point(103, 25);
            this.valueTB.Name = "valueTB";
            this.valueTB.Size = new System.Drawing.Size(162, 20);
            this.valueTB.TabIndex = 3;
            // 
            // outputRB
            // 
            this.outputRB.AutoSize = true;
            this.outputRB.Location = new System.Drawing.Point(3, 49);
            this.outputRB.Name = "outputRB";
            this.outputRB.Size = new System.Drawing.Size(91, 17);
            this.outputRB.TabIndex = 2;
            this.outputRB.Text = "Output values";
            this.outputRB.UseVisualStyleBackColor = true;
            // 
            // valueRB
            // 
            this.valueRB.AutoSize = true;
            this.valueRB.Location = new System.Drawing.Point(3, 26);
            this.valueRB.Name = "valueRB";
            this.valueRB.Size = new System.Drawing.Size(103, 17);
            this.valueRB.TabIndex = 1;
            this.valueRB.Text = "Is value equal to";
            this.valueRB.UseVisualStyleBackColor = true;
            // 
            // existsRB
            // 
            this.existsRB.AutoSize = true;
            this.existsRB.Checked = true;
            this.existsRB.Location = new System.Drawing.Point(3, 3);
            this.existsRB.Name = "existsRB";
            this.existsRB.Size = new System.Drawing.Size(58, 17);
            this.existsRB.TabIndex = 0;
            this.existsRB.TabStop = true;
            this.existsRB.Text = "Exists?";
            this.existsRB.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.goButton2);
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(292, 194);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Processes/Services";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // goButton2
            // 
            this.goButton2.Location = new System.Drawing.Point(254, 169);
            this.goButton2.Name = "goButton2";
            this.goButton2.Size = new System.Drawing.Size(33, 20);
            this.goButton2.TabIndex = 17;
            this.goButton2.Text = "Go";
            this.goButton2.UseVisualStyleBackColor = true;
            this.goButton2.Click += new System.EventHandler(this.goButton2_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.serviceSelectHelpButton);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.restartCheckBox);
            this.panel3.Controls.Add(this.toSearchFor);
            this.panel3.Controls.Add(this.MultipleRB);
            this.panel3.Controls.Add(this.SingleRB);
            this.panel3.Location = new System.Drawing.Point(0, 47);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(290, 116);
            this.panel3.TabIndex = 1;
            // 
            // serviceSelectHelpButton
            // 
            this.serviceSelectHelpButton.Enabled = false;
            this.serviceSelectHelpButton.Location = new System.Drawing.Point(207, 72);
            this.serviceSelectHelpButton.Name = "serviceSelectHelpButton";
            this.serviceSelectHelpButton.Size = new System.Drawing.Size(75, 20);
            this.serviceSelectHelpButton.TabIndex = 16;
            this.serviceSelectHelpButton.Text = "Help Me";
            this.serviceSelectHelpButton.UseVisualStyleBackColor = true;
            this.serviceSelectHelpButton.Click += new System.EventHandler(this.serviceSelectHelpButton_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.serviceSystemNameRB);
            this.panel4.Controls.Add(this.serviceDisplayNameRB);
            this.panel4.Location = new System.Drawing.Point(63, 24);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(222, 45);
            this.panel4.TabIndex = 4;
            // 
            // serviceSystemNameRB
            // 
            this.serviceSystemNameRB.AutoSize = true;
            this.serviceSystemNameRB.Location = new System.Drawing.Point(3, 25);
            this.serviceSystemNameRB.Name = "serviceSystemNameRB";
            this.serviceSystemNameRB.Size = new System.Drawing.Size(90, 17);
            this.serviceSystemNameRB.TabIndex = 1;
            this.serviceSystemNameRB.Text = "System Name";
            this.serviceSystemNameRB.UseVisualStyleBackColor = true;
            // 
            // serviceDisplayNameRB
            // 
            this.serviceDisplayNameRB.AutoSize = true;
            this.serviceDisplayNameRB.Checked = true;
            this.serviceDisplayNameRB.Location = new System.Drawing.Point(3, 4);
            this.serviceDisplayNameRB.Name = "serviceDisplayNameRB";
            this.serviceDisplayNameRB.Size = new System.Drawing.Size(90, 17);
            this.serviceDisplayNameRB.TabIndex = 0;
            this.serviceDisplayNameRB.TabStop = true;
            this.serviceDisplayNameRB.Text = "Display Name";
            this.serviceDisplayNameRB.UseVisualStyleBackColor = true;
            // 
            // restartCheckBox
            // 
            this.restartCheckBox.AutoSize = true;
            this.restartCheckBox.Enabled = false;
            this.restartCheckBox.Location = new System.Drawing.Point(63, 75);
            this.restartCheckBox.Name = "restartCheckBox";
            this.restartCheckBox.Size = new System.Drawing.Size(79, 17);
            this.restartCheckBox.TabIndex = 3;
            this.restartCheckBox.Text = "and restart.";
            this.restartCheckBox.UseVisualStyleBackColor = true;
            // 
            // toSearchFor
            // 
            this.toSearchFor.Location = new System.Drawing.Point(63, 2);
            this.toSearchFor.Name = "toSearchFor";
            this.toSearchFor.Size = new System.Drawing.Size(223, 20);
            this.toSearchFor.TabIndex = 2;
            this.toSearchFor.Text = "<Name of process or service>";
            this.toSearchFor.Enter += new System.EventHandler(this.toSearchFor_Enter);
            this.toSearchFor.Leave += new System.EventHandler(this.toSearchFor_Leave);
            // 
            // MultipleRB
            // 
            this.MultipleRB.AutoSize = true;
            this.MultipleRB.Location = new System.Drawing.Point(2, 94);
            this.MultipleRB.Name = "MultipleRB";
            this.MultipleRB.Size = new System.Drawing.Size(54, 17);
            this.MultipleRB.TabIndex = 1;
            this.MultipleRB.Text = "List all";
            this.MultipleRB.UseVisualStyleBackColor = true;
            this.MultipleRB.CheckedChanged += new System.EventHandler(this.ServicesRB_CheckedChanged);
            // 
            // SingleRB
            // 
            this.SingleRB.AutoSize = true;
            this.SingleRB.Checked = true;
            this.SingleRB.Location = new System.Drawing.Point(3, 3);
            this.SingleRB.Name = "SingleRB";
            this.SingleRB.Size = new System.Drawing.Size(45, 17);
            this.SingleRB.TabIndex = 0;
            this.SingleRB.TabStop = true;
            this.SingleRB.Text = "Find";
            this.SingleRB.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.ServicesRB);
            this.panel2.Controls.Add(this.ProcessRB);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(290, 48);
            this.panel2.TabIndex = 0;
            // 
            // ServicesRB
            // 
            this.ServicesRB.AutoSize = true;
            this.ServicesRB.Location = new System.Drawing.Point(3, 26);
            this.ServicesRB.Name = "ServicesRB";
            this.ServicesRB.Size = new System.Drawing.Size(71, 17);
            this.ServicesRB.TabIndex = 1;
            this.ServicesRB.Text = "Service/s";
            this.ServicesRB.UseVisualStyleBackColor = true;
            this.ServicesRB.CheckedChanged += new System.EventHandler(this.ServicesRB_CheckedChanged);
            // 
            // ProcessRB
            // 
            this.ProcessRB.AutoSize = true;
            this.ProcessRB.Checked = true;
            this.ProcessRB.Location = new System.Drawing.Point(3, 3);
            this.ProcessRB.Name = "ProcessRB";
            this.ProcessRB.Size = new System.Drawing.Size(79, 17);
            this.ProcessRB.TabIndex = 0;
            this.ProcessRB.TabStop = true;
            this.ProcessRB.Text = "Process/es";
            this.ProcessRB.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.echoOffBox);
            this.tabPage3.Controls.Add(this.richTextBox1);
            this.tabPage3.Controls.Add(this.CmdLine5);
            this.tabPage3.Controls.Add(this.CmdLine4);
            this.tabPage3.Controls.Add(this.CmdLine3);
            this.tabPage3.Controls.Add(this.CmdLine2);
            this.tabPage3.Controls.Add(this.CmdLine1);
            this.tabPage3.Controls.Add(this.goButton3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(292, 194);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Commands";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // echoOffBox
            // 
            this.echoOffBox.AutoSize = true;
            this.echoOffBox.Location = new System.Drawing.Point(6, 117);
            this.echoOffBox.Name = "echoOffBox";
            this.echoOffBox.Size = new System.Drawing.Size(76, 17);
            this.echoOffBox.TabIndex = 25;
            this.echoOffBox.Text = "@echo off";
            this.echoOffBox.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.DetectUrls = false;
            this.richTextBox1.Location = new System.Drawing.Point(6, 136);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(246, 52);
            this.richTextBox1.TabIndex = 24;
            this.richTextBox1.Text = "Use %machine% to get the current machine name/ip. \nExample: shutdown -s -m \\\\%mac" +
    "hine%\nCould become: shutdown -s -m \\\\localhost";
            // 
            // CmdLine5
            // 
            this.CmdLine5.Location = new System.Drawing.Point(6, 94);
            this.CmdLine5.Name = "CmdLine5";
            this.CmdLine5.Size = new System.Drawing.Size(280, 20);
            this.CmdLine5.TabIndex = 23;
            this.CmdLine5.Text = "<Type a command, ignored otherwise>";
            this.CmdLine5.Enter += new System.EventHandler(this.CmdLine_Enter);
            this.CmdLine5.Leave += new System.EventHandler(this.CmdLine_Leave);
            // 
            // CmdLine4
            // 
            this.CmdLine4.Location = new System.Drawing.Point(6, 72);
            this.CmdLine4.Name = "CmdLine4";
            this.CmdLine4.Size = new System.Drawing.Size(280, 20);
            this.CmdLine4.TabIndex = 22;
            this.CmdLine4.Text = "<Type a command, ignored otherwise>";
            this.CmdLine4.Enter += new System.EventHandler(this.CmdLine_Enter);
            this.CmdLine4.Leave += new System.EventHandler(this.CmdLine_Leave);
            // 
            // CmdLine3
            // 
            this.CmdLine3.Location = new System.Drawing.Point(6, 50);
            this.CmdLine3.Name = "CmdLine3";
            this.CmdLine3.Size = new System.Drawing.Size(280, 20);
            this.CmdLine3.TabIndex = 21;
            this.CmdLine3.Text = "<Type a command, ignored otherwise>";
            this.CmdLine3.Enter += new System.EventHandler(this.CmdLine_Enter);
            this.CmdLine3.Leave += new System.EventHandler(this.CmdLine_Leave);
            // 
            // CmdLine2
            // 
            this.CmdLine2.Location = new System.Drawing.Point(6, 28);
            this.CmdLine2.Name = "CmdLine2";
            this.CmdLine2.Size = new System.Drawing.Size(280, 20);
            this.CmdLine2.TabIndex = 20;
            this.CmdLine2.Text = "<Type a command, ignored otherwise>";
            this.CmdLine2.Enter += new System.EventHandler(this.CmdLine_Enter);
            this.CmdLine2.Leave += new System.EventHandler(this.CmdLine_Leave);
            // 
            // CmdLine1
            // 
            this.CmdLine1.Location = new System.Drawing.Point(6, 6);
            this.CmdLine1.Name = "CmdLine1";
            this.CmdLine1.Size = new System.Drawing.Size(280, 20);
            this.CmdLine1.TabIndex = 19;
            this.CmdLine1.Text = "<Type a command, ignored otherwise>";
            this.CmdLine1.Enter += new System.EventHandler(this.CmdLine_Enter);
            this.CmdLine1.Leave += new System.EventHandler(this.CmdLine_Leave);
            // 
            // goButton3
            // 
            this.goButton3.Location = new System.Drawing.Point(253, 168);
            this.goButton3.Name = "goButton3";
            this.goButton3.Size = new System.Drawing.Size(33, 20);
            this.goButton3.TabIndex = 18;
            this.goButton3.Text = "Go";
            this.goButton3.UseVisualStyleBackColor = true;
            this.goButton3.Click += new System.EventHandler(this.goButton3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Simultaneous queries\r\n";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.tabControl);
            this.splitContainer1.Panel1.Controls.Add(this.simultaneousQ);
            this.splitContainer1.Panel1.Controls.Add(this.outputLocationButton);
            this.splitContainer1.Panel1.Controls.Add(this.pcName);
            this.splitContainer1.Panel1.Controls.Add(this.inputLocationButton);
            this.splitContainer1.Panel1.Controls.Add(this.multipleQueries);
            this.splitContainer1.Panel1.Controls.Add(this.outputTB);
            this.splitContainer1.Panel1.Controls.Add(this.singleQuery);
            this.splitContainer1.Panel1.Controls.Add(this.inputTB);
            this.splitContainer1.Panel1.Resize += new System.EventHandler(this.splitContainer1_Panel1_Resize);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.infoLabel);
            this.splitContainer1.Panel2.Controls.Add(this.exitProgramButton);
            this.splitContainer1.Panel2.Controls.Add(this.progressBar);
            this.splitContainer1.Panel2.Controls.Add(this.computerList);
            this.splitContainer1.Panel2.Controls.Add(this.cancelButton);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.Resize += new System.EventHandler(this.splitContainer1_Panel2_Resize);
            this.splitContainer1.Size = new System.Drawing.Size(627, 359);
            this.splitContainer1.SplitterDistance = 304;
            this.splitContainer1.TabIndex = 14;
            // 
            // infoLabel
            // 
            this.infoLabel.Location = new System.Drawing.Point(101, 106);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(109, 23);
            this.infoLabel.TabIndex = 19;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(627, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveSetupToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.loadFileToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveSetupToolStripMenuItem
            // 
            this.saveSetupToolStripMenuItem.Name = "saveSetupToolStripMenuItem";
            this.saveSetupToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.saveSetupToolStripMenuItem.Text = "Save Setup";
            this.saveSetupToolStripMenuItem.Click += new System.EventHandler(this.saveSetupToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.saveAsToolStripMenuItem.Text = "Save Setup As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // loadFileToolStripMenuItem
            // 
            this.loadFileToolStripMenuItem.Name = "loadFileToolStripMenuItem";
            this.loadFileToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.loadFileToolStripMenuItem.Text = "Load Setup";
            this.loadFileToolStripMenuItem.Click += new System.EventHandler(this.loadFileToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitProgramButton_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // RQT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 383);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(643, 421);
            this.Name = "RQT";
            this.Text = "Remote Query Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RQT_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.simultaneousQ)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.RB1Panel.ResumeLayout(false);
            this.RB1Panel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ListView computerList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button exitProgramButton;
        private System.Windows.Forms.TextBox inputTB;
        private System.Windows.Forms.RadioButton singleQuery;
        private System.Windows.Forms.TextBox outputTB;
        private System.Windows.Forms.RadioButton multipleQueries;
        private System.Windows.Forms.Button inputLocationButton;
        private System.Windows.Forms.TextBox pcName;
        private System.Windows.Forms.Button outputLocationButton;
        private System.Windows.Forms.NumericUpDown simultaneousQ;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button PathContructButton;
        private System.Windows.Forms.TextBox keyPathTB;
        private System.Windows.Forms.Panel RB1Panel;
        private System.Windows.Forms.RadioButton usersRB;
        private System.Windows.Forms.RadioButton localMachineRB;
        private System.Windows.Forms.RadioButton currentUserRB;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox valueTB;
        private System.Windows.Forms.RadioButton outputRB;
        private System.Windows.Forms.RadioButton valueRB;
        private System.Windows.Forms.RadioButton existsRB;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button goButton2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox toSearchFor;
        private System.Windows.Forms.RadioButton MultipleRB;
        private System.Windows.Forms.RadioButton SingleRB;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton ServicesRB;
        private System.Windows.Forms.RadioButton ProcessRB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.CheckBox restartCheckBox;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox CmdLine5;
        private System.Windows.Forms.TextBox CmdLine4;
        private System.Windows.Forms.TextBox CmdLine3;
        private System.Windows.Forms.TextBox CmdLine2;
        private System.Windows.Forms.TextBox CmdLine1;
        private System.Windows.Forms.Button goButton3;
        private System.Windows.Forms.CheckBox echoOffBox;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton serviceSystemNameRB;
        private System.Windows.Forms.RadioButton serviceDisplayNameRB;
        private System.Windows.Forms.Button serviceSelectHelpButton;
    }
}

