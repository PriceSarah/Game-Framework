using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Framework
{
    class Wall : Entity
    {
        public Wall(int x, int y) : base(' ', "wall.png")
        {
            X = x;
            Y = y;
            OriginX = 16;
            OriginY = 16;
            Solid = true;
            Icon = '#';
            OnUpdate += spin;
        }

        void spin()
        {
            // Rotation = 0.01f;
            //Rotate(100f);
        }
    }
}
