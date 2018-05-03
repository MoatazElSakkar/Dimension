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
        public int stageWpx, stageHpx; //Width and height in pixels defaults at 720x360.

        public Dictionary<int[], Texture> textureData = new Dictionary<int[], Texture>();

        //Some image processing/Light source simulation/Bitmap composition goes here..

        public Bitmap Outbound; //Output Bitmap

        public Renderer(int a, int b)
        {
            stageWpx = a;
            stageHpx = b;
            Outbound = new Bitmap(a, b);
        }

        //Places points only as of now
        public Bitmap GenerateStageView(Projection input)
        {
            Outbound = new Bitmap(stageWpx, stageHpx);
            for (int i = 0; i < stageWpx; i++)
                for (int j = 0; j < stageHpx; j++)
                    Outbound.SetPixel(i, j, Color.DarkBlue);
            foreach (Structure S in input.Sillhouette)
            {
                foreach (object obj in S.WireFrame.Values)
                {
                    Bound B = (Bound) obj;
                    for (int i = 0; i < B.wireFrameSegment.Count();i++)
                    {
                        Outbound.SetPixel((int)B.wireFrameSegment[i].x, (int)B.wireFrameSegment[i].y, Color.Aqua);


                    }
                }
            }
            return Outbound;
        }

        void createOutline(Structure S)
        {
            //Will fill in the lines between 2 points using
            //Equation y=mx+C;
        }
    }
}
