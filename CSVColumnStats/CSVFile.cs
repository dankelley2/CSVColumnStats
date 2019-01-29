using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

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
        public float        kbDataProcessed;
        public string       metaDataSQL;
        public string       SQLTableCreateStatement;
        public List<Column> columnList = new List<Column>();

        private string      appPath = Path.GetDirectoryName(Application.ExecutablePath);
        private char[]      charBuffer = new char[20480];
        private int         charBufferOffset = 0;
        private char[]      fieldBuffer = new char[500000];
        private int         fieldBufferWriteIndex = -1;
        private int         fieldBufferStartIndex = -1;
        private int         columnIndex = 0;
        private List<int>   rowBreakList = new List<int>(){0};
        private bool        quotesOpen = false;
        private bool        trimNextField = false;

        //DEBUG
        Stopwatch watch;
        public CSVFile()
        {

        }

        public CSVFile(string FILE_PATH, string COLUMN_SEPARATOR, string ROW_SEPARATOR,
                        bool HAS_HEADERS, bool TEXT_QUALIFIED, int NUM_SAMPLE_LINES)
        {
            this.FILE_PATH = FILE_PATH;
            this.COLUMN_SEPARATOR =  new Delimiter(COLUMN_SEPARATOR);
            this.ROW_SEPARATOR    =  new Delimiter(ROW_SEPARATOR);
            this.HAS_HEADERS      =  HAS_HEADERS;
            this.TEXT_QUALIFIED   =  TEXT_QUALIFIED;
            this.NUM_SAMPLE_LINES =  NUM_SAMPLE_LINES;

            if (true)//checkFileIntegrity())
            {
                this.fileName = Path.GetFileName(FILE_PATH);
                this.fileNameNoExt = Path.GetFileNameWithoutExtension(FILE_PATH);
                this.fileDirectory = Path.GetDirectoryName(FILE_PATH);
                getColumnStats();
                metaDataUpdateAndExport();
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
                fieldBufferWriteIndex = (fieldBuffer.Length - 1) + diff;
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
                    fieldData[fieldDataIndex] += fieldBuffer[i];
                    fieldDataIndex++;
                }
                for (int i = 0; i < fieldBufferWriteIndex; i++)
                {
                    fieldData[fieldDataIndex] += fieldBuffer[i];
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

        private void AddRow(int streamOffset)
        {
            rowBreakList.Add(streamOffset);
        }

        private void outputConsoleStats()
        {
            //Debug output
            Console.WriteLine(metaDataSQL);
            Console.WriteLine((rowBreakList.Count - 1).ToString() + " Rows Processed.");
            Console.WriteLine((watch.ElapsedTicks / rowBreakList.Count).ToString() + " ticks per row.");
            Console.WriteLine(watch.ElapsedMilliseconds.ToString() + "ms Total.");
            Console.WriteLine(kbDataProcessed.ToString("0.00") + " kb processed.");
            Console.WriteLine("Done");
        }

        private void outputXMLStream()
        {
            //Serialize stream
            using (StreamWriter writer = new StreamWriter(
                appPath + Path.DirectorySeparatorChar + fileName + @".meta", false))
            {
                writer.Write(xmlSerializer.SerializeCSVFile(this));
            }
        }

        private void metaDataUpdateAndExport()
        {
            refreshMetaDataVariables();
            outputXMLStream();
            outputConsoleStats();
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

            foreach (Column Col in columnList)
            {
                Col.CalculateColumnMetrics();
                sb.Append(Col.ToString());

                SQLTableCreateStatement +=
                    "\r\n\t" + Col.sqlType + ",";
            }

            // SQL Table Continued
            SQLTableCreateStatement = SQLTableCreateStatement.Substring(0, SQLTableCreateStatement.Length - 1);
            SQLTableCreateStatement += ");\r\n\r\nGO\r\n\r\n";

            // File stat vars
            metaDataSQL =
                "\r\n\r\nDROP TABLE IF EXISTS #Columns\r\n"
                + "CREATE TABLE #Columns([ColIndex] int, [Name] varchar(200), [ReccomendedType] varchar(200), [MaxLength] int, [NonZeroMinLength] int, [ReccomendedLength] int, [IsNumeric] varchar(5), [Precision] int, [Scale] int, [IsDate] varchar(5), [Sample] varchar(max))\r\n"
                + "INSERT INTO #Columns ([ColIndex], [Name], [ReccomendedType], [MaxLength], [NonZeroMinLength], [ReccomendedLength], [IsNumeric], [Precision], [Scale], [IsDate], [Sample]) VALUES\r\n"
                + sb.ToString().Substring(1)
                + "SELECT * FROM #Columns ORDER BY ColIndex\r\n\r\n";


            numCharsProcessed = charBufferOffset;
            msTimeToProcess = watch.ElapsedMilliseconds;
            kbDataProcessed = numCharsProcessed / 1024;
        }

    }  
}
