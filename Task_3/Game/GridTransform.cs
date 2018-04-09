using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3.Game
{
    public enum Rotate { up, down, right, left };
    public class GridTransform
    {
        
        int x; int y;
        Rotate rotate;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        internal Rotate Rotate { get => rotate; set => rotate = value; }

        public bool Equals(GridTransform t)
        {
            return t.X == X && t.Y == y;
        }

    }
}
