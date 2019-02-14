using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace CSVColumnStats
{
    public partial class MainWindow : Form
    {

        string appPath = Path.GetDirectoryName(Application.ExecutablePath);
        string filePath = null;
        CSVTabPage targetTab = null;
        Dictionary<string, string> dictRowDelimiters
            = new Dictionary<string, string>() {
                {"[CR][LF]","\r\n"},
                {"[CR]","\r"},
                {"[LF]","\n"},
            };
        Queue<string> bulkFileQueue = new Queue<string>();


        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            // File Drag Drop
            DragEnter += new DragEventHandler(Form1_DragEnter);
            DragDrop += new DragEventHandler(Form1_DragDrop);
            actionsToolStripMenuItem1.HideDropDown();

            // Set up checked settings
            CheckBoxHasHeaders.Checked = true;
            checkBoxIsTextQualified.Checked = true;
            tabContainer.MouseClick += tabContainer_MouseClick;
            scanForNewFiles();

            // Set up BGW
            bgwWorker_CSVFile.DoWork += processFile;
            bgwWorker_CSVFile.ProgressChanged += reportProgress;
            bgwWorker_CSVFile.RunWorkerCompleted += bgWorker_RunWorkerCompleted;

            // Set up BGW
            bgwWorker_BulkProcess.DoWork += processFile;
            bgwWorker_BulkProcess.ProgressChanged += reportProgress;
            bgwWorker_BulkProcess.RunWorkerCompleted += bgWorker_BulkRunWorkerCompleted;

        }

        void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Count() > 1)
            {
                var answer = MessageBox.Show(
                    "Would you like to bulk analyze these files using the current settings?"
                    , "Confirm Bulk Process"
                    , MessageBoxButtons.YesNo);
                if (answer == DialogResult.Yes)
                {
                    setupBulkProcess(files);
                }
            }
            else if (files.Count() == 1)
            {
                openFile(files[0]);
            }
                

        }

        private void scanForNewFiles()
        {
            foreach (var file in new DirectoryInfo(appPath).GetFiles("*.meta"))
            {
                AddMetaDataTab(file.Name, file.FullName);
            }
        }

        private void scanForSingleFile(string fileName)
        {
            foreach (var file in new DirectoryInfo(appPath).GetFiles("*.meta").Where(f => f.Name == fileName + ".meta"))
            {
                AddMetaDataTab(file.Name, file.FullName);
            }
        }

        private void AddMetaDataTab(string name, string path)
        {
            if (!tabContainer.Controls.ContainsKey(path))
            //Add New Tab
            {
                CSVTabPage newTab = new CSVTabPage(File.ReadAllText(path));
                newTab.Text = name;
                newTab.Name = path;
                RichTextBox newMetaData = new RichTextBox();
                newMetaData.Dock = DockStyle.Fill;
                newMetaData.Name = name + "MetaData";
                newMetaData.Text = newTab.rawFile;
                newMetaData.Font = new Font("Consolas", 8, FontStyle.Regular);

                newTab.Controls.Add(newMetaData);
                tabContainer.Controls.Add(newTab);
                newTab.Show();
            }
            else
            //Refresh
            {
                RemoveTab((CSVTabPage)tabContainer.Controls[path]);
                AddMetaDataTab(name, path);
            }
        }

        private void tabContainer_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right )
            {
                var type = sender.GetType();

                this.contextMenuStripTabs.Show(this, e.Location);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bgWorker_DoWorkAsync(bgwWorker_CSVFile);
        }

        private void bgWorker_DoWorkAsync(BackgroundWorker bgw)
        {
            //var progressIndicator = new Progress<MyTaskProgressReport>(reportProgress);
            if (filePath != null && checkSettings())
            {
                List<object> arguments = new List<object>();
                arguments.Add(filePath);
                arguments.Add(txtFieldDelimiter.Text.Replace("\\t", "\t"));
                arguments.Add(dictRowDelimiters[comboBoxRowDelimiter.SelectedItem.ToString()]);
                arguments.Add(CheckBoxHasHeaders.Checked);
                arguments.Add(checkBoxIsTextQualified.Checked);
                arguments.Add((int)numericUpDownSampleRows.Value);
                arguments.Add(appPath);
                arguments.Add(bgw);

                bgw.RunWorkerAsync(arguments);
            }
        }

        void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
                throw new Exception("Error Processing File", e.Error);
            scanForSingleFile(Path.GetFileName(filePath));
            fileSampleProgressBar.Value = 0;
        }

        void bgWorker_BulkRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
                throw new Exception("Error Processing File", e.Error);
            scanForSingleFile(Path.GetFileName(filePath));
            fileSampleProgressBar.Value = 0;
            startBulkProcess();
        }

        private void reportProgress(object sender, ProgressChangedEventArgs e)
        {

            //label1.Text = progress.CurrentProgressMessage;
            fileSampleProgressBar.Value = (e.ProgressPercentage);
        }

        private void processFile(object sender, DoWorkEventArgs e)
        {
            List<object> arguments = e.Argument as List<object>;
                new CSVFile(arguments);
        }

        private bool checkSettings()
        {
            if (txtFieldDelimiter.Text.Length < 1)
            {
                return false;
            }
            
            if (dictRowDelimiters[comboBoxRowDelimiter.SelectedItem.ToString()] == null)
            {
                return false;
            }

            //Check not needed? TODO: Test
            //if (txtBoxFilePreview.Text == "")
            //{
            //    return false;
            //}

            return true;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            openFile(openFileDialog.FileName);


        }

        private void openFile(string fpath)
        {
            filePath = fpath;
            Console.WriteLine(filePath);
            txtBoxFilePath.Text = filePath;

            txtBoxFilePreview.Visible = false;

            var preview = new Preview(filePath, 5000, txtBoxFilePreview);

            txtBoxFilePreview.Visible = true;
        }
        private void setupBulkProcess(string[] filePaths)
        {
            foreach (string fpath in filePaths)
            {
                bulkFileQueue.Enqueue(fpath);
            }
            startBulkProcess();
        }

        private void startBulkProcess()
        {
            if (bulkFileQueue.Count > 0)
            {
                filePath = bulkFileQueue.Dequeue();
                bgWorker_DoWorkAsync(bgwWorker_BulkProcess);
            }

        }

        private void txtFieldDelimiter_TextChanged(object sender, EventArgs e)
        {

        }

        private void contextMenuStripTabs_Opening(object sender, CancelEventArgs e)
        {
            Point p = tabContainer.PointToClient(Cursor.Position);
            for (int i = 0; i < tabContainer.TabCount; i++)
            {
                Rectangle r = tabContainer.GetTabRect(i);
                if (r.Contains(p))
                {
                    tabContainer.SelectedIndex = i; // i is the index of tab under cursor
                    if (tabContainer.SelectedTab.Name == "tabSettings")
                    {
                        targetTab = null;
                        actionsToolStripMenuItem1.HideDropDown();
                    }
                    else
                    {
                        actionsToolStripMenuItem1.ShowDropDown();
                        targetTab = (CSVTabPage)tabContainer.SelectedTab;
                        return;
                    }
                    
                }
            }
            e.Cancel = true;
        }

        private void copyAnylysisSQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (targetTab != null)
            {
                Clipboard.SetText(targetTab.csvFile.metaDataSQL);
            }
        }

        private void copyTableSQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (targetTab != null)
            {
                Clipboard.SetText(targetTab.csvFile.SQLTableCreateStatement);
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (targetTab != null)
            {
                tabContainer.Controls.Remove(targetTab);
            }
        }

        private void deleteMetaFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (targetTab != null)
            {
                deleteRemoveTab(targetTab);
            }
        }

        private void deleteRemoveTab(CSVTabPage tab)
        {
            File.Delete(tab.Name);
            tabContainer.Controls.Remove(tab);
        }

        private void RemoveTab(CSVTabPage tab)
        {
            tabContainer.Controls.Remove(tab);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bgwWorker_CSVFile.IsBusy)
            {
                bgwWorker_CSVFile.CancelAsync();
                Thread.Sleep(1000);
            }
            Application.Exit();
        }

        private void tabContainer_TabIndexChanged(object sender, EventArgs e)
        {
            if (tabContainer.SelectedTab.Name == "tabSettings")
            {
                targetTab = null;
            }
            else
            {
                targetTab = (CSVTabPage)tabContainer.SelectedTab;
                return;
            }
        }
    }
    
}
