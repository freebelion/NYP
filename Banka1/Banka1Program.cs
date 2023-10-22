namespace Banka1
{
    internal class Banka1Program
    {
        static void Main(string[] args)
        {
            DateTime tarih = DateTime.Now;
            Random rnd = new Random((int)tarih.Ticks);

            List<Hesap> hesaplar = new List<Hesap>();

            for(int i=0, n= rnd.Next(10,100); i < n; i++)
            { hesaplar.Add(new Hesap()); }

            string? cevap;
            Console.WriteLine("Bu program belirsiz sayıda banka hesabı üzerinde rasgele işlemler yaptıracaktır.");
            Console.WriteLine("ENTER tuşuna basarak döngüyü devam ettirebilirsiniz.");
            Console.WriteLine("Döngüyü sonlandırmak için başka herhangi bir tuşa basabiliriniz.");

            Console.WriteLine("\n\n{0,12}\t\t{1,12}\t\t{2,12}\n", "Hesap", "Tutar", "Bakiye");
            Console.WriteLine("{0,12}\t{0,12}\t{0,12}\n", "_________________");
            do
            {
                int sirano = rnd.Next(hesaplar.Count);
                Hesap h = hesaplar[sirano];
                Console.Write("{0,12}\t\t", h.No);

                decimal tutar = (decimal)(1000 + 1E6 * rnd.NextDouble());

                if((rnd.Next() % 2) != 0)
                {
                    h.ParaEkle(tutar);
                }
                else
                {
                    h.ParaCek(tutar);
                    tutar = -tutar;
                }
                Console.Write("{0,12}\t\t", tutar.ToString("0.00"));

                Console.Write("{0,12}\n", h.Bakiye.ToString("0.00"));

                cevap = Console.ReadLine();
            } while (string.IsNullOrEmpty(cevap));
        }
    }
}