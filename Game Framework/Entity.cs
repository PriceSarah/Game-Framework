using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using RL = Raylib.Raylib;

namespace Game_Framework
{

    delegate void Event();

    class Entity
    {
        public Event OnStart;
        public Event OnUpdate;
        public Event OnDraw;

        private Vector2 _location = new Vector2();

        public char Icon { get; set; } = ' ';

        public Texture2D Sprite { get; set; }

        public bool Solid { get; set; } = false;
        public float X
        {
            get
            {
                return _location.x;
            }
            set
            {
                _location.x = value;
            }
        }
        public float Y
        {
            get
            {
                return _location.y;
            }
            set
            {
                _location.y = value;
            }
        }

        private Scene _scene;
        public Scene MyScene
        {
            set
            {
                _scene = value;
            }
            get
            {
                return _scene;
            }
        }

        public Entity()
        {

        }
        public Entity(char icon)
        {
            Icon = icon;
        }

        public Entity(char icon, string imageName) : this(icon)
        {
            Sprite = RL.LoadTexture(imageName);
        }
        public void Start()
        {
            OnStart?.Invoke();
        }

        public void Update()
        {
            OnUpdate?.Invoke();
        }
        public void Draw()
        {
            OnDraw?.Invoke();
        }
    }
}
