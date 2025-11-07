using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banka2
{
    class Hesap
    {
        private static int hesap_sayisi;

        protected decimal _bakiye;
        private int _hesapNo;

        static Hesap()
        { hesap_sayisi = 1000; }

        public Hesap()
        {
            _hesapNo = hesap_sayisi;
            hesap_sayisi++;

            _bakiye = 0;
        }

        public int No
        { get { return _hesapNo; } }

        public decimal Bakiye
        { get { return _bakiye; } }

        public void ParaEkle(decimal tutar)
        { _bakiye += tutar; }

        public virtual void ParaCek(decimal tutar)
        {
            if (_bakiye >= tutar)
            { _bakiye -= tutar; }
        }
    }
}
