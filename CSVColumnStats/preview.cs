using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSVColumnStats
{
    public class Preview
    {
        private readonly List<string[]>  listReplace = new List<string[]>()
        {
            new string[] {"\r","[CR]\r"},
            new string[] {"\n","[LF]\n"},
            new string[] { "[CR]\r[LF]\n", "[CR][LF]\r\n"}
        };
        private readonly Dictionary<string, Color> dictPatternColors = new Dictionary<string, Color>()
        {
            {@",",Color.Black },
            {@"\[CR\]",Color.DarkBlue },
            {@"\[LF\]",Color.DarkGreen },
            {"\"",Color.DarkRed },
            {@"\|",Color.Black }
        };

        private string _filePath;
        private int _numChars;
        private RichTextBox _richTextBox;

        public string sampleData;

        public Preview(string filePath, int numChars, RichTextBox rtb)
        {
            _filePath = filePath;
            _numChars = numChars;
            _richTextBox = rtb;

            using (StreamReader sr = new StreamReader(_filePath))
            {
                var chars = new char[_numChars];
                sr.Read(chars, 0, _numChars);

                sampleData = new string(chars);
                foreach (string[] strArray in listReplace)
                {
                    sampleData = sampleData.Replace(strArray[0], strArray[1]);
                }
                
            }
            rtb.ForeColor = Color.Gray;
            rtb.Text = sampleData;

            foreach (KeyValuePair<string,Color> kvp in dictPatternColors)
            {
                ColorWord(rtb, kvp.Key, kvp.Value);
            }
            

        }

        int ColorWord(RichTextBox rtb, string regExPattern, Color foreColor)
        {
            var matches = Regex.Matches(rtb.Text, regExPattern);

            for (int i = matches.Count - 1; i >= 0; i--)
            {
                var m = matches[i];

                rtb.SelectionStart = m.Index;
                rtb.SelectionLength = m.Length;
                rtb.SelectionColor = foreColor;
                rtb.SelectionBackColor = rtb.BackColor;
            }

            return matches.Count;
        }


    }
}
