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
                List<Structure> Sillhouettes = ProjectShadows(Quicksort(OuterSet.ToList()));
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
                            //int u, v;
                            //if (P.z != 1)
                            //{
                            //    u = (int)(P.x / P.z);
                            //    v = (int)(P.y / P.z);

                            //}
                            //else
                            //{
                            //    u = (int)(P.x)/2;
                            //    v = (int)(P.y)/2;
                            //}

                            //v = v * -1;

                            //u += stageWpx / 2;
                            //v += stageHpx / 2;

                            //nWireframeSegment.Add(new Point(u,v,0));
                            //Note to self create an int point "Projected Point"
                            #endregion

                            //Orthogonal Projection
                            Matrix Mat = new Matrix(new float[3,3]{
                            {1,0,0},
                            {0,1,0},
                            {0,0,0},
                            });

                            Matrix PointMatrix = new Matrix(new float[1,3]{
                            {P.x,P.y,P.z}
                            }
                            );
                            LinearAlgebra.LinearAlgebra.Multiply(PointMatrix,Mat);

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

            //A generic QuickSort function
            public static List<Structure> Quicksort(List<Structure> Entry)
            {

            if (Entry.Count() < 2) return Entry;

            var PivotIndex = (Entry.Count())/2;
            var PivotValue = Entry[PivotIndex];

            List<Structure> loBound = new List<Structure>();
            List<Structure> hibound = new List<Structure>();

            for (int i = 0; i < Entry.Count(); i++) 
            {
                if (i != PivotIndex) {
                    if (Entry[i].getMaxZScore()<PivotValue.getMaxZScore()) 
                    {
                        loBound.Add(Entry[i]);
                    }
                    else 
                    {
                        hibound.Add(Entry[i]);
                    }
                }
            }

            List<Structure> Output = Quicksort(loBound);
            Output.Add(PivotValue);
            Output.AddRange(Quicksort(hibound));

            return Output;
        }
    }
}
