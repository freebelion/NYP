## Dizi1
Bu projede içeriğindeki `double` türü
ondalıklı sayılar dizisine eleman ekleme
imkanı veren bir "sarıcı sınıf"
(*wrapper class*) oluşturuyorum.
> In this project, I am creating a *wrapper class*
which enables its programmer to add elements
to the `double` array it contains.

`Dizi` sınıfının boş kurucu fonksiyonu
1 eleman kapasiteli bir boş dizi oluşturuyor.
Argüman alan kurucu fonksiyonu ise
argüman olarak iletilen sayıda kapasitesi olan
bir boş dizi oluşturuyor.
> `Dizi` class creates an array with
1 element capacity.
Its constructor with parameter
creates an array with the capacity
specified by its argument.

`Dizi` sınıfı `Ekle()` fonksiyonuyla iletilen
yeni değerleri içeriğindeki `_array`deki
boş yerlere aktarıyor.
Yeni elemanlar için kullandığı kapasiteyi
`ElemanSayisi` özelliği aracılığıyla
takip ediyor.
> `Ekle()` function of the `Dizi` class
places the new values it receives as arguments
to the unused spots in the member `_array`.
It keeps track of the capacity it has used
for new elements with the property
`ElemanSayisi` (Element Count).

Normalde bir diziye eleman eklenerek veya
diziden eleman silinerek dizi boyutu değiştirilemez.
Bizim `Dizi` sınıfı burada özetlediğimizi
özellik ve fonksiyonları ile
içeriğindeki diziye eleman ekleme/silme
yeteneği kazandırmış oluyor.
> Normally, an array's size cannot be changed
by adding/deleting elements to and from it.
Our `Dizi` class adds the ability to add/delete
elements in the array it contains.

Eklenen elemanlar `_array`in kapasitesini
doldurmuşsa, `KapasiteArttir()` fonksiyonu
`_array` dizisini iki kat kapasite ile
yeniden oluşturuyor ve var olan elemanları
yeni diziye kopyalıyor.
> If the added elements have used up
all the capacity of `_array`,
the function `KapasiteArttir()` (Increase Capacity)
creates another array with twice the capacity
and copies the existing elements to the new array.

`Dizi` sınıfının `this[int sirano]`
*indexer* özelliği elemanlara sıra numarasıyla
 erişim sağlıyor.\Tabi ki böyle bir esnek dizi
 sınıfını sıfırdan tanımlamak yerine
 `List<>` türü bir jenerik liste kullanmak
 daha doğru olurdu.
 Bu deneme yalnızca bir programlama egzersizidir.
 > The indexer property `this[int sirano]`
 of the class `Dizi` provides acces to the elements
 through index numbers.\
 Of course, it would be better to use a jeneric
 collection of the `List<>` type,
 instead of designing a flexible array class
 like this from scratch.
 This attempt is only a programming exercise.
