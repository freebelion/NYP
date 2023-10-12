using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector1
{
    public class Vector
    {
        public double X {  get; set; }
        public double Y { get; set; }

        public Vector()
        { X = 0; Y = 0; }

        public Vector(double initX, double initY)
        {
            X = initX;
            Y = initY;
        }

        public static Vector operator + (Vector v1, Vector v2)
        {
            return new Vector(v1.X + v2.X, v1.Y + v2.Y);
        }

        public override string ToString()
        {
            return "(" + X.ToString("F3") + " | " + Y.ToString("F3") + ")";
        }
    }
}
