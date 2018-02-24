using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users
{
    
    public class User
    {

        private static bool StringIsCorrect(String s)
        {
            return s.All(c => Char.IsLetter(c));
        }
        protected string firstName;
        protected string surName;
        protected string middleName;
        protected DateTime birthDay;

        public int Age
        {
            get
            {
                return (int)DateTime.Now.Subtract(birthDay).TotalDays / 365;
            }
        }
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (!StringIsCorrect(value))
                    throw new FormatException("Строка имени содержит недопустимые символы");
                firstName=value;
            }
        }
        public string SurName
        {
            get
            {
                return surName;
            }
            set
            {
                if (!StringIsCorrect(value))
                    throw new FormatException("Строка имени содержит недопустимые символы");
                surName = value;
            }
        }
        public string MiddleName
        {
            get
            {
                return middleName;
            }
            set
            {
                if (!StringIsCorrect(value))
                    throw new FormatException("Строка имени содержит недопустимые символы");
                middleName = value;
            }
        }
        public DateTime BirthDay
        {
            get
            {
                return birthDay.Date;
            }
            set
            {
                birthDay = value.Date;
            }
        }

        public User(string firstName, string surName, string middleName, DateTime birthday)
        {
            FirstName = firstName;
            SurName = surName;
            MiddleName = middleName;
            BirthDay = birthday;
        }
        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3}", FirstName, SurName, MiddleName, BirthDay);
        }
    }
    public class Employee : User
    {
        private DateTime workday;
        private string position;

        public string Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }
        public DateTime WorkDay
        {
            get
            {
                return workday;
            }
            set
            {
                workday = value;
            }
        }



        public Employee
            (
            string firstName,
            string surName,
            string middleName,
            DateTime birthday,
            DateTime workday,
            string position
            ) : base(firstName, surName, middleName, birthday)
        {
            
        }
    }
}
