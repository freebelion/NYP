using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabrika1
{
    internal class Basvuru
    {
        public string FirmaAdi { get; private set; }

        public Basvuru()
        { FirmaAdi = Guid.NewGuid().ToString().Substring(0, 8); }
    }
}
