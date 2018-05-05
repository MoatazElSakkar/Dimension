using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dimension.data
{
    public class Point
    {
        public static float getDistance(Point a, Point b) //Gets Distance between 2 given points
        {
            float A = b.x - a.x;
            A *= A;
            float B = b.y - a.y;
            B *= B;
            float C = b.z - a.z;
            C *= C;
            return (float) Math.Sqrt(A + B + C);
        }

        public float x, y,z;

        public Point(float a, float b,float c)
        {
            x = a;
            y = b;
            z = c;
        }
    }
}
