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
                    //Rendering Triangle Outline
                    renderTriangleOutline(T);

                    //Filling triangle
                    fillFromVertix(T);
                }
            }
            return Outbound;
        }

        void renderTriangleOutline(Triangle T)
        {
            //Will fill in the lines between 2 points using
            //Equation y=mx+C;
            for (int i = 0; i < T.wireframeSegment.Count(); i++)
            {
                //Outbound.SetPixel((int)T.wireframeSegment[i].x, (int)T.wireframeSegment[i].y, Color.Aqua);
                int f = (i + 1) % T.wireframeSegment.Count();
                LineEquation curLine = new LineEquation(T.wireframeSegment[i], T.wireframeSegment[f]);
                Dimension.data.Point curPoint = T.wireframeSegment[i];
                Color[] colors ={
                                            Color.Lime,
                                            Color.Pink,
                                            Color.Green,
                                       };
                for (int j = 0; j < curLine.length; j++)
                {
                    Outbound.SetPixel((int)curPoint.x, (int)curPoint.y, colors[i]);
                    curPoint = curLine.calculateNextPoint(curPoint);
                }
            }
        }

        void fillFromApex(Triangle T)
        {
            Dimension.data.Point Apex = new data.Point(0, float.MaxValue, 0);
            int ApexIndex = 0;

            //Finding Apex
            for (int i = 0; i < T.wireframeSegment.Count(); i++)
            {
                if (T.wireframeSegment[i].y < Apex.y)
                {
                    Apex = T.wireframeSegment[i];
                    ApexIndex = i;
                }
            }
            fillTriangle(T, ApexIndex);
        }

        void fillFromVertix(Triangle T)
        {
            for(int i=0;i<3;i++)
            {
                fillTriangle(T, i);
            }
        }

        void fillTriangle(Triangle T, int ApexIndex)
        {
            LineEquation L1, L2;

            Dimension.data.Point Apex = T.wireframeSegment[ApexIndex];

            L1=new LineEquation(Apex,T.wireframeSegment[(ApexIndex+1)%3]);
            L2 = new LineEquation(Apex, T.wireframeSegment[(ApexIndex + 2) % 3]);

            Dimension.data.Point raster1, raster2,rasterPoint;

            raster1 = L1.calculateNextPoint(Apex);
            raster2 = L2.calculateNextPoint(Apex);

            for (int i = 0; i < L2.length; i++)
            {
                LineEquation RasterLine = new LineEquation(raster1, raster2);
                rasterPoint = RasterLine.calculateNextPoint(raster1);
                for (int j = 0; j < RasterLine.length; j++)
                {
                    Outbound.SetPixel((int)rasterPoint.x, (int)rasterPoint.y, Color.Red);
                    rasterPoint = RasterLine.calculateNextPoint(rasterPoint);
                }
                raster1 = L1.calculateNextPoint(raster1);
                raster2 = L2.calculateNextPoint(raster2);
            }
        }
    }
}
