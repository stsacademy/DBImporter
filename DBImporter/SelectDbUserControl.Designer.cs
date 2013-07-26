namespace DBImporter
{
    partial class SelectDBUserControl
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
            this.gbSelectDB = new System.Windows.Forms.GroupBox();
            this.rbMySQL = new System.Windows.Forms.RadioButton();
            this.rbAccess = new System.Windows.Forms.RadioButton();
            this.gbSelectDB.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSelectDB
            // 
            this.gbSelectDB.Controls.Add(this.rbMySQL);
            this.gbSelectDB.Controls.Add(this.rbAccess);
            this.gbSelectDB.Location = new System.Drawing.Point(12, 39);
            this.gbSelectDB.Name = "gbSelectDB";
            this.gbSelectDB.Size = new System.Drawing.Size(105, 119);
            this.gbSelectDB.TabIndex = 0;
            this.gbSelectDB.TabStop = false;
            this.gbSelectDB.Text = "SelectDB";
            // 
            // rbMySQL
            // 
            this.rbMySQL.AutoSize = true;
            this.rbMySQL.Location = new System.Drawing.Point(19, 70);
            this.rbMySQL.Name = "rbMySQL";
            this.rbMySQL.Size = new System.Drawing.Size(60, 17);
            this.rbMySQL.TabIndex = 1;
            this.rbMySQL.Text = "MySQL";
            this.rbMySQL.UseVisualStyleBackColor = true;
            // 
            // rbAccess
            // 
            this.rbAccess.AutoSize = true;
            this.rbAccess.Location = new System.Drawing.Point(19, 47);
            this.rbAccess.Name = "rbAccess";
            this.rbAccess.Size = new System.Drawing.Size(60, 17);
            this.rbAccess.TabIndex = 0;
            this.rbAccess.Text = "Access";
            this.rbAccess.UseVisualStyleBackColor = true;
            // 
            // SelectDBUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbSelectDB);
            this.Name = "SelectDBUserControl";
            this.Size = new System.Drawing.Size(124, 166);
            this.gbSelectDB.ResumeLayout(false);
            this.gbSelectDB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSelectDB;
        internal System.Windows.Forms.RadioButton rbMySQL;
        internal System.Windows.Forms.RadioButton rbAccess;
    }
}
