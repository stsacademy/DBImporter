using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using STSdb4.Database;
using STSdb4;
using System.Threading;
using AccessDbImporter;

// MainForm
namespace DBImporter
{
    public partial class MainForm : Form
    {
        private string filePath { get; set; }

        private string dbDir { get; set; }

        UserControl[] userControls;

        StartUserControl startUserControl = new StartUserControl();
        OpenDBUserControl openDBUserControl = new OpenDBUserControl();
        SelectionUserControl selectionUserControl = new SelectionUserControl();
        SelectDBUserControl selectDBUserControl = new SelectDBUserControl();
        StringBuilderUserControl stringBuilderUserControl = new StringBuilderUserControl();

        IReader reader;

        LogAnalyzer analyzer = new LogAnalyzer();

        STSDbWritter writter = new STSDbWritter(null, @"C:\", @"C:\", null);

        int index = 0;

        bool flag = true;

        Dictionary<string, List<FieldSaver>> selectedTables = new Dictionary<string, List<FieldSaver>>();

        public MainForm()
        {
            InitializeComponent();

            btnBack.Enabled = false;
            btnNext.Enabled = false;

            userControls = new UserControl[] { selectDBUserControl, openDBUserControl, selectionUserControl, startUserControl, stringBuilderUserControl };

            openDBUserControl.btnOpen.Click += btnOpen_Click;
            openDBUserControl.btnBrowse.Click += btnBrowse_Click;

            selectionUserControl.listBoxTableNames.SelectedValueChanged += listBoxTableNames_SelectedIndexChanged;
            selectionUserControl.checkedListBoxFields.ItemCheck += checkedListBoxFields_ItemCheck;
            selectionUserControl.checkedListBoxFields.SelectedIndexChanged += checkedListBoxFields_SelectedIndexChanged;
            startUserControl.btnStart.Click += btnStart_Click;
            selectionUserControl.btnSelect.Click += btnSelect_Click;
            openDBUserControl.btnSett.Click += btnSet_Click;
            stringBuilderUserControl.btnSet.Click += btnSett_Click;
            selectDBUserControl.rbAccess.CheckedChanged += rbAccess_CheckedChanged;
            selectDBUserControl.rbMySQL.CheckedChanged += rbMySQL_CheckedChanged;

        }

        void rbMySQL_CheckedChanged(object sender, EventArgs e)
        {
            if (selectDBUserControl.rbMySQL.Checked == true)
                btnNext.Enabled = true;             
        }

        void rbAccess_CheckedChanged(object sender, EventArgs e)
        {
            if(selectDBUserControl.rbAccess.Checked==true)
                btnNext.Enabled = true;           
        }

        private void btnSett_Click(object sender, EventArgs e)
        {
            StringBuilder connStr = new StringBuilder();
            connStr.Append("Server=" + stringBuilderUserControl.txtBxServer.Text + ";" + "Database=" + stringBuilderUserControl.txtBxDatabase.Text +
                ";" + "UID=" + stringBuilderUserControl.txtBxuID.Text + ";" + "Password=" + stringBuilderUserControl.txtBxPassword.Text + ";");
            openDBUserControl.txtBxConnStr.Text = connStr.ToString();

            Controls.Remove(userControls[4]);
            index = 1;
            Controls.Add(userControls[index]);
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            Controls.Remove(userControls[1]);
            index = 4;
            Controls.Add(userControls[index]);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Controls.Add(userControls[index]);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (selectDBUserControl.rbAccess.Checked == true)
            {
                openFileDialog.InitialDirectory = "D:\\";
                openFileDialog.Filter = "Access(*.mdb;*.accdb)|*.mdb;*.accdb;*.";               
            }
            else
            {
                openFileDialog.InitialDirectory = "D:\\";
                openFileDialog.Filter = "MySql(*.mwb)|*.mwb;*.";               
            }
            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {                         
                if (selectDBUserControl.rbAccess.Checked == true)
                {
                    filePath = openFileDialog.FileName;
                    openDBUserControl.txbFilePath.Text = filePath;
                    reader = new AccessReader(@"Provider=Microsoft.ACE.Oledb.12.0;Data Source=" + filePath);
                }
                else 
                {
                    string database = stringBuilderUserControl.txtBxDatabase.Text;
                    openDBUserControl.txbFilePath.Text = database;
                    string connectionString = openDBUserControl.txtBxConnStr.Text;
                    reader = new MySqlDbImporter(connectionString);
                }      
                
                writter.Log += EventHandler;

                try
                {
                    reader.OpenConnection();

                    writter.OnLog("INF", "Service", "Connected to database.", reader.ConnectionString);

                    selectionUserControl.listBoxTableNames.Items.Clear();
                    selectionUserControl.checkedListBoxFields.Items.Clear();
                    selectedTables.Clear();

                    foreach (var TableName in reader.GetTableNames())
                    {
                        selectionUserControl.listBoxTableNames.Items.Add(TableName);
                    }

                    if (openDBUserControl.txbDbDir.Text != "")
                        btnNext.Enabled = true;
                }

                catch (Exception ex)
                {
                    writter.OnLog("ERR", "Service", "Can't connect to database.", ex.ToString());
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (index == 4)
            {
                Controls.Remove(userControls[4]);
                index = 1;
                Controls.Add(userControls[index]);
            }
            else
            {
                Controls.Remove(userControls[index]);
                index--;
                Controls.Add(userControls[index]);

                btnNext.Enabled = true;
                btnBack.Enabled = false;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            btnNext.Enabled = false;

            Controls.Remove(userControls[index]);
            index++;
            Controls.Add(userControls[index]);

            if (selectDBUserControl.rbAccess.Checked == true)
            {
                openDBUserControl.txtBxConnStr.Enabled = false;
                openDBUserControl.btnSett.Enabled = false;
                openDBUserControl.lblConnStr.Enabled = false;
            }
        }

        private void listBoxTableNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            if (selectionUserControl.listBoxTableNames.SelectedIndex != -1)
            {
                selectionUserControl.checkedListBoxFields.Items.Clear();

                foreach (var data in selectedTables)
                {
                    if (selectionUserControl.listBoxTableNames.SelectedItem.ToString() == data.Key)
                    {
                        foreach (var field in data.Value)
                        {
                            selectionUserControl.checkedListBoxFields.Items.Add(field.GetName, field.GetState);

                            if (field.GetState == true)
                                btnNext.Enabled = true;
                        }
                        flag = false;
                    }
                }

                if (flag == true)
                {
                    List<FieldSaver> columnList = new List<FieldSaver>();

                    foreach (var field in reader.GetFieldNames(selectionUserControl.listBoxTableNames.SelectedItem.ToString()))
                    {
                        selectionUserControl.checkedListBoxFields.Items.Add(field.ToString());
                        columnList.Add(new FieldSaver(field.ToString(), false));
                    }
                    selectedTables.Add(selectionUserControl.listBoxTableNames.SelectedItem.ToString(), columnList);
                }
                flag = true;
            }
            else MessageBox.Show("Select table.");
        }

        private void checkedListBoxFields_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            btnNext.Enabled = false;
            if (selectionUserControl.checkedListBoxFields.SelectedIndex == -1)
                return;

            var state = selectionUserControl.checkedListBoxFields.GetItemCheckState(
                selectionUserControl.checkedListBoxFields.SelectedIndex);

            foreach (var table in selectedTables)
            {
                foreach (var field in table.Value)
                {
                    if (selectionUserControl.checkedListBoxFields.SelectedItem == field.GetName)
                    {
                        field.GetState = !(state == CheckState.Checked);
                    }
                    if (field.GetState == true)
                        btnNext.Enabled = true;
                }
            }
        }

        private void OnReportProgress(string message)
        {
            Log(message);
        }

        private void Log(string message)
        {
            analyzer.Analyze(message);
            LogingTextBox.AppendText(message + "\r\n");
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (reader != null)
                reader.CloseConnection();

            Application.Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (reader != null)
                reader.CloseConnection();
        }

        private void timer_Tick(object sender, EventArgs e)
        {          
            btnBack.Enabled = index > 0;

            if (index > 2)
                btnNext.Enabled = false;

            startUserControl.btnStart.Enabled = !analyzer.IsWorking;

            startUserControl.label2.Text = analyzer.TableCount.ToString();
        }

        public void btnBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                dbDir = folderBrowserDialog.SelectedPath;
                openDBUserControl.txbDbDir.Text = dbDir;

                if (openDBUserControl.txbFilePath.Text != "")
                    btnNext.Enabled = true;
            }
        }

        public void btnSelect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < selectionUserControl.checkedListBoxFields.Items.Count; i++)
            {
                selectionUserControl.checkedListBoxFields.SelectedItem = selectionUserControl.checkedListBoxFields.Items[i];
                selectionUserControl.checkedListBoxFields.SetItemChecked(i, true);
            }
        }

        public void checkedListBoxFields_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var data in selectedTables)
            {
                foreach (var field in data.Value)
                {
                    if (field.GetState == true)
                        btnNext.Enabled = true;
                }
            }
        }

        public void btnStart_Click(object sender, EventArgs e)
        {
            if (selectionUserControl.checkedListBoxFields.CheckedItems.Count != 0)
            {
                STSDbWritter writter = new STSDbWritter(reader, filePath, dbDir, selectedTables);
                writter.Log += EventHandler;
                writter.Start();
            }
            else
                MessageBox.Show("Select fields to extract!");
        }

        public void EventHandler(STSDbWritter sender, string msg)
        {
            try { Invoke(new Action<string>(OnReportProgress), msg); }
            catch { }
        }
    }
}
