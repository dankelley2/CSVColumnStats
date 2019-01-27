using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVColumnStats
{
    public class Column
    {
        private static readonly char[] NumericChars = { '.'};
        private static readonly char[] DateChars = { ':', '/', '-', ' ', ',', '.', 'A', 'P', 'M', 'a', 'p', 'm' };
        private static readonly int[] varcharLengths = { 1, 2, 10, 50, 100, 500, 2000, 4000, 8000 };
        private static readonly int[] precisionLengths = { 10, 18 };

        public int columnIndex;
        public string columnName;
        public string sampleData = "";
        public string sqlType = "";
        public int maxLength = 0;
        public int minLength = int.MaxValue;
        public int lengthDeviation = 0;
        public int nonZeroMinLength = int.MaxValue;
        public int nonZeroLengthDeviation = 0;
        public int reccomendedLength = 0;
        public int decimalPrecision = 0;
        public int decimalScale = 0;
        public bool isNumeric = true;
        public bool isDate = true;
        public bool isHeader = true;

        public Column()
        {

        }

        public Column(int index, string name)
        {
            this.columnIndex = index;
            this.columnName = name;
        }

        public void RunDataChecks(char[] chars)
        {
            if (isHeader)
            {
                isHeader = false;
                return;
            }
            else
            {
                if (chars.Length > 0)
                {
                    if (sampleData == "")
                    {
                        sampleData = new string(chars);
                    }
                    CheckMaxLength(chars.Length);
                    if (isNumeric) { CheckIsNumeric(chars); }
                    if (isDate) { CheckIsDate(chars); }
                }
            }
        }

        public void CalculateColumnMetrics()
        {
            RoundMaxLength();
            RoundMaxPrecision();
            CalculateDeviation();
            getReccomendedType();
        }

        private void CheckMaxLength(int len)
        {
            maxLength = Math.Max(len, maxLength);
            minLength = Math.Min(len, minLength);
            if (len > 0)
            {
                nonZeroMinLength = Math.Min(len, nonZeroMinLength);
            }

        }

        private void CheckIsNumeric(char[] chars)
        {
            int sign = 0;
            int index = 0;
            if (chars[0] == '-')
            {
                if (chars.Length == 1)
                {
                    this.isNumeric = false;
                    return;
                }
                sign = 1;
            }

            if (chars.Length > 1 && chars[0 + sign] == '0')
            {
                if (chars.Length > 2 && chars[1 + sign] != '.')
                {
                    this.isNumeric = false;
                    return;
                }
            }

            foreach (char c in chars)
            {

                if (!(c > 47 && c < 58 || NumericChars.Contains(c) || sign == 1))
                {
                    this.isNumeric = false;
                    return;
                }
                if (c == '-' && sign != 1)
                {
                    this.isNumeric = false;
                    return;
                }
                if (c == NumericChars[0])
                {
                    decimalPrecision = Math.Max(((chars.Length - 1) - sign), decimalPrecision);
                    decimalScale = Math.Max(((chars.Length - index - 1) - sign), decimalScale);
                }
                index++;
            }
        }

        private void CheckIsDate(char[] chars)
        {
            if (chars.Length == 0)
            {
                return;
            }
            // Fast Check
            foreach (char c in chars)
            {
                if (!(c > 47 && c < 58 || DateChars.Contains(c)))
                {
                    this.isDate = false;
                    return;
                }
            }
            // Slow Check
            var dateString = new string(chars);
            DateTime dateValue;
            if (!DateTime.TryParse(dateString, out dateValue))
            {
                this.isDate = false;
            }
        }

        private void RoundMaxLength()
        {
            foreach (int newLen in varcharLengths)
            {
                if (maxLength == 0)
                {
                    reccomendedLength = 100;
                    break;
                }
                else if (maxLength <= newLen)
                {
                    reccomendedLength = newLen;
                    break;
                }
            }
        }

        private void RoundMaxPrecision()
        {
            if (decimalPrecision > 0)
            {
                foreach (int newLen in precisionLengths)
                {
                    if (decimalPrecision <= newLen)
                    {
                        decimalPrecision = newLen;
                        break;
                    }
                }
            }
        }

        private void CalculateDeviation()
        {
            if (maxLength == 0)
            {
                minLength = 0;
                nonZeroMinLength = -1;
            }
            lengthDeviation = maxLength - minLength;
            nonZeroLengthDeviation = nonZeroMinLength == 0 ? 0 : maxLength - nonZeroMinLength;
        }

        private void getReccomendedType()
        {
            var strObject = new string[] {
                columnName,
                reccomendedLength.ToString(),
                (decimalPrecision + decimalScale).ToString(),
                decimalScale.ToString()
            };

            //Date
            if (isDate && maxLength > 0)
            { sqlType = string.Format("[{0}] DATETIME", strObject); }
            //Decimal
            else if (isNumeric && decimalPrecision > 0)
            { sqlType = string.Format("[{0}] DECIMAL({2},{3})", strObject); }
            //Abnormally large int, possibly Claim No
            else if (isNumeric && maxLength > 9)
            { sqlType = string.Format("[{0}] VARCHAR({1})", strObject); }
            //Possibly Zip-Codes
            else if (isNumeric && maxLength == 5)
            { sqlType = string.Format("[{0}] VARCHAR({1})", strObject); }
            //Int
            else if (isNumeric && maxLength > 0)
            { sqlType = string.Format("[{0}] INT", strObject); }
            //Varchar
            else if (maxLength == 0)
            { sqlType = string.Format("[{0}] VARCHAR(100)", strObject); }
            //Varchar
            else
            { sqlType = string.Format("[{0}] VARCHAR({1})", strObject); }

        }

        public override string ToString()
        {
            var strObject = new string[] {
                columnIndex.ToString(),
                columnName,
                sqlType,
                maxLength.ToString(),
                nonZeroMinLength.ToString(),
                reccomendedLength.ToString(),
                isNumeric.ToString(),
                decimalPrecision.ToString(),
                decimalScale.ToString(),
                isDate.ToString(),
                sampleData.Replace("'","''")
            };
            return string.Format(
                ", ({0}, '{1}', '{2}', {3}, {4}, {5}, '{6}', {7}, {8}, '{9}', '{10}')\r\n"
                , strObject);
        }
        

    }
}
