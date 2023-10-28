## Seri1
Bu projede soyut sınıf kavramını tanıtıyorum.

### Soyut sınıf `Seri`
Ortaokul veya ilkokulda aritmetik ve geometrik dizileri
öğrenmiş olabilirsiniz. O dizilerin iki ortak özelliği
vardı: Bir ilk değer ile başlıyorlardı ve her adımda
o değeri belli bir adım değerini kullanan bir ilerleme
formülü ile değiştiriyorlardı.

Bu projedeki `Seri` sınıfı o dizilerin iki ortak 
özelliğini `ILK` ve `ADIM` olarak tanımlıyor.<br>
*Programlama dillerinde "dizi" farklı bir anlam taşıdığı
için matematiksel diziler için `Seri` diye farklı bir
isim uydurdum.*<br>
`Seri` sınıfı ayrıca bir sonraki sayıyı hesaplacak
olan bir fonksiyona sahip olmalıdır.
Onu da `Sonraki()` adıyla tanımladım.
Ama matematiksel dizilerin sayı üretme yöntemi
(yani "dizi formülü") aynı değildir.
Aritmetik bir dizi sonraki sayıyı o an geçerli
sayıya adım değerini ekleyerek -ya da çıkartarak-
hesaplar, ama geometrik bir dizi her adımda bir çarpma
işlemi yapar.

Kısacası, matematiksel dizilerin ortak özelliklerini
tanımlayan `Seri` sınıfı sonraki sayıyı hesaplamak
için belli bir formül dikte edemez. Bu fonksiyonun
içini boş bırakmalıdır.
Ama o zaman da, `Seri` sınıfı türünden bir nesne
sonraki sayı istendiğinde hiç bir hesap yapmadan
boş oturacaktır. O da saçma olurdu tabi ki.

Yani benim tanımladığım `Seri` sınıfı
farklı türden matematiksel dizilerin ortak
özelliklerini tanımlıyor, ama kendisi
gerçek bir nesneyi temsil etmiyor.
Bu nedenle `Seri` sınıfını bir "soyut sınıf"
(*abstract class*) olarak tanımladım. 
Dolayısıyla, program kodlarında <br>
`Seri s = new Seri()` <br>
gibi bir komutla bu türden bir nesne tanımlayamam.
Bu sınıf ancak tanımladığı ortak özelliklere
sahip olacak başka sınıflar türetmek içindir.

### Soyut `Seri` sınıfından türetilmiş sınıflar
Matematik derslerinden hatırladığınız gerçek dizi
türlerini temsilen oluşturduğum `AritmetikSeri` 
ve `GeometrikSeri` sınıflarını yukarıda anlattığım
soyut `Seri` sınıfından türettim.

Türettiğim bu sınıflar ata sınıftan miras aldıkları
değişken ve özellikleri kendi ilerleme formüllerinde
kullanmak için `Sonraki()` fonksiyonunu yeniden
tanımlıyorlar.

Ama şöyle bir durum var: Soyut `Seri` sınıfından
türetilmiş olan sınıflarda `Sonraki()` fonksiyonunu
yeniden tanımlamak zorunlu olmalıdır.
`Seri` sınıfı o fonksiyonun kod blokunu boş
bırakmakla yetinemez, çünkü bir programcı
yeni bir sınıf türetirken `Sonraki()` fonksiyonunu
yeniden tanımlamazsa, ilerleme formülü olmayan
işe yaramaz bir matematiksel dizi oluşturmuş olur.

### Soyut özellik veya fonksiyonlar
Kısacası, soyut sınıf `Seri` tanımındaki
`Sonraki()` fonksiyonu gerçek bir fonksiyon
bile olmamalıdır. Bu nedenle, onu da 
`abstract` etiketiyle, soyut bir sınıf olarak
tanımladım. Dolayısıyla, bu fonksiyonun bir kod
bloku yok, ve olamaz da.
Fonksiyon tanım başlığı boş argüman listesini
içeren **()** parantez çiftinden sonra
bir noktalı birgül ile bitiyor.

Bir soyut sınıfın içeriğini belirlemediği özellik
tanımları da olabilir. Onları da `abstract` etiketiyle
tanımlarız ve `get` ve `set` bloklarını kod yazmadan
bırakırız, tıpkı oto-özelliklerde yaptığımız gibi.

Soyut sınıftan türetilen sınıflar ata sınıfın
`abstract` etiketiyle tanımladığı fonksiyon ve
özellikleri `override` etiketiyle yeniden tanımlamak
zorundadırlar. Örnek proje kodlarını kopyalayıp
yapıştırmak yerine `AritmetikSeri` ve `GeometrikSeri`
sınıflarını kendiniz tanımlarsanız,
`Seri` sınıfından türetme ilişkisini gösteren 
tanım başlığını yazdıktan sonra, derleyici
o sınıfların soyut fonksiyon `Sonraki()`yi
yeniden tanımlamaları gerektiği konusunda
sizi uyaracaktır.

### Soyut sınıfların önemli özellikleri
Kısaca özetlersek,
- Bir soyut sınıfı `class` teriminden önce gelen
  `abstract` etiketiyle tanımlanır.
- Soyut sınıf türünden bir nesne oluşturulamaz.
  Bu sınıf tanımı yalnızca ondan türetilecek
  başka sınıfların ortak özellik ve davranışlarını
  belirleyecektir.
- Soyut sınıf tanımında
    - üye değişken tanımları,
    - özellik tanımları
    - üye fonksiyon tanımları<br>
  olabilir. Türetilmiş sınıflar bütün o tanımları
  miras alırlar, ve `protected` veya `public`
  etiketli olanları kendi kodlarında kullanabilirler.
- Soyut sınıf içeriğini kendi belirlemediği özellik
  veya fonksiyonları `abstract` etiketiyle
  "soyut özellik" veya "soyut fonksiyon" olarak
  tanımlayabilir. Türetilmiş sınıflar o soyut özellik
  ve fonksiyonları `override`etiketiyle yeniden
  tanımlamak zorundadırlar.
  - *ÖNEMLİ NOT: Bir soyut sınıf tanımında
     soyut özellik veya fonksiyon tanımları olabilir,
     ama olmaları zorunlu değildir.*
  - *Öte yandan, ancak soyut bir sınıfta
     soyut özellik veya fonksiyon tanımları olabilir.
    `abstract` etiketi taşımayan normal bir sınıf
     tanımında `abstract` etiketli özellik veya fonksiyon
     tanımları olamaz.*
- Bir soyut sınıf tanımında argüman alan veya almayan
  kurucu fonksiyonlar olabilir. Türetilmiş sınıflar
  soyut sınıfın kurucu fonksiyonlarını aynı şekilde
  tanımlamış olmalıdır.<br>
  *Netekim, benim `AritmetikSeri` ve `GeometrikSeri`
  sınıflarımda tıpkı soyut sınıf `Seri` sınıfındaki 
  gibi, matematiksel dizinin ilk değerini ve adım değerini
  argüman olarak bir kurucu fonksiyon var.*<br>
  Türetilmiş sınıflar yeniden tanımladıkları
  bu kurucu fonksiyonların tanım başlıklarında
  soyut ata sınıfın kurucu fonksiyonunu çağırabilirler.<br>
  *AritmetikSeri` ve `GeometrikSeri` sınıf tanımlarında
   bunu nasıl yapacağınızı gösterdim.*