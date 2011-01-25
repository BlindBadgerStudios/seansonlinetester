using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OnlineTester
{
    public partial class Credentials : Form
    {
        public bool altEnable
        {
            get { return !(chkCurrentCred.Checked); }
            set { chkCurrentCred.Checked = !(value); }
        }
        public string uName
        {
            get { return txtUser.Text; }
            set { txtUser.Text = value; }
        }
        public string pWord
        {
            get { return txtPass.Text; }
            set { txtPass.Text = value; }
        }

        public Credentials()
        {
            InitializeComponent();
        }

        private void chkCurrentCred_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCurrentCred.Checked)
            {
                //disable textboxes, grey out text
                txtUser.Enabled = false; 
                txtPass.Enabled = false;
            }
            else
            {
                //enable textboxes, ungrey text
                txtUser.Enabled = true;
                txtPass.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
