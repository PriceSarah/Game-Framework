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

        public override string ToString()
        {
            return "{ " + x + ", " + y + " }";
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

        public float Dot(Vector2 rhs)
        {
            return x * rhs.x + y * rhs.y;
        }       

        public float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y);
        }

        public float MagnitudeSqr()
        {
            return (x * x + y * y);
        }

        public float Distance(Vector2 other)
        {
            float diffX = x - other.x;
            float diffY = y - other.y;

            return (float)Math.Sqrt(diffX * diffX + diffY * diffY);

        }

        public float DistanceSqr(Vector3 other)
        {
            float diffX = x - other.x;
            float diffY = y - other.y;

            return (diffX * diffX + diffY * diffY);

        }

        public void Normalize()
        {
            float m = Magnitude();
            this.x /= m;
            this.y /= m;
        }

        public Vector2 GetNormalised()
        {
            return (this / Magnitude());
        }

        public float Angle(Vector2 other)
        {
            Vector2 a = GetNormalised();
            Vector2 b = other.GetNormalised();
            return (float)Math.Acos(a.x * b.x + a.y * b.y);
        }

    }
}
