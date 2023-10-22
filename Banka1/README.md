## Banka1
Bu projede `static` terimiyle sınıfa ait ortak kullanılacak
üye değişkenler tanımlamayı gösteriyorum.

### `Hesap` Sınıf tanımındaki `static` numaralandırıcı
`Hesap` sınıf tanımı gerçek hayattaki bir bankanın yönetim
sisteminde oluşturulacak bir hesabı temsil ediyor.
Gerçek hayatta bir banka oluşturacağı her hesaba türüne
göre, kendi banka tanıtım kodunu da ekleyerek, birbirleriyle
çakışmayacak hesap numaraları verirdi. Ben bu ilkel örnekte
yalnızca oluşturulan `Hesap` nesnelerini sayarak onlara
otomatik artan numaralar verme yoluna gittim.

`Hesap` nesneleri, tabi ki birbirlerinden habersiz olacaklardı.
O nedenle, onların ortak kullanacağı `hesap_sayisi` değişkenini
`static` etiketiyle tanımladım. Yani bu değişken artık sınıfa
aitti. Her `Hesap` nesnesi oluşturulduğunda bu sayı bir artsın
diye, `Hesap` sınıfının boş kurucu fonksiyonuna gerekli
arttırma komutunu ekledim. Sınıf kendi türünden nesnelerin
sayısını istendiğinde dışarıya iletsin diye de,
bu gizli `static` değişkenin değerini bildiren bir `static`
özellik tanımladım.

Ortak değişken `hesap_sayisi` için ilk değer atamasını
bu değişkenin tanım satırında yapabilirdim.
Sırf örnek olsun diye, bu ilk değer atamasını
(bu örnekte 1000, yani hesaplar 1000'den başlayan
numaralar alacaklar) yapmak için bir de `static`
etiketli ayrı bir kurucu fonksiyon tanımladım.

`static` etiketli bir üye değişkenin yalnızca
bir örneği olacak, sınıf türünden tüm nesneler
o tek değişkeni ortak kullanacaklardır.
Bu etiketi taşıyan bir ortak değişkene nesne
oluşturan bir kurucu fonksiyonda değer ataması
yapabiliriz; nitekim, `Hesap` sınıfının boş
kurucu fonksiyonunda `hesap_sayisi` değişkeni
değerini arttırıyoruz. Ama bu değişkenden yalnızca
bir tane olacağına göre, ilk değer atamasını da
yalnızca bir kez yapmalıyız. `static` etiketli kurucu
fonksiyon işte bu işe yarar; sınıfa ait ortak değişken
veya özellikler için ilk değer atamasını aynı etiketi
taşıyan kurucu fonksiyonda yaparız. Böyle bir ortak
kurucu fonksiyon yalnızca bir kez, program çalışmaya
başladığında, işleme konur.

### `Hesap` Sınıf tanımındaki diğer özellik ve fonksiyonlar
Bu sınıf tanımını sınıf türetme örneklerinde de kullanacağım.
O yüzden, daha şimdiden faydalı olabilecek başka eklemeler yaptım.
- `Bakiye` özelliği hesap bakiyesinin dışarıdan değiştirilmeden
  öğrenilmesini sağlıyor.
- `ParaEkle` fonksiyonu argüman olarak iletilen tutarı
  hesap bakiyesine ekliyor.
- `ParaCek` fonksiyonu argüman olarak iletilen tutarı
  *bakiye yeterliyse* hesap bakiyesinden düşüyor.
- `BakiyeYeterli` fonksiyonu argüman olarak iletilen tutarı
  hesap bakiyesiyle karşılaştırıyor ve bakiye bu tutarı
  karşılıyorsa olumlu `true` sonucu,
  karşılamıyorsa`olumsuz `false` sonucu gönderiyor.

Program kodlarında bütünüyle rasgele tarih ve zamanlarda
`Hesap`türü nesneler üzerinde hayali işlemler yaptırıyorum.