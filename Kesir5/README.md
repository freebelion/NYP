## Kesir5
**Kesir4** projesinde, programın ana fonksiyonu
Main içinde<br>
`Kesir k3 = new Kesir();`<br>
gibi bir komut ile, pay ve paydaya ilk değer
atamadan üçüncü bir kesir nesnesi
oluşturmaya kalksaydınız,
ilk değer için argüman iletmediğinizi
bildiren bir hata mesajıyla karşılaşırdınız:
```
There is no argument given that corresponds
to the required parameter 'p' of
'Kesir4Program.Kesir.Kesir(int, int)'
```
Halbuki **Kesir3** projesindeki sınıf tanımında
hiç kurucu fonksiyon yoktu, ama ona rağmen
iki kesir nesnesini de ilk değer argümanları
iletmeden oluşturmuştuk.

**Kesir3** projesinde sorun çıkmamıştı,
çünkü normalde bir C# .NET projesindeki
bir sınıf tanımında kurucu fonksiyon
olması zorunlu değildir.
Kurucu fonksiyon yoksa üye değişkenler
.NET platformunda varsayılan ilk değerleri
alırlar. Tamsayı değişkenler için de
varsayılan ilk değer 0 olacaktır.
> *Ders oturumlarında Linux ortamında 
oluşturduğumuz örnek projeler
.NET Core platformuna dayalı olduğu için, 
onlardaki sınıf tanımlarında
argüman almıyor da olsa bile,
bir kurucu fonksiyon olması zorunluydu.*

**Kesir4** projesinde ilk değerleri
dışarıdan iletilen argüman aracılığıyla
alan bir kurucu fonksiyon oluşturmuştuk.
Tek kurucu fonksiyon argüman istediği
için de ilk değer iletmeden yeni bir
kesir nesnesi oluşturamazdık.

Bu projede sınıf tanımına argüman almayan
bir "boş kurucu fonksiyon" (*default constructor*)
ekliyoruz:
```
public Kesir()
{ _pay = 0; _payda = 1; }
```
ve iyi de oluyor, çünkü kurucu fonksiyon
olmadığında varsayılan ilk değer 0
`_payda` üye değişkeni için sorun olacaktı.

Paydaya 0 değeri atanmasından kaçınmamız
gerektiğini anlayınca, aslında argüman
alan kurucu fonksiyonda da gevşek davrandığımızı
da anlarız. İkinci argüman `q` değerini
kontrol etmeden üye değişken `_payda`ya
aktarıyorduk.

Hem 0 değeri, hem de olası negatif değerlerin
yol açabileceği sorunları önceden düşünerek,
bu projede `Kesir` sınıf tanımını daha sağlam
olacak şekilde yeniden düzenledim.
Elim değmişken, kesrin ondalıklı eşdeğerini
hesaplayan `Oran` fonksiyonu yerine de
ondalıklı değeri veren bir tür dönüşüm
işlemcisi tanımladım.