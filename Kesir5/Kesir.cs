using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kesir5
{
    class Kesir
    {
        private int _pay;
        private int _payda;

        // default (empty) constructor
        public Kesir()
        { Pay = 0; Payda = 1; }

        public Kesir(int p, int q)
        { Pay = p; Payda = q; }

        public int Pay
        {
            get { return _pay; }
            set { _pay = value; }
        }

        public int Payda
        {
            get { return _payda; }
            set
            {
                if (value > 0)
                { _payda = value; }
                else if (value < 0)
                { _payda = -value; _pay = -_pay; }
                else
                { throw new ApplicationException("_payda değeri 0 olamaz!"); }
            }
        }

        public static explicit operator double(Kesir k)
        { return (double)k.Pay / k.Payda; }

        public static implicit operator string(Kesir k)
        { return "[" + k.Pay.ToString() + "/" + k.Payda.ToString() + "]"; }
    }
}
