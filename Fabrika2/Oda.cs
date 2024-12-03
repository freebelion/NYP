using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabrika2
{
    internal class Oda
    {
        public static Random RND = new Random((int) DateTime.Now.Ticks);

        private List<IFirma> firmalar;
        private FirmaFabrika firmaFabrika;

        public Oda()
        {
            firmalar = new List<IFirma>();
            firmaFabrika = new FirmaFabrika();
        }

        public void KayitTakip()
        {
            string? cevap;
            
            // Türkçe karakterler doğru gözüksün diye şu komutla konsol penceresine ayar çekelim.
            Console.OutputEncoding = Encoding.UTF8;

            DateTime raporTarih = DateTime.Today;
            do
            {// Bu döngü gerçek bir kayıt/takip uygulamasının sürekli çalışmasını taklit ediyor.
                
                BasvurulariAl();

                raporTarih = raporTarih.AddMonths(1);
                RaporlariAl(raporTarih);

                cevap = Console.ReadLine();
            } while (string.IsNullOrEmpty(cevap));
        }

        public void BasvurulariAl()
        {
            int basvuruSayisi = RND.Next(6);

            for(int i=0; i <basvuruSayisi; i++)
            {
                Basvuru firmaBasvuru = new Basvuru();
                IFirma? yeniFirma = firmaFabrika.FirmaKayit(firmaBasvuru);
                if (yeniFirma != null) { firmalar.Add(yeniFirma); }
            }
        }

        

        public void RaporlariAl(DateTime raporTarih)
        {
            for (int i = 0; i < firmalar.Count; i++)
            {
                Console.WriteLine(firmalar[i].Rapor(raporTarih));
            }
            Console.WriteLine();
        }
    }
}
