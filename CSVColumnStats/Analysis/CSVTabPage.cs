using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSVColumnStats
{
    class CSVTabPage : TabPage
    {
        public string rawFile;
        public CSVFile csvFile;

        public CSVTabPage(string rawFile)
        {
            this.rawFile = rawFile;
            csvFile = (CSVFile)xmlSerializer.FromXml(rawFile, typeof(CSVFile));
        }

        public CSVTabPage()
        {

        }
    }
}
