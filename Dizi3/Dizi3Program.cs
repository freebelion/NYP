namespace Dizi3
{
    internal class Dizi3Program
    {
        static void Main(string[] args)
        {
            Ogrenci ogr;
            Random rnd = new Random();
            int[] bolumKodlari = new int[] { 521, 654, 701, 785, 906 };

            List<Ogrenci> ogrenciler = new List<Ogrenci>();
            for (int i=0, n = rnd.Next(10,100), bolumSayisi = bolumKodlari.Length;
                i < n; i++)
            {
                int yilKodu = rnd.Next(19, 24);
                int bolumKodu = bolumKodlari[rnd.Next(bolumSayisi)];
                int ogrSayi = rnd.Next(100, 1000);

                ogr = new Ogrenci();
                ogr.No = yilKodu.ToString("00") + bolumKodu.ToString("000") + ogrSayi.ToString("000");
                ogr.Not = 100 * rnd.NextDouble();
                ogrenciler.Add(ogr);
            }

            Console.WriteLine("Orijinal ogrenciler listesi:");
            // Orijinal listeyi yazdır
            foreach (Ogrenci o in ogrenciler)
            { Console.WriteLine("{0}\t{1, 5:0.0}", o.No, o.Not); }
            Console.WriteLine();

            // LINQ ile öğrenci numarasına göre sırala ve elemanları yazdır
            var numaraSiraliListe = ogrenciler.OrderBy(o => o.No).ToList();
            Console.WriteLine("LINQ ile numaraya göre sıralanmış liste:");
            foreach (Ogrenci o in numaraSiraliListe)
            { Console.WriteLine("{0}\t{1, 5:0.0}", o.No, o.Not); }
            Console.WriteLine();

            // LINQ ile öğrenci notuna göre (tersine) sırala ve elemanları yazdır
            var notSiraliListe = ogrenciler.OrderByDescending(o => o.Not).ToList();
            Console.WriteLine("LINQ ile nota göre (tersine) sıralanmış liste:");
            foreach (Ogrenci o in notSiraliListe)
            { Console.WriteLine("{0}\t{1, 5:0.0}", o.No, o.Not); }
            Console.WriteLine();

            // LINQ ile önce bölüm koduna göre, sonra (tersine) nota göre sırala ve elemanları yazdır
            var bolumnotSiraliListe = ogrenciler.OrderBy(o => o.Bolum).ThenByDescending(o => o.Not).ToList();
            Console.WriteLine("LINQ ile önce bölüm koduna, sonra nota göre (tersine) sıralanmış liste:");
            foreach (Ogrenci o in bolumnotSiraliListe)
            { Console.WriteLine("{0}\t{1, 5:0.0}", o.No, o.Not); }
            Console.WriteLine();

            // IComparer arabirimini uyarlayan sıralayıcı sınıfı kullan
            NumaraSiralayici ns = new NumaraSiralayici();
            ogrenciler.Sort(ns);
            Console.WriteLine("IComparer arabirimini uyarlayan sınıf ile orijinal listenin numaraya göre sıralanmış hali:");
            foreach (Ogrenci o in ogrenciler)
            { Console.WriteLine("{0}\t{1, 5:0.0}", o.No, o.Not); }
            Console.WriteLine();
        }
    }
}