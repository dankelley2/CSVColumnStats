using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace CSVColumnStats
{
    public class CSVFile
    {
        //Params
        public string       FILE_PATH;
        public Delimiter    COLUMN_SEPARATOR;
        public Delimiter    ROW_SEPARATOR;
        public bool         HAS_HEADERS;
        public bool         TEXT_QUALIFIED;
        public int          NUM_SAMPLE_LINES;

        //Derived Vars
        public string       fileName;
        public string       fileNameNoExt;
        public string       fileDirectory;

        //Stat Vars
        public long         msTimeToProcess;
        public long         numCharsProcessed;
        public long         numRowsProcessed;
        public float        kbDataProcessed;
        public string       metaDataSQL;
        public string       SQLTableCreateStatement;
        public List<Column> columnList = new List<Column>();

        private string      APP_PATH;
        private char[]      charBuffer = new char[20480];
        private long        charBufferOffset = 0;
        private char[]      fieldBuffer = new char[500000];
        private int         fieldBufferWriteIndex = -1;
        private int        fieldBufferStartIndex = -1;
        private long        columnIndex = 0;
        private List<long>  rowBreakList = new List<long>(){0};
        private bool        quotesOpen = false;
        private bool        trimNextField = false;
        private bool        abort = false;
        private BackgroundWorker BGWWorker;

        //DEBUG
        Stopwatch watch;
        public CSVFile()
        {

        }

        public CSVFile(List<object> arguments)
        {
            this.FILE_PATH = (string)arguments[0];
            this.COLUMN_SEPARATOR = new Delimiter((string)arguments[1]);
            this.ROW_SEPARATOR = new Delimiter((string)arguments[2]);
            this.HAS_HEADERS = (bool)arguments[3];
            this.TEXT_QUALIFIED = (bool)arguments[4];
            this.NUM_SAMPLE_LINES = (int)arguments[5];
            this.APP_PATH = (string)arguments[6];
            this.BGWWorker = (BackgroundWorker)arguments[7];

            if (true)//checkFileIntegrity())
            {
                this.fileName = Path.GetFileName(FILE_PATH);
                this.fileNameNoExt = Path.GetFileNameWithoutExtension(FILE_PATH);
                this.fileDirectory = Path.GetDirectoryName(FILE_PATH);
                getColumnStats();
                if (!abort)
                {
                    metaDataUpdateAndExport();
                }
            }

        }
        public CSVFile(string FILE_PATH, string COLUMN_SEPARATOR, string ROW_SEPARATOR,
                        bool HAS_HEADERS, bool TEXT_QUALIFIED, int NUM_SAMPLE_LINES, string AppPath)
        {
            this.FILE_PATH = FILE_PATH;
            this.COLUMN_SEPARATOR = new Delimiter(COLUMN_SEPARATOR);
            this.ROW_SEPARATOR = new Delimiter(ROW_SEPARATOR);
            this.HAS_HEADERS = HAS_HEADERS;
            this.TEXT_QUALIFIED = TEXT_QUALIFIED;
            this.NUM_SAMPLE_LINES = NUM_SAMPLE_LINES;
            this.APP_PATH = AppPath;

            if (true)//checkFileIntegrity())
            {
                this.fileName = Path.GetFileName(FILE_PATH);
                this.fileNameNoExt = Path.GetFileNameWithoutExtension(FILE_PATH);
                this.fileDirectory = Path.GetDirectoryName(FILE_PATH);
                getColumnStats();
                if (!abort)
                {
                    metaDataUpdateAndExport();
                }
            }

        }

        public string getColumnStats()
        {
            using(System.IO.StreamReader sourceFS = new System.IO.StreamReader(FILE_PATH))
            {
                watch = Stopwatch.StartNew();
                while (rowBreakList.Count() < NUM_SAMPLE_LINES+1 && (!sourceFS.EndOfStream))
                {
                    // Read chars into buffer
                    var charsRead = (char)sourceFS.Read(charBuffer, 0, charBuffer.Length);
                    charBufferOffset += charsRead;

                    //Check for cancellation
                    if (BGWWorker.CancellationPending)
                    {
                        abort = true;
                        break;
                    }

                    // Loop through buffer
                    for (int i = 0; i < charsRead; i++)
                    {
                        // Assign current char
                        char c = charBuffer[i];

                        // Add to Data Buffer
                        AddToFieldBuffer(c);

                        if (IsInsideQuotes(c))
                        {
                            trimNextField = true;
                            continue;
                        }

                        if (COLUMN_SEPARATOR.delimiterFound(c))
                        {

                            var charData = MeasureThenStartNewField(COLUMN_SEPARATOR.Length);
                            CheckAddColumn(charData);
                            UpdateColumnStats(charData);
                            // Increment Column
                            columnIndex++;
                        }
                        else if (ROW_SEPARATOR.delimiterFound(c))
                        {
                            var charData = MeasureThenStartNewField(ROW_SEPARATOR.Length);
                            CheckAddColumn(charData);
                            UpdateColumnStats(charData);
                            AddRow(charBufferOffset+i);
                            
                            // Column zero again
                            columnIndex = 0;

                            if (rowBreakList.Count() >= NUM_SAMPLE_LINES + 1)
                            {
                                break;
                            }
                        }
                    }
                }
                watch.Stop();
            }
            return fileName;
        }

        private void AddToFieldBuffer(char c)
        {
            // Increment Field buffer
            if (++fieldBufferWriteIndex > fieldBuffer.Length-1)
            {
                fieldBufferWriteIndex = 0;
            }

            //
            fieldBuffer[fieldBufferWriteIndex] = c;
        }

        private void BacktrackFieldBuffer(int amt)
        {
            // If we've already started writing to a new loop
            // We need to move back to the far side of the buffer
            if (fieldBufferWriteIndex - amt < 0)
            {
                var diff = fieldBufferWriteIndex - amt;
                fieldBufferWriteIndex = (fieldBuffer.Length) + diff;
            }
            else
            {
                fieldBufferWriteIndex -= amt;
            }
        }

        private bool IsInsideQuotes(char c)
        {
            // Check Quote situation
            if (TEXT_QUALIFIED)
            {
                if (c == '"')
                {
                    quotesOpen = !quotesOpen;
                }
            }

            if (quotesOpen)
            {
                return true;
            }
            return false;
        }

        private void UpdateColumnStats(char[] fieldData)
        {
            try
            {
                columnList.Where(l => l.columnIndex == columnIndex)
                    .FirstOrDefault()
                    .RunDataChecks(fieldData);
            }
            catch( IndexOutOfRangeException ie)
            {
                //Console.WriteLine("Index out of range, extra delimiter in data.");
            }
        }

        private char[] MeasureThenStartNewField(int backtrackAmt)
        {
            // Backtrack, removing delimiter
            BacktrackFieldBuffer(backtrackAmt);

            char[] fieldData;
            var fieldDataIndex = 0;

            if (fieldBufferStartIndex > fieldBufferWriteIndex)
            // If we've looped around the buffer
            {
                var numChars = (fieldBuffer.Length - fieldBufferStartIndex) + (fieldBufferWriteIndex);
                fieldData = new char[numChars-1];
                for (int i = fieldBufferStartIndex + 1; i < fieldBuffer.Length; i++)
                {
                    fieldData[fieldDataIndex] = fieldBuffer[i];
                    fieldDataIndex++;
                }
                for (int i = 0; i < fieldBufferWriteIndex; i++)
                {
                    fieldData[fieldDataIndex] = fieldBuffer[i];
                    fieldDataIndex++;
                }
            }
            else
            {
                fieldData = new char[(fieldBufferWriteIndex - fieldBufferStartIndex)];

                for (int i = fieldBufferStartIndex + 1; i <= fieldBufferWriteIndex; i++)
                {
                    fieldData[fieldDataIndex] = fieldBuffer[i];
                    fieldDataIndex++;
                }
            }
            fieldBufferStartIndex = fieldBufferWriteIndex;

            if (trimNextField)
            {
                fieldData = new string(fieldData).Substring(1, fieldData.Length - 2).ToCharArray();
                trimNextField = false;
            }
            return fieldData;

        }

        private void CheckAddColumn(char[] fieldText)
        {
            // Check if we need to find Headers
            if (rowBreakList.Count() < 2)
            {
                
                if (HAS_HEADERS)
                // Add Column Name
                {
                    var strFieldText = new string(fieldText);

                    // If it's the first
                    if (columnList.Count() == 0)
                    {
                        columnList.Add(new Column(0, strFieldText));
                    }
                    else
                    {
                        var newIndex = columnList.Max(c => c.columnIndex) + 1;
                        columnList.Add(new Column(newIndex, strFieldText));
                    }
                    
                }
                else
                // Add Index as Name
                {
                    // If it's the first
                    if (columnList.Count() == 0)
                    {
                        columnList.Add(new Column(0, "Column 0"));
                    }
                    else
                    {
                        var newIndex = columnList.Max(c => c.columnIndex) + 1;
                        columnList.Add(new Column(newIndex, "Column " + newIndex.ToString()));
                    }

                }
            }
        }

        private void AddRow(long streamOffset)
        {
            rowBreakList.Add(streamOffset);
            if (rowBreakList.Count % 10 == 0)
            {
                BGWWorker.ReportProgress((int)((float)rowBreakList.Count*100 / (float)NUM_SAMPLE_LINES),"Analyzing...");
            }
        }

        private void metaDataUpdateAndExport()
        {
            refreshMetaDataVariables();
            outputXMLStream();
        }

        private void refreshMetaDataVariables()
        {
            StringBuilder sb = new StringBuilder();

            SQLTableCreateStatement =
                  "\r\n\r\n/**********************************************\r\n"
                + "Table Script Generated by CSV Analyzer\r\n"
                + "Copyright © 2019 Daniel Kelley (but not really)\r\n"
                + "**********************************************/\r\n"
                + "CREATE TABLE [" + fileNameNoExt + "] (";

            int colNameLen = 0;
            foreach (Column Col in columnList)
            {
                colNameLen = Math.Max(colNameLen, Col.columnName.Length);
            }

            foreach (Column Col in columnList)
            {
                Col.CalculateColumnMetrics();
                sb.Append(Col.ToString());

                //give format padding
                var spaces = "";
                for (int i = 0; i < (colNameLen - Col.columnName.Length + 1); i++) { spaces += " "; }

                SQLTableCreateStatement +=
                    "\r\n    [" + Col.columnName + "]" + spaces + Col.sqlType + ",";
            }


            // SQL Table Continued
            SQLTableCreateStatement = SQLTableCreateStatement.Substring(0, SQLTableCreateStatement.Length - 1);
            SQLTableCreateStatement += "\r\n);\r\nGO\r\n\r\n";

            // File stat vars
            metaDataSQL =
                "\r\n\r\nDROP TABLE IF EXISTS #Columns\r\n"
                + "CREATE TABLE #Columns([ColIndex] int, [Name] varchar(200), [ReccomendedType] varchar(200), [MaxLength] int, [NonZeroMinLength] int, [ReccomendedLength] int, [IsNumeric] varchar(5), [Precision] int, [Scale] int, [IsDate] varchar(5), [Sample] varchar(max))\r\n"
                + "INSERT INTO #Columns ([ColIndex], [Name], [ReccomendedType], [MaxLength], [NonZeroMinLength], [ReccomendedLength], [IsNumeric], [Precision], [Scale], [IsDate], [Sample]) VALUES\r\n"
                + sb.ToString().Substring(1)
                + "SELECT * FROM #Columns ORDER BY ColIndex\r\n\r\n";

            numRowsProcessed = rowBreakList.Count;
            numCharsProcessed = charBufferOffset;
            msTimeToProcess = watch.ElapsedMilliseconds;
            kbDataProcessed = numCharsProcessed / 1024;
        }
        
        private void outputXMLStream()
        {
            //Serialize stream
            using (StreamWriter writer = new StreamWriter(
                APP_PATH + Path.DirectorySeparatorChar + fileName + @".meta", false))
            {
                writer.Write(xmlSerializer.SerializeCSVFile(this));
                writer.Flush();
                writer.Close();
            }
        }


    }  
}
