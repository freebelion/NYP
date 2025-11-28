using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dizi1
{
    /// <summary>
    /// İçeriğindeki ondalıklı sayılar dizisine
    /// eleman ekleme imkanı sunan bir "esnek" dizi sınıfı.
    /// </summary>
    internal class Dizi
    {
        private double[] _array;

        public int ElemanSayisi { get; private set; }

        public int Kapasite
        { get { return _array.Length; } } 

        public Dizi()
        { 
            _array = new double[1];
            ElemanSayisi = 0;
        }

        public Dizi(int ilk_kapasite)
        {
            if (ilk_kapasite > 0)
            { _array = new double[ilk_kapasite]; }
            else
            { throw(new ArgumentException("Dizi kapasitesi 0 veya negatif olamaz!"));}
            ElemanSayisi = 0;
        }

        public double this[int sirano]
        {// an indexer property
            // Sıra numarasını kontrol edecek koşul ifadeleri ekleyin.
            get { return _array[sirano]; }
            set { _array[sirano] = value; }
        }

        private void KapasiteArttir()
        {
            double[] _newarray = new double[Kapasite * 2];
            for(int i = 0; i < Kapasite; i++)
            { _newarray[i] = _array[i]; }
            _array = _newarray;
        }

        public void Ekle(double yenieleman)
        {
            if (ElemanSayisi == Kapasite)
            { KapasiteArttir(); }
            _array[ElemanSayisi] = yenieleman;
            ElemanSayisi++;
        }

        /// <summary>
        /// Argüman olarak iletilen değeri dizide aratan,
        /// varsa sıra numarasını, yoksa null değeri ileten
        /// fonksiyon.
        /// </summary>
        /// <param name="arananeleman">Aranan değer</param>
        /// <returns></returns>
        public int? SiraNo(double arananeleman)
        {
            // İçeriğini siz yazın.
        }

        /// <summary>
        /// d argümanıyla iletilen değeri
        /// sirano argümanıyla belirtilen konumda
        /// araya sokacak olan fonksiyon.
        /// </summary>
        /// <param name="sirano">Yeni elemanın yerleşeceği sıra numarası</param>
        /// <param name="yenieleman">Yeni eleman değeri</param>
        public void Ekle(int sirano, double yenieleman)
        {
            // İçeriğini siz yazın.
            // Gerekli kontrolleri yaptırmayı unutmayın.
        }
    }
}
