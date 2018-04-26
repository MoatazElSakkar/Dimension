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
            throw new NotImplementedException();
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
