using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace CSVColumnStats
{
    public sealed class WarningView : ListView
    {

        public static Bitmap bmpHotSpot = null;
        public WarningView(object baseObject)
        {
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("CSVColumnStats.Analysis.MetaDataViewDependencies.Icons.HotSpot.png");
            bmpHotSpot = new Bitmap(myStream);
        }
        
    }
    
}
