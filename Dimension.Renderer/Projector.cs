using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dimension.data;
using Dimension.LinearAlgebra;

namespace Dimension.Renderer
{
    public class Projector
    {
        //Converting that fancy 3D graph to some simple 2D points

        int stageWpx, stageHpx;

        public List <Structure> OuterSet; //Shapes data
        Dictionary<int, Point> Locations; //Locations of the centers of the shapes on the stage

        //Will be used in clipping if we ended up using masks
        Dictionary<int,Point> RedrawMask=new Dictionary<int,Point>();

        public Projector(List <Structure> a,Dictionary<int, Point> b,int W,int H)
        {
            OuterSet = a;
            Locations = b;
            stageWpx = W;
            stageHpx = H;
        }

        public Projection GeneratePorjection()
        {
            //We quick sort by MaxZ for renderer's convenience and clipping in the future
            OuterSet.Sort();
            List<Structure> Sillhouettes = ProjectShadows(OuterSet);
            Projection stageShadow = new Projection();
            stageShadow.Sillhouette = Sillhouettes;
            return stageShadow;
        }

        public List<Structure> ProjectShadows(List<Structure> Entry)
        {
            List<Structure> OutBound=new List<Structure>();

            foreach (Structure S in Entry)
            {
                List<Triangle> nBound = new List<Triangle>();
                foreach (Triangle T in S.WireFrame)
                {
                    List<Point> nWireframeSegment=new List<Point>();
                    foreach (Point P in T.wireframeSegment)
                    {
                        #region WeakPrespective <Commented>
                        //Weak Prespective Projection algorithm (still untested on 3D)
                        int u, v;
                        if (P.z != 1)
                        {
                            u = (int)(P.x / P.z);
                            v = (int)(P.y / P.z);

                        }
                        else
                        {
                            u = (int)(P.x) / 2;
                            v = (int)(P.y) / 2;
                        }

                        v = v * -1;

                        u += stageWpx / 2;
                        v += stageHpx / 2;

                        nWireframeSegment.Add(new Point(u, v, 0));
                        //Note to self create an int point "Projected Point"
                        #endregion

                        #region Orthogonal Projection <commented>
                        //Orthogonal Projection
                        //Matrix Mat = new Matrix(new float[4,4]{
                        //{2/1280,0,0,0},
                        //{0,2/720,0,0},
                        //{0,0,2/30,0},
                        //{0,0,0,1}
                        //});

                        //Matrix PointMatrix = new Matrix(P);
                        //Matrix Output = LinearAlgebra.LinearAlgebra.Multiply(Mat,PointMatrix);
                        #endregion


                        //habd projection algorithm
                        //float v, u;


                        //if (P.y > stageHpx / 2)
                        //{
                        //    v = P.x - P.z;
                        //    u = P.y - P.z;
                        //}
                        //else
                        //{
                        //    v = P.x + P.z;
                        //    u = P.y + P.z;
                        //}

                        //v *= -1;

                        //u += stageWpx / 2;
                        //v += stageHpx / 2;

                        //nWireframeSegment.Add(new Point(u, v, 0));
                    }
                    T.wireframeSegment=nWireframeSegment.ToArray();
                    nBound.Add(T);
                }
                Structure nS=S;
                nS.WireFrame=nBound;
                OutBound.Add(nS);
            }

            return OutBound;
        }
    }
}
