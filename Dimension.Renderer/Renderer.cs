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
                for(int i=0;i<S.WireFrame.Count;i++)
                {
                    //Rendering Triangle Outline
                    renderTriangleOutline(S.WireFrame[i],S.StructureColor[i]);

                    //Filling triangle
                    fillFromVertix(S.WireFrame[i], S.StructureColor[i]);
                }
            }
            return Outbound;
        }

        public Bitmap GenerateStageView(Projection input,List<Color> EntryColorList)
        {
            Outbound = new Bitmap(stageWpx, stageHpx);
            for (int i = 0; i < stageWpx; i++)
                for (int j = 0; j < stageHpx; j++)
                    Outbound.SetPixel(i, j, Color.DarkBlue);
            foreach (Structure S in input.Sillhouette)
            {
                for(int i=0;i<S.WireFrame.Count;i++)
                {
                    //Rendering Triangle Outline
                    renderTriangleOutline(S.WireFrame[i], EntryColorList[i]);

                    //Filling triangle
                    fillFromVertix(S.WireFrame[i], EntryColorList[i]);
                }
            }
            return Outbound;
        }

        public Bitmap GenerateStageView(Projection input, List<Color> EntryColorList,Color stageC)
        {
            Outbound = new Bitmap(stageWpx, stageHpx);
            for (int i = 0; i < stageWpx; i++)
                for (int j = 0; j < stageHpx; j++)
                    Outbound.SetPixel(i, j, stageC);
            int colorIndex = 0;
            foreach (Structure S in input.Sillhouette)
            {
                for (int i = 0;i < S.WireFrame.Count; i++, colorIndex++)
                {
                    //Rendering Triangle Outline
                    renderTriangleOutline(S.WireFrame[i], EntryColorList[colorIndex]);

                    //Filling triangle
                    fillFromVertix(S.WireFrame[i], EntryColorList[colorIndex]);
                }
            }
            return Outbound;
        }

        void renderTriangleOutline(Triangle T,Color C)
        {
            //Will fill in the lines between 2 points using
            //Equation y=mx+C;
            for (int i = 0; i < T.wireframeSegment.Count(); i++)
            {
                //Outbound.SetPixel((int)T.wireframeSegment[i].x, (int)T.wireframeSegment[i].y, Color.Aqua);
                int f = (i + 1) % T.wireframeSegment.Count();
                LineEquation curLine = new LineEquation(T.wireframeSegment[i], T.wireframeSegment[f]);
                Dimension.data.Point curPoint = T.wireframeSegment[i];
                for (int j = 0; j < curLine.length; j++)
                {
                    if (curPoint.x >= stageWpx || curPoint.y >= stageHpx || curPoint.x < 0 || curPoint.y < 0)
                    {
                        curPoint = curLine.calculateNextPoint(curPoint);
                        continue;
                    }
                    Outbound.SetPixel((int)curPoint.x, (int)curPoint.y, C);
                    curPoint = curLine.calculateNextPoint(curPoint);
                }
            }
        }

        void fillFromApex(Triangle T, Color C)
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
            fillTriangle(T, ApexIndex,C);
        }

        void fillFromVertix(Triangle T, Color C)
        {
            for(int i=0;i<3;i++)
            {
                fillTriangle(T, i,C);
            }
        }

        void fillTriangle(Triangle T, int ApexIndex, Color C)
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
                    if (rasterPoint.x >= stageWpx || rasterPoint.y >= stageHpx || rasterPoint.x < 0 || rasterPoint.y < 0)
                    {
                        rasterPoint = RasterLine.calculateNextPoint(rasterPoint);
                        continue;
                    }
                    Outbound.SetPixel((int)rasterPoint.x, (int)rasterPoint.y, C);
                    rasterPoint = RasterLine.calculateNextPoint(rasterPoint);
                }
                raster1 = L1.calculateNextPoint(raster1);
                raster2 = L2.calculateNextPoint(raster2);
            }
        }

        void FillWithTexture() //Advised course of action below
        {
            throw new NotImplementedException();
        }
        //Advised course of action is to operate on the structure as whole
        //take 2 parallel lines (from 2 different triangles) and create a line between them
        //using line equation, then itirate over that line coloring with the bitmap data as you do
    }
}
