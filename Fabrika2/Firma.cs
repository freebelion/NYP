using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabrika2
{
    internal enum FirmaSektor
    {
        Imalat,
        Finans,
        Ticaret
    }

    internal class FirmaKimlik
    {
        public string Ad { get; private set; }
        public string SicilNo { get; private set; }
        public FirmaSektor Sektor { get; private set; }

        public FirmaKimlik(string firmaAdi, string firmaNo, FirmaSektor fsektor)
        {
            Ad = firmaAdi; SicilNo = firmaNo; Sektor = fsektor;
        }
    }

    internal interface IFirma
    {
        public FirmaKimlik Kimlik { get; }
        public string Rapor(DateTime raporTarih);
    }

    internal interface IFirmaFabrika
    {
        public IFirma? FirmaKayit(Basvuru firmaBasvuru);
    }

    internal class FirmaFabrika : IFirmaFabrika
    {
        private int FirmaSayisi { get; set; }

        public FirmaFabrika()
        { FirmaSayisi = 0; }

        public IFirma? FirmaKayit(Basvuru firmaBasvuru)
        {
            FirmaSayisi++;
            string sicilNo = string.Format("{0}_{1}", DateTime.Today.ToString("yyyy"), FirmaSayisi.ToString("0000"));

            switch (firmaBasvuru.FaliyetSektor)
            {
                case FirmaSektor.Imalat:
                    return new ImalatFirma(new FirmaKimlik(firmaBasvuru.FirmaAdi, sicilNo, FirmaSektor.Imalat));
                case FirmaSektor.Finans:
                    return new FinansFirma(new FirmaKimlik(firmaBasvuru.FirmaAdi, sicilNo, FirmaSektor.Finans));
                case FirmaSektor.Ticaret:
                    return new TicariFirma(new FirmaKimlik(firmaBasvuru.FirmaAdi, sicilNo, FirmaSektor.Ticaret));
            }
            return null;
        }
    }

    internal class ImalatFirma : IFirma
    {
        public FirmaKimlik Kimlik { get; private set; }

        public ImalatFirma(FirmaKimlik fkimlik)
        {
            Kimlik = fkimlik; 
        }

        public string Rapor(DateTime raporTarih)
        {
            return string.Empty;
        }
    }

    internal class FinansFirma : IFirma
    {
        public FirmaKimlik Kimlik { get; private set; }

        public FinansFirma(FirmaKimlik fkimlik)
        {
            Kimlik = fkimlik;
        }

        public string Rapor(DateTime raporTarih)
        {
            return string.Empty;
        }
    }

    internal class TicariFirma : IFirma
    {
        public FirmaKimlik Kimlik { get; private set; }

        public TicariFirma(FirmaKimlik fkimlik)
        {
            Kimlik = fkimlik;
        }

        public string Rapor(DateTime raporTarih)
        {
            return string.Empty;
        }
    }
}
