namespace OnlineTester
{
    partial class WMIOptions
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
            this.lblColName = new System.Windows.Forms.Label();
            this.lblNamespace = new System.Windows.Forms.Label();
            this.lblQuery = new System.Windows.Forms.Label();
            this.txtColName = new System.Windows.Forms.TextBox();
            this.txtNamespace = new System.Windows.Forms.TextBox();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.bntCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblColName
            // 
            this.lblColName.AutoSize = true;
            this.lblColName.Location = new System.Drawing.Point(12, 15);
            this.lblColName.Name = "lblColName";
            this.lblColName.Size = new System.Drawing.Size(76, 13);
            this.lblColName.TabIndex = 0;
            this.lblColName.Text = "Column Name:";
            // 
            // lblNamespace
            // 
            this.lblNamespace.AutoSize = true;
            this.lblNamespace.Location = new System.Drawing.Point(12, 41);
            this.lblNamespace.Name = "lblNamespace";
            this.lblNamespace.Size = new System.Drawing.Size(93, 13);
            this.lblNamespace.TabIndex = 1;
            this.lblNamespace.Text = "WMI Namespace:";
            // 
            // lblQuery
            // 
            this.lblQuery.AutoSize = true;
            this.lblQuery.Location = new System.Drawing.Point(12, 67);
            this.lblQuery.Name = "lblQuery";
            this.lblQuery.Size = new System.Drawing.Size(64, 13);
            this.lblQuery.TabIndex = 2;
            this.lblQuery.Text = "WMI Query:";
            // 
            // txtColName
            // 
            this.txtColName.Location = new System.Drawing.Point(111, 12);
            this.txtColName.Name = "txtColName";
            this.txtColName.Size = new System.Drawing.Size(263, 20);
            this.txtColName.TabIndex = 3;
            // 
            // txtNamespace
            // 
            this.txtNamespace.Location = new System.Drawing.Point(111, 38);
            this.txtNamespace.Name = "txtNamespace";
            this.txtNamespace.Size = new System.Drawing.Size(263, 20);
            this.txtNamespace.TabIndex = 4;
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(111, 64);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(263, 20);
            this.txtQuery.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(218, 90);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // bntCancel
            // 
            this.bntCancel.Location = new System.Drawing.Point(299, 90);
            this.bntCancel.Name = "bntCancel";
            this.bntCancel.Size = new System.Drawing.Size(75, 23);
            this.bntCancel.TabIndex = 7;
            this.bntCancel.Text = "Cancel";
            this.bntCancel.UseVisualStyleBackColor = true;
            this.bntCancel.Click += new System.EventHandler(this.bntCancel_Click);
            // 
            // WMIOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 123);
            this.Controls.Add(this.bntCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.txtNamespace);
            this.Controls.Add(this.txtColName);
            this.Controls.Add(this.lblQuery);
            this.Controls.Add(this.lblNamespace);
            this.Controls.Add(this.lblColName);
            this.Name = "WMIOptions";
            this.Text = "WMI Options";
            this.Load += new System.EventHandler(this.WMIOptions_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblColName;
        private System.Windows.Forms.Label lblNamespace;
        private System.Windows.Forms.Label lblQuery;
        private System.Windows.Forms.TextBox txtColName;
        private System.Windows.Forms.TextBox txtNamespace;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button bntCancel;
    }
}