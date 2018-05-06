using System;
using System.Collections.Generic;
using System.Text;
using Dimension.data;

namespace Dimension.Renderer
{
    //Only Logic Light effect is required
    //which is darkening/brightening the color of the structure depending on it's location from the light source
    public class LightSource
    {
        public System.Drawing.Color Intensity;
        public Point Location;

        public LightSource()
        {
            Intensity = System.Drawing.Color.White;
            Location = new Point(0,0,0);
        }

        public LightSource(Point location)
        {
            Intensity = System.Drawing.Color.White;
            Location.x = -location.x;
            Location.y = -location.y;
            Location.z = location.z;
        }

        public LightSource(System.Drawing.Color intensity, Point location)
        {
            Intensity = intensity;
            Location = location;
        }

        //public void TuneStructureColorSet(Structure S)
        //{
        //    for (int i = 0; i < S.WireFrame.Count; i++)
        //    {
        //        S.StructureColor[i] = TuneColor(S.WireFrame[i], S.StructureColor[i]);
        //    }
        //}

        public List<System.Drawing.Color> TuneStructureColorSet(Structure S)
        {
            List<System.Drawing.Color> Outbound = new List<System.Drawing.Color>();
            for (int i = 0; i < S.WireFrame.Count; i++)
            {
                Outbound.Add(TuneColor(S.WireFrame[i], S.StructureColor[i]));
            }
            return Outbound;
        }

        public System.Drawing.Color TuneColor(Triangle T, System.Drawing.Color oldColor)
        {
            System.Drawing.Color newColor;
            newColor = System.Drawing.Color.FromArgb((oldColor.R * Intensity.R + 254) / 255, (oldColor.G * Intensity.G + 254) / 255, (oldColor.B * Intensity.B + 254) / 255);
            Point normalVector = Point.crossProduct(T.wireframeSegment[0], T.wireframeSegment[1]);
            Point origin = new Point(0,0,0);
            Point centerOfGravity = new Point(0,0,0);
            foreach(Point p in T.wireframeSegment)
            {
                centerOfGravity = centerOfGravity + p;
            }
            centerOfGravity = centerOfGravity / 3;
            Point vectorFromLight = Location - centerOfGravity;
            float cosAngle = Point.dotProduct(vectorFromLight, normalVector) / Point.getDistance(origin, vectorFromLight) / Point.getDistance(origin, normalVector);
            cosAngle = Math.Abs(cosAngle);
            if(cosAngle < 0) cosAngle = 0;
            else if(cosAngle > 1) cosAngle = 1;
            return System.Drawing.Color.FromArgb((int)Math.Round(newColor.R * cosAngle), (int)Math.Round(newColor.G * cosAngle), (int)Math.Round(newColor.B * cosAngle));
        }

    }
}
