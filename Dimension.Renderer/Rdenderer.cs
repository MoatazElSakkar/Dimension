using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dimension.Renderer
{
    public class Rdenderer
    {
        int stageWpx, stageHpx; //Width and height in pixels defaults at 640x480.

        public Dictionary<int[], Texture> textureData = new Dictionary<int[], Texture>();

        //Some image processing/Light source simulation/Bitmap composition goes here..
    }
}
