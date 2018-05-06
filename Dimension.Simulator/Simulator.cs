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
        public List<Structure> StageData = new List<Structure>(); //IDs vs strcutures
        public Dictionary<int, Point> Locations = new Dictionary<int, Point>(); //IDs vs Locations
        public int curID = 0;

    }

    public class Simulator
    {

        public Matrix getRotation(params object[] A)
        {

            Matrix multMatrix = new Matrix();

            Angle rotationAngleX = new Angle(float.Parse(A[0].ToString()));

            Angle rotationAngleY = new Angle(float.Parse(A[1].ToString()));

            Angle rotationAngleZ = new Angle(float.Parse(A[2].ToString()));

            float[,] bufferData = new float[4, 4];

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    bufferData[i, j] = 0;

            if (rotationAngleX.value == 0)
            {
                for (int i = 0; i < 4; i++) bufferData[i, i] = 1;
            }

            bufferData[1, 1] = rotationAngleX.cos();
            bufferData[1, 2] = -rotationAngleX.sin();
            bufferData[2, 1] = rotationAngleX.sin();
            bufferData[2, 2] = rotationAngleX.cos();

            Matrix xMat = new Matrix(bufferData);

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    bufferData[i, j] = 0;

            if (rotationAngleY.value == 0)
            {
                for (int i = 0; i < 4; i++) bufferData[i, i] = 1;
            }

            bufferData[0, 0] = rotationAngleY.cos();
            bufferData[0, 2] = rotationAngleY.sin();
            bufferData[2, 0] = -rotationAngleY.sin();
            bufferData[2, 2] = rotationAngleY.cos();

            Matrix yMat = new Matrix(bufferData);

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    bufferData[i, j] = 0;
            if (rotationAngleZ.value == 0)
            {
                for (int i = 0; i < 4; i++) bufferData[i, i] = 1;
            }

            bufferData[0, 0] = rotationAngleZ.cos();
            bufferData[0, 1] = -rotationAngleZ.sin();
            bufferData[1, 0] = rotationAngleZ.sin();
            bufferData[1, 1] = rotationAngleZ.cos();

            Matrix zMat = new Matrix(bufferData);

            multMatrix = LinearAlgebra.LinearAlgebra.Multiply(xMat, yMat);
            multMatrix = LinearAlgebra.LinearAlgebra.Multiply(multMatrix, zMat);

            return multMatrix;
        }
        public Matrix getScaling(params object[] A)
        {
            float scaleX = float.Parse(Convert.ToString(A[0]));

            float scaleY = float.Parse(Convert.ToString(A[1]));

            float scaleZ = float.Parse(Convert.ToString(A[2]));

            float[,] bufferData = new float[4, 4];

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    bufferData[i, j] = 0;

            for (int i = 0; i < 4; i++) bufferData[i, i] = 1;

            bufferData[0, 0] = scaleX;
            bufferData[1, 1] = scaleY;
            bufferData[2, 2] = scaleZ;

            Matrix multMatrix = new Matrix(bufferData);

            return multMatrix;
        }

        public Matrix getTranslation(params object[] A)
        {
            
                float translateX = float.Parse(A[0].ToString());

                float translateY = float.Parse(A[1].ToString());

                float translateZ = float.Parse(A[2].ToString());

                float[,] bufferData = new float[4, 4];

                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 4; j++)
                        bufferData[i, j] = 0;

                for (int i = 0; i < 4; i++) bufferData[i, i] = 1;

                bufferData[0, 3] = translateX;
                bufferData[1, 3] = translateY;
                bufferData[2, 3] = translateZ;

                Matrix multMatrix = new Matrix(bufferData);
                return multMatrix;
        }

        public Structure SimulateTransformation(Structure S, Transformation T, params object[] A)
        {

            Matrix multMatrix = new Matrix();   

            if (T == Transformation.Rotation)
            {
                multMatrix = getRotation(A);
            }
            else if (T == Transformation.Scaling)
            {
                multMatrix = getScaling(A);
            }
            else
            {
                multMatrix = getTranslation(A);
            }

            ///For Every Triangle in the Structre 

            foreach (Triangle tri in S.WireFrame)
            {

                ///For Every Point in the triangle 

                foreach (Point Pt in tri.wireframeSegment)
                {
                    Matrix pointMatrix = new Matrix(Pt);

                    
                    pointMatrix = LinearAlgebra.LinearAlgebra.Multiply(multMatrix, pointMatrix);

                    ///Assignment of Points

                    Pt.x = pointMatrix.MatData[0,0];

                    Pt.y = pointMatrix.MatData[1,0];

                    Pt.z = pointMatrix.MatData[2,0];

                }
            }

            return S;
        }

        //public SimulationStage SimulateTransformation(SimulationStage S, Transformation T, object A)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
