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
            Solid = true;
            Icon = '#';
        }
    }
}
