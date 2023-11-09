## Dizi1
Bu projede içeriğindeki `double` türü
ondalıklı sayılar dizisine eleman ekleme
imkanı veren bir "sarıcı sınıf"
(*wrapper class*) oluşturuyorum.

### Esnek dizi sınıfı
**Dizi.cs** kod dosyasında tanımladığım
`Dizi` sınıfı ile yeni başlayan programcılara
bir kaç değişik kavramı tanıtmayı umuyorum:

- Bu sınıf tanımı aslında kendi içeriğindeki
  gizli üye değişken `_array` ile
  normal bir dizi tanımı barındırmaktadır.
  Amacı kendi tanımladığı özellik veya
  üye fonksiyonlar aracılığıyla içeriğindeki
  diziye başka özellik veya davranışlar
  kazandırmaktır.<br>
  Yani içeriğindeki nesneyi dışarıdan
  kontrollü erişime sunan
  bir "sarıcı sınıf"tır.
> *"sarıcı" deyince, hediyeleri
   saran paket kağıdı (wrapper)
   gelsin aklınıza.*
- `Dizi` sınıfı içeriğindeki diziyi
    - boş kurucu fonksiyonda 1 elemanı,
    - argüman alan kurucu fonksiyonunda
      ise belirtilen sayıda elemanı olan
      bir dizi olarak oluşturmaktadır.
- `Dizi` sınıfı türünden bir nesne
  sardığı asıl dizi `_array`in eleman
  sayısına bakmaksızın,
  `ElemanSayisi` özelliği aracılığıyla,
  kendi eleman sayısını
  kendi takip edecektir.
> *Gizli dizi `_array`in eleman sayısı
  `Dizi` nesnesi için `Kapasite` değeridir.*
- `Ekle` fonksiyonuyla `Dizi` nesnesine
  eleman eklenince `ElemanSayisi`
  değeri 1 artacaktır.
  - `ElemanSayisi` değeri kapasiteyi
    belirleyen `_array`in eleman
    sayısına eşitlenmişse,
    `_array` dizisi boyutu ikiye katlanarak
    yeniden oluşturulacak, böylece 
    Dizi` nesnesinin kapasitesi iki katına
    çıkacaktır.
- `Dizi` sınıfı içeriğindeki diziye
  kontrollü erişim sağlarken, kendisi de
  bir dizi gibi davranacağı için,
  bir "koleksiyon sınıfı"dır.
  Dolayısıyla, elemanlarına sırayla
  veya sıra numarasıyla erişim sağlamalıdır.
  Biz `this[int sirano]` *indexer*
  özelliği aracılığıyla sıra numarasıyla
  erişim sağlıyoruz.
- Böyle bir esnek dizi sınıfı tanımlamak
  yerine `List<>` türü bir liste kullanmak
  daha doğru olurdu.
  Yine de, egzersiz yapsınlar diye,
  yeni programcıların bu sınıf tanımında
  boş bıraktığım yerleri tamamlamalarını öneriyorum.
