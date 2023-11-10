using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dizi3
{
    public class NumaraSiralayici : IComparer<Ogrenci>
    {
        public int Compare(Ogrenci? o1, Ogrenci? o2)
        {
            if (o1 != null && o2 != null)
            { return o1.No.CompareTo(o2.No); }
            else if(o1 != null)
            { return +1; }
            else if (o2 != null)
            { return -1; }
            return 0;
        }
    }
}
