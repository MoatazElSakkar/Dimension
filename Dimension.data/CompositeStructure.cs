using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dimension.data
{
    //A composite structure is a shape of shapes, think like a rubik cube, it's a cube made of 3 slices of cubes
    //And you keep binding/unbinding those cubes as you scramble it, so any cube that changes slices will be unbounded
    //from it's original slice and added to the slice it lands in

    //This will allow for a more fluid animation experience

    public class CompositeStructure:Structure
    {


        public CompositeStructure()
        {

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
