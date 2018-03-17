using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3.Shapes
{
    public struct Point
    {

        public int X { get; set;}
        public int Y { get; set; }
        public override string ToString()
        {
            return $"X:{X} Y:{Y}";
        }
        public Point(int x,int y)
        {
            X = x;
            Y = y;
        }
    }

}
