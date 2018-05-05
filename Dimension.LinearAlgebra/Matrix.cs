using System;
using System.Diagnostics;
using System.Collections.Generic;
using Dimension.data;

namespace Dimension.LinearAlgebra
{


    public static class LinearAlgebra
    {
        public static Matrix Multiply(Matrix Mx1, Matrix Mx2)
        {
            Debug.Assert(Mx1.Columns == Mx2.Rows);

            int outRows = Mx1.Rows;
            int outColumns = Mx2.Columns;

            ///Intialization of an empty data as preparation for the output Matrix

            float [] tempo = new float [outRows * outColumns];

            for(int i = 0; i < outRows; i++){

                for(int j = 0; j < outColumns; j++){

                    tempo[i * outColumns + j] = 0.0f;

                }

            }


            Matrix outputMx = new Matrix(tempo, outRows, outColumns);

            /// The Multiplication Part

            int moveOnRow = Mx1.Columns;

            for (int i = 0; i < outRows; i++)
            {
                for (int j = 0; j < outColumns; j++)
                {

                    for (int k = 0; k < moveOnRow; k++)
                    {

                        outputMx.MatData[i, j] = Mx1.MatData[i,k] * Mx2.MatData[k,j];

                    }

                }

            }

            return outputMx;
            
        }
    }

    public class Matrix
    {
        public float[,] MatData;
        public int Rows, Columns;
        public Matrix() { }
        public Matrix(float[] entryData, int i_Columns, int i_Rows) //Entry as a single array
        {
            //Conversion to 2D array
            MatData = new float[i_Rows,i_Columns];
            for (int i = 0; i < i_Columns; i++)
            {
                for (int j = 0; j < i_Rows; j++)
                {
                    MatData[i,j]=entryData[i * Columns + j];
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
