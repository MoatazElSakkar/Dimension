using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dimension.data;

namespace Dimension.LinearAlgebra
{
    public class LineEquation
    {
        //y=mx+c

        public int Slope; //(y2-y1)/(x2-x1)

        public int intercept; //Intersection with Y axis (or X axis if inverted)

        bool inverted = false; //Inverts operation in case the slope of the line is undefined
                              //facilitates drawing horizontal lines

        Point intialPoint;

        public LineEquation(Point a, Point b)
        {
            intialPoint = a;
            int yDelta=(int)(b.y - a.y);
            int xDelta=(int)(b.x - a.x);
            if (yDelta != 0)
            {
                Slope = yDelta / xDelta;
            }
            else
            {
                inverted = true;
                Slope = xDelta / yDelta;
            }
        }

        void CalculateIntercept()
        {
            if (!inverted)
            {
                intercept = (int)(intialPoint.y - (Slope * intialPoint.x));
            }
            else
            {
                intercept = (int)(intialPoint.x-(intialPoint.y / Slope));
            }
        }
    }
}
