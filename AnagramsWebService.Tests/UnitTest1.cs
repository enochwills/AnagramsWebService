using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnagramsWebService.Controllers;

namespace AnagramsWebService.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ValuesController controller = new ValuesController(@"c:\\temp\\wordlist.txt");
            for (int i = 1; i < 18; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    string word = RandomString(i);
                    controller.Get(word);
                }
            }
        }
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz`~!@#$%^&*()_+[]|,.<>/?";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
