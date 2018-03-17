using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3.Shapes
{
    public class Round : IShape
    {
        private int r;

        public Point Center { get; set; }
        public int R
        {
            get
            {
                return r;
            }
            set
            {
                if (R < 0)
                    throw new ArgumentException();
                r = value;
            }
        }
        public Round(Point center, int r)
        {
            Center = center;
            R = r;
        }

        public string GetDescription()
        {
            return $"Round with center point:{Center} of radius: {R}";
        }

    }
}
