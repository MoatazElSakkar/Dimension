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

    }
}
