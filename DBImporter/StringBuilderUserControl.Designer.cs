namespace DBImporter
{
    partial class StringBuilderUserControl
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSet = new System.Windows.Forms.Button();
            this.txtBxServer = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBxPassword = new System.Windows.Forms.TextBox();
            this.txtBxuID = new System.Windows.Forms.TextBox();
            this.txtBxDatabase = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSet);
            this.groupBox2.Controls.Add(this.txtBxServer);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtBxPassword);
            this.groupBox2.Controls.Add(this.txtBxuID);
            this.groupBox2.Controls.Add(this.txtBxDatabase);
            this.groupBox2.Location = new System.Drawing.Point(12, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(322, 138);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Set connection string";
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(227, 26);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(75, 23);
            this.btnSet.TabIndex = 17;
            this.btnSet.Text = "set";
            this.btnSet.UseVisualStyleBackColor = true;
            // 
            // txtBxServer
            // 
            this.txtBxServer.Location = new System.Drawing.Point(88, 28);
            this.txtBxServer.Name = "txtBxServer";
            this.txtBxServer.Size = new System.Drawing.Size(121, 20);
            this.txtBxServer.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "uID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Password:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Database:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Server:";
            // 
            // txtBxPassword
            // 
            this.txtBxPassword.Location = new System.Drawing.Point(88, 104);
            this.txtBxPassword.Name = "txtBxPassword";
            this.txtBxPassword.PasswordChar = '*';
            this.txtBxPassword.Size = new System.Drawing.Size(121, 20);
            this.txtBxPassword.TabIndex = 11;
            // 
            // txtBxuID
            // 
            this.txtBxuID.Location = new System.Drawing.Point(88, 78);
            this.txtBxuID.Name = "txtBxuID";
            this.txtBxuID.Size = new System.Drawing.Size(121, 20);
            this.txtBxuID.TabIndex = 10;
            // 
            // txtBxDatabase
            // 
            this.txtBxDatabase.Location = new System.Drawing.Point(88, 54);
            this.txtBxDatabase.Name = "txtBxDatabase";
            this.txtBxDatabase.Size = new System.Drawing.Size(121, 20);
            this.txtBxDatabase.TabIndex = 9;
            // 
            // StringBuilderUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Name = "StringBuilderUserControl";
            this.Size = new System.Drawing.Size(343, 180);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Button btnSet;
        internal System.Windows.Forms.TextBox txtBxServer;
        internal System.Windows.Forms.TextBox txtBxPassword;
        internal System.Windows.Forms.TextBox txtBxuID;
        internal System.Windows.Forms.TextBox txtBxDatabase;
        private System.Windows.Forms.GroupBox groupBox2;

    }
}
