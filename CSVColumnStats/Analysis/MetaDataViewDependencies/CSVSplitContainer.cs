using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace CSVColumnStats
{
    internal class CSVSplitContainer : SplitContainer
    {
        private XmlDocument xmlDoc;
        private string rawFile;
        public CSVSplitContainer(XmlDocument xmlDoc, string rawFile)
        {
            this.xmlDoc = xmlDoc;
            this.Dock = DockStyle.Fill;
            this.rawFile = rawFile;
           // this.SplitterDistance = 100;// (int)(Parent.Width * .4);
            AddChildControls();
        }

        private void AddChildControls()
        {
            this.Panel1.Controls.Add(new CSVTreeView(xmlDoc));

            RichTextBox newMetaData = new RichTextBox();
            newMetaData.Dock = DockStyle.Fill;
            newMetaData.Name = "RawMetaData";
            newMetaData.Text = rawFile;
            newMetaData.Font = new Font("Consolas", 8, FontStyle.Regular);
            this.Panel2.Controls.Add(newMetaData);
        }
    }
}