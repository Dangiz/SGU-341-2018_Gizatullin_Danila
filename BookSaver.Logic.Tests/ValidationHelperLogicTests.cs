using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookSaver.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaver.Logic.Tests
{
    [TestClass()]
    public class ValidationHelperLogicTests
    {
        public TestContext TestContext {get; set;}
        [TestMethod()]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "testData.xml", "year", DataAccessMethod.Sequential)]
        public void YearValidationTest()
        {
            int year = Convert.ToInt32(TestContext.DataRow["number"]);
            bool expected = Convert.ToBoolean(TestContext.DataRow["expected"]);
            bool actual = ValidationHelper.YearValidation(year);
            Assert.AreEqual(expected, actual);
        }
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "testData.xml", "alphaWord", DataAccessMethod.Sequential)]
        [TestMethod()]
        public void StringAlphaValidationTest()
        {
            string name = Convert.ToString(TestContext.DataRow["name"]);
            int length = Convert.ToInt32(TestContext.DataRow["length"]);
            bool expected = Convert.ToBoolean(TestContext.DataRow["expected"]);
            bool actual = ValidationHelper.StringAlphaValidation(name,length);
            Assert.AreEqual(expected, actual);
        }
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML","testData.xml","alphaNumericWord",DataAccessMethod.Sequential)]
        [TestMethod()]
        public void StringAlphaNumericValidationTest()
        {
            string name = Convert.ToString(TestContext.DataRow["name"]);
            int length = Convert.ToInt32(TestContext.DataRow["length"]);
            bool expected = Convert.ToBoolean(TestContext.DataRow["expected"]);
            bool actual = ValidationHelper.StringAlphaNumericValidation(name, length);
            Assert.AreEqual(expected, actual);
        }
    }
}