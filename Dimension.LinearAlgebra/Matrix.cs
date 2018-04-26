using System;
using System.Collections.Generic;
using Dimension.data;

namespace Dimension.LinearAlgebra
{


    public static class LinearAlgebra
    {
        public static Matrix Multiply(Matrix Mx1, Matrix Mx2)
        {
            throw new NotImplementedException();
        }
    }

    public class Matrix
    {
        public float[,] MatData;
        public int Rows, Columns;

        public Matrix(float[] entryData, int i_Columns, int i_Rows) //Entry as a single array
        {
            //Conversion to 2D array
            MatData = new float[i_Rows,i_Columns];
            for (int i = 0; i < i_Columns; i++)
            {
                for (int j = 0; j < i_Rows; j++)
                {
                    MatData[i,j]=entryData[i + j];
                }
            }
        }

        public Matrix(float[,] entryData) //Entry as a single array
        {
            MatData = entryData;
        }

        public Matrix(Point i_point) //Entry as a Dimension Point
        {
            MatData = new float[4, 1]; //a point is represented as 4x1 matrix in transformation
            MatData[0, 0]=i_point.x;
            MatData[1, 0] = i_point.y;
            MatData[2, 0] = i_point.z;
            MatData[3, 0] = 1;
        }
    }
}
