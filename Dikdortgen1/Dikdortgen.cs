using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dikdortgen1
{
    public class Dikdortgen
    {
        // The top-left corner point is an auto-property
        public Nokta SolUstKose { get; private set; }

        private double _gen; // member variable to store width
        private double _yuk; // member variable to store height

        public double Genislik
        {
            get { return _gen; }
            set
            {
                if (value <= 0)
                { throw new ApplicationException("Width cannot be zero or negative!"); }
                else { _gen = value; }
            }
        }

        public double Yukseklik
        {
            get { return _yuk; }
            set
            {
                if (value <= 0)
                { throw new ApplicationException("Yükseklik değeri negatif olamaz!"); }
                else { _yuk = value; }
            }
        } 

        public Dikdortgen()
        {
            SolUstKose = new Nokta();
        }

        public Dikdortgen(Nokta solUst, double ilkGenislik, double ilkYukseklik)
            : this() // calling default constructor beforehand
        {
            // SolUstKose = solUst; // this is bad
            SolUstKose.X = solUst.X;
            SolUstKose.Y = solUst.Y;
            Genislik = ilkGenislik;
            Yukseklik = ilkYukseklik;
        }

        public Dikdortgen(double solUstX, double solUstY, double ilkGenislik, double ilkYukseklik)
        {
            SolUstKose = new Nokta(solUstX, solUstY);
            Genislik = ilkGenislik;
            Yukseklik = ilkYukseklik;
        }

        public double Alan()
        {// now okay
            return _gen * _yuk; 
        }

        public double Cevre()
        {
            return 2 * (_gen + _yuk);
        }
    }
}
