using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSVColumnStats
{
    /** Available Properties:
    * IsNumeric
    * IsDate
    * DecimalScale
    * DecimalPrecision
    * Length
    * MinLength
    * NonZeroMinLength
    * ReccomendedLength
    * */

    public class ColumnRuleSet
    {
        //Dictionary <string,Func<string,string,bool>> StringComparisons = new Dictionary <string, Func<string,string,bool>>() {
        //    {"EQUAL", isEqual("one","Two")}
        //};
        //List<int> IntComparisons = new List<int>() {
        //    (int)AssertionType.Equal,
        //    (int)AssertionType.NotEqual,
        //    (int)AssertionType.LessThan,
        //    (int)AssertionType.GreaterThan
        //};
        //List<ColumnRule> listRules = new List<ColumnRule>();
        //public ColumnRuleSet()
        //{
        //}

        static bool isEqual(string in1, string in2)
        {
            return true;
        }

    }



    public static class Comparison
    {

        static bool str_IsEqual(string s1, string s2)
        {
            if (s1.Equals(s2, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            return false;
        }

        static bool str_IsNotEqual(string s1, string s2)
        {
            if (s1.Equals(s2, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            return true;
        }

        static bool str_regexMatch(string s1, string expression)
        {
            if (Regex.IsMatch(s1,expression,RegexOptions.IgnoreCase,TimeSpan.FromSeconds(10)))
            {
                return true;
            }
            return false;
        }
    }


    public static class SQLTypes
    {
        public static string DATETIME = "DATETIME";
        public static string DECIMAL  = "DECIMAL({2},{3})";
        public static string VARCHAR  = "VARCHAR({1})";
        public static string INT      = "INT";
    }

}
