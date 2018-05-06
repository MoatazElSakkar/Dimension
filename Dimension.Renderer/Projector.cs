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
            OuterSet = a.ToList();
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
                        float nZ = P.z;


                        
                        //if (nZ < 1)
                        //{
                        //    nZ = 1;
                        //}

                        if (nZ < 100)
                        {
                            nZ = 2f / 3f;
                        }
                        else
                        {
                            nZ /= 100;
                        }

                           
                            u = (int)(P.x / nZ);
                            v = (int)(P.y / nZ);


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
                    nBound.Add(new Triangle(nWireframeSegment.ToArray(),T.ID));
                }
                Structure nS=new Structure();
                nS.ID = S.ID;
                nS.StructureColor = S.StructureColor;
                nS.CenterPoint = S.CenterPoint;
                nS.WireFrame=nBound;
                OutBound.Add(nS);
            }

            return OutBound;
        }
    }
}
