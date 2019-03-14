using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace CSVColumnStats
{
    internal class MetaDataSplitContainer : SplitContainer
    {
        private XmlDocument xmlDoc;
        private string rawFile;
        private CSVFile csvFile;

        public MetaDataSplitContainer(XmlDocument xmlDoc, string rawFile, CSVFile csvFile)
        {
            this.xmlDoc = xmlDoc;
            this.Dock = DockStyle.Fill;
            this.rawFile = rawFile;
            this.csvFile = csvFile;
            AddChildControls();
        }

        private void AddChildControls()
        {
            this.FixedPanel = FixedPanel.Panel1;
            this.IsSplitterFixed = false;
            this.Panel1.Controls.Add(new SummaryRichTextBox(xmlDoc, rawFile));
            this.Panel1MinSize = 200;
            this.SplitterDistance = 200;
            AddPanel1Buttons();
            this.Panel2.Controls.Add(new RawDataTabControl(xmlDoc,rawFile));
        }

        private void AddPanel1Buttons()
        {
            Button btnInjectToSSIS = new Button();
            btnInjectToSSIS.Text = "Inject to SSIS Package";
            btnInjectToSSIS.Width = 200;
            btnInjectToSSIS.Click += (object sender, EventArgs e) =>
            {
                MessageBox.Show("Not Yet Implemented");
            };
            btnInjectToSSIS.Dock = DockStyle.Top;
            Panel1.Controls.Add(btnInjectToSSIS);

            Button btnCopyAnalysisSQL = new Button();
            btnCopyAnalysisSQL.Text = "Copy Analysis SQL";
            btnCopyAnalysisSQL.Click += (object sender, EventArgs e) =>
            {
                Clipboard.SetText(csvFile.metaDataSQL);
            };
            btnCopyAnalysisSQL.Dock = DockStyle.Top;
            Panel1.Controls.Add(btnCopyAnalysisSQL);

            Button btnCopyTableSQL = new Button();
            btnCopyTableSQL.Text = "Copy Table SQL";
            btnCopyTableSQL.Click += (object sender, EventArgs e) =>
            {
                Clipboard.SetText(csvFile.SQLTableCreateStatement);
            };
            btnCopyTableSQL.Dock = DockStyle.Top;
            Panel1.Controls.Add(btnCopyTableSQL);
        }
    }
}