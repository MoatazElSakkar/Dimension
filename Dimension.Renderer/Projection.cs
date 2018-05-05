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
                    for(int i=0;i<3;i++)
                    {
                        if (T.wireframeSegment[i].x > stageWpx)
                        {

                        }
                    }
                }
            }
        }

        void resolvePoint()
        {

        }
    }
}
