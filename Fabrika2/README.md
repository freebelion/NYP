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
- Gördüğünüz gibi, farklı sektörlerdeki firmaları temsil eden sınıflar
  yalnızca sektörün adını ekleyen taklit raporlar gönderiyorlar.
  Tanıtım amaçlı bu proje için o kadarı yeter.
- **Fabrika1** projesinde firma kimlik bilgileri
  firma adı ve sicil (kayıt) numarasından ibaretti.
  Halbuki gerçek hayattaki bir projede kimlik bilgileri
  firma adını, kuruluş zamanını, kuruluş sermayesini,
  faliyet sektörünü, ortak sayısını, ve daha bir çok bilgiyi içerebilir.
- Daha da geniş düşünürsek, kimlik bilgileri firmaları kaydedip takip eden
  kuruluşun amaçlarına göre de değiştir. Örneğin, bir ticaret odası
  firmaların finansal faliyetlerine veya muhasebe işlemlerine
  temel olacak bilgilerine ihtiyaç duyacaktır, ama firma birlikleri
  veya dernekleri onların sektörün gelişmesine yönelik faliyetlerine
  odaklanacaktır.
- Dolayısıyla, bu örnek projede firma kimlik bilgilerini ayrı bir sınıfta
  toplamaya karar verdim. Bir "bileşen sınıf" diye düşünebileceğimiz
  `FirmaKimlik` sınıfı programdan programa veya dönemden döneme
  değişebilecek olan kimlik bilgilerini firmaları temsil eden
  sınıflardan ayrı tutuyor.
- Her türden firma bu kimlik bilgilerini saklamak zorunda olduğu
  için de, firma kimlik bilgisini saklayacak olan `Kimlik` özelliği
  tanımını soyut ana sınıf `Firma`tanımına koydum.
  Böylelikle, farklı sektör firmalarını temsil eden sınıflar
  o özelliği yeniden tanımlamıyorlar, ama ilk kimlik bilgileriyle
  firma oluşturmak gerektiğinde, kendi kurucu fonksiyonlarından
  soyut ana sınıfın kurucu fonksiyonunu çağırıyorlar.
- Gerçek firmaları temsil edecek sınıfların ortak özellik
  ve davranışlarını bir soyut ana sınıfta toplamak iyi bir
  fikir olsa da, geniş kapsamlı bir gerçek projede
  bir alt sınıf türünden nesne oluşturulduğunda
  bu ortak özellik ve davranışlarda
  farklı düzenlemeler yapmak gerekebilir.
  O durumda ya ana sınıfta nesne türüne göre `if`-`else`
  ya da `switch` blokları ile seçimler yapılması
  gerekecektir, ya da nesne türüne göre yapılacak
  düzenlemeler alt sınıflara ait kodlarla
  gerçekleştirilecektir.