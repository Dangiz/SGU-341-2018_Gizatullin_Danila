using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3.Game.Models
{
    class PlayerCharacter : GameCharacter
    {
        public GridTransform Transform { get; set; }
        public int Health { get; set; }
        public int Strength { get; set; }

        public void Destroy()
        {
            throw new NotImplementedException();
        }

        public void OnBorderCrossing(int Height, int Width)
        {
            throw new NotImplementedException();
        }

        public void OnCollision(GameObject obj)
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            //Input & Transform logic
            throw new NotImplementedException();
        }
    }
}
