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
        [TestMethod()]
        public void YearValidationTest()
        {
            int year = 2010;
            bool actual = ValidationHelper.YearValidation(year);
            Assert.AreEqual(true, actual);
        }
        [TestMethod()]
        public void StringAlphaValidationTest()
        {
            string name = "History";
            int length = 70;
            bool actual = ValidationHelper.StringAlphaValidation(name,length);
            Assert.AreEqual(true, actual);
        }
        [TestMethod()]
        public void StringAlphaNumericValidationTest()
        {
            string name = "History2";
            int length = 70;
            bool actual = ValidationHelper.StringAlphaNumericValidation(name, length);
            Assert.AreEqual(true, actual);
        }
    }
}