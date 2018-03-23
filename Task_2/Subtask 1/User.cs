using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users
{

    public class User
    {
        #region Fields
        protected string firstName;
        protected string surName;
        protected string middleName;
        protected DateTime birthDay;
        #endregion
        #region properities
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
                if (string.IsNullOrEmpty(value?.Trim()))
                {
                    throw new ArgumentException("Неверное значение аргумента");
                }
                firstName = value;
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
                if (string.IsNullOrEmpty(value?.Trim()))
                {
                    throw new ArgumentException("Неверное значение аргумента");
                }
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
                if (string.IsNullOrEmpty(value?.Trim()))
                {
                    throw new ArgumentException("Неверное значение аргумента");
                }
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
                if (value == null)
                {
                    throw new NullReferenceException("Значение не может быть null");
                }
                birthDay = value.Date;
            }
        }
        #endregion
        #region Constructs
        public User(string firstName, string surName, string middleName, DateTime birthday)
        {
            FirstName = firstName;
            SurName = surName;
            MiddleName = middleName;
            BirthDay = birthday;
        }
        #endregion
        #region Methods
        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3}", FirstName, SurName, MiddleName, BirthDay);
        }
        #endregion
    }
    public class Employee : User
    {
        #region Fields
        protected DateTime workday;
        protected string position;
        #endregion
        #region proparties
        public string Position
        {
            get
            {
                return position;
            }
            set
            {
                if (string.IsNullOrEmpty(value?.Trim()))
                {
                    throw new ArgumentException("Неверное значение аргумента");
                }

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
                if (value == null)
                    throw new NullReferenceException("Значение не может быть null");
                if (value.CompareTo(BirthDay) != 1)
                    throw new FormatException("Дата поступления на работу раньше дня рождения");
                workday = value;
            }
        }
        public int WorkExp
        {
            get
            {
                return (int)DateTime.Now.Subtract(workday).TotalDays / 365;
            }
        }
        #endregion
        #region Constrctors
        public Employee(string firstName, string surName, string middleName, DateTime birthday, DateTime workday, string position) : base(firstName, surName, middleName, birthday)
        {
            WorkDay = workday;
            Position = position;
        }
        #endregion
        #region Methods
        public override string ToString()
        {
            return base.ToString() + " " + position + " стаж: " + WorkExp.ToString() + "лет";
        }
        #endregion
    }
}
