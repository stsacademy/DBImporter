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
using System.IO;

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
        
        IStorageEngine Engine;

        IReader reader;

        LogAnalyzer analyzer = new LogAnalyzer();

        STSDbWritter writter = new STSDbWritter(null,null, @"C:\", @"C:\", null);

        int index = 0;

        bool flag = true;

        Dictionary<string, List<FieldSaver>> selectedTables = new Dictionary<string, List<FieldSaver>>();

        public MainForm()
        {
            InitializeComponent();

            selectDBUserControl.rbLocal.Checked = true;

            btnBack.Enabled = false;

            btnNext.Enabled = false;

            userControls = new UserControl[] { selectDBUserControl, openDBUserControl, selectionUserControl, startUserControl};

            openDBUserControl.btnOpen.Click += btnOpen_Click;
            openDBUserControl.btnBrowse.Click += btnBrowse_Click;

            selectionUserControl.listBoxTableNames.SelectedValueChanged += listBoxTableNames_SelectedIndexChanged;
            selectionUserControl.checkedListBoxFields.ItemCheck += checkedListBoxFields_ItemCheck;
            selectionUserControl.checkedListBoxFields.SelectedIndexChanged += checkedListBoxFields_SelectedIndexChanged;

            startUserControl.btnStart.Click += btnStart_Click;

            selectionUserControl.btnSelect.Click += btnSelect_Click;          
            selectDBUserControl.rbAccess.CheckedChanged += rbAccess_CheckedChanged;
            selectDBUserControl.rbMySQL.CheckedChanged += rbMySQL_CheckedChanged;

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
                filePath = openFileDialog.FileName;
                openDBUserControl.txbFilePath.Text = filePath;

                if (selectDBUserControl.rbAccess.Checked == true)                                                    
                    reader = new AccessReader(@"Provider=Microsoft.ACE.Oledb.12.0;Data Source=" + filePath);
                
                else 
                {                                             
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

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                dbDir = folderBrowserDialog.SelectedPath;
                openDBUserControl.txbDbDir.Text = dbDir;

                if (openDBUserControl.txbFilePath.Text != "")
                    btnNext.Enabled = true;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Controls.Remove(userControls[index]);
            index--;
            Controls.Add(userControls[index]);

            btnNext.Enabled = true;
            btnBack.Enabled = false;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {           
            openDBUserControl.txtBxConnStr.Enabled = true;
            openDBUserControl.txtBxSTSConnStr.Enabled = true;
       
            if (selectDBUserControl.rbLocal.Checked == true)
            {
                openDBUserControl.txtBxSTSConnStr.Enabled = false;
                openDBUserControl.txtBxSTSConnStr.Text = "";

                openDBUserControl.lblSTSConnStr.Enabled = false;
                openDBUserControl.lblConnStr.Enabled = false;
            }
            else
            {
                openDBUserControl.txtBxSTSConnStr.Text = "localhost;7182";
                openDBUserControl.lblSTSConnStr.Enabled = true;
            }

            if (selectDBUserControl.rbAccess.Checked == true)
            {             
                openDBUserControl.txtBxConnStr.Text = "";
                openDBUserControl.txtBxConnStr.Enabled = false;
      
                openDBUserControl.lblConnStr.Enabled = false;
            }

            else
            {
                openDBUserControl.lblConnStr.Enabled = true;               
                openDBUserControl.txtBxConnStr.Text = "Server=localhost;Database=database;UID=root;Password=password;";

                if (selectDBUserControl.rbLocal.Checked == false)
                {
                    openDBUserControl.txtBxSTSConnStr.Text = "localhost;7182";
                    openDBUserControl.lblSTSConnStr.Enabled = true;
                    openDBUserControl.lblConnStr.Enabled = true;
                }
            }

            btnNext.Enabled = false;
            Controls.Remove(userControls[index]);
            index++;
            Controls.Add(userControls[index]);         
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

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (selectionUserControl.checkedListBoxFields.CheckedItems.Count != 0)
            {
                if (selectDBUserControl.rbLocal.Checked == true)
                {
                    Engine = STSdb.FromFile(Path.Combine(dbDir, "stsdb4.sys"), Path.Combine(dbDir, "stsdb4.dat"));
                }
                else
                {
                    if (selectDBUserControl.rbMySQL.Checked == true)
                    {
                        string[] server;
                        server = openDBUserControl.txtBxSTSConnStr.Text.Split(';');

                        Engine = STSdb.FromNetwork(server[0], Int32.Parse(server[1]));
                    }
                    else
                    {
                        string[] server;
                        server = openDBUserControl.txtBxSTSConnStr.Text.Split(';');

                        Engine = STSdb.FromNetwork(server[0], Int32.Parse(server[1]));
                    }
                }
            }

            else MessageBox.Show("Select fields to extract!");

            writter = new STSDbWritter(reader, Engine, filePath, dbDir, selectedTables);
            writter.Log += EventHandler;
            writter.Start();
        }       
         
        private void btnSelect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < selectionUserControl.checkedListBoxFields.Items.Count; i++)
            {
                selectionUserControl.checkedListBoxFields.SelectedItem = selectionUserControl.checkedListBoxFields.Items[i];
                selectionUserControl.checkedListBoxFields.SetItemChecked(i, true);
            }
        }

        private void checkedListBoxFields_SelectedIndexChanged(object sender, EventArgs e)
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

        private void rbMySQL_CheckedChanged(object sender, EventArgs e)
        {
            if (selectDBUserControl.rbMySQL.Checked == true)
                btnNext.Enabled = true;
        }

        private void rbAccess_CheckedChanged(object sender, EventArgs e)
        {
            if (selectDBUserControl.rbAccess.Checked == true)
                btnNext.Enabled = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            btnBack.Enabled = index > 0;

            if (index > 2)
                btnNext.Enabled = false;

            startUserControl.btnStart.Enabled = !analyzer.IsWorking;

            startUserControl.label2.Text = analyzer.TableCount.ToString();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }      

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (reader != null)
                reader.CloseConnection();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (reader != null)
                reader.CloseConnection();

            Application.Exit();
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

        private void EventHandler(STSDbWritter sender, string msg)
        {
            try { Invoke(new Action<string>(OnReportProgress), msg); }
            catch { }
        }  
    }
}
