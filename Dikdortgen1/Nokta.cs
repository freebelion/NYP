using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dikdortgen1
{
    public class Nokta
    {
        public double X {  get; set; }
        public double Y { get; set; }

        public Nokta()
        { X = 0.0; Y = 0.0; }

        public Nokta(double initX, double initY)
        { X = initX; Y = initY; }

        public double Uzaklik()
        { return Math.Sqrt(X * X + Y * Y); }
    }
}
