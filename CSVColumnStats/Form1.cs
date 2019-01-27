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

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            watcherProgramDirectory.Path = appPath;
            watcherProgramDirectory.Created += WatcherProgramDirectory_Created;
            watcherProgramDirectory.Changed += WatcherProgramDirectory_Changed;

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
            if (!tabContainer.Controls.ContainsKey(name))
            {
                TabPage newTab = new TabPage();
                newTab.Text = name;
                newTab.Name = name;

                RichTextBox newMetaData = new RichTextBox();
                newMetaData.Dock = DockStyle.Fill;
                newMetaData.Name = name + "MetaData";
                newMetaData.Text = File.ReadAllText(path);

                newTab.Controls.Add(newMetaData);
                tabContainer.Controls.Add(newTab);
                newTab.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            processFile();
        }

        private void processFile()
        {
            CSVFile csvFile;
            if (filePath != null)
            {
                csvFile = new CSVFile(
                    filePath, ",", "\n", true, true, 500000);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            filePath = openFileDialog.FileName;
            Console.WriteLine(filePath);
            txtBoxFilePath.Text = filePath;
            var preview = new Preview(filePath, 2048, txtBoxFilePreview);

        }
    }
}
