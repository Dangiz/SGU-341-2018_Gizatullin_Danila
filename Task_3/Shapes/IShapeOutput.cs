using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_3.Shapes;

namespace Task_3
{
    interface IShapeOutput
    {
        void Draw(IEnumerable<IShape> shapes);
        void Draw(IShape shape);
        //void CreateReactangle(Point A,Point B, Point C, Point D);
        //void CreateRing(Point center, int innerR, int outterR);
    }
}
