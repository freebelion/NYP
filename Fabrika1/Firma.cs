using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabrika1
{
    internal class Firma
    {
        public string Ad { get; private set; }
        public string SicilNo { get; private set; }

        public Firma(string firmaAdi, string firmaNo)
        {
            Ad = firmaAdi;
            SicilNo = firmaNo;
        }

        public string Rapor(DateTime raporTarih)
        {
            // Rapor dediğimiz şey de aslında rasgele belirlenen bir kar7zarar bildirimi:
            decimal bilanco = (decimal)(-5E6 + 10E6 * Oda.RND.NextDouble());

            return string.Format("{0} {1} bilançosu: {2}", Ad, raporTarih.ToString("yyyy MMMM"), bilanco.ToString("C2"));
        }
    }
}
