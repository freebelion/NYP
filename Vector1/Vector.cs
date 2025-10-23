using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector1
{
    public class Vector
    {
        // auto-property
        public double X { get; set; }
        public double Y { get; set; }

        // default (empty) constructor
        public Vector()
        { X = 0; Y = 0; }

        // constructor with parameters
        public Vector(double initX, double initY)
        {
            X = initX;
            Y = initY;
        }

        public static Vector operator + (Vector v1, Vector v2)
        {
            return new Vector(v1.X + v2.X, v1.Y + v2.Y);
        }

        // object (ultimate parent class) has already defined ToString()
        public override string ToString()
        {
            return "(" + X.ToString("F3") + " | " + Y.ToString("F3") + ")";
        }
    }
}
