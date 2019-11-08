using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
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

        protected Entity _parent = null;
        protected List<Entity> _children = new List<Entity>(); 

        //private Vector3 _location = new Vector3(0, 0, 1);
        //The Velocity of the entity
        private Vector2 _velocity = new Vector2();
        //private Matrix3 _transform = new Matrix3();
        //private Matrix3 _translation = new Matrix3();
        //private Matrix3 _rotation = new Matrix3();
        //private Matrix3 _scale = new Matrix3();
        //private float _scale = 1.0f;
        private Matrix3 _localTransform = new Matrix3();
        private Matrix3 _globalTransform = new Matrix3();

        public char Icon { get; set; } = ' ';

        public Texture2D Sprite { get; set; }

        public bool Solid { get; set; } = false;

        public float OriginX { get; set; } = 0;
        public float OriginY { get; set; } = 0;
        public float X
        {
            get
            {
                return _localTransform.m13;
            }
            set
            {
                _localTransform.SetTranslation(value, Y, 1);
                UpdateTransform();
            }
        }

        public float XAbsolute
        {
            get { return _globalTransform.m13; }
        }
        public float Y
        {
            get
            {
                return _localTransform.m23;
            }
            set
            {
                _localTransform.SetTranslation(X, value, 1);
                UpdateTransform();
            }
        }

        public float YAbsolute
        {
            get { return _globalTransform.m23; }
        }
        public float XVelocity
        {
            get
            {
                return _velocity.x;
                //return _translation.m31;
                
            }
            set
            {
                _velocity.x = value;
                //_translation.SetTranslation(value, YVelocity, 1);
            }
        }

        public float YVelocity
        {
            get
            {
                return _velocity.y;
                //return _translation.m32;
            }
            set
            {
                _velocity.y = value;
                //_translation.SetTranslation(XVelocity, value, 1);
            }
        }

        public float Size
        {
            get
            {
                //return _translation.m11;
                //return _scale;
                return 1;
            }
            //set
            //{
            //    _localTransform.SetScaled(value, value, 1);
            //    //_scale = value;

            //}
        }

        public float Rotation
        {
            get
            {
                return (float)Math.Atan2(_localTransform.m21, _localTransform.m11);
            }
            set
            {
                _localTransform.SetRotateZ(value);
            }

        }



        private Scene _scene;
        public Scene MyScene { get; set; }

        public Entity Parent
        {
            get
            {
                return _parent;
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

        ~Entity()
        {
            if (_parent != null)
            {
                _parent.RemoveChild(this);
            }

            foreach (Entity e in _children)
            {
                e._parent = null;
            }
        }

        public int GetChildCount()
        {
            return _children.Count;
        }

        public Entity GetChild(int index)
        {
            return _children[index];
        }

        public void AddChild(Entity child)
        {
            //Make sure the child doesn't already have a parent
            Debug.Assert(child._parent == null);
            //Assign this Entity as the childs parent
            child._parent = this;
            //Add child to collection
            _children.Add(child);
        }

        public void RemoveChild(Entity child)
        {
            
            bool isMyChild = _children.Remove(child);
            if (isMyChild)
            {
                child._parent = null;
            }
        }

        public void Scale(float width, float height)
        {
            _localTransform.Scale(width, height, 1);
            UpdateTransform();
        }

        public void Rotate(float radians)
        {
            _localTransform.RotateZ(radians);
            UpdateTransform();
        }

        protected void UpdateTransform()
        {
            if (Parent != null)
            {
                _globalTransform = _parent._globalTransform * _localTransform;
            }
            else
            {
                _globalTransform = _localTransform;
            }

            foreach (Entity child in _children)
            {
                child.UpdateTransform();
            }
        }

        public void Start()
        {
            OnStart?.Invoke();
        }

        //Call the entity's OnUpdate event
        public void Update()
        {
            //Matrix3 transform = _translation * _rotation;
            //_location += _velocity;
            //_location = transform * _location;
            X += _velocity.x;
            Y += _velocity.y;
            OnUpdate?.Invoke();
        }
        public void Draw()
        {
            OnDraw?.Invoke();
        }
    }
}
