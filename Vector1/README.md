## Vector1
Bu projede fizik derslerinde öğrendiğim
türden bir vektörü temsil edecek `Vector` sınıf
tanımını kendi ayrı kod dosyasında oluşturdum.

Vektör bileşenlerini dışarıya açık iki
oto-özellik (*auto-property*) ile temsil
etmeyi seçtim. Vektör bileşenlerinin alabileceği
değerler için bir ön kontrol gerekmiyordu;
o nedenle, dışarıya açık bir üye değişkenle
eşdeğer (sanki!) olacak bu özellikleri tanımladım.
> *Derinlere inecek bir bilgi taraması yaparsanız,
oto-özelliklerin dışarıya açık üye değişkenlerle
eşdeğer olup olmadığına dair tartışmaları
okuyabilirsiniz. Okuduklarınızdan mantıklı
sonuçlar çıkartırsanız, bana da bir özet gönderin.*

`Vector` sınıfına iki kurucu fonksiyon ekledim.
Biri bileşenler için varsayılan 0 değerlerini
atayan boş kurucufonksiyon
(.NET Core için gerekebilir).
Diğeri de dışarıdan iletilecek ilk değerleri
atayan argüman alan bir kurucu fonksiyon.

Fizikte vektörlerin toplanması kuralını
(iki vektörün toplamı, bileşenleri
o iki vektör bileşenlerinin karşılıklı
toplamlarına eşit olan üçüncü bir vektördür)
uygulayan bir de toplama işlemcisi tanımladım.
Gerçek hayatta normal aritmetik işlemlere
tabi tutulan türden nesneleri
(vektör, karmaşık sayı, kesir, vb.)
temsil eden sınıf tanımlarında
işlemci tanımları yapılabilir.
İşlemci tanımı aynı bu örnekteki gibi olmalıdır:
- İşlemcinin nesnenin kendisine ait
  değil de sınıfa ait olduğunu belirten
  **static** etiketi.
- İşlemcinin elde edeceği sonucun türü
  (bu örnekte `Vector`, çünkü iki vektör
  toplanıyorsa sonuç yine bir vektördür)
- Bir işlemci tanımladığımızı belirten
  **operator** terimi.
- İşlemcinin alacağı argümanlar listesi
  (toplama, çarpma, vb. aritmetik işlemciler
  için iki adet).

Programın ana fonksiyonunda bu sınıf türünden
beş elemanlı bir `vektorler` dizisi tanımladım.
Bu diziyi tanımlayarak 5 adet `Vector` nesnesi
oluşturmadım.
Bu dizinin her elemanı ileride oluşturabileceğim
bir `Vector` nesnesinin adresini saklayacak
olan bir "referans değişkeni"
(*reference variable*) idi.

Dizi tanımını izleyen döngüyle, dizi boyutu kadar
yani beş adet `Vector` nesnesi oluşturdum.
Bu nesneleri oluştururken, argüman alan
kurucu fonksiyon aracılığıyla, bileşenlere
-10 ile +10 arasında değişen ondalıklı
ilk değerler atadım.
Bu döngüde oluşturduğum nesnelerin adreslerini
dizinin elemanlarına,
yani o beş adet referans değişkenine aktardım.

Bu ilk komutlardan sonraki döngülerde ise
dizi elemanlarına karışılık gelen `Vector`
nesnelerinin toplamını aldım,
nesnelerin her birinin gösteren toplama işlemini
yazdırdıktan sonra sonucu yazdırdım.