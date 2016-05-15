using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Preprocessor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = System.IO.File.ReadAllLines(@"c:\\temp\\wordlist.txt");
            DataTable anagrams = new DataTable("Anagrams");
            DataColumn colIndex = new DataColumn("SortedKey");
            DataColumn colValue = new DataColumn("Word");
            anagrams.Columns.Add(colIndex);
            anagrams.Columns.Add(colValue);
            
            foreach (string word in words)
            {
                string w = (word.ToLower()).Trim();
                if (w.Length < 2 || System.Text.RegularExpressions.Regex.IsMatch(w, @"[^a-z]"))
                    continue;
                //end if

                string sorted = String.Concat(w.OrderBy(c => c));
                DataRow row = anagrams.NewRow();
                row[0] = sorted;
                row[1] = w;
                anagrams.Rows.Add(row);
            }//next

            XmlSerializer serializer = new XmlSerializer(typeof(DataTable));
            StreamWriter xmlFile = new StreamWriter(@"c:\\temp\\wordlist.xml");
            serializer.Serialize(xmlFile, anagrams);
        }//end Main
    }//end class
}//end namespace
