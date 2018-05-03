using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dimension.data
{
    class Triangle
    {
        public Point[] Wireframe =new Point[3];


        public Triangle(Point a, Point b, Point c)
        {
            Wireframe[0] = a;
            Wireframe[1] = b;
            Wireframe[2] = c;
        }
    }
}
