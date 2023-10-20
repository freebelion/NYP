using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banka1
{
    static class Banka
    {
        static Random rnd;

        static Banka()
        {
            rnd = new Random((int) DateTime.Now.Ticks);
        }
    }
}
