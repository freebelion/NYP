using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banka1
{
    internal class Hesap
    {
        private decimal _bakiye;

        public Hesap()
        {
            _bakiye = 0;
        }

        public decimal Bakiye
        { get { return _bakiye; } }
    }
}
