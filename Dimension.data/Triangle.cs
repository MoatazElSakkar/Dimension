using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dimension.data
{
    public class Triangle
    {
        public Point[] wireframeSegment =new Point[3];

        public int ID;

        public Triangle(Point a, Point b, Point c)
        {
            if (!AssertCyclicFeature(a, b, c))
            {
                throw new Exception("Invalid Triangle intialization");
            }
            wireframeSegment[0] = a;
            wireframeSegment[1] = b;
            wireframeSegment[2] = c;
        }

        public Triangle(Point[] Entry)
        {
            if (!AssertCyclicFeature(Entry))
            {
                throw new Exception("Invalid Triangle intialization");
            }
            wireframeSegment = Entry;
        }

        bool AssertCyclicFeature(Point a,Point b,Point c)
        {
            //check if a b c are actually connected
            return true;
        }

        bool AssertCyclicFeature(Point[] Entry)
        {
            if (Entry.Length != 3)
            {
                return false;
            }

            //check if a b c are actually connected

            return true;
        }
    }
}
