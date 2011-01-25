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
    public partial class Service : Form
    {
        public Service()
        {
            InitializeComponent();
        }

        public string svcName
        {
            get { return txtSvc.Text; }
            set { txtSvc.Text = value; }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not yet implemented");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
