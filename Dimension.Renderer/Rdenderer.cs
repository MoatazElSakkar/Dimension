using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Dimension.data;

namespace Dimension.Renderer
{
    public class Renderer
    {
        public int stageWpx, stageHpx; //Width and height in pixels defaults at 640x480.

        public Dictionary<int[], Texture> textureData = new Dictionary<int[], Texture>();

        //Some image processing/Light source simulation/Bitmap composition goes here..

        public Bitmap Outbound;

        public Renderer(int a, int b)
        {
            stageWpx = a;
            stageHpx = b;
            Outbound = new Bitmap(a, b);
        }

        public Bitmap GenerateStageView(Projection input)
        {
            Outbound = new Bitmap(stageWpx, stageHpx);

            
        }

        void createOutline(Structure S)
        {
            foreach (object Obj in S.WireFrame.Values)
            {
                Bound B = (Bound)Obj;
                foreach (Dimension.data.Point P in B.wireFrameSegment)
                {
                    Outbound.SetPixel((int) P.x,(int) P.y, Color.Red); //Note to Self: Make Projections operate on integers

                }
            }
        }
    }
}
