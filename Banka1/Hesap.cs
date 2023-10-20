﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banka1
{
    class Hesap
    {
        private static int hesap_sayisi;

        private decimal _bakiye;
        private int _hesapNo;

        static Hesap()
        { hesap_sayisi = 1000; }

        public Hesap()
        {
            _hesapNo = hesap_sayisi;
            hesap_sayisi++;

            _bakiye = 0;
        }

        public static int Hesapsayisi
        { get { return hesap_sayisi; } }

        public int No
        { get { return _hesapNo; } }

        public decimal Bakiye
        { get { return _bakiye; } }

        public bool BakiyeYeterli(decimal tutar)
        {  return _bakiye > tutar; }

        public void ParaEkle(decimal tutar)
        { _bakiye += tutar; }

        public void ParaCek(decimal tutar)
        {
            if(BakiyeYeterli(tutar))
            { _bakiye -= tutar; }           
        }
    }
}
