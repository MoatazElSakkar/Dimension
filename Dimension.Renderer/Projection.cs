using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dimension.data;

namespace Dimension.Renderer
{
    public class Projection
    {
        public List<Structure> Sillhouette = new List<Structure>();

        public void Clip(int stageWpx,int stageHpx)
        {
            foreach (Structure S in Sillhouette)
            {
                foreach (Triangle T in S.WireFrame)
                {
                    foreach (Point P in T.wireframeSegment)
                    {
                        if (P.x > stageWpx)
                        {

                        }
                    }
                }
            }
        }
    }
}
