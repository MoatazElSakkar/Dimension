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

        public static Point crossProduct(Point a, Point b)
        {
            Point c = new Point();
            c.x = a.y * b.z - a.z * b.y;
            c.y = a.z * b.x - a.x * b.y;
            c.z = a.x * b.y - a.y * b.x;
            return c;
        }

        public static float dotProduct(Point a, Point b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z;
        }

        public static Point operator-(Point a, Point b)
        {
            return new Point(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        public static Point operator+(Point a, Point b)
        {
            return new Point(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        public static Point operator*(Point p, float c)
        {
            return new Point(p.x * c, p.y * c, p.z * c);
        }

        public static Point operator/(Point p, float c)
        {
            return new Point(p.x / c, p.y / c, p.z / c);
        }

        public float x, y,z;

        public Point(float a, float b,float c)
        {
            x = a;
            y = b;
            z = c;
        }

        public Point()
        {
            x = 0;
            y = 0;
            z = 0;
        }
    }
}
