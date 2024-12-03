using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabrika2
{
    internal class Basvuru
    {
        public string FirmaAdi { get; private set; }
        public FirmaSektor FaliyetSektor { get; private set; }

        public Basvuru()
        {
            FirmaAdi = Guid.NewGuid().ToString().Substring(0, 8);

            switch(Oda.RND.Next() % 3)
            {
                case 0: FaliyetSektor = FirmaSektor.Imalat; break;
                case 1: FaliyetSektor = FirmaSektor.Finans; break;
                case 2: FaliyetSektor = FirmaSektor.Ticaret; break;
            }
        }
    }
}
