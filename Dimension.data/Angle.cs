using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dimension.data
{
    public class Angle
    {
        public float value;

        public Angle(float theta)
        {
            //Boundries
            value = theta;
        }

        //Paththroughs that will be used to edit in case floating points floated south!
        public float sin()
        {
            return (float)Math.Sin(value);
        }

        public float cos()
        {
            return (float)Math.Cos(value);
        }
    }
}
