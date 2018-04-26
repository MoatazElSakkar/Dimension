using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dimension.data
{
    class Morph:Bound
    {
        public float height;

        public Morph()
        {
            wireFrameSegment = new Point[4];
        }

        public Morph(Point a,Point b, Point h1,Point h2) //entering the point co-ordinates directly
        {
            wireFrameSegment = new Point[4];
            wireFrameSegment[0] = a;
            wireFrameSegment[1] = b;
            wireFrameSegment[3] = h1;
            wireFrameSegment[4] = h2;
        }
    }
}
