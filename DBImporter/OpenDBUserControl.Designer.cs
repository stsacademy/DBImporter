namespace DBImporter
{
    partial class OpenDBUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblSTSConnStr = new System.Windows.Forms.Label();
            this.txtBxSTSConnStr = new System.Windows.Forms.TextBox();
            this.lblConnStr = new System.Windows.Forms.Label();
            this.txtBxConnStr = new System.Windows.Forms.TextBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txbDbDir = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txbFilePath = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblSTSConnStr);
            this.groupBox1.Controls.Add(this.txtBxSTSConnStr);
            this.groupBox1.Controls.Add(this.lblConnStr);
            this.groupBox1.Controls.Add(this.txtBxConnStr);
            this.groupBox1.Controls.Add(this.btnOpen);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txbDbDir);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Controls.Add(this.txbFilePath);
            this.groupBox1.Location = new System.Drawing.Point(12, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(541, 156);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Step1: Select database,  file to import and directory for the new database...";
            // 
            // lblSTSConnStr
            // 
            this.lblSTSConnStr.AutoSize = true;
            this.lblSTSConnStr.Location = new System.Drawing.Point(11, 119);
            this.lblSTSConnStr.Name = "lblSTSConnStr";
            this.lblSTSConnStr.Size = new System.Drawing.Size(127, 13);
            this.lblSTSConnStr.TabIndex = 17;
            this.lblSTSConnStr.Text = "STSdb connection string:";
            // 
            // txtBxSTSConnStr
            // 
            this.txtBxSTSConnStr.Location = new System.Drawing.Point(143, 116);
            this.txtBxSTSConnStr.Name = "txtBxSTSConnStr";
            this.txtBxSTSConnStr.Size = new System.Drawing.Size(254, 20);
            this.txtBxSTSConnStr.TabIndex = 16;
            // 
            // lblConnStr
            // 
            this.lblConnStr.AutoSize = true;
            this.lblConnStr.Location = new System.Drawing.Point(11, 93);
            this.lblConnStr.Name = "lblConnStr";
            this.lblConnStr.Size = new System.Drawing.Size(129, 13);
            this.lblConnStr.TabIndex = 14;
            this.lblConnStr.Text = "MySQL connection string:";
            // 
            // txtBxConnStr
            // 
            this.txtBxConnStr.Location = new System.Drawing.Point(143, 90);
            this.txtBxConnStr.Name = "txtBxConnStr";
            this.txtBxConnStr.Size = new System.Drawing.Size(254, 20);
            this.txtBxConnStr.TabIndex = 13;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(433, 34);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select file:";
            // 
            // txbDbDir
            // 
            this.txbDbDir.Location = new System.Drawing.Point(143, 61);
            this.txbDbDir.Name = "txbDbDir";
            this.txbDbDir.ReadOnly = true;
            this.txbDbDir.Size = new System.Drawing.Size(254, 20);
            this.txbDbDir.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Select directory:";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(433, 61);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 6;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            // 
            // txbFilePath
            // 
            this.txbFilePath.Location = new System.Drawing.Point(143, 36);
            this.txbFilePath.Name = "txbFilePath";
            this.txbFilePath.ReadOnly = true;
            this.txbFilePath.Size = new System.Drawing.Size(254, 20);
            this.txbFilePath.TabIndex = 1;
            // 
            // OpenDBUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "OpenDBUserControl";
            this.Size = new System.Drawing.Size(556, 185);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txbDbDir;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Button btnBrowse;
        internal System.Windows.Forms.TextBox txbFilePath;
        internal System.Windows.Forms.TextBox txtBxConnStr;
        internal System.Windows.Forms.Label lblConnStr;
        internal System.Windows.Forms.Label lblSTSConnStr;
        internal System.Windows.Forms.TextBox txtBxSTSConnStr;

    }
}
