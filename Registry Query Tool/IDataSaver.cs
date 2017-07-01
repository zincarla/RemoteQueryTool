using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Resources;
using System.Reflection;

namespace Remote_Query_Tool
{
    /// <summary>
    /// Provides a generic interface to save outputted data in different formats
    /// </summary>
    public interface IDataSaver
    {
        bool Init(string path, string[] columnnames);
        bool Write(string[] data);
        bool Finish();
    }
    /// <summary>
    /// Saves data in a tab delimited format
    /// </summary>
    public class TabDelimitedSaver : IDataSaver
    {
        #region IDataSaver Members

        string Path = "";
        StreamWriter SW;
        string T = "\t";
        bool started = false;
        public bool Init(string path, string[] columnnames)
        {
            Path = path;
            SW = new StreamWriter(Path);
            started = true;
            int pos = 0;
            while (pos < columnnames.Length)
            {
                SW.Write(columnnames[pos].Replace(T, "").Replace("\r\n", ""));

                pos++;
                if (pos < columnnames.Length)
                {
                    SW.Write(T);
                }
            }
            SW.Write("\r\n");

            return true;
        }

        public bool Write(string[] row)
        {
            int pos = 0;
            while (pos < row.Length)
            {
                SW.Write(row[pos].Replace(T, "").Replace("\r\n", ""));

                pos++;
                if (pos < row.Length)
                {
                    SW.Write(T);
                }
            }
            SW.Write("\r\n");

            return true;
        }

        public bool Finish()
        {
            SW.Flush();
            SW.Close();
            started = false;
            return true;
        }

        #endregion
    }

    /// <summary>
    /// Saves data in a XML delimited format
    /// </summary>
    public class XMLSaver : IDataSaver
    {
        #region IDataSaver Members

        string Path = "";
        StreamWriter SW;
        bool started = false;
        ResourceManager RM;
        public bool Init(string path, string[] columnnames)
        {
            RM = new ResourceManager("Remote_Query_Tool.Properties.Resources", Assembly.GetExecutingAssembly());
            Path = path;
            SW = new StreamWriter(Path);
            started = true;

            SW.Write(RM.GetString("XMLHeader"));

            SW.WriteLine("<Row>");
            int pos = 0;
            while (pos < columnnames.Length)
            {
                SW.Write("<Cell ss:StyleID=\"s16\"><Data ss:Type=\"String\">" + columnnames[pos].Replace("\r\n", "&#10;").Replace("<", "&lt;").Replace(">", "&gt;") + "</Data></Cell>");
                pos++;
            }
            SW.WriteLine("</Row>");
            return true;
        }

        public bool Write(string[] row)
        {
            int pos = 0;
            SW.WriteLine("<Row>");
            while (pos < row.Length)
            {
                SW.WriteLine("<Cell ss:StyleID=\"s17\"><Data ss:Type=\"String\">" + row[pos].Replace("\r\n", "&#10;").Replace("<", "&lt;").Replace(">", "&gt;") + "</Data></Cell>");
                pos++;
            }
            SW.WriteLine("</Row>");

            return true;
        }

        public bool Finish()
        {
            SW.Write(RM.GetString("XMLFinisher"));
            SW.Flush();
            SW.Close();
            started = false;
            return true;
        }

        #endregion
    }

    /// <summary>
    /// Saves data in a CSV delimited format
    /// </summary>
    public class CSVSaver : IDataSaver
    {
        #region IDataSaver Members

        string Path = "";
        StreamWriter SW;
        bool started = false;

        private string CleanForCSV(string ToClean)
        {
            ToClean = ToClean.Replace("\"", "\"\"").Replace("\r\n", "\n");
            if (ToClean.Contains(",") || ToClean.Contains("\n"))
            {
                ToClean = "\"" + ToClean + "\"";
            }
            return ToClean;
        }

        public bool Init(string path, string[] columnnames)
        {
            Path = path;
            SW = new StreamWriter(Path);
            started = true;
            int pos = 0;
            while (pos < columnnames.Length)
            {
                SW.Write(CleanForCSV(columnnames[pos]));

                pos++;
                if (pos < columnnames.Length)
                {
                    SW.Write(",");
                }
            }
            SW.Write("\r\n");

            return true;
        }

        public bool Write(string[] row)
        {
            int pos = 0;
            while (pos < row.Length)
            {
                SW.Write(CleanForCSV(row[pos]));

                pos++;
                if (pos < row.Length)
                {
                    SW.Write(",");
                }
            }
            SW.Write("\r\n");

            return true;
        }

        public bool Finish()
        {
            SW.Flush();
            SW.Close();
            started = false;
            return true;
        }

        #endregion
    }
}
