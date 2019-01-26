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

        public string appPath = Path.GetDirectoryName(Application.ExecutablePath);
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            runProcess();
        }

        private void runProcess()
        {
            var CSVFile = new CSVFile(
                @"\\pitsvfil01\Shared\Subro\ArbForum\OpenReport\OpenArb012519 Copy.csv", ",", "\r\n", true, true, 1415);
        }

    }
}
