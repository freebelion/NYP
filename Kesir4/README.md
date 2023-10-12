## Kesir4
Bir nesneyi temsil eden bilgileri
bir sınıf (`class`) tanımında
paketlemişsek, o bilgilerin dışarıdan
kontrolsüz bir şekilde değiştirilmesini
engellemek daha doğru olur.

Bu nedenle, aynı nesneye ait bilgileri
saklayacak olan sınıf içi değişken
tanımları -ki bunlara "üye değişkenler"
(*member variables*) diyoruz-
normalde sınıf dışındaki kodlardan
erişime kapalıdır.
> ***Kesir3** projesinde,
kendime kolaylık olsun diye,
üye değişkenler `pay` ve `payda`yı
dışarıdan erişime açmak için
`public` etiketiyle tanımlamıştım.<br>


Bu projede sınıf üye değişkenlerine
dışarıdan serbest erişimi engellemek için
tanımlara `private` etiketini ekledim.
> *"Verilerin gizliliği" (**data hiding**)
nesneye yönelik programlamanın
ikinci önemli prensibidir.*

> *EK BİLGİ: Sınıf içindeki bir tanımda herhangi
bir etiket yoksa `private` etiketi
kullanılmış varsayılır.*

Tabi o zaman da bir kesir nesnesini
oluşturan `pay` ve `payda` değerlerini
dışarıdan öğrenip yazdırmak için
bir kontrollü erişim sağlamam gerekli oldu.

Bunu da özellik (*property*) tanımlarıyla
sağladım. Üye değişkenleri ayırt etmek
için başlarına alt çizgi karakteri ekledim.
Adet yerini bulsun diye baş harflerini
büyük yaptığı özellikler birer fonksiyon
gibi davranan `get` bloklarında
gizli üye değişkenlerin değerlerini
dışarıya iletiyorlar.
> *"Gizli" değişkenlerin değerlerini
böyle serbestçe dışarıya iletmekle
gizlilik prensibine aykırı davranmış 
olmayız. Bir kesrin pay veya payda
değerini dışarıya iletmekte sorun yoktur,
ama olsaydı bile `get` blokunda erişim
kontrolü sağlayacak kodlar ekleyebilirdik.*

Programda tanımladığım iki kesrin
pay ve paydasına kendi belirlediğim
ilk değerleri atamak için de sınıf
tanımına bir kurucu fonkisyon
(*constructor*) ekledim. 
Sınıf ile aynı adı taşıyan ve sonuç
türü (`void`, `int`, `double` vs.)
olmayan bu özel fonksiyon argüman
olarak aldığı iki tamsayı değeri
gizli üye değişkenleri `_pay` ve
`_payda`ya aktarıyor.

Programdaki `k1` ve `k2` Kesir nesnelerini
oluşturan `new Kesir(2,5)` ve
`new Kesir(3,5)` komutlarıyla iletilen
ilk değerler bu kurucu fonksiyona
`p` ve `q` argüman değerleri olarak
geliyor ve gizli üye değişkenlere
aktarılmış ve kesirlerin ondalıklı
eşdeğerleri önceki programlardaki gibi
doğru hesaplanmıştır.