using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3.Game
{
    class GridScene
    {
        int Height, Width;
        List<GameObject> GridObjects;
        public void Update()
        {
            foreach (GameObject obj in GridObjects)
            {
                obj.Update();
                if (obj.Transform.X > Width || obj.Transform.X < 0 || obj.Transform.Y > Height || obj.Transform.Y < 0)
                    obj.OnBorderCrossing(Height,Width);
            }

            foreach(GameObject obj in GridObjects)
            {
                GameObject CollisionObject=GridObjects.Find(x => x.Transform.Equals(obj.Transform));
                if (CollisionObject != null)
                    obj.OnCollision(CollisionObject);
            }


        }
    }
}
