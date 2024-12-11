## Fabrika2
Bu proje Fabrika (**Factory**) tasarım deseninin
tanıtımındaki ikinci örnektir. Bu proje için de geliştirme adımlarını
aşağıda özetlemeye çalıştım:

- Bu projede yine **Fabrika1** projesindeki gibi bir firma
  kayıt/takip programının taklitini oluşturuyorum.
- Bu kez birden fazla türden firma olsun diye,
  Imalat, Finans ve Ticaret adlarıyla üç faliyet sektörü
  varmış gibi düşündüm.
- Faliyet sektörlerini `FirmaSektor` adlı adlandırılmış
  değerler grubunda topladım:
```
    internal enum FirmaSektor
    {
        Imalat,
        Finans,
        Ticaret
    }
```
- Farklı sektörlerde faliyet gösteren firmalar için
  geçerli olacak vergi oranları, sermaya limitleri,
  teşvik tutarları vb. için farklı farklı düzenlemeler
  olacaktır. Dolayısıyla onları temsil edecek farklı
  sınıf tanımlarım olacak:
```
  internal class ImalatFirma { }
  internal class FinansFirma { }
  internal class TicariFirma { }
```
- Ama kayıt/takip programı bunların her birine aynı
  türden bir kimlikle erişecebilir. Yani tüm bu
  `...Firma` sınıfları **Fabrika1** projesinde
  olduğu gibi `Firma` diye bir ana sınıftan türetilmelidir:
```
  internal class ImalatFirma : Firma { }
  internal class FinansFirma : Firma { }
  internal class TicariFirma : Firma { }
```
- Hangi sektörde faliyet gösterdiğine bakmaksınızın,
  kayıt/takip programı tüm firmalara bu ana sınıf
  `Firma` türü referans değişkenleri aracılığıyla
  erişecektir. Program firmalardan düzenli rapor
  isteyeceğine göre, ana sınıf `Firma` tanımında
  bir `Rapor()` fonksiyonu olmalıdır.
- Raporlama prosedürü farklı sektörlerdeki firmalar
  için farklı olacaktır tabi ki. Dolayısıyla,
  ana sınıfın `Rapor()` fonksiyonu `virtual` olmalıdır ki
  onları temsil eden sınıflar bu fonksiyonu `override`
  etiketiyle yeniden tanımlasın.
- Ama, biraz düşününce farkettim ki, artık ana sınıf
  `Firma`nın kendisi gerçek bir firmayı temsil edemez.
  Gerçek bir firma gibi belli bir faliyet sektörü de olamaz.
  Bu nedenle, ana sınıf `Firma` soyut bir sınıf olabilir ancak:
```
    internal abstract class Firma
    {
        public FirmaKimlik Kimlik { get; private set; }

        public Firma(FirmaKimlik fkimlik)
        {
            Kimlik = fkimlik;
        }

        public abstract string Rapor(DateTime raporTarih);
    }
```
- Gerçek firmaları temsil eden sınıflar da soyut ana sınıfın
  içeriksiz bıraktığı soyut fonksiyonu kendi koşullarına göre
  tanımlamayacaklar:
```
    internal class ImalatFirma : Firma
    {
        public ImalatFirma(FirmaKimlik fkimlik)
            : base(fkimlik)

        public string Rapor(DateTime raporTarih)
        {
            // Rapor dediğimiz şey de aslında rasgele belirlenen bir kar/zarar bildirimi:
            decimal bilanco = (decimal)(-5E6 + 10E6 * Oda.RND.NextDouble());

            return string.Format("{0} {1} imalat faliyet bilançosu: {2}", Ad, raporTarih.ToString("yyyy MMMM"), bilanco.ToString("C2"));
        }
    }

    internal class FinansFirma : Firma
    {
        public FinansFirma(FirmaKimlik fkimlik)
            : base(fkimlik)

        public string Rapor(DateTime raporTarih)
        {
            // Rapor dediğimiz şey de aslında rasgele belirlenen bir kar/zarar bildirimi:
            decimal bilanco = (decimal)(-5E6 + 10E6 * Oda.RND.NextDouble());

            return string.Format("{0} {1} finansal faliyet bilançosu: {2}", Ad, raporTarih.ToString("yyyy MMMM"), bilanco.ToString("C2"));
        }
    }

    internal class TicariFirma : Firma
    {
        public TicariFirma(FirmaKimlik fkimlik)
            : base(fkimlik)

        public string Rapor(DateTime raporTarih)
        {
            // Rapor dediğimiz şey de aslında rasgele belirlenen bir kar/zarar bildirimi:
            decimal bilanco = (decimal)(-5E6 + 10E6 * Oda.RND.NextDouble());

            return string.Format("{0} {1} ticari faliyet bilançosu: {2}", Ad, raporTarih.ToString("yyyy MMMM"), bilanco.ToString("C2"));
        }
    }
```

