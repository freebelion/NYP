using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banka2
{
    class KrediliHesap : Hesap
    {
        // Aşağıdaki sayı yüzbinmilyon değil!
        const decimal EKSILIMIT = 100000M;

        public override void ParaCek(decimal tutar)
        {
            if(_bakiye + EKSILIMIT > tutar)
            { _bakiye -= tutar; }
        }
    }
}
