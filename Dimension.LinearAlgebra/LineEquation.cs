using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dimension.data;

namespace Dimension.LinearAlgebra
{
    public enum Direction
    {
        upwards,
        downwards,
        left,
        right
    }

    public class LineEquation
    {
        //y=mx+c

        public int Slope; //(y2-y1)/(x2-x1)

        public int intercept; //Intersection with Y axis (or X axis if inverted)

        bool inverted = false; //Inverts operation in case the slope of the line is undefined
                              //facilitates drawing horizontal lines

        Point intialPoint;

        public int length;

        Direction monotony;
        int direction;

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
            CalculateIntercept();
            CalculateLength(a,b);
            CalculateDirection(a, b);
        }

        void CalculateIntercept()
        {
            if (!inverted)
            {
                intercept = (int)(intialPoint.y - (Slope * intialPoint.x));
            }
            else
            {
                //intercept = (int)(intialPoint.x-(intialPoint.y / Slope));
                intercept = (int)(intialPoint.x - (Slope * intialPoint.y));
            }
        }

        void CalculateLength(Point a,Point b) //Getting the distance between 2 points
        {
            int A = (int) Math.Pow((a.x - b.x), 2.0);
            int B = (int) Math.Pow((a.y - b.y), 2.0);
            length = (int) Math.Sqrt(A + B);
        }

        void CalculateDirection(Point a, Point b)
        {
            if (!inverted)
            {
                if (a.y > b.y)
                {
                    monotony = Direction.downwards;
                    direction = -1;
                }
                else if (a.y < b.y)
                {
                    monotony = Direction.upwards;
                    direction = 1;
                }
                else
                {
                    throw new Exception("Duplicate point exception");
                }
            }
            else
            {
                if (a.x > b.x)
                {
                    monotony = Direction.right;
                    direction = 1;
                }
                else if (a.y < b.y)
                {
                    monotony = Direction.left;
                    direction = -1;
                }
                else
                {
                    throw new Exception("Duplicate point exception");
                }
            }

        }

        public Point calculateNextPoint(Point P)
        {
            float nY, nX;
            if (!inverted)
            {
                nY = P.y + direction;
                nX = Map(nY);
            }
            else
            {
                nX = P.x + direction;
                nY = Map(nX);
            }
            return new Point(nY, nX, 0);
        }

        float Map(float i)
        {
            return i * Slope + intercept;
        }
    }
}
