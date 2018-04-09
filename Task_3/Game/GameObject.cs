using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3.Game
{
    public interface GameObject
    {
        void Start();
        void Update();
        void Destroy();
        void OnCollision(GameObject obj);
        void OnBorderCrossing(int Height,int Width);
        GridTransform Transform { get; set; }
    }
}
