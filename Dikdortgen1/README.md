## Dikdortgen1
Bu projede biri diğerinin bir örneğini
kullanan iki sınıf tanımı oluşturdum.
`Nokta` sınıfı koordinatlarını dışarıya
açık oto-özelliklerle belirleyeceğimiz
bir iki boyutlu bir noktayı temsil ediyor.
`Dikdortgen` sınıfı ise, sürprüz!
bir dikdörtgen alanı temsil ediyor.
> In this project, I have created two class definitions,
where one uses an instance of the other.
`Nokta` (Point) class represents a point
on a two-dimensional coordinate space.
`Dikdortgen` (Rectangle) class, on the other hand,
*Surprise!* represents a rectangular area.


`Dikdortgen` sınıfında temsil ettiği
dikdörtgenin sol üst köşe noktasını
temsil edecek olan bir `Nokta` türü
bir özellik tanımladım:
```
public Nokta SolUstKose { get; private set; }
```
> In the `Dikdortgen` class definition,
I defined a property of `Nokta` type,
which will represent the top-left corner point
of the rectangle (see above)

`SolUstKose` özelliği, ki aslında bir referans
değişkenidir, `get` blokuyla sol üst köşe
koordinatlarının dışarıdan öğrenilmesine
veya değiştirilmesine izin veriyor,
ama `set` blokunu gizli tuttuğu için 
köşe noktası referansının başka bir nokta
nesnesinin referansıyla değiştirilmesine
izin vermiyor.
Yani bu özellik yarı-gizli bir oto-özelliktir.
> The property `SolUstKose`, which is actually
a reference variable, will allow learning
the coordinates of the top-left corner through
its `get` block, but it will not let the reference
to the point object because it keeps its `set`
block private.
In other words, that property
is a half-private auto-property.


`Dikdortgen` sınıf tanımını yalnızca
yukarıdaki `SolUstKose` özelliğini
tanımladıktan sonra yarım bırakırsanız,
aşağıdaki gibi bir hata mesajıyla
karşılaşırsınız:
```
Non-nullable property 'SolUstKose' must contain a non-null value when exiting constructor.
Consider declaring the property as nullable.

```
> If you leave the definition of the `Dikdortgen`
class incomplete, after simply writing the
definition of `SolUstKose` property,
you will see an error messqage like the one above.

Bu mesaj .NET derleyicisi tanımladığınız
referans değişkenine karşılık gelecek
bir nesne tanımladığınızı belirtiyor.
Alternatif bir çözüm olarak, referans
değişkeninin "boş" (`null`) kalmasına
izin verecek bir tanım şekli öneriyor.
> This message indicates that you have not created
an object which will be referenced by that property.
As an alternate solution, it suggests using 
a definition which would allow the reference
be "empty" (null).

.NET Core platformunun sunduğu
boş kalabilen referans kavramını sonra 
inceleriz. Ben şimdilik her `Dikdortgen`
sınıf tanımına bu özellik aracılığıyla
bir sol-üst köşe noktası oluşturan
bşr boş (varsayılan) kurucu fonksiyon ekleyeceğim:
```
    public Dikdortgen()
    {
        SolUstKose = new Nokta();
    }
```
> We will look into 'nullable' reference concept
some time later. For now, I will add an empty
(default) constructor definition which will
create a top-left point through that property.

`Dikdortgen` sınıf tanımını kullanan
bir programcı sol-üst köşe koordinatlarını
ve dikdörtgen boyutlarını dışarıdan iletmek
isteyebilir.
Bunu mümkün kılmak için argüman alan başka kurucu
fonksiyonlar da tanımladım.
Dikkat edin, bu kurucu fonksiyonlar
birbirlerinin alternatifleri olacaktır.
Yani, örneğin `Nokta` türü bir argüman
ile ondalıklı (`double`) türü
iki argüman iletilmişse,
ikinci kurucu fonksiyon devreye girecektir.
> A client programmer using the `Dikdortgen`
class definiton may want to pass on the
top-left corner coordinates and rectangle
dimensions from outside.
To make that possible, I have also defined
other constructor functions accepting arguments.
Notice that these constructor functions
will be each other's alternatives.
For example, if an argument of `Nokta` type
reference is passed along with two `double`
values, the second constructor function
will be executed.

Dikkat edin, ikinci kurucu fonksiyon gelen 
`Nokta` türü referans değişkenini
doğrudan kendi `SolUstKose` özelliğinde
saklayamıyor, çünkü sınıf tanımı
dışından gelen bir nesne referansına güvenemez.
Bu nedenle, bu kurucu fonksiyon tıpkı
boş kurucu fonksiyondaki gibi,
dikdörtgenin sol üst köşe noktasını
iletilmiş koordinatlarla kendisi oluşturuyor.
> Notice that, this second constructor function
does not directly store the reference passed as
its first argument in its own `SolUstKose`
property, because it cannot rely on a reference
passed from the code outside the class definition.
For that reason, just like in the default
constructor function, it creates its own
top-left corner point with the coordinates
obtained from that reference.

İkinci kurucu fonksiyon tanım başlığındaki
`: this()` ifadesi boş kurucu fonksiyonu
çağırmak içindir. Yani ikinci kurucu fonksiyon
ön hazırlık olarak sol-üst köşe noktasını
oluşturmak işini boş kurucu fonksiyona yaptırıyor.
Daha donra da argüman olarak gelen
`Nokta` nesnesinin koordinatlarını
kendi köşe koordinatları olarak saklıyor.
> The expression `: this()` in the header
of the second constructor function is for
calling the default constructor function.
In other words, this seconde constructor function
lets the default constructor create the top-left
corner point as the first step.
Afterwards, it stores the coordinates of the
incoming `Nokta` point reference in its
own top-left corner point.


Sol üst köşe koordinatlarını da argüman
olarak alan üçüncü kurucu fonksiyon ise
köşe noktası nesnesini kendisi oluşturuyor,
o işi boş kurucu fonksiyona havale etmiyor.
> When it comes to the third constructor function,
that one takes the top-left point coordinates
through the first two arguments
and creates its own top-left corner point,
without leaving this job to the default
constructor function.