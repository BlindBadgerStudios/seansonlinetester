using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Management;
using System.IO;
using System.ServiceProcess;

//Version History:
//V1: Commandline, hard-coded values
//V2: Commandline, arguments to customize some values
//V3: GUI: Threaded checks, hard-coded WMI values, enabled groups of hosts to be checked
//V4: Rebuild (due to loss of previous code).  Service checks (customizable), WMI checks (customizable)

//ToDo:
//- Add option to turn off dns double verification
//- Add support for IPv6
//- Add support for auto-updating to newest published version
namespace OnlineTester
{
    public partial class MainForm : Form
    {
        private Thread mainThread, pingThread, dnsThread, svcThread, wmiThread, assassinThread;
        private ConnectionOptions oConn = new ConnectionOptions();
        private bool altCred = false;
        private string userN = "";
        private string passW = "";
        private ManagementScope oMs;
        private ObjectQuery oQuery;
        private string customWMIPath = "\\root\\cimv2";
        private string customWMIQuery = "Select Username from Win32_ComputerSystem";
        private string svcName = "Contego_Spop";

        public MainForm()
        {
            InitializeComponent();
            chkUser.Text = "Check " + dgComputers.Columns[5].HeaderText;
        }

        #region Threadsafe Status Methods
        private delegate void enableButtonDelegate(bool tf);
        private void enableButton(bool tf)
        {
            if (InvokeRequired)
            {
                Invoke(new enableButtonDelegate(enableButton), new object[] { tf });
            }

            if (tf)
            {
                btnGo.Enabled = true;
                btnGo.Text = "Run Tests";
            }
            else
            {
                btnGo.Enabled = false;
                btnGo.Text = "Stopping Tests";
            }
        }

        private delegate bool checkWMIDelegate();
        private bool checkWMI()
        {
            if (InvokeRequired)
            {
                Invoke(new checkWMIDelegate(checkWMI));
            }
            return chkUser.Checked;
        }

        private delegate bool checkOSDelegate();
        private bool checkOS()
        {
            if (InvokeRequired)
            {
                Invoke(new checkOSDelegate(checkOS));
            }
            return chkOS.Checked;
        }

        private delegate bool checkSvcDelegate();
        private bool checkSvc()
        {
            if (InvokeRequired)
            {
                Invoke(new checkSvcDelegate(checkSvc));
            }
            return chkSvc.Checked;
        }

        private delegate void updateMainStatusDelegate(string newStatus);
        private void updateMainStatus(string newStatus)
        {
            if (InvokeRequired)
            {
                Invoke(new updateMainStatusDelegate(updateMainStatus), new object[] { newStatus });
            }
            lblMainStatus.Text = newStatus;
        }

        private delegate void updateDnsStatusDelegate(string newStatus);
        private void updateDnsStatus(string newStatus)
        {
            if (InvokeRequired)
            {
                Invoke(new updateDnsStatusDelegate(updateDnsStatus), new object[] { newStatus });
            }
            lblDnsStatus.Text = newStatus;
        }

        private delegate void updatePingStatusDelegate(string newStatus);
        private void updatePingStatus(string newStatus)
        {
            if (InvokeRequired) {
                Invoke(new updatePingStatusDelegate(updatePingStatus), new object[] { newStatus });
            }
            lblPingStatus.Text = newStatus;
        }

        private delegate void updateSvcStatusDelegate(string newStatus);
        private void updateSvcStatus(string newStatus)
        {
            if (InvokeRequired)
            {
                Invoke(new updateSvcStatusDelegate(updateSvcStatus), new object[] { newStatus });
            }
            lblSvcStatus.Text = newStatus;
        }

        private delegate void updateWmiStatusDelegate(string newStatus);
        private void updateWmiStatus(string newStatus)
        {
            if (InvokeRequired)
            {
                Invoke(new updateWmiStatusDelegate(updateWmiStatus), new object[] { newStatus });
            }
            lblWmiStatus.Text = newStatus;
        }

        private int dgCount
        {
            get { return dgComputers.RowCount; }
        }

        private delegate string getHostDelegate(int r);
        private string getHost(int r)
        {
            if (InvokeRequired)
            {
                Invoke(new getHostDelegate(getHost), new object[] { r });
            }
            if (dgComputers.Rows[r].Cells[0].Value.ToString().Length > 0)
            {
                return dgComputers.Rows[r].Cells[0].Value.ToString();
            }
            else
            {
                return dgComputers.Rows[r].Cells[1].Value.ToString();
            }
        }

        private delegate void dgInputDelegate(int y, int x, string myStr);
        private void dgInput(int y, int x, string myStr)
        {
            if (InvokeRequired)
            {
                Invoke(new dgInputDelegate(dgInput), new object[] { y, x, myStr });
            }
            dgComputers.Rows[y].Cells[x].Value = myStr;

            //color appropriately for errors
            if (myStr.ToLower().StartsWith("err") || myStr.ToLower().StartsWith("dead"))
            {
                dgComputers.Rows[y].Cells[x].Style.BackColor = Color.Red;
            }
            else if (myStr.StartsWith("Offline"))
            {
                dgComputers.Rows[y].Cells[x].Style.BackColor = Color.Yellow;
            }
            else if (myStr.StartsWith("Online"))
            {
                dgComputers.Rows[y].Cells[x].Style.BackColor = Color.Green;
            }
            else
            {
                dgComputers.Rows[y].Cells[x].Style.BackColor = dgComputers.Rows[y].Cells[x].Style.BackColor;
            }
        }

        private delegate string dgReadDelegate(int y, int x);
        private string dgRead(int y, int x)
        {
            if (InvokeRequired)
            {
                Invoke(new dgReadDelegate(dgRead), new object[] { y, x });
            }
            return dgComputers.Rows[y].Cells[x].Value.ToString();
        }

        private delegate bool threadCompleteDelegate();
        private bool threadComplete()
        {
            if (InvokeRequired)
            {
                Invoke(new threadCompleteDelegate(threadComplete));
            }

            if (lblDnsStatus.Text == "DNS Thread Ready" &&
                lblPingStatus.Text == "Ping Thread Ready" &&
                lblSvcStatus.Text == "Service Thread Ready" &&
                lblWmiStatus.Text == "WMI Thread Ready")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        //return whether any cell in this row is selected
        private bool isSelected(int i)
        {
            bool result = false;
            if (dgComputers.Rows[i].Selected)
            {
                result = true;
            }
            return result;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgAddRow(string addTxt)
        {
            if (addTxt.Length > 0)
            {
                IPAddress junkIP;
                string[] dgRow;
                //parse input as IP address (if valid) or computer name
                if (IPAddress.TryParse(addTxt, out junkIP))
                {
                    dgRow = new string[] { "", addTxt, "", "", "" };
                }
                else
                {
                    dgRow = new string[] { addTxt, "", "", "", "" };
                }
                dgComputers.Rows.Add(dgRow);
            }
        }

        void txtComputer_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                // Then Enter key was pressed
                dgAddRow(txtComputer.Text);
                txtComputer.Clear();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dgAddRow(txtComputer.Text);
        }

        private void btnClearList_Click(object sender, EventArgs e)
        {
            dgComputers.Rows.Clear();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            //stop threads if they are running
            if (btnGo.Text == "Stop Tests")
            {
                //kill threads
                assassinThread = new Thread(new ThreadStart(assassinThreadRun));
                assassinThread.Start();

                timer1.Stop();
            }
            else
            {
                //start new thread main thread
                btnGo.Text = "Stop Tests";
                //clear old data for a clean run
                lblMainStatus.Text = "Clearing Old Data";
                for (int i = 0; i < dgCount; i++)
                {
                    dgComputers.Rows[i].Cells[2].Value = "";
                    dgComputers.Rows[i].Cells[2].Style.BackColor = Color.White;
                    dgComputers.Rows[i].Cells[3].Value = "";
                    dgComputers.Rows[i].Cells[3].Style.BackColor = Color.White;
                    dgComputers.Rows[i].Cells[4].Value = "";
                    dgComputers.Rows[i].Cells[4].Style.BackColor = Color.White;
                    dgComputers.Rows[i].Cells[5].Value = "";
                    dgComputers.Rows[i].Cells[5].Style.BackColor = Color.White;
                }
                lblMainStatus.Text = "Starting Main Thread";
                mainThread = new Thread(new ThreadStart(mainThreadRun));
                mainThread.Start();
                timer1.Start();
                lblMainStatus.Text = "Running Tests";
            }
        }

        #region Threaded Operations
        //kill all others threads (Hit List: MainThread and it's spawn, dnsThread, pingThread, svcThread, wmiThread)
        private void assassinThreadRun()
        {
            enableButton(false);
            try
            {
                wmiThread.Abort();
                svcThread.Abort();
                pingThread.Abort();
                dnsThread.Abort();
                mainThread.Abort();
            }
            catch (Exception ex)
            {
            }

            while (wmiThread.ThreadState == ThreadState.Running || wmiThread.ThreadState == ThreadState.WaitSleepJoin
                || svcThread.ThreadState == ThreadState.Running || svcThread.ThreadState == ThreadState.WaitSleepJoin
                || pingThread.ThreadState == ThreadState.Running || pingThread.ThreadState == ThreadState.WaitSleepJoin
                || dnsThread.ThreadState == ThreadState.Running || dnsThread.ThreadState == ThreadState.WaitSleepJoin
                || mainThread.ThreadState == ThreadState.Running || mainThread.ThreadState == ThreadState.WaitSleepJoin)
            {
                //sit and spin until all threads are dead
                Thread.Sleep(1000);
            }

            updateDnsStatus("DNS Thread Ready");
            updatePingStatus("Ping Thread Ready");
            updateSvcStatus("Service Thread Ready");
            updateWmiStatus("WMI Thread Ready");
            updateMainStatus("Main Thread Ready");

            enableButton(true);
        }

        private void mainThreadRun()
        {
            //perform name resolution
            dnsThread = new Thread(new ThreadStart(dnsThreadRun));
            updateDnsStatus("DNS Thread Starting...");
            dnsThread.Start();

            //start the ping thread and update status to indicate that the ping thread has started
            pingThread = new Thread(new ThreadStart(pingThreadRun));
            updatePingStatus("Ping Thread Starting...");
            pingThread.Start();

            svcThread = new Thread(new ThreadStart(svcThreadRun));
            updateSvcStatus("Service Thread Starting...");
            svcThread.Start();

            wmiThread = new Thread(new ThreadStart(wmiThreadRun));
            updateWmiStatus("WMI Thread Starting...");
            wmiThread.Start();

            /*while (dnsThread.ThreadState == ThreadState.Running ||
                pingThread.ThreadState == ThreadState.Running ||
                svcThread.ThreadState == ThreadState.Running ||
                wmiThread.ThreadState == ThreadState.Running)*/
            //don't end this thread until all the other threads are finished
            while(!threadComplete())
            {
                Thread.Sleep(1000);
            }

            updateMainStatus("Main Thread Ready");
        }

        //attempt to resolve DNS and double check results (in case of bad DNS configuration)
        private void dnsThreadRun()
        {
            IPHostEntry iph1;
            IPAddress ipDump;
            bool isIP;
            //loop through list
            for (int i = 0; i < dgCount; i++)
            {
                updateDnsStatus("DNS: Resolving " + getHost(i));
                isIP = IPAddress.TryParse(getHost(i), out ipDump);
                
                //this is to allow for interruption
                Thread.Sleep(1);
                
                //perform resolution
                try
                {
                    iph1 = Dns.GetHostEntry(getHost(i));
                }
                catch (Exception ex)
                {
                    dgInput(i, 0, getHost(i));
                    dgInput(i, 1, getHost(i));
                    dgInput(i, 2, "Error: No DNS Entry");
                    dgInput(i, 3, "Error: No DNS Entry");
                    dgInput(i, 4, "Error: No DNS Entry");
                    dgInput(i, 5, ex.ToString().Substring(ex.ToString().IndexOf(':'), (ex.ToString().IndexOf("at") - ex.ToString().IndexOf(':'))));
                    continue;
                }

                //double check results
                if (isIP)
                {
                    if (!iph1.AddressList.Contains(IPAddress.Parse(getHost(i))))
                    {
                        //output error to row
                        dgInput(i, 2, "Error: Bad DNS Entry (IP)");
                        dgInput(i, 3, "Error: Bad DNS Entry (IP)");
                        dgInput(i, 4, "Error: Bad DNS Entry (IP)");

                        //loop through all addresses and list them in a string for use in the error
                        string addressList = "[";
                        for (int q=0; q<iph1.AddressList.Length; q++) {
                            addressList += iph1.AddressList[q].ToString() + ", ";
                        }
                        addressList += "]";

                        dgInput(i, 5, getHost(i) + " != " + addressList);

                    }
                    dgInput(i, 0, iph1.HostName);
                }
                else //!isIP
                {
                    try
                    {
                        //check for cases where FQDN does not return...meaning there are no '.' characters in the  name
                        string myhost = getHost(i).ToLower();
                        string resulthost = iph1.HostName.ToLower();
                        if (getHost(i).ToLower().Contains('.'))
                        {
                            myhost = getHost(i).ToLower().Substring(0, getHost(i).IndexOf('.'));
                        }

                        if (iph1.HostName.ToLower().Contains('.'))
                        {
                            resulthost = iph1.HostName.ToLower().Substring(0, iph1.HostName.IndexOf('.'));
                        }

                        //this is to allow for interruption
                        Thread.Sleep(1);

                        //check if the hostname doesn't match what we attempted to resolve from user-entry
                        if (!(myhost == resulthost))
                        {
                            //output error to row
                            dgInput(i, 2, "Error: Bad DNS Entry (Name)");
                            dgInput(i, 3, "Error: Bad DNS Entry (Name)");
                            dgInput(i, 4, "Error: Bad DNS Entry (Name)");
                            dgInput(i, 5, myhost + " != " + resulthost);

                        }

                        //loop through address list and look for an IPv4 address
                        dgInput(i, 1, getipv4(iph1));
                    }
                    catch (Exception ex)
                    {
                        dgInput(i, 5, ex.ToString().Substring(ex.ToString().IndexOf(':'), (ex.ToString().IndexOf("at") - ex.ToString().IndexOf(':'))));
                    }
                }

                //this is to allow for interruption
                Thread.Sleep(1);
            }
            updateDnsStatus("DNS Resolution Complete");
            Thread.Sleep(2000);
            updateDnsStatus("DNS Thread Ready");
        }

        //extract an IPv4 address from an IPHostEntry or spit out error text
        private string getipv4(IPHostEntry host)
        {
            string result = "Err: No IPv4 Found";

            for (int n = 0; n < host.AddressList.Length; n++)
            {
                //if it's a valid IPv4 address, output it
                if (host.AddressList[n].ToString().Contains('.'))
                {
                    result = host.AddressList[n].ToString();
                }
            }

            return result;
        }

        private void pingThreadRun()
        {
            Ping pinger = new Ping();

            //loop through list
            for (int i = 0; i < dgCount; i++)
            {
                //if resolution is not yet complete for this row, sleep until it is
                while (dgRead(i, 0).Length < 1 || dgRead(i, 1).Length < 1)
                {
                    updatePingStatus("Ping Thread Waiting...");
                    Thread.Sleep(1);
                }

                //skip row if error occured during dns resolution
                if (dgRead(i, 2).ToLower().StartsWith("error"))
                {
                    continue;
                }

                updatePingStatus("Pinging " + dgRead(i, 1) + "...");

                //ping the computer
                try
                {
                    if (pinger.Send(dgRead(i, 1)).Status == IPStatus.Success)
                    {
                        dgInput(i, 2, "Online");
                    }
                    else
                    {
                        dgInput(i, 2, "Offline");
                        dgInput(i, 3, "Offline");
                        dgInput(i, 4, "Offline");
                        dgInput(i, 5, "Offline");
                    }
                }
                catch (Exception ex)
                {
                    dgInput(i, 2, "Error: Ping");
                    dgInput(i, 3, "Error: Ping");
                    dgInput(i, 4, "Error: Ping");
                    dgInput(i, 5, ex.ToString().Substring(ex.ToString().IndexOf(':'), (ex.ToString().IndexOf("at") - ex.ToString().IndexOf(':'))));
                }
                //this is to allow for interruption
                Thread.Sleep(1);
            }
            updatePingStatus("Ping Test Complete");
            Thread.Sleep(2000);
            updatePingStatus("Ping Thread Ready");
        }

        private void svcThreadRun()
        {
            //loop through computer list
            for (int i = 0; i < dgCount; i++)
            {
                string target; 

                //wait for other threads to finish if we end up moving too fast
                while (dgRead(i, 2).Length < 1)
                {
                    updateSvcStatus("Service Thread Waiting...");
                    Thread.Sleep(1);
                }

                //skip over offline or error readings
                if (dgRead(i, 4).ToLower().StartsWith("error") || dgRead(i, 4).ToLower().StartsWith("offline"))
                {
                    continue;
                }

                if (checkSvc())
                {
                    target = dgRead(i, 0);
                    updateSvcStatus("Service Thread: Checking Service (" + target + ")");
                    dgInput(i, 3, checkService(target));
                    
                    //this is to allow for interruption
                    Thread.Sleep(1);
                }

                //this is to allow for interruption
                Thread.Sleep(1);
            }

            updateSvcStatus("Service Tests Complete");
            Thread.Sleep(2000);
            updateSvcStatus("Service Thread Ready");
        }

        private string checkService(string target)
        {
            ServiceController sc = new ServiceController(svcName, target);
            string returnme = "";
            //display service status
            try
            {
                returnme = sc.Status.ToString();
            }
            catch (Exception ex)
            {
                returnme = "Err: Not Installed";

                if (ex.ToString().Contains("Access is denied"))
                {
                    returnme = "Err: Permission";
                }
            }

            return returnme;
        }

        private void wmiThreadRun()
        {
            string target = "";

            if (altCred)
            {
                oConn.Username = userN;
                oConn.Password = passW;
            }
            else
            {
                oConn.Username = null;
                oConn.Password = null;
            }

            //loop through computer list
            for (int i = 0; i < dgCount; i++)
            {
                
                //wait for other threads to finish if we end up moving too fast
                while (dgRead(i, 2).Length < 1)
                {
                    updateWmiStatus("WMI Thread Waiting...");
                    Thread.Sleep(1);
                }

                //skip over offline or error readings
                if (dgRead(i, 3).ToLower().StartsWith("err") || dgRead(i, 3).ToLower().StartsWith("offline"))
                {
                    continue;
                }

                if (checkOS())
                {
                    target = dgRead(i, 0);
                    updateWmiStatus("WMI: Checking OS Version (" + target + ")");

                    //this is to allow for interruption
                    Thread.Sleep(1);

                    dgInput(i, 4, wmiCheckOS(target));
                }

                //this is to allow for interruption
                Thread.Sleep(1);

                if (checkWMI())
                {
                    updateWmiStatus("WMI: Checking " + dgComputers.Columns[4].HeaderText + " (" + target + ")");

                    //this is to allow for interruption
                    Thread.Sleep(1);

                    dgInput(i, 5, wmiCheckCustom(target));
                }

                //this is to allow for interruption
                Thread.Sleep(1);
            }

            updateWmiStatus("WMI Tests Complete");
            Thread.Sleep(2000);
            updateWmiStatus("WMI Thread Ready");
        }

        private string wmiCheckOS(string target)
        {
            string returnme = "";
            try
            {
                oMs = new ManagementScope("\\\\" + target + "\\root\\cimv2", oConn);
                oQuery = new ObjectQuery("Select Caption from Win32_OperatingSystem");
                ManagementObjectSearcher oSearcher = new ManagementObjectSearcher(oMs, oQuery);
                ManagementObjectCollection oCollection = oSearcher.Get();
                foreach (ManagementObject oReturn in oCollection)
                {
                    //this is to allow for interruption
                    Thread.Sleep(1);
                    returnme = oReturn["Caption"].ToString().Replace("Microsoft ", "").Replace("Windows", "Win");
                }
            }
            catch (Exception ex)
            {
                returnme = "Error: WMI";
            }
            return returnme;
        }

        private string wmiCheckCustom(string target)
        {
            string returnme = "";
            try
            {
                oMs = new ManagementScope("\\\\" + target + customWMIPath, oConn);
                oQuery = new ObjectQuery(customWMIQuery);
                ManagementObjectSearcher oSearcher = new ManagementObjectSearcher(oMs, oQuery);
                ManagementObjectCollection oCollection = oSearcher.Get();
                foreach (ManagementObject oReturn in oCollection)
                {
                    string[] result = customWMIQuery.Split(' ');
                    returnme = oReturn[result[1]].ToString();
                }
            }
            catch (Exception ex)
            {
                returnme = "Error: WMI";

                if (ex.ToString().ToLower().Contains("null"))
                {
                    returnme = "<Empty>";
                }
            }

            //this is to allow for interruption
            Thread.Sleep(1);

            return returnme;
        }
        #endregion

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            ofd.Title = "Select file to import";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //read in file
                    string file = ofd.FileName;
                    using (StreamReader r = new StreamReader(file))
                    {
                        string line;
                        while ((line = r.ReadLine()) != null)
                        {
                            //parse each line as it's own row
                            dgAddRow(line);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Unable to open file." + Environment.NewLine + Environment.NewLine + ex, "Error");
                }
            }
        }

        private void selectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Comma-seperated values (*.csv)|*.txt|All files (*.*)|*.*";
            sfd.Title = "Save results to file";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string file = sfd.FileName;
                    using (StreamWriter w = new StreamWriter(file))
                    {
                        string line = "";
                        for (int i = 0; i < dgCount; i++)
                        {
                            if (isSelected(i))
                            {
                                line = dgRead(i, 0);
                                for (int j = 1; j < 5; j++)
                                {
                                    line += "," + dgRead(i, j);
                                }
                                w.WriteLine(line);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Unable to save file." + Environment.NewLine + Environment.NewLine + ex, "Error");
                }
            }
        }

        private void hostListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Comma-seperated values (*.csv)|*.txt|All files (*.*)|*.*";
            sfd.Title = "Save results to file";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string file = sfd.FileName;
                    using (StreamWriter w = new StreamWriter(file))
                    {
                        string line = "";
                        for (int i = 0; i < dgCount; i++)
                        {
                            line = dgRead(i, 0);
                            w.WriteLine(line);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Unable to save file." + Environment.NewLine + Environment.NewLine + ex, "Error");
                }
            }
        }
        
        private void fullResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Comma-seperated values (*.csv)|*.txt|All files (*.*)|*.*";
            sfd.Title = "Save results to file";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string file = sfd.FileName;
                    using (StreamWriter w = new StreamWriter(file))
                    {
                        string line = "";
                        for (int i = 0; i < dgCount; i++)
                        {
                            line = dgRead(i, 0);
                            for (int j = 1; j < 5; j++)
                            {
                                line += "," + dgRead(i, j);
                            }
                            w.WriteLine(line);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Unable to save file." + Environment.NewLine + Environment.NewLine + ex, "Error");
                }
            }
        }
        
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Created by Sean Wells");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (lblMainStatus.Text == "Main Thread Ready")
            {
                btnGo.Text = "Run Tests";
                timer1.Stop();
            }
        }

        private void customWMIReplacesLastColumnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //new form containing fields for "Column Name", "WMI Path", "WMI Query"
            WMIOptions wmiopt = new WMIOptions();
            wmiopt.colName = dgComputers.Columns[4].HeaderText;
            wmiopt.wPath = customWMIPath;
            wmiopt.wQuery = customWMIQuery;

            if (wmiopt.ShowDialog() == DialogResult.OK)
            {
                //safe information into variables
                dgComputers.Columns[4].HeaderText = wmiopt.colName;
                chkUser.Text = "Check " + dgComputers.Columns[4].HeaderText;
                customWMIPath = wmiopt.wPath;
                customWMIQuery = wmiopt.wQuery;
            }
            else
            {
                //no changes
            }

        }

        private void alternateCredentialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Credentials cred = new Credentials();
            cred.altEnable = altCred;
            cred.uName = userN;
            cred.pWord = passW;

            if (cred.ShowDialog() == DialogResult.OK)
            {
                //save information to variables
                altCred = cred.altEnable;
                userN = cred.uName;
                passW = cred.pWord;
            }
            else
            {
                //no changes
            }
        }

        private void changeServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Service svc = new Service();
            svc.svcName = svcName;

            if (svc.ShowDialog() == DialogResult.OK)
            {
                //save information to variables
                svcName = svc.svcName;
            }
            else
            {
                //no changes
            }
        }

    }
}
