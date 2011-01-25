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
    public partial class WMIOptions : Form
    {
        public string colName
        {
            get { return txtColName.Text; }
            set { txtColName.Text = value; }
        }
        public string wPath
        {
            get { return txtNamespace.Text; }
            set { txtNamespace.Text = value; }
        }
        public string wQuery
        {
            get { return txtQuery.Text; }
            set { txtQuery.Text = value; }
        }

        public WMIOptions()
        {
            InitializeComponent();
        }

        private void WMIOptions_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void bntCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
