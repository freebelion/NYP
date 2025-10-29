using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dikdortgen1
{
    public class Nokta
    {
        // This is an auto-property
        public double X {  get; set; }
        public double Y { get; set; }

        // This is the default constructor
        public Nokta()
        { X = 0.0; Y = 0.0; }

        // This is a constructor with parameters
        public Nokta(double initX, double initY)
        { X = initX; Y = initY; }

        /// <summary>
        /// This member function calculates the distance
        /// of this point to the origin.
        /// </summary>
        /// <returns></returns>
        public double Uzaklik()
        { return Math.Sqrt(Math.Pow(X,2) + Math.Pow(Y,2)); }
    }
}
