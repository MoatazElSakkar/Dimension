using System;
using System.Collections.Generic;
using System.Text;
using Dimension.data;

namespace Dimension.simulator
{
    //Only Logic Light effect is required
    //which is darkening/brightening the color of the structure depending on it's location from the light source
    class LightSource
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
            Location = location;
        }

        public LightSource(System.Drawing.Color intensity, Point location)
        {
            Intensity = intensity;
            Location = location;
        }

        public System.Drawing.Color TuneColor(Triangle T, System.Drawing.Color oldColor)
        {
            System.Drawing.Color newColor = oldColor;
            newColor = System.Drawing.Color.FromArgb(oldColor.A, (oldColor.R * Intensity.R + 254) / 255, (oldColor.G * Intensity.G + 254) / 255, (oldColor.B * Intensity.B + 254) / 255);
            Point normalVector = Point.crossProduct(T.wireframeSegment[0], T.wireframeSegment[1]);
            Point origin = new Point(0,0,0);
            Point centerOfGravity = new Point(0,0,0);
            for(int i = 0;i < 3;i++) centerOfGravity = centerOfGravity + T.wireframeSegment[i];
            centerOfGravity = centerOfGravity / 3;
            Point vectorFromLight = Location - centerOfGravity;
            float cosAngle = Point.dotProduct(vectorFromLight, normalVector) / Point.getDistance(origin, vectorFromLight) / Point.getDistance(origin, normalVector);
            if(cosAngle < 0) cosAngle = 0;
            else if(cosAngle > 1) cosAngle = 1;
            return System.Drawing.Color.FromArgb(newColor.A, (int)Math.Round(newColor.R * cosAngle), (int)Math.Round(newColor.G * cosAngle), (int)Math.Round(newColor.B * cosAngle));
        }

    }
}
