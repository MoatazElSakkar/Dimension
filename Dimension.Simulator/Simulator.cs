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

    
    public class SimulationStage
    {
        public List<Structure> StageData = new List<Structure>(); //List Of Structures
        public Dictionary<int, Point> Locations = new Dictionary<int, Point>(); //IDs vs Locations
        public int curID = 0;

    }

    public class Simulator
    {

        public Structure SimulateTransformation(Structure S,Transformation T, object A)
        {
            throw new NotImplementedException();
        }

        public SimulationStage SimulateTransformation(SimulationStage S, Transformation T, object A)
        {
            throw new NotImplementedException();
        }
    }
}
