using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Framework
{
    class Vector3
    {
        public float x;
        public float y;
        public float z;

        public Vector3()
        {
            x = 0;
            y = 0;
            z = 0;
        }

        public Vector3(float newX, float newY, float newZ)
        {
            x = newX;
            y = newY;
            z = newZ;
        }


        public static Vector3 operator +(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
        }

        public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z + rhs.z);
        }

        public static Vector3 operator *(Vector3 vector, float scaler)
        {
            return new Vector3(vector.x * scaler, vector.y * scaler, vector.z * scaler);
        }

        public static Vector3 operator *( float scaler, Vector3 vector)
        {
            return new Vector3(scaler * vector.x, scaler * vector.y, scaler * vector.z);
        }

        public static Vector3 operator /(Vector3 vector, float scaler)
        {
            return new Vector3(vector.x / scaler, vector.y / scaler, vector.z / scaler);
        }

        public static Vector3 operator /(float scaler, Vector3 vector)
        {
            return new Vector3(scaler / vector.x, scaler / vector.y, scaler / vector.z);
        }

    }
}
