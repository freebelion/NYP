using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabrika1
{
    internal class Oda
    {
        public static Random RND = new Random((int) DateTime.Now.Ticks);

        private int FirmaSayisi {  get; set; }
        private List<Firma> firmalar;

        public Oda()
        {
            firmalar = new List<Firma>();
            FirmaSayisi = 0;
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
                Firma yeniFirma = FirmaKayit(firmaBasvuru);
                firmalar.Add(yeniFirma);
            }
        }

        public Firma FirmaKayit(Basvuru firmaBasvuru)
        {
            FirmaSayisi++;
            string sicilNo = string.Format("{0}_{1}", DateTime.Today.ToString("yyyy"), FirmaSayisi.ToString("0000"));
            return new Firma(firmaBasvuru.FirmaAdi, sicilNo);
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
