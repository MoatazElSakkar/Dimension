using System;
using System.Collections.Generic;
using Dimension.data;
using Dimension.LinearAlgebra;

namespace Dimension.simulator
{
    public enum Transformation
    {
        Translation,
        Rotation,
        Scaling
    }

    
    public class Stage
    {
        public Dictionary<int, Structure> StageData = new Dictionary<int, Structure>(); //IDs vs strcutures
        public Dictionary<int, Point> Locations = new Dictionary<int, Point>(); //IDs vs Locations
        public int curID = 0;

    }

    public class Simulator
    {

        public Structure SimulateTransformation(Structure S,Transformation T, object A)
        {
            throw new NotImplementedException();
        }

        public Stage SimulateTransformation(Stage S, Transformation T, object A)
        {
            throw new NotImplementedException();
        }
    }
}
