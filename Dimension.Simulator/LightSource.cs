using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dimension.data;

namespace Dimension.simulator
{
    //Only Logic Light effect is required
    //which is darkening/brightening the color of the structure depending on it's location from the light source
    class LightSource
    {
        public Angle A;
        public Point Location;
    }
}
