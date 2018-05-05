using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dimension.data
{
    public enum Dimension
    {
        X,Y,Z
    }

    public class Structure : IComparable<Structure>
    {
        public List <Triangle> WireFrame;

        public System.Drawing.Color StructureColor;

        public Point CenterPoint=new Point(0,0,0); //avg of all points a 3D space center

        public int ID;

        //in case of a shape these 2 functions operate on morphs/Lines
        //However in case of structure composition they operate on shapes

        public float getMaxZScore()
        {
            float curMax = float.MinValue;

            foreach (Triangle T in WireFrame)
            {
                foreach (Point P in T.wireframeSegment)
                {
                    if (P.z > curMax)
                    {
                        curMax = P.z;
                    }
                }
            }

            return curMax;
        }

        public void updateCenterPoint() //assigns the average of all points to centerPoint
        {
            throw new NotImplementedException();
        }

        public virtual int bind(object S) //You create a shape/Bound you get a refrence ID
        {
            throw new NotImplementedException();
        }

        public virtual object unbind(int i) //you destroy a shape/Bound you get a copy
        {
            throw new NotImplementedException();
        }

        public int CompareTo(Structure other)
        {
            float diff = getMaxZScore() - other.getMaxZScore();
            if(Math.Abs(diff) <= 1e-9) return 0;
            return diff < 0?-1:1;
        }

        //Lists to track transformations - easier to work with when applying textures
        //Alternative is to store 2 wireframes an original and a modified
        public Dictionary<Dimension, Angle> Rotation = new Dictionary<Dimension, Angle>
        {
            {Dimension.X,new Angle(0)},
            {Dimension.Y,new Angle(0)},
            {Dimension.Z,new Angle(0)}
        };

        public Dictionary<Dimension, int> Scaling = new Dictionary<Dimension, int>
        {
            {Dimension.X,0},
            {Dimension.Y,0},
            {Dimension.Z,0}
        };
    }
}
