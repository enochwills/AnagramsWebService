using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AnagramsWebService.Controllers
{
    public class ValuesController : ApiController
    {
        private SortedDictionary<string, List<string>> anagrams = new SortedDictionary<string, List<string>>();

        private void init(string fullPath)
        {
            string[] words = System.IO.File.ReadAllLines(fullPath);
            foreach (string word in words)
            {
                string w = (word.ToLower()).Trim();
                if (w.Length < 2 || System.Text.RegularExpressions.Regex.IsMatch(w, @"[^a-z]"))
                    continue;
                //end if

                string sorted = String.Concat(w.OrderBy(c => c));

                if (anagrams.ContainsKey(sorted))
                {
                    List<string> list = anagrams[sorted];
                    list.Add(w);
                }
                else
                {
                    List<string> list = new List<string>();
                    list.Add(w);
                    anagrams.Add(sorted, list);
                }//end if
            }//next
        }
        public ValuesController()
        {
            string fullPath = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/wordlist.txt");
            init(fullPath);
        }
        public ValuesController(string fullPath)
        {
            init(fullPath);
        }

        public IEnumerable<string> Get(string word)
        {
            string w = (word.ToLower()).Trim();
            if (w.Length < 2 || w.Length > 17 || System.Text.RegularExpressions.Regex.IsMatch(w, @"[^a-z]"))
                return null;
            //end if
            string sorted = String.Concat(w.OrderBy(c => c));
            if (anagrams.ContainsKey(sorted))
            {
                List<string> list = anagrams[sorted];
                List<string> clone = new List<string>(list.ToArray());
                clone.RemoveAt(clone.IndexOf(w));
                return clone.ToArray();
            }
            else
            {
                return null;
            }//end if
        }
    }
}
