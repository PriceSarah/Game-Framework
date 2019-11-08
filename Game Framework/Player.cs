using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Game_Framework
{
    class Player : Entity
    {

        private PlayerInput _input = new PlayerInput();

        public Player() : this("player.png")
        {

        }

        public Player(string imageName) : base('@', imageName)
        {
            _input.AddKeyEvent(MoveRight, 100); //D
            _input.AddKeyEvent(MoveLeft, 97); //A
            _input.AddKeyEvent(MoveUp, 119); //W
            _input.AddKeyEvent(MoveDown, 115); //S
            OnUpdate += _input.ReadKey;
            OnUpdate += Orbit;
        }

        private void Orbit()
        {
            foreach (Entity child in _children)
            {
                child.Rotate(1.0f);
            }
        }

        public Player(char icon) : base(icon)
        {
            _input.AddKeyEvent(MoveRight, 100); //D
            _input.AddKeyEvent(MoveLeft, 97); //A
            _input.AddKeyEvent(MoveUp, 119); //W
            _input.AddKeyEvent(MoveDown, 115); //S
        }

        //Move one space to the right
        private void MoveRight()
        {
            if (X + 1 >= MyScene.SizeX)
            {
                if (MyScene is Room)
                {
                    Room dest = (Room)MyScene;
                    Travel(dest.East);
                }
                X = 0;
            }
            else if (!MyScene.GetCollision(X + 1, Y))
            {
                X++;
            }
        }

        //Move one space to the left
        private void MoveLeft()
        {
            if (X - 1 < 0)
            {
                if (MyScene is Room)
                {
                    Room dest = (Room)MyScene;
                    Travel(dest.West);
                }
                X = MyScene.SizeX - 1;
            }
            else if (!MyScene.GetCollision(X - 1, Y))
            {
                X--;
            }
        }

        //Move one space up
        private void MoveUp()
        {
            if (Y - 1 < 0)
            {
                if (MyScene is Room)
                {
                    Room dest = (Room)MyScene;
                    Travel(dest.North);
                }
                Y = MyScene.SizeY - 1;
            }
            else if (!MyScene.GetCollision(X, Y - 1))
            {
                Y--;
            }
        }

        //Move one space up
        private void MoveDown()
        {
            if (Y + 1 >= MyScene.SizeY)
            {
                if (MyScene is Room)
                {
                    Room dest = (Room)MyScene;
                    Travel(dest.South);
                }
                Y = 0;
            }
            else if (!MyScene.GetCollision(X, Y + 1))
            {
                Y++;
            }
        }

        //move the player from one room to another
        private void Travel(Room destination)
        {
            if (destination == null)
            {
                return;
            }

            MyScene.RemoveEntity(this);
            destination.AddEntity(this);
            Game.CurrentScene = destination;
        }
    }
}
