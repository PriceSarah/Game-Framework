using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Framework
{
    class Vector2
    {

        public float x;
        public float y;

        public Vector2()
        {
            x = 0;
            y = 0;
        }

        public Vector2(float newX, float newY)
        {
            x = newX;
            y = newY;
        }


        public static Vector2 operator +(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.x + rhs.x, lhs.y + rhs.y);
        }

        public static Vector2 operator -(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.x - rhs.x, lhs.y - rhs.y);
        }

        public static Vector2 operator *(Vector2 vector, float scaler)
        {
            return new Vector2(vector.x * scaler, vector.y * scaler);
        }

        public static Vector2 operator *(float scaler, Vector2 vector)
        {
            return new Vector2(scaler * vector.x, scaler * vector.y);
        }

        public static Vector2 operator /(Vector2 vector, float scaler)
        {
            return new Vector2(vector.x / scaler, vector.y / scaler);
        }

        public static Vector2 operator /(float scaler, Vector2 vector)
        {
            return new Vector2(scaler / vector.x, scaler / vector.y);
        }
    }
}
