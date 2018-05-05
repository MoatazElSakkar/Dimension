using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Dimension.Renderer
{
    public class Texture
    {
        public Bitmap TextureData;

        public Texture(string path)
        {
            //Assertion..
            TextureData = (Bitmap) Bitmap.FromFile(path);
        }

        //Some image processing mapping/Transformation functions..
        //Matrix Multiplier can come in handy
        //Some research required

    }
}
