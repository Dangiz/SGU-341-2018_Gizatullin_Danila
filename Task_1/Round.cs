using System;

namespace Task_1
{
    public class Round
    {
        private double r;
        
        public double X { get; set; }
        public double Y { get; set; }
        public double R
        {
            get
            {
                return r;
            }
            set
            {
                if (value < 0)
                {
                    throw new FormatException("Attempting assigment a negative radius");
                }
                    
                r = value;
            }
        }

        public double Length
        {
            get { return 2 * r * Math.PI; }
        }

        public double Space
        {
            get { return Math.Pow(r, 2) * Math.PI; }
        }

        public Round(double radius, double x, double y)
        {
            R = radius;
            X = x;
            Y = y;
        }
        
        
    }
}