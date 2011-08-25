namespace OnlineTester
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.dgComputers = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSvc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblMainStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSeperator1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDnsStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblPingStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSeperator2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSvcStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSeperator3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblWmiStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hostListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alternateCredentialsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customWMIReplacesLastColumnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGo = new System.Windows.Forms.ToolStripMenuItem();
            this.lblComputer = new System.Windows.Forms.Label();
            this.txtComputer = new System.Windows.Forms.TextBox();
            this.btnClearList = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.chkUser = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.chkOS = new System.Windows.Forms.CheckBox();
            this.chkSvc = new System.Windows.Forms.CheckBox();
            this.selectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgComputers)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgComputers
            // 
            this.dgComputers.AllowUserToAddRows = false;
            this.dgComputers.AllowUserToResizeColumns = false;
            this.dgComputers.AllowUserToResizeRows = false;
            this.dgComputers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgComputers.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgComputers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgComputers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colIP,
            this.colStatus,
            this.colSvc,
            this.colOS,
            this.colUser});
            this.dgComputers.Location = new System.Drawing.Point(12, 53);
            this.dgComputers.Name = "dgComputers";
            this.dgComputers.RowHeadersVisible = false;
            this.dgComputers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgComputers.Size = new System.Drawing.Size(688, 259);
            this.dgComputers.TabIndex = 0;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            // 
            // colIP
            // 
            this.colIP.HeaderText = "IP Address";
            this.colIP.Name = "colIP";
            this.colIP.Width = 90;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Width = 80;
            // 
            // colSvc
            // 
            this.colSvc.HeaderText = "Service";
            this.colSvc.Name = "colSvc";
            // 
            // colOS
            // 
            this.colOS.HeaderText = "Operating System";
            this.colOS.Name = "colOS";
            // 
            // colUser
            // 
            this.colUser.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colUser.HeaderText = "Logged In User";
            this.colUser.Name = "colUser";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMainStatus,
            this.lblSeperator1,
            this.lblDnsStatus,
            this.toolStripStatusLabel2,
            this.lblPingStatus,
            this.lblSeperator2,
            this.lblSvcStatus,
            this.lblSeperator3,
            this.lblWmiStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 315);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(712, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblMainStatus
            // 
            this.lblMainStatus.Name = "lblMainStatus";
            this.lblMainStatus.Size = new System.Drawing.Size(100, 17);
            this.lblMainStatus.Text = "Main Thread Ready";
            // 
            // lblSeperator1
            // 
            this.lblSeperator1.Name = "lblSeperator1";
            this.lblSeperator1.Size = new System.Drawing.Size(11, 17);
            this.lblSeperator1.Text = "|";
            // 
            // lblDnsStatus
            // 
            this.lblDnsStatus.Name = "lblDnsStatus";
            this.lblDnsStatus.Size = new System.Drawing.Size(98, 17);
            this.lblDnsStatus.Text = "DNS Thread Ready";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(11, 17);
            this.toolStripStatusLabel2.Text = "|";
            // 
            // lblPingStatus
            // 
            this.lblPingStatus.Name = "lblPingStatus";
            this.lblPingStatus.Size = new System.Drawing.Size(98, 17);
            this.lblPingStatus.Text = "Ping Thread Ready";
            // 
            // lblSeperator2
            // 
            this.lblSeperator2.Name = "lblSeperator2";
            this.lblSeperator2.Size = new System.Drawing.Size(11, 17);
            this.lblSeperator2.Text = "|";
            // 
            // lblSvcStatus
            // 
            this.lblSvcStatus.Name = "lblSvcStatus";
            this.lblSvcStatus.Size = new System.Drawing.Size(113, 17);
            this.lblSvcStatus.Text = "Service Thread Ready";
            // 
            // lblSeperator3
            // 
            this.lblSeperator3.Name = "lblSeperator3";
            this.lblSeperator3.Size = new System.Drawing.Size(11, 17);
            this.lblSeperator3.Text = "|";
            // 
            // lblWmiStatus
            // 
            this.lblWmiStatus.Name = "lblWmiStatus";
            this.lblWmiStatus.Size = new System.Drawing.Size(100, 17);
            this.lblWmiStatus.Text = "WMI Thread Ready";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.btnGo});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(712, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.importToolStripMenuItem.Text = "Import...";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectionToolStripMenuItem,
            this.hostListToolStripMenuItem,
            this.fullResultsToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exportToolStripMenuItem.Text = "Export...";
            // 
            // hostListToolStripMenuItem
            // 
            this.hostListToolStripMenuItem.Name = "hostListToolStripMenuItem";
            this.hostListToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.hostListToolStripMenuItem.Text = "Host List";
            this.hostListToolStripMenuItem.Click += new System.EventHandler(this.hostListToolStripMenuItem_Click);
            // 
            // fullResultsToolStripMenuItem
            // 
            this.fullResultsToolStripMenuItem.Name = "fullResultsToolStripMenuItem";
            this.fullResultsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.fullResultsToolStripMenuItem.Text = "Full Results";
            this.fullResultsToolStripMenuItem.Click += new System.EventHandler(this.fullResultsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alternateCredentialsToolStripMenuItem,
            this.changeServiceToolStripMenuItem,
            this.customWMIReplacesLastColumnToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // alternateCredentialsToolStripMenuItem
            // 
            this.alternateCredentialsToolStripMenuItem.Name = "alternateCredentialsToolStripMenuItem";
            this.alternateCredentialsToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.alternateCredentialsToolStripMenuItem.Text = "Alternate Credentials";
            this.alternateCredentialsToolStripMenuItem.Click += new System.EventHandler(this.alternateCredentialsToolStripMenuItem_Click);
            // 
            // changeServiceToolStripMenuItem
            // 
            this.changeServiceToolStripMenuItem.Name = "changeServiceToolStripMenuItem";
            this.changeServiceToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.changeServiceToolStripMenuItem.Text = "Change Service";
            this.changeServiceToolStripMenuItem.Click += new System.EventHandler(this.changeServiceToolStripMenuItem_Click);
            // 
            // customWMIReplacesLastColumnToolStripMenuItem
            // 
            this.customWMIReplacesLastColumnToolStripMenuItem.Name = "customWMIReplacesLastColumnToolStripMenuItem";
            this.customWMIReplacesLastColumnToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.customWMIReplacesLastColumnToolStripMenuItem.Text = "Change WMI Query (Replaces last column)";
            this.customWMIReplacesLastColumnToolStripMenuItem.Click += new System.EventHandler(this.customWMIReplacesLastColumnToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // btnGo
            // 
            this.btnGo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(67, 20);
            this.btnGo.Text = "Run Tests";
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // lblComputer
            // 
            this.lblComputer.AutoSize = true;
            this.lblComputer.Location = new System.Drawing.Point(12, 30);
            this.lblComputer.Name = "lblComputer";
            this.lblComputer.Size = new System.Drawing.Size(55, 13);
            this.lblComputer.TabIndex = 3;
            this.lblComputer.Text = "Computer:";
            // 
            // txtComputer
            // 
            this.txtComputer.Location = new System.Drawing.Point(73, 27);
            this.txtComputer.Name = "txtComputer";
            this.txtComputer.Size = new System.Drawing.Size(137, 20);
            this.txtComputer.TabIndex = 4;
            this.txtComputer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtComputer_KeyPress);
            // 
            // btnClearList
            // 
            this.btnClearList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearList.Location = new System.Drawing.Point(634, 27);
            this.btnClearList.Name = "btnClearList";
            this.btnClearList.Size = new System.Drawing.Size(66, 21);
            this.btnClearList.TabIndex = 5;
            this.btnClearList.Text = "Clear List";
            this.btnClearList.UseVisualStyleBackColor = true;
            this.btnClearList.Click += new System.EventHandler(this.btnClearList_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(216, 28);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(42, 19);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // chkUser
            // 
            this.chkUser.AutoSize = true;
            this.chkUser.Checked = true;
            this.chkUser.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUser.Location = new System.Drawing.Point(447, 29);
            this.chkUser.Name = "chkUser";
            this.chkUser.Size = new System.Drawing.Size(133, 17);
            this.chkUser.TabIndex = 9;
            this.chkUser.Text = "Check Logged In User";
            this.chkUser.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // chkOS
            // 
            this.chkOS.AutoSize = true;
            this.chkOS.Checked = true;
            this.chkOS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOS.Location = new System.Drawing.Point(366, 29);
            this.chkOS.Name = "chkOS";
            this.chkOS.Size = new System.Drawing.Size(75, 17);
            this.chkOS.TabIndex = 10;
            this.chkOS.Text = "Check OS";
            this.chkOS.UseVisualStyleBackColor = true;
            // 
            // chkSvc
            // 
            this.chkSvc.AutoSize = true;
            this.chkSvc.Checked = true;
            this.chkSvc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSvc.Location = new System.Drawing.Point(264, 29);
            this.chkSvc.Name = "chkSvc";
            this.chkSvc.Size = new System.Drawing.Size(96, 17);
            this.chkSvc.TabIndex = 11;
            this.chkSvc.Text = "Check Service";
            this.chkSvc.UseVisualStyleBackColor = true;
            // 
            // selectionToolStripMenuItem
            // 
            this.selectionToolStripMenuItem.Name = "selectionToolStripMenuItem";
            this.selectionToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.selectionToolStripMenuItem.Text = "Selected Rows";
            this.selectionToolStripMenuItem.Click += new System.EventHandler(this.selectionToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 337);
            this.Controls.Add(this.chkSvc);
            this.Controls.Add(this.chkOS);
            this.Controls.Add(this.chkUser);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnClearList);
            this.Controls.Add(this.txtComputer);
            this.Controls.Add(this.lblComputer);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.dgComputers);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Online Tester 4.2 Beta r6";
            ((System.ComponentModel.ISupportInitialize)(this.dgComputers)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgComputers;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel lblPingStatus;
        private System.Windows.Forms.Label lblComputer;
        private System.Windows.Forms.TextBox txtComputer;
        private System.Windows.Forms.Button btnClearList;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ToolStripStatusLabel lblSeperator1;
        private System.Windows.Forms.ToolStripStatusLabel lblDnsStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblSeperator2;
        private System.Windows.Forms.ToolStripStatusLabel lblWmiStatus;
        private System.Windows.Forms.ToolStripMenuItem btnGo;
        private System.Windows.Forms.CheckBox chkUser;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox chkOS;
        private System.Windows.Forms.ToolStripStatusLabel lblMainStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblSeperator3;
        private System.Windows.Forms.ToolStripMenuItem customWMIReplacesLastColumnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alternateCredentialsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hostListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullResultsToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSvc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOS;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUser;
        private System.Windows.Forms.CheckBox chkSvc;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel lblSvcStatus;
        private System.Windows.Forms.ToolStripMenuItem changeServiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectionToolStripMenuItem;
    }
}

