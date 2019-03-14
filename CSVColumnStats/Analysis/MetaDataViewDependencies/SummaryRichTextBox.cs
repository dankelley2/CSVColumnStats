using System.Windows.Forms;
using System.Xml;

namespace CSVColumnStats
{
    internal class SummaryRichTextBox : RichTextBox
    {
        private string rawFile;
        private XmlDocument xmlDoc;

        public SummaryRichTextBox(XmlDocument xmlDoc, string rawFile)
        {
            this.xmlDoc = xmlDoc;
            this.rawFile = rawFile;
            this.Dock = DockStyle.Fill;
            this.BringToFront();
        }
    }
}