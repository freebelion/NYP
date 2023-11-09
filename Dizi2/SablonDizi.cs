using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dizi2
{
    /// <summary>
    /// Eleman türünün kullanıcı-programcı tarafından belirlenmesine
    /// imkan veren şablo dizi sınıfı
    /// </summary>
    /// <typeparam name="T">Sonradan belirlenecek eleman türü</typeparam>
    public class SablonDizi<T>
    {
        private T[] _array;

        public int ElemanSayisi { get; private set; }

        public int Kapasite
        { get { return _array.Length; } }

        public SablonDizi()
        {
            _array = new T[1];
            ElemanSayisi = 0;
        }

        public SablonDizi(int ilk_kapasite)
        {
            if (ilk_kapasite > 0)
            { _array = new T[ilk_kapasite]; }
            else
            { throw (new ArgumentException("Dizi kapasitesi 0 veya negatif olamaz!")); }
            ElemanSayisi = 0;
        }

        public T this[int sirano]
        {
            // Sıra numarasını kontrol edecek koşulifadeleri ekleyin.
            get { return _array[sirano]; }
            set { _array[sirano] = value; }
        }

        private void KapasiteArttir()
        {
            T[] _newarray = new T[Kapasite * 2];
            for (int i = 0; i < Kapasite; i++)
            { _newarray[i] = _array[i]; }
            _array = _newarray;
        }

        public void Ekle(T yenieleman)
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
        public int? SiraNo(T arananeleman)
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
