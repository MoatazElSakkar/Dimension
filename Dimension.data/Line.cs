using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dimension.data
{
    public class Line:Bound
    {
        public int length; //Derived and stored for refrence
        public Line()
        {
            wireFrameSegment = new Point[2];
        }

        public Line(Point a,Point b) //entering the point co-ordinates directly
        {
            wireFrameSegment = new Point[2];
            wireFrameSegment[0] = a;
            wireFrameSegment[1] = b;
        }
    }
}
