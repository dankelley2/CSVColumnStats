using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVColumnStats
{
    public class Delimiter
    {

        public char[] chars;
        public int Length { get { return chars.Length; } }
        private int _index = 0;
        private char currentChar { get { return chars[_index]; } }

        public Delimiter()
        {

        }

        public Delimiter(string strDelim)
        {
            if (strDelim.Length == 0)
            {
                throw new Exception("Delimiter was zero length");
            }
            this.chars = strDelim.ToCharArray();
        }

        private int charsRemaining(char c)
        {
            if (currentChar == c)
            {
                _index++;
            }
            else
            {
                reset();
            }

            return chars.Length - _index;
        }

        private void reset()
        {
            _index = 0;
        }

        public bool delimiterFound(char c)
        {
            if (charsRemaining(c) == 0)
            {
                reset();
                return true;
            }
            return false;
        }

    }
}
