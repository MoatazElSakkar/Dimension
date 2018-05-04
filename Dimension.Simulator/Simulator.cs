using System;
using System.Collections.Generic;
using Dimension.data;
using Dimension.LinearAlgebra;
using System.Diagnostics;

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
        public Dictionary<int, Structure> StageData = new Dictionary<int, Structure>(); //IDs vs strcutures
        public Dictionary<int, Point> Locations = new Dictionary<int, Point>(); //IDs vs Locations
        public int curID = 0;

    }

    public class Simulator
    {

        public Structure SimulateTransformation(Structure S,Transformation T, object A)
        {

            Matrix multMat;
            
            if (T == Transformation.Rotation)
            {
                Angle rotationAngle = new Angle(float.Parse(A.ToString()));

                for (; ; )
                {

                }
                
            }
            else if (T == Transformation.Scaling)
            {

            }
            else
            {

            }

            return S;
        }

        public SimulationStage SimulateTransformation(SimulationStage S, Transformation T, object A)
        {
            throw new NotImplementedException();
        }
    }
}
