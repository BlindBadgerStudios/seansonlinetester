namespace OnlineTester
{
    partial class Service
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblSvc = new System.Windows.Forms.Label();
            this.txtSvc = new System.Windows.Forms.TextBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(138, 39);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "Save";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(219, 39);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblSvc
            // 
            this.lblSvc.AutoSize = true;
            this.lblSvc.Location = new System.Drawing.Point(12, 15);
            this.lblSvc.Name = "lblSvc";
            this.lblSvc.Size = new System.Drawing.Size(77, 13);
            this.lblSvc.TabIndex = 2;
            this.lblSvc.Text = "Service Name:";
            // 
            // txtSvc
            // 
            this.txtSvc.Location = new System.Drawing.Point(95, 12);
            this.txtSvc.Name = "txtSvc";
            this.txtSvc.Size = new System.Drawing.Size(162, 20);
            this.txtSvc.TabIndex = 3;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(263, 10);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(31, 23);
            this.btnHelp.TabIndex = 4;
            this.btnHelp.Text = "?";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // Service
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 75);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.txtSvc);
            this.Controls.Add(this.lblSvc);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "Service";
            this.Text = "Service Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblSvc;
        private System.Windows.Forms.TextBox txtSvc;
        private System.Windows.Forms.Button btnHelp;
    }
}