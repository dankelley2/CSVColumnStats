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

namespace CSVColumnStats
{
    public partial class MainWindow : Form
    {

        string appPath = Path.GetDirectoryName(Application.ExecutablePath);
        string filePath = null;
        TabPage targetTab = null;
        Dictionary<string, string> dictRowDelimiters
            = new Dictionary<string, string>() {
                {"[CR][LF]","\r\n"},
                {"[CR]","\r"},
                {"[LF]","\n"},
            };


        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            watcherProgramDirectory.Path = appPath;
            watcherProgramDirectory.Created += WatcherProgramDirectory_Created;
            watcherProgramDirectory.Changed += WatcherProgramDirectory_Changed;

            // Set up checked settings
            CheckBoxHasHeaders.Checked = true;
            checkBoxIsTextQualified.Checked = true;
            tabContainer.MouseClick += tabContainer_MouseClick;

            foreach (var file in new DirectoryInfo(appPath).GetFiles("*.meta"))
            {
                AddMetaDataTab(file.Name, file.FullName);
            }
        }

        private void WatcherProgramDirectory_Changed(object sender, FileSystemEventArgs e)
        {
            AddMetaDataTab(e.Name, e.FullPath);
        }

        private void WatcherProgramDirectory_Created(object sender, FileSystemEventArgs e)
        {
            AddMetaDataTab(e.Name, e.FullPath);

        }

        private void AddMetaDataTab(string name, string path)
        {
            if (!tabContainer.Controls.ContainsKey(path))
            {
                TabPage newTab = new TabPage();
                newTab.Text = name;
                newTab.Name = path;
                RichTextBox newMetaData = new RichTextBox();
                newMetaData.Dock = DockStyle.Fill;
                newMetaData.Name = name + "MetaData";
                newMetaData.Text = File.ReadAllText(path);
                newMetaData.Font = new Font("Consolas", 8, FontStyle.Regular);

                newTab.Controls.Add(newMetaData);
                tabContainer.Controls.Add(newTab);
                newTab.Show();
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
            processFile();
        }

        private void processFile()
        {
            CSVFile csvFile;
            if (filePath != null && checkSettings())
            {
                csvFile = new CSVFile(
                    filePath, txtFieldDelimiter.Text
                    , dictRowDelimiters[comboBoxRowDelimiter.SelectedItem.ToString()]
                    , true
                    , true
                    , (int)numericUpDownSampleRows.Value
                    );
            }
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

            if (txtBoxFilePreview.Text == "")
            {
                return false;
            }

            return true;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            filePath = openFileDialog.FileName;
            Console.WriteLine(filePath);
            txtBoxFilePath.Text = filePath;

            txtBoxFilePreview.Visible = false;

            var preview = new Preview(filePath, 5000, txtBoxFilePreview);

            txtBoxFilePreview.Visible = true;


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
                    }
                    else
                    {
                        targetTab = tabContainer.SelectedTab;
                        return;
                    }
                    
                }
            }
            e.Cancel = true;
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
                File.Delete(targetTab.Name);
                tabContainer.Controls.Remove(targetTab);
            }
        }
    }
}
