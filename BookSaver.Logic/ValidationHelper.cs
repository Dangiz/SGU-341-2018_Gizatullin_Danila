using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookSaver.Logic
{
    public class ValidationHelper
    {
        private static Regex alphaAndNumbersRegex=new Regex(@"\A[a-zA-Z0-9 ]+\Z");
        private static Regex alphaRegex = new Regex(@"\A[a-zA-Z]+\Z");
        private static int minimumYear=1000;
        private static int maximumYear = 2018;

        public static bool YearValidation(int year)
        {
            return year >= minimumYear & year <= maximumYear;
        }

        public static bool StringAlphaNumericValidation(string name,int maxLength)
        {
            return !(String.IsNullOrEmpty(name) || name.Length >maxLength  || alphaAndNumbersRegex.Match(name).Length != name.Length);
        }

        public static bool StringAlphaValidation(string name, int maxLength)
        {
            return !(String.IsNullOrEmpty(name) || name.Length > maxLength || alphaRegex.Match(name).Length != name.Length);
        }

    }
}
