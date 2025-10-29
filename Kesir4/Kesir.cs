using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kesir4
{
    class Kesir
    {
        // data hiding (2nd principle of OOP)
        private int _pay;
        private int _payda;

        // constructor function (with parameters)
        public Kesir(int p, int q)
        { _pay = p; _payda = q; }

        // property definition
        public int Pay
        {
            // get block (helps learn hidden values)
            get { return _pay; }
        }

        public int Payda
        { get { return _payda; } }

        public double Oran()
        { return (double)_pay / _payda; }
    }
}
