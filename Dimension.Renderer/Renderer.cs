using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Dimension.data;
using Dimension.LinearAlgebra;

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
                foreach (Triangle T in S.WireFrame)
                {
                    for (int i = 0; i < T.wireframeSegment.Count()-1;i++)
                    {
                        //Outbound.SetPixel((int)T.wireframeSegment[i].x, (int)T.wireframeSegment[i].y, Color.Aqua);
                        LineEquation curLine = new LineEquation(T.wireframeSegment[i], T.wireframeSegment[i + 1]);
                        Dimension.data.Point curPoint = T.wireframeSegment[i];
                        for (int j = 0; j < curLine.length; j++)
                        {
                            Outbound.SetPixel((int)curPoint.x, (int) curPoint.y, Color.Aqua);
                            curPoint=curLine.calculateNextPoint(curPoint);
                        }
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
