using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVColumnStats.Util
{
    public class SSISColumn
    {

        public string ColumnType = "Delimited";
        public string ColumnDelimiter;
        public int MaximumWidth;
        public int DataType;
        public bool TextQualified = true;
        public string ObjectName;
        public Guid DTSID;
        public string CreationName = "";

        public SSISColumn(Column c, Delimiter delim)
        {
            ColumnDelimiter = delim.ToString();
            MaximumWidth = c.reccomendedLength;
            DataType = DataTypes.getDataTypeFromSQLString(c.sqlType);
        }


    }

    public static class DataTypes
    {

        public static int getDataTypeFromSQLString(string SQLString)
        {
            foreach (object[] obj in dataTypes)
            {
                if ((string)obj[5] == SQLString)
                {
                    return (int)obj[7];
                }
            }
            return 0;

        }
        public static object[] dataTypes = new object[] {
        new object[] {1 , true , null, null, null, "VARCHAR({0})", "STR", 129 },
        new object[] {2 , true , null, null, null, "VARCHAR(MAX)", "TEXT", 302 },
        new object[] {3 , true , null, null, null, "INT", "I4", 3 },
        new object[] {4 , true , null, null, null, "SMALLINT", "I2", 2 },
        new object[] {5 , true , null, null, null, "DATETIME", "DATE", 7 },
        new object[] {6 , true , null, null, null, "CURRENCY", "CY", 6 },
        new object[] {7 , true , null, null, null, "DECIMAL({0},{1})", "DECIMAL", 14 },
        new object[] {8 , true , null, null, null, "NUMERIC", "NUMERIC", 131 },
        new object[] {9 , true , null, null, null, "BIT", "BOOL", 11 },
        new object[] {10, true , null, null, null, "NVARCHAR", "WSTR", 130 },
        new object[] {12, true , null, null, null, "NVARCHAR(MAX)", "NTEXT", 303 },
        new object[] {13, true , null, null, null, "GUID"             , "GUID"             , 72 }//,
        //new object[] {14, false, null, null, null, "BYTES"            , "BYTES"            , 128 },
        //new object[] {15, false, null, null, null, "DBDATE"           , "DBDATE"           , 133 },
        //new object[] {16, false, null, null, null, "DBTIME"           , "DBTIME"           , 134 },
        //new object[] {17, false, null, null, null, "DBTIME2"          , "DBTIME2"          , 145 },
        //new object[] {18, false, null, null, null, "DBTIMESTAMP"      , "DBTIMESTAMP"      , 135 },
        //new object[] {19, false, null, null, null, "DBTIMESTAMP2"     , "DBTIMESTAMP2"     , 304 },
        //new object[] {20, false, null, null, null, "DBTIMESTAMPOFFSET", "DBTIMESTAMPOFFSET", 146 },
        //new object[] {21, false, null, null, null, "EMPTY"            , "EMPTY"            , 0 },
        //new object[] {22, false, null, null, null, "FILETIME"         , "FILETIME"         , 64 },
        //new object[] {23, false, null, null, null, "I1"               , "I1"               , 16 },
        //new object[] {24, false, null, null, null, "I8"               , "I8"               , 20 },
        //new object[] {25, false, null, null, null, "IMAGE"            , "IMAGE"            , 301 },
        //new object[] {26, false, null, null, null, "NULL"             , "NULL"             , 1 },
        //new object[] {27, false, null, null, null, "R4"               , "R4"               , 4 },
        //new object[] {28, false, null, null, null, "R8"               , "R8"               , 5 },
        //new object[] {29, false, null, null, null, "UI1"              , "UI1"              , 17 },
        //new object[] {30, false, null, null, null, "UI2"              , "UI2"              , 18 },
        //new object[] {31, false, null, null, null, "UI4"              , "UI4"              , 19 },
        //new object[] {32, false, null, null, null, "UI8"              , "UI8"              , 21 }
        };
    }
}
