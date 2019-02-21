﻿using System;
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

        private void scanForNewFiles(string fName = null)
        {
            IEnumerable<FileInfo> listFiles = 
                fName == null ?
                listFiles = new DirectoryInfo(appPath).GetFiles("*.meta") :
                listFiles = new DirectoryInfo(appPath).GetFiles("*.meta").Where(f => f.Name == fName + ".meta") ;

            foreach (var file in listFiles)
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

        private void deleteRemoveTab(CSVTabPage tab)
        {
            File.Delete(tab.Name);
            tabContainer.Controls.Remove(tab);
        }

        private void RemoveTab(CSVTabPage tab)
        {
            tabContainer.Controls.Remove(tab);
        }
    }
}
