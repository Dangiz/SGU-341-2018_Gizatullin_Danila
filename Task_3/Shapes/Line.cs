using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3.Shapes
{
    public class Line:IShape
    {

        Point Start { get; set; }
        Point End { get; set; }

        public string GetDescription()
        {
            return $"Line with points: {Start} {End}";
        }

        public Line(Point start, Point end)
        {
            Start = start;
            End = end;
        }

    }
}
