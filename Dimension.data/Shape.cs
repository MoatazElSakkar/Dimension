using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dimension.data
{
    public enum Dimension
    {
        X, Y, Z
    }

    public class Shape:Structure
    {
        public Shape()
        {

        }

        public Shape(Bound[] i_bounds)
        {
            foreach (Bound B in i_bounds)
            {
                bind(B);
            }
        }




        public override int bind(object S)
        {
            throw new NotImplementedException();
        }

        public override object unbind(int i)
        {
            throw new NotImplementedException();
        }
    }
}
