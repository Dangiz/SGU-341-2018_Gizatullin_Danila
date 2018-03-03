using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingClass
{
    public class Ring
    {
        #region Fields
        private double x, y;
        private double innerR, outerR;
        #endregion
        #region Properities
        public double X
        {
            set
            {
                if (double.IsNaN(value) || double.IsInfinity(value))
                {
                    throw new ArgumentException("Значение аргумента не являеся числом, либо бесконечно");
                }
                x = value;
            }
            get
            {
                return x;
            }
        }
        public double Y
        {
            set
            {
                if (double.IsNaN(value) || double.IsInfinity(value))
                {
                    throw new ArgumentException("Значение аргумента не являеся числом, либо бесконечно");
                }
                y = value;
            }
            get
            {
                return y;
            }
        }
        public double InnerR
        {
            get
            {
                return innerR;
            }
            set
            {
                if (double.IsNaN(value) || double.IsInfinity(value))
                {
                    throw new ArgumentException("Значение аргумента не являеся числом, либо бесконечно");
                }
                if (value<0)
                {
                    throw new ArgumentException("Значение аргумента не может быть отрицательным числом");
                }
                if(value>OuterR)
                {
                    throw new ArgumentException("Внутренний радиус кольца не может превышать внешний");
                }
                innerR = value;
            }
        }
        public double OuterR
        {
            get
            {
                return outerR;
            }
            set
            {              
                if (double.IsNaN(value) || double.IsInfinity(value))
                {
                    throw new ArgumentException("Значение аргумента не являеся числом, либо бесконечно");
                }
                if(value<0)
                {
                    throw new ArgumentException("Значение аргумента не может быть отрицательным числом");
                }
                if (value < InnerR)
                {
                    throw new ArgumentException("Внутренний радиус кольца не может превышать внешний");
                }
                outerR = value;
            }
        }
        public double Area
        {
            get
            {
                return Math.PI * Math.Pow(OuterR, 2) - Math.PI * Math.Pow(InnerR, 2);
            }
        }
        public double Length
        {
            get
            {
                return 2 * Math.PI * (OuterR + InnerR);
            }
        }
        #endregion
        #region Constuctors
        public Ring(double x,double y,double innerR,double outerR)
        {
            X = x;
            Y = y;
            OuterR = outerR;
            InnerR = innerR;
        }
        #endregion
        #region Methods
        public void SetRads(double innerR,double outerR)
        {
            InnerR = 0;
            OuterR = outerR;
            InnerR = innerR;
        }
        public override string ToString()
        {
            return String.Format("Ring on {0} {1} with InnerR: {2} OuterR: {3}", X, Y, InnerR, OuterR);
        }
        #endregion
    }

}
