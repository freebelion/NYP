## Kesir4
Bir nesneye ait özel bilgileri bir sınıf (`class`)
tanımında paketlemişsek (kapsüllemişsek),
o bilgilerin dışarıdan kontrolsüz bir şekilde
değiştirilmesini engellemek daha doğru olur.
> If we have packaged (encapsulated) the
private information belonging to an object
in a `class` definition, it is better to prevent
them from being changed from outside in an
uncontrolled manner.

Buna ek olarak, bir sınıf tanımını tek başına ayrı
bir kod dosyasına koymak da daha doğru olur.
Sebep şudur ki, gerçek hayatta bu sınıf tanımını
gerçek hayattaki bir nesnenin gizli/açık özelliklerini
ve davranışlarını bilen bir tasarımcı programcı
oluşturacak ve onu ayrı bir **.dll** kütüphane modülü
içinde paketleyip onu kullanan program kodlarını 
yazacak olan aracı programcılara teslim edecektir.
> In addition to that, it is also better to place
a class definition in a separate code file by itself.
The reason is that, in real life, the class definition
will be created by a designer programmer
who knows of the hidden/open properties and behaviors
of a real-life object and will be delivered in a
**.dll** library module to a client programmer
who will write the program code
that make use of the class definition.

Bu nedenle, sınıf içi değişken tanımları -ki bunlara
"üye değişkenler" (*member variables*) diyoruz-
normalde sınıf dışındaki kodlardan erişime kapalı
olmalıdır.
> For that reason, the variables defined within
a class -which we call "member variables"-
should normally be closed to outside access.

**Kesir3** projesinde, ilk giriş örneği
kolay anlaşılsın diye, üye değişkenler
`pay` ve `payda`yı `public` etiketiyle
dışarıdan erişime açmıştım.<br>
Bu projede ise, sınıf üye değişkenlerine
dışarıdan serbest erişimi engellemek için
tanımlara `private` etiketini ekledim.<br>
*"Verilerin gizliliği" (**data hiding**)
nesneye yönelik programlamanın
ikinci önemli prensibidir.*
> In **Kesir3** project, to make this introductory
example easier to understand, I had made
the member variables `pay` and `payda`
open to outside access with the `public` label.<br>
In this project, I have added the `private` labels
to them to prevent free access to them from outside.<br>
*The privacy of information (**data hiding**) is the
second important principle of object-oriented programming.*

Bu gizlilik tercihim nedeniyle, bir kesir nesnesini
oluşturan `pay` ve `payda` değerleri dışarıdan
öğrenilip yazılabilsinler diye
bir kontrollü erişim yolu sağlamam gerekli oldu.
> Due to my preference of privacy, it became necessary
for me to provide a means for controlled access
so that the values of `pay` and `payda` variables
could be learned and written from outside.

Bunu da özellik (*property*) tanımlarıyla sağladım.
Üye değişkenleri ayırt etmek için başlarına
alt çizgi karakteri ekledim.
*Bu birçok programcının tercih ettiği
bir isimlendirme şeklidir, 
ama öyle yapılmasu zorunlu değildir.*
Adet yerini bulsun diye özelliklere hangi değerleri
sağladıklarını belli eden, baş harfleri büyük
anlamlı isimler verdim, ama yine hatırlatalım,
öyle yapılması zorunlu değildir.
> I have made this possible through *property*
definitions. I have also added **_** (underscore)
character to distinguish the member variable names.
*This is a naming method preferred by many programmers,
but doing so is not mandatory.*
Just to follow the customs, I have given the properties
meaningful names which start with capital letters
to clarify what values they provide,
but let us remind again, doing so is not mandatory.<br>

Bu özellikler birer fonksiyon
gibi davranan `get` bloklarında
gizli üye değişkenlerin değerlerini
dışarıya iletiyorlar, ama bir özellik tanımı
mutlaka gizli bir değişklene kontrollü erişim
sağlayacak diye bir kural yoktur.
> These properties simply send the values of hidden
member variables to outside in their `get` blocks;
however, there is no hard rule which states that
a property definition must provide controlled access
to a hidden member variable.

"Gizli" değişkenlerin değerlerini
böyle serbestçe dışarıya iletmekle
gizlilik prensibine aykırı davranmış  olmayız.
Bir kesrin pay veya payda değerini
dışarıya iletmekte sorun yoktur,
ama olsaydı bile `get` blokunda erişim
kontrolü sağlayacak kodlar ekleyebilirdik.
> We won't be in conflict with the data hiding principle
by so freely providing the values of private variables
like that.
There is nothing wrong with sending the values of
a fraction's numerator and denominator to outside code;
even if there could be some issues, we could add
certain conditional statements within the `get` blocks
to ensure the proper access controls.

Artık `private` etiketleriyle gizlenmiş
olan `_pay` ve `_payda` değişkenlerine
en azından ilk değerleri atamak için de
sınıf tanımına bir kurucu fonksiyon
(*constructor*) ekledim.
> I have also added a *constructor* function
to help assign at least initial values
to `_pay` and `_payda` variables which are
now hidden with `private` labels.

Bir kurucu fonksiyon -zorunlu olarak- 
sınıf ile aynı adı taşır
ve sonuç türü belirten (`void`, `int`, `double` vs.)
etiketleri taşımaz.
Bu örneğimizdeki kurucu fonksiyon argüman
olarak aldığı iki tamsayı değeri üye değişkenler
`_pay` ve `_payda`ya aktaracaktır.
> A constructor function -by requirement- 
carries the same name as the class
and does not have any labels like
`void`, `int`, `double`, etc. 
which specify the data type of a result.
In this example of ours, the constructor function
will assign the two integer values which it receives
as arguments to the member variables 
`_pay` and `_payda`.

**Kesir4Program** kod dosyasında `k1` ve `k2`
kesir nesnelerini argüman alan
kurucu fonksiyonumuzla oluşturuyoruz:<br>
`Kesir k1 = new Kesir(2,5);`<br>
`Kesir k2 = new Kesir(3,5);`<br>
Bu komutlardaki ilk değerler (2 ve 5 ile 3 ve 5)
bu kurucu fonksiyona `p` ve `q` argüman değerleri olarak
geliyor ve gizli üye değişkenlere aktarılmış
ve yazdırma komutlarında pay ve payda değerleri
özellik tanımları sayesinde öğrenilmiştir.
> In **Kesir4Program** code file,
we create the fraction objects `k1` and `k2`
by using our constructor function which accepts
parameters:<br>
`Kesir k1 = new Kesir(2,5);`<br>
`Kesir k2 = new Kesir(3,5);`<br>
In these commands, the initial values (2,5 and 3,5)
have been assigned to hidden member variables
as the values of `p` and `q` parameters
and the numerator and denominator values
have been obtained through the property definitions
in the printing statements.