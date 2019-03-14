using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace CSVColumnStats
{
    internal class RawDataTabControl : TabControl
    {
        private XmlDocument xmlDoc;
        private string rawFile;

        public RawDataTabControl(XmlDocument xmlDoc, string rawFile)
        {
            this.xmlDoc = xmlDoc;
            this.rawFile = rawFile;
            this.TabPages.Clear();
            this.TabPages.Add("Raw XML View");
            this.TabPages.Add("XML Treeview");
            this.Dock = DockStyle.Fill;
            AddChildControls();
        }

        private void AddChildControls()
        {


            RichTextBox newMetaData = new RichTextBox();
            newMetaData.Dock = DockStyle.Fill;
            newMetaData.Name = "RawMetaData";
            newMetaData.Text = rawFile;
            newMetaData.Font = new Font("Consolas", 8, FontStyle.Regular);
            this.TabPages[0].Controls.Add(newMetaData);
            this.TabPages[1].Controls.Add(new RawDataTreeView(xmlDoc));
        }
    }
}