using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CSVColumnStats
{
    class RawDataTabPage : TabPage
    {
        public string rawFile;
        public CSVFile csvFile;

        private XmlDocument xmlDoc;

        public RawDataTabPage(string name, string path, string rawFile)
        {
            this.Text = name;
            this.Name = path;
            this.rawFile = rawFile;
            this.csvFile = (CSVFile)xmlTools.FromXml(rawFile, typeof(CSVFile));
            xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(rawFile);
            AddChildControls();

        }

        private void AddChildControls()
        {
            Controls.Add(new MetaDataSplitContainer(xmlDoc, rawFile, csvFile));
        }

        public RawDataTabPage()
        {

        }
    }
}
