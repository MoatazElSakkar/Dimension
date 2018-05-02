using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dimension.data;

namespace Dimension.Renderer
{
        public class Projector
        {
            //Converting that fancy 3D graph to some simple 2D points

            public Dictionary<int, Structure> OuterSet;
            Dictionary<int, Point> Locations;

            Dictionary<int,Point> RedrawMask=new Dictionary<int,Point>();

            public Projector(Dictionary<int, Structure> a,Dictionary<int, Point> b)
            {
                OuterSet = a;
                Locations = b;
            }

            public Projection GeneratePorjection()
            {
                foreach (KeyValuePair<int,Structure> KVP in OuterSet)
                {
                    KVP.Value.ID=KVP.Key;
                }

                List<Structure> Sillhouettes =  ProjectShadows(Quicksort(OuterSet.Values.ToList()));
                Projection stageShadow = new Projection();
                stageShadow.Sillhouette = Sillhouettes;
                return stageShadow;
            }

            public List<Structure> ProjectShadows(List<Structure> Entry)
            {
                List<Structure> OutBound=new List<Structure>();

                foreach (Structure S in Entry)
                {
                    Dictionary<int,object> nBound=new Dictionary<int,object>();
                    foreach (KeyValuePair<int,object> kvp in S.WireFrame)
                    {
                        Bound B = (Bound) kvp.Value;
                        List<Point> nWireframeSegment=new List<Point>();
                        foreach (Point P in B.wireFrameSegment)
                        {
                            float u=P.x/P.z;
                            float v=P.y/P.z;
                            v = v * -1;

                            u += 720 / 2;
                            v += 480 / 2;


                            nWireframeSegment.Add(new Point(u,v,0));
                        }
                        B.wireFrameSegment=nWireframeSegment.ToArray();
                        nBound.Add(kvp.Key,B);
                    }
                    Structure nS=S;
                    nS.WireFrame=nBound;
                    OutBound.Add(nS);
                }

                return OutBound;
            }

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
