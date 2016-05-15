using System;
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
            ValuesController controller = new ValuesController();
            IEnumerable <string> result = controller.Get("tea");
        }
    }
}
