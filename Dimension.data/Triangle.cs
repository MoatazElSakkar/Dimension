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
            wireframeSegment[0] = new Point(a.x,a.y,a.z);
            wireframeSegment[1] = new Point(b.x,b.y,b.z);
            wireframeSegment[2] = new Point(c.x,c.y,c.z);
        }

        public Triangle(Point[] Entry)
        {
            if (!AssertCyclicFeature(Entry))
            {
                throw new Exception("Invalid Triangle intialization");
            }
            wireframeSegment = Entry;
        }

        public Triangle(Point[] Entry,int i_ID)
        {
            if (!AssertCyclicFeature(Entry))
            {
                throw new Exception("Invalid Triangle intialization");
            }
            ID = i_ID;
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
