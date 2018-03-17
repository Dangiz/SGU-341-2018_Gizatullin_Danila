using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3.Shapes
{
    class ShapeConsoleOutput:IShapeOutput
    {
       public void Draw(IEnumerable<IShape> shapes)
        {
            foreach(IShape shape in shapes)
            {
                Console.WriteLine(shape.GetDescription());
            }
        }

        public void Draw(IShape shape)
        {
            Console.Write(shape);
        }
        

    }
}
