using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using RL = Raylib.Raylib;

namespace Game_Framework
{
    class Scene
    {
        private List<Entity> _entities = new List<Entity>();
        private List<Entity> _removals = new List<Entity>();
        private int _sizeX;
        private int _sizeY;

        public Event OnStart;
        public Event OnUpdate;
        public Event OnDraw;

        private bool[,] _collision;

        private List<Entity>[,] _tracking;

        public Scene() : this(6, 6)
        {
        }

        public Scene(int sizeX, int sizeY)
        {
            _sizeX = sizeX;
            _sizeY = sizeY;
            _collision = new bool[_sizeX, _sizeY];
            _tracking = new List<Entity>[_sizeX, _sizeY];
        }

        public int SizeX
        {
            get
            {
                return _sizeX;
            }
        }

        public int SizeY
        {
            get
            {
                return _sizeY;
            }
        }

        //int counter = 0;

        public void Start()
        {
            OnStart?.Invoke();
            foreach (Entity e in _entities)
            {
                e.Start();
            }
        }

        public void Update()
        {
            OnUpdate?.Invoke();

            //clear collision grid
            _collision = new bool[_sizeX, _sizeY];
            //claer the tracking grid
            for (int y = 0; y < _sizeY; y++)
            {
                for (int x = 0; x < _sizeX; x++)
                {
                    _tracking[x, y] = new List<Entity>();
                }
            }

            foreach (Entity e in _removals)
            {
                //remove e from _removals
                _entities.Remove(e);
            }
            _removals.Clear();
            //counter++;
            foreach (Entity e in _entities)
            {
                
                int x = (int)e.X;
                int y = (int)e.Y;
                if (x >= 0 && x < _sizeX && y >= 0 && y < _sizeY)
                {
                    //add the entity to the tracking array
                    _tracking[x, y].Add(e);
                    if (!_collision[x, y])
                    {
                        _collision[x, y] = e.Solid;
                    }
                }             
            }
            foreach (Entity e in _entities)
            {

                e.Update();
            }
        }

        public void Draw()
        {
            OnUpdate?.Invoke();

            //clear the screen
            Console.Clear();
            RL.ClearBackground(Color.BLACK);
            //Console.Write(counter);

            char[,] display = new char[_sizeX, _sizeY];

            foreach (Entity e in _entities)
            {
                
                //Position each Entity's icon in the display
                if (e.X >= 0 && e.X < _sizeX && e.Y >= 0 && e.Y < _sizeY)
                {
                    display[(int)e.X, (int)e.Y] = e.Icon;
                }
            }

            //Render the display grid to the screen
            for (int y = 0; y < _sizeY; y++)
            {

                for (int x = 0; x < _sizeX; x++)
                {
                    Console.Write(display[x, y]);
                    foreach (Entity e in _tracking[x, y])
                    {
                        RL.DrawTexture(e.Sprite, x * Game.SizeX, y * Game.SizeY, Color.WHITE);
                    }
                }
                Console.WriteLine();
            }

            foreach (Entity e in _entities)
            {

                e.Draw();
            }
        }

        //Add an Entity to the scene
        public void AddEntity(Entity entity)
        {
            _entities.Add(entity);
            entity.MyScene = this;
        }

        //Remove an Entity from the scene
        public void RemoveEntity(Entity entity)
        {
            _removals.Add(entity);
            entity.MyScene = null;
        }

        //Clear the scene of Entities
        public void ClearEntity(Entity entity)
        {
            foreach (Entity e in _entities)
            {
                RemoveEntity(e);
            }
           
        }
        //Returns whether there is a solid entity at this point
        public bool GetCollision(float x, float y)
        {
            if (x >= 0 && y >= 0 && x < _sizeX && y < _sizeY)
            {
                return _collision[(int)x, (int)y];
            }
            else
            {
                return true;
            }
        }
        public List<Entity> GetEntities(float x, float y)
        {
            if (x >= 0 && y >= 0 && x < _sizeX && y < _sizeY)
            {
                return _tracking[(int)x, (int)y];
            }
            else
            {
                return new List<Entity>();
            }
        }
    }
}
