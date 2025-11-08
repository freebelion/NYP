using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banka1
{
    class Hesap
    {
        // a static variable belongs to the class
        // it's a available to all objects of this type
        private static int hesapIndeks;

        protected decimal _bakiye;
        private int _hesapNo;

        // a static constructor is needed to initialize static variables that belong to the class
        static Hesap()
        { hesapIndeks = 1000; }

        public Hesap()
        {
            hesapIndeks++;
            _hesapNo = hesapIndeks;
            
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
            if(_bakiye >= tutar)
            { _bakiye -= tutar; }           
        }
    }
}
