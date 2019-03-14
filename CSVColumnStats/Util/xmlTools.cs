using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace CSVColumnStats
{
    public static class xmlTools
    {
        

        //Returns the target namespace for the serializer.
        public static string TargetNamespace { get { return @"http://www.w3.org/2001/XMLSchema"; } }

        public static XmlSerializerNamespaces GetNamespaces()
        {

            XmlSerializerNamespaces ns;
            ns = new XmlSerializerNamespaces();
            ns.Add("xs", "http://www.w3.org/2001/XMLSchema");
            ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            return ns;

        }

        //Creates an object from an XML string.
        public static object FromXml(string Xml, System.Type ObjType)
        {

            XmlSerializer ser;
            ser = new XmlSerializer(ObjType, TargetNamespace);
            StringReader stringReader;
            stringReader = new StringReader(Xml);
            XmlTextReader xmlReader;
            xmlReader = new XmlTextReader(stringReader);
            object obj;
            obj = ser.Deserialize(xmlReader);
            xmlReader.Close();
            stringReader.Close();
            return obj;

        }

        //Serializes the <i>Obj</i> to an XML string.
        public static string ToXml(object Obj, System.Type ObjType)
        {

            XmlSerializer ser;
            ser = new XmlSerializer(ObjType, TargetNamespace);
            MemoryStream memStream;
            memStream = new MemoryStream();
            XmlTextWriter xmlWriter;
            xmlWriter = new XmlTextWriter(memStream, Encoding.UTF8);
            xmlWriter.Namespaces = true;
            xmlWriter.Formatting = Formatting.Indented;
            ser.Serialize(xmlWriter, Obj, GetNamespaces());
            xmlWriter.Close();
            memStream.Close();
            string xml;
            xml = Encoding.UTF8.GetString(memStream.GetBuffer());
            xml = xml.Substring(xml.IndexOf(Convert.ToChar(60)));
            xml = xml.Substring(0, (xml.LastIndexOf(Convert.ToChar(62)) + 1));
            return xml;

        }

        //Serializes a CSVFile Object
        public static string SerializeCSVFile(CSVFile csvF)
        {
            return xmlTools.ToXml(csvF, typeof(CSVFile));
        }

        //Deserializes a CSVFile Object
        public static CSVFile DeserializeCSVFile(string csvFileXML)
        {
            return (CSVFile)xmlTools.FromXml(csvFileXML, typeof(CSVFile));
        }

        public static string FindXPath(XmlNode node)
        {
            StringBuilder builder = new StringBuilder();
            while (node != null)
            {
                switch (node.NodeType)
                {
                    case XmlNodeType.Attribute:
                        builder.Insert(0, "/@" + node.Name);
                        node = ((XmlAttribute)node).OwnerElement;
                        break;
                    case XmlNodeType.Element:
                        int index = FindElementIndex((XmlElement)node);
                        builder.Insert(0, "/" + node.Name + "[" + index + "]");
                        node = node.ParentNode;
                        break;
                    case XmlNodeType.Document:
                        return builder.ToString();
                    default:
                        return "";
                }
            }
            throw new ArgumentException("Node was not in a document");
        }

        private static int FindElementIndex(XmlElement element)
        {
            XmlNode parentNode = element.ParentNode;
            if (parentNode is XmlDocument)
            {
                return 1;
            }
            XmlElement parent = (XmlElement)parentNode;
            int index = 1;
            foreach (XmlNode candidate in parent.ChildNodes)
            {
                if (candidate is XmlElement && candidate.Name == element.Name)
                {
                    if (candidate == element)
                    {
                        return index;
                    }
                    index++;
                }
            }
            throw new ArgumentException("Couldn't find element within parent");
        }

        public static bool updateNodeAttribute(XmlDocument xml_doc, string AttrXPath, string value)
        {
            var nsmgr = new XmlNamespaceManager(xml_doc.NameTable);
            nsmgr.AddNamespace("DTS", "www.microsoft.com/SqlServer/Dts");

            string[] array = AttrXPath.Split('@');
            XmlElement xml_node = (XmlElement)xml_doc.SelectSingleNode(array[0].TrimEnd('/'), nsmgr);
            if (xml_node != null)
            {
                xml_node.SetAttribute(array[1], value);
                return true;
            }
            return false;
        }

        public static Dictionary<string, object> AddDefaultIfNonExist(this Dictionary<string, object> dict, List<string> ListKeys, object defaultValue)
        {
            foreach (string key in ListKeys)
            {
                if (!dict.ContainsKey(key))
                    dict.Add(key, defaultValue);
            }
            return dict;
        }

        public static DataTable ConvertToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }

        // Verifies string input in txt_xmlPath (textBox)
        // Returns file path if valid
        // Returns emptystring if invalid
        public static string getVerifiedFilePath(string path)
        {
            string txtFile = path.Replace("\"", "");
            if (TryParseXmlPath(txtFile))
            {
                return txtFile;
            }
            return string.Empty;
        }

        private static bool TryParseXmlPath(string strxml)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(strxml);
                return true;
            }
            catch (XmlException e)
            {
                Console.WriteLine("File supplied is not XML");
                return false;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Please enter a valid XML file path.");
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Please enter a valid XML file path.");
                return false;
            }
        }

        public static string strUTF8ToChar(this string utf8Code)
        {
            var strArray = utf8Code.Replace("__", ",").Split(',');
            var charArray = new char[10];
            var SB = new StringBuilder();

            Encoding enc = Encoding.GetEncoding("UTF-8");
            for (int i = 0; i < strArray.Length; i++)
            {
                charArray[i] = (char)Int16.Parse(
                    strArray[i].Replace("_", "").Replace("x", ""), NumberStyles.AllowHexSpecifier);
                switch (charArray[i])
                {
                    case '\r': { SB.Append("{CR}"); break; }
                    case '\n': { SB.Append("{LF}"); break; }
                }

            }
            if (SB.Length > 0)
                return SB.ToString();
            return new string(charArray);

        }

    }
}
