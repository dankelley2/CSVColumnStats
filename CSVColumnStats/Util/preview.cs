﻿using System;
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
            new string[] {"\r","[\\r]\r"},
            new string[] {"\n","[\\n]\n"},
            new string[] { "[\\r]\r[\\n]\n", "[\\r][\\n]\r\n"},
            new string[] { "\t", "\t[\\t]"},
            new string[] { " ", "·"}
        };
        private readonly Dictionary<string, Color> dictPatternColors = new Dictionary<string, Color>()
        {
            {@",",Color.WhiteSmoke },
            {@"\[\\r\]",Color.Blue },
            {@"\[\\n\]",Color.Green },
            {"\"[^\"]*?\"",Color.OrangeRed },
            {@"\|",Color.WhiteSmoke },
            {@"\[\\t\]",Color.YellowGreen },
            {@"·",Color.DarkSlateGray }
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
            rtb.ResetText();
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
                if (regExPattern == "·")
                    rtb.SelectionFont = new Font(rtb.Font, FontStyle.Regular);
                else
                    rtb.SelectionFont = new Font(rtb.Font, FontStyle.Bold);
                //rtb.SelectionBackColor = rtb.BackColor;
            }

            return matches.Count;
        }


    }
}
