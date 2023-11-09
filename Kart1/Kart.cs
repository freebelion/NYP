using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kart1
{
    public enum KartRenk
    {
        Sinek = 0,
        Karo,
        Maca,
        Kupa
    }

    public class Kart : IComparable<Kart>
    {
        public const string KartDegerleri = "0123456789VKP"; // ilk karakter kullanılamayacak!

        private readonly int _degerIndeks;
        public Kart(KartRenk r, int s)
        {
            Renk = r;
            _degerIndeks = s;
        }

        public KartRenk Renk { get; set; }
        public char Deger { get { return KartDegerleri[_degerIndeks]; } }

        public override string ToString()
        {
            char renkchar = ' ';
            switch(Renk)
            {
                case KartRenk.Kupa: renkchar = '\u2665'; break;
                case KartRenk.Maca: renkchar = '\u2660'; break;
                case KartRenk.Karo: renkchar = '\u2666'; break;
                case KartRenk.Sinek: renkchar = '\u2663'; break;
            }

            return string.Format("{0}{1}", renkchar, Deger);
        }


        public int CompareTo(Kart? diger)
        {
            if (diger == null) return +1;

            int r1 = (int)this.Renk;
            int r2 = (int)diger.Renk;
            int s1 = this._degerIndeks;
            int s2 = diger._degerIndeks;

            if (r1 < r2) { return -1; }
            else if (r1 > r2) { return +1; }
            else
            {
                if (s1 < s2) { return -1; }
                else if (s1 > s2) { return +1; }
                else { return 0; }
            }
        }

    }
}
