using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dikdortgen1
{
    public class Dikdortgen
    {
        public Nokta SolUstKose { get; private set; }

        private double _gen;
        private double _yuk;

        public double Genislik
        {
            get { return _gen; }
            set
            {
                if (value < 0)
                { throw new ApplicationException("Genişlik değeri negatif olamaz!"); }
                else { _gen = value; }
            }
        }

        public double Yukseklik
        {
            get { return _yuk; }
            set
            {
                if (value < 0)
                { throw new ApplicationException("Yükseklik değeri negatif olamaz!"); }
                else { _yuk = value; }
            }
        }

        public Dikdortgen()
        {
            SolUstKose = new Nokta();
        }

        public Dikdortgen(Nokta solUst, double ilkGenislik, double ilkYukseklik)
            : this()
        {
            SolUstKose.X = solUst.X;
            Genislik = ilkGenislik;
            Yukseklik = ilkYukseklik;
        }

        public Dikdortgen(double solUstX, double solUstY, double ilkGenislik, double ilkYukseklik)
        {
            SolUstKose = new Nokta(solUstX, solUstY);
            Genislik = ilkGenislik;
            Yukseklik = ilkYukseklik;
        }
    }
}
