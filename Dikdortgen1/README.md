## Dikdortgen1
Bu projede biri diğerinin bir örneğini
kullanan iki sınıf tanımı oluşturdum.
`Nokta` sınıfı koordinatlarını dışarıya
açık oto-özelliklerle belirleyeceğimiz
bir iki boyutlu bir noktayı temsil ediyor.

`Dikdortgen` sınıfı ise, sürprüz!
bir dikdörtgen alanı temsil ediyor.
`Dikdortgen` sınıfında temsil ettiği
dikdörtgenin sol üst köşe noktasını
temsil edecek olan bir `Nokta` türü
bir özellik tanımladım:
```
public Nokta SolUstKose { get; private set; }
```

`SolUstKose` özelliği, ki aslında bir referans
değişkenidir, `get` blokuyla sol üst köşe
koordinatlarının dışarıdan öğrenilmesine
veya değiştirilmesine izin veriyor,
ama `set` blokunu gizli tuttuğu için 
köşe noktası referansının başka bir nokta
nesnesinin referansıyla değiştirilmesine
izin vermiyor.

Yukarıdaki komutla tanımladığımız özellik
yarı-gizli bir oto-özelliktir. Aslında
alt yapısında bir üye değişken vardır.
Dışarıya tam açık bir oto-özellikten farkı
şudur ki dikdörtgeni oluşturan temel bir öğe
olan sol üst köşenin dışarıda yaratılmasına
veya dışarıda yaratılmış bir nesneye referans
yapmasına izin vermez.

`Dikdortgen` sınıf tanımını yalnızca
yukarıdaki `SolUstKose` özelliğini
tanımladıktan sonra yarım bırakırsanız,
aşağıdaki gibi bir hata mesajıyla
karşılaşırsınız:
```
Non-nullable property 'SolUstKose' must contain a non-null value when exiting constructor.
Consider declaring the property as nullable.

```
Bu mesajda .NET derleyicisi tanımladığınız
referans değişkenine karşılık gelecek
bir nesne tanımladığınızı belirtiyor.
Alternatif bir çözüm olarak, referans
değişkeninin "boş" (`null`) kalmasına
izin verecek bir tanım şekli öneriyor.
.NET Core platformunun sunduğu
boş kalabilen referans kavramını sonra 
inceleriz. Ben şimdilik her `Dikdortgen`
nesnesinin kendine ait bir sol üst köşe
noktası var olsun diye, sınıfa bu noktayı
oluşturan bir boş kurucu fonksiyon
ekleyeceğim:
```
    public Dikdortgen()
    {
        SolUstKose = new Nokta();
    }
```

Bu sınıf tanımını hazır kullanacak olan
bir programcı belki sol üst köşe
koordinatlarını ve dikdörtgen boyutlarını
önceden belirleyip dışarıdan iletmek ister
diye, argüman alan başka kurucu
fonksiyonlar da tanımladım.
Dikkat edin, bu kurucu fonksiyonlar
birbirlerinin alternatifleri olacaktır.
Yani, örneğin `Nokta` türü bir argüman
ile ondalıklı (`double`) türü
iki argüman iletilmişse,
ikinci kurucu fonksiyon devreye girecektir.

Bu ikinci kurucu fonksiyon gelen 
`Nokta` türü referans değişkenini
doğrudan kendi `SolUstKose` özelliğinde
saklayabilirdi, ama o zaman sol üst köşe
noktasını dışarıdan tanımlanmış,
ne idüğü belirsiz, geleceği hepten belirsiz
bir nesneye bağlamış olurdu.
Bu nedenle, bu kurucu fonksiyon tıpkı
boş kurucu fonksiyondaki gibi,
dikdörtgenin sol üst köşe noktasını
kendisi oluşturmalıdır.

Kurucu fonksiyon tanım başlığında
boş kurucu fonksiyon referansı ekleyerek,
bu işi yine boş kurucu fonksiyona
havale ettik. Daha donra bu yeni
kurucu fonksiyon referansı argüman olarak
gelen `Nokta` nesnesinin koordinatlarını
kendi köşe koordinatları olarak sakladı.

Sol üst köşe koordinatlarını da argüman
olarak alan üçüncü kurucu fonksiyon ise
köşe noktası nesnesini kendisi oluşturuyor,
o işi boş kurucu fonksiyona havale etmiyor.
> *Tüm bu alavere-dalavereleri planlarken,
  bu `Dikdortgen` sınıf tanımını kullanacak
  olan örnek program komutları yazmayı
  unutmuşum. Bir zahmet, örnek komutları
  siz yazın ve belki de `Dikdortgen`
  sınıf tanımına faydalı olacağını
  düşündüğünüz başka özellik veya fonksiyon
  tanımları ekleyin.*