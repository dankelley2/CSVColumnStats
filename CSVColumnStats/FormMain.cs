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
using System.Reflection;

namespace CSVColumnStats
{
    public partial class MainWindow : Form
    {

        string appPath = Path.GetDirectoryName(Application.ExecutablePath);
        string filePath = null;
        CSVTabPage targetTab = null;
        Queue<string> bulkFileQueue = new Queue<string>();


        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

            // File Drag Drop
            DragEnter += new DragEventHandler(FormMain_DragEnter);
            DragDrop += new DragEventHandler(FormMain_DragDrop);
            actionsToolStripMenuItem1.Available = false;

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

        private void btnProcess_Click(object sender, EventArgs e)
        {
            bgWorker_DoWorkAsync(bgwWorker_CSVFile);
        }

        private void bgWorker_DoWorkAsync(BackgroundWorker bgw)
        {
            if (filePath != null && checkSettings())
            {
                List<object> arguments = new List<object>();
                arguments.Add(filePath);
                arguments.Add(replaceMetaChars(txtFieldDelimiter.Text));
                arguments.Add(replaceMetaChars(txtRowDelimiter.Text));
                arguments.Add(CheckBoxHasHeaders.Checked);
                arguments.Add(checkBoxIsTextQualified.Checked);
                arguments.Add((int)numericUpDownSampleRows.Value);
                arguments.Add(appPath);
                arguments.Add(bgw);

                bgw.RunWorkerAsync(arguments);
            }
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
                throw new Exception("Error Processing File", e.Error);
            scanForNewFiles(Path.GetFileName(filePath));
            fileSampleProgressBar.Value = 0;
        }

        private void bgWorker_BulkRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
                throw new Exception("Error Processing File", e.Error);
            scanForNewFiles(Path.GetFileName(filePath));
            fileSampleProgressBar.Value = 0;
            startBulkProcess();
        }

        private void processFile(object sender, DoWorkEventArgs e)
        {
            List<object> arguments = e.Argument as List<object>;
                new CSVFile(arguments);
        }

        private void reportProgress(object sender, ProgressChangedEventArgs e)
        {

            //label1.Text = progress.CurrentProgressMessage;
            fileSampleProgressBar.Value = (e.ProgressPercentage);
        }

        private void tabContainer_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right )
            {
                var type = sender.GetType();

                this.contextMenuStripTabs.Show(this, e.Location);
            }
        }

        private void FormMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void FormMain_DragDrop(object sender, DragEventArgs e)
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

        private void tabContainer_TabIndexChanged(object sender, EventArgs e)
        {
            if (tabContainer.SelectedTab.Name == "tabSettings")
            {
                targetTab = null;
                actionsToolStripMenuItem1.Available = false;
            }
            else
            {
                try
                {
                    targetTab = (CSVTabPage)tabContainer.SelectedTab;
                    actionsToolStripMenuItem1.Available = true;
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Object was not CSVTabPage");
                    actionsToolStripMenuItem1.Available = false;
                }
                return;
            }
        }

        private void MenuStrip_open_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            openFile(openFileDialog.FileName);


        }

        private void MenuStrip_exit_Click(object sender, EventArgs e)
        {
            if (bgwWorker_CSVFile.IsBusy)
            {
                bgwWorker_CSVFile.CancelAsync();
                Thread.Sleep(1000);
            }
            Application.Exit();
        }

        private void MenuStrip_copyAnylysisSQL_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem_copyAnylysisSQL_Click(sender, e);
        }

        private void MenuStrip_copyTableSQL_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem_copyTableSQL_Click(sender, e);
        }

        private void ToolStripMenuTabs_Opening(object sender, CancelEventArgs e)
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
                    }
                    else
                    {
                        targetTab = (CSVTabPage)tabContainer.SelectedTab;
                        return;
                    }

                }
            }
            e.Cancel = true;
        }

        private void ToolStripMenuItem_copyAnylysisSQL_Click(object sender, EventArgs e)
        {
            if (targetTab != null)
            {
                Clipboard.SetText(targetTab.csvFile.metaDataSQL);
            }
        }

        private void ToolStripMenuItem_copyTableSQL_Click(object sender, EventArgs e)
        {
            if (targetTab != null)
            {
                Clipboard.SetText(targetTab.csvFile.SQLTableCreateStatement);
            }
        }

        private void ToolStripMenuItem_close_Click(object sender, EventArgs e)
        {
            if (targetTab != null)
            {
                tabContainer.Controls.Remove(targetTab);
            }
        }

        private void ToolStripMenuItem_deleteMetaFile_Click(object sender, EventArgs e)
        {
            if (targetTab != null)
            {
                deleteRemoveTab(targetTab);
            }
        }

        private void splitContainer_MetaData_Panel1_DoubleClick(object sender, EventArgs e)
        {
            //var box = new WarningPanel(comboBox1);
            //box.Dock = DockStyle.Fill;
            //splitContainer_MetaData.Panel1.Controls.Add(box);
            //box.Items.Add(new DropDownItem(""));

            //Assembly myAssembly = Assembly.GetExecutingAssembly();
            //string[] names = myAssembly.GetManifestResourceNames();
            //foreach (string name in names)
            //{
            //    Console.WriteLine(name);
            //}

        }
    }
    
}
