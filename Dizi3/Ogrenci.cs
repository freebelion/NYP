using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dizi3
{
    public class Ogrenci
    {
        public string No {  get; set; }
        public string Yil { get {  return No.Substring(0, 2); } }
        public string Bolum { get { return No.Substring(2, 3); } }

        private double _not;
        
        public double Not
        {
            get => _not;
            set => _not = (value >= 0 && value <= 100) ? Math.Round(value, 1) : double.NaN;
        }

        public Ogrenci()
        {
            No = string.Empty;
        }
    }
}
