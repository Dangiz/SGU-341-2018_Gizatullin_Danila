using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3.Game
{
    public interface GameCharacter:GameObject
    {
        GridTransform Transform{ get; set;}
        int Health { get; set; }
        int Strength { get; set; }
  
    }
}
