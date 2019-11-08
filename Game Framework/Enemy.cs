using Game_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Framework
{
    class Enemy : Entity
    {
        private Direction _facing;
        public float Speed { get; set; } = .2f;

        public Enemy() : this("enemy.png")
        {
        }

        public Enemy(string imageName) : base('e', imageName)
        {
            _facing = Direction.North;
            OnUpdate += Move;
            OnUpdate += TouchPlayer;
        }

        public Enemy(char icon) : base(icon)
        {
            _facing = Direction.North;
            OnUpdate += Move;
            OnUpdate += TouchPlayer;
        }

        private void TouchPlayer()
        {
            List<Entity> touched;
            touched = MyScene.GetEntities(X, Y);
            bool hit = false;
            foreach (Entity e in touched)
            {
                if (e is Player)
                {
                    hit = true;
                    break;
                }
            }
            if (hit)
            {
                MyScene.RemoveEntity(this);
            }
        }

        private void Move()
        {
            //Rotation = 5;
            switch (_facing)
            {
                case Direction.North:
                    MoveUp();
                    break;
                case Direction.South:
                    MoveDown();
                    break;
                case Direction.East:
                    MoveRight();
                    break;
                case Direction.West:
                    MoveLeft();
                    break;
            }
        }

        private void MoveUp()
        {
            if (!MyScene.GetCollision(X, Y - Speed))
            {
                YVelocity = -Speed;
            }
            else
            {
                YVelocity = 0f;
                _facing++;
            }
        }

        private void MoveDown()
        {
            if (!MyScene.GetCollision(X, Y + Speed))
            {
                YVelocity = Speed;
            }
            else
            {
                YVelocity = 0f;
                _facing++;
            }
        }

        private void MoveRight()
        {
            if (!MyScene.GetCollision(X + Speed, Y))
            {
                XVelocity = Speed;
            }
            else
            {
                XVelocity = 0f;
                _facing++;
            }
        }

        private void MoveLeft()
        {
            if (!MyScene.GetCollision(X - Speed, Y))
            {
                XVelocity = -Speed;
            }
            else
            {
                XVelocity = 0f;
                _facing = Direction.North;
            }
        }
    }
}
