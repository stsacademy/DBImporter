namespace DBImporter
{
    partial class SelectionUserControl
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
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.listBoxTableNames = new System.Windows.Forms.ListBox();
            this.checkedListBoxFields = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxTableNames
            // 
            this.listBoxTableNames.FormattingEnabled = true;
            this.listBoxTableNames.Location = new System.Drawing.Point(6, 43);
            this.listBoxTableNames.Name = "listBoxTableNames";
            this.listBoxTableNames.Size = new System.Drawing.Size(166, 95);
            this.listBoxTableNames.TabIndex = 3;
            // 
            // checkedListBoxFields
            // 
            this.checkedListBoxFields.CheckOnClick = true;
            this.checkedListBoxFields.FormattingEnabled = true;
            this.checkedListBoxFields.Location = new System.Drawing.Point(196, 43);
            this.checkedListBoxFields.Name = "checkedListBoxFields";
            this.checkedListBoxFields.Size = new System.Drawing.Size(166, 94);
            this.checkedListBoxFields.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Tables:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(193, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Fields:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.listBoxTableNames);
            this.groupBox1.Controls.Add(this.checkedListBoxFields);
            this.groupBox1.Location = new System.Drawing.Point(12, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 148);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Step2: Select tables and fields to extract...";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(427, 73);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(88, 39);
            this.btnSelect.TabIndex = 29;
            this.btnSelect.Text = "Select all";
            this.btnSelect.UseVisualStyleBackColor = true;
            // 
            // SelectionUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.groupBox1);
            this.Name = "SelectionUserControl";
            this.Size = new System.Drawing.Size(581, 193);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        internal System.Windows.Forms.ListBox listBoxTableNames;
        internal System.Windows.Forms.CheckedListBox checkedListBoxFields;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Button btnSelect;
    }
}
