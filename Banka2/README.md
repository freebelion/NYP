## Banka2
Bu projede sınıf türetmenin ilk örneğini sunuyorum.
> In this project, I am presenting the first example
of deriving a class.

Bu projedeki `Hesap` sınıf tanımını önceki
**Banka1** projesinden kopyaladım.
**Banka2** proje simgesi üstünde kısayol menüsünü
açınca, **Add** başlığı altında **Existing Item** 
seçeneğini tıklayp, **Banka1** proje klasöründen
**Hesap.cs** kod dosyasını seçtim.
Böylece o kod dosyasındaki sınıf tanımını
bu yeni projeye getirmiş oldum.
Sınıf tanımı bu projeye ait olsun diye,
kod dosyasındaki ad uzayı ismini **Banka2** yaptım.
> I copied the `Hesap` (Account) class definition
from the **Banka1** project.
When I opened up the shortcut menu on the icon
of the **Banka2** project, I clicked on the
**Existing Item** option under the heading **Add**,
and then selected the code file **Hesap.cs**
in the project folder of **Banka1**.
Thus I ended up bringing the class definition
in that code file to this new project.
To ensure that the class definition would not belong
to this project, I changed the name of the namespace
to **Banka2**.

Sonra da `Hesap` sınıfından `KrediliHesap` sınıfını türettim.<br>
Bu sınıfın tanım başlığı<br>
`class KrediliHesap : Hesap`<br>
iki sınıf arasındaki türetme ilişkisini
gösteriyor. **:** sembolünün sağındaki `Hesap`
sınıfı bu ilişkideki "ata sınıf" (*ancestor class*)
veya "ana sınıf"tır (*parent class*). 
**:** sembolünün solundaki `KrediliHesap` sınıfı
ise "türetilen sınıf" (*derived class*)
veya "çocuk sınıf"tır (*child class*).
> Afterwards, I derived the class `KrediliHesap`
(CreditAccount) from the `Hesap` class.<br>
In the class definition header<br>
`class KrediliHesap : Hesap`<br>
displays the derivation relationship
between the two classes.
The `Hesap` class on the right side of the symbol **:**
is the parent class.
The `KrediliHesap` class on the left side of **:**
is the "derived class" or the child class.

Türetilmiş sınıf ata sınıfın tüm tanımlarını "miras alır" (*inherit*).
Yani, `Hesap` türü bir nesnenin sahip olacağı her üye değişken,
özellik ve fonksiyon (`_bakiye`, `Bakiye`, `ParaEkle` vb.)
`KrediliHesap` türünden bir nesnede vardır.
Ama türetilmiş sınıf nesnesi ata sınıfın `private` etiketli
gizli değişken ve özelliklerine doğrudan erişemez.
`public` etiketi de gizliliği ortadan kaldırır.
Bir orta yol bulmak için, çocuk sınıf nesnelerinin
erişmesi gereken değişken ve özellikler için
`protected` etiketini kullanırız.
Ben de `Hesap` sınıfındaki `_bakiye` değişkeninin
etiketini `protected` yaptım ki, hem dışarıdan gizli
kalsın, hem de türetilmiş sınıf `KrediliHesap` nesneleri
bakiyeyi değiştirebilsin.
> A derived class *inherits* all the definitions
of the parent class.
In other words, all member variables, properties and functions
possessed by an object of `Hesap` type are also possesed
by an object of `KrediliHesap` type.
However, an object of the derived type cannot directly access
the hidden variables or properties of the parent class
carrying the label `private`.
On the other hand, the label `public` removes all barriers.
To find a compromise, we use the `protected` label
for the member variables and properties which should be
accessible by objects of child types.
I have, therefore, labeled the `_bakiye` variable of
the `Hesap` class as `protected`, so that objects of
`KrediliHesap` type can change the account balance.

Türetilmiş sınıf türünden bir nesne,
ata sınıftan miras aldığı her değişken ve özelliğe 
ek olarak, kendi tanımında yer alan değişken
ve özelliklere de sahip olacaktır.
Bu örnekteki `KrediliHesap` sınıfındaki
`EKSILIMIT` yalnızca bu yeni sınıfa ait olan
bir sabit değer. Bu tutar kedili hesaplar
için izin verilen eksi bakiye limitini saklıyor.
> An object of a derived type can also possess
variables and properties in its own definition,
in addition to all the variables and properties
which inherits from the parent class.
In this example, `EKSILIMIT` (OVERDRAFT_LIMIT)
is a constant value which belongs only
to this new class. It stores the negative limit
for the account balance for the accounts with credit.

Bir ata sınıfın belli bir davranışını belirleyen
bir özellik veya fonksiyon onu sanallaştıran
`virtual` etiketiyle tanımlanmışsa,
türetilmiş bir sınıf onu `override` etiketiyle
yeniden tanımlayabilir. Orijinali `Hesap` sınıfında
yer alan `ParaCek` fonksiyonunda işte bunu gösteriyorum.
`KrediliHesap` sınıfı bu fonksiyonu yeniden
tanımlıyor ki hesap bakiyesi belli bir eksi limite
kadar düşebiliyor.
> If a property or a function of a parent class
has been virtualized with the label `virtual`,
a derived class can redefine it with the label
`override`. That's what did for the `ParaCek`
(WithdrawMoney) function whose original is in
the `Hesap` class.
`KrediliHesap` class overrides this function
with its own definiton, so that the account
balance can go negative, down to the overdraft limit.

Deneme amaçlı program kodlarında `Hesap` türü
nesnelerin listesinde son beş eleman aslında
`KrediliHesap` türü nesnelerdir.
Programı çalıştırıp denerseniz,
1005 ila 1009 numaralı bu hesaplarda
bakiyenin eksiye düşebildiğini göreceksiniz.
Onlar da `hesaplar` listesinde `Hesap` sınıfı
türünden elemanlar olarak gözükmektedir,
ama para çekme işlemi onlardan birisine
denk gelirse eksi limite kadar düşme
imkanı sağlamaktadırlar.
> In the code lines of the testing program,
the last 5 elements of the list of `Hesap` objects
are actually `KrediliHesap` objects representing
accounts with credit.
If you run this program for a trial,
you will see that the balance of the accounts
numbered 1005 to 1009 can go negative.
These objects are accessed as objects of `Hesap` type
in the general list of accounts,
but in case of withdrawals, they behave as accounts
with credit and allow negative balances,
down to their overdraft limits.

Türetilmiş bir sınıf, `new` etiketini kullanarak
ata sınıfın bir özellik ya da fonksiyonunun
"yenisini" tanımlayabilir. Bunu denemek için,
`KrediliHesap` sınıfındaki `ParaCek` fonksiyonunun
`override` etiketini `new` diye değiştirin.
Bu değişiklikten sonra, deneme kodlarında
`hesaplar` listesindeki `KrediliHesap` türü
elemanların hiç eksiye düşmediklerini göreceksiniz.
Çünkü `new` etiketli fonksiyon ata sınıftan miras
alınan fonksiyonun yerine geçmez.
`hesaplar` listesindeki elemanlar ise
ata sınıf `Hesap` türünden değişkenler
aracılığıyla erişiliyordu.
> A derived class can also use the label `new`
to define a "new" version of a property or a function
of the parent class. To try this, change the
`override` label of the `ParaCek` function
in the `KrediliHesap` class to `new`.
Then  you will see that the elements of
`KrediliHesap` type in the `hesaplar` list
will never go down to negative balance.
The reason is that, a function with the `new` label
in the derived class does not replace the parent
class' function.
When they are accessed as objects of the parent type
`Hesap`, objects of `KrediliHesap` behave just like
regular accounts of `Hesap` type.

`KrediliHesap` türü bir nesne `new` etiketli
`ParaCek` fonksiyonunu ancak kendi türünden
bir değişken aracılığıyla kullanabilecektir.
İsterseniz, deneme kodlarında `KrediliHesap` 
türü elemanlardan oluşan başka bir liste
tanımlayın ve ona `KrediliHesap` türü nesneler
ekleyin. O zaman para çekme işlemlerinde
bakiyelerin eksiye düşebildiğini göreceksiniz.
> An object of `KrediliHesap` type can only make use
of its function `ParaCek` only through a reference variable
of its own type. If you want, create a separate list of
`KrediliHesap` type objects in the trial program's code.
Then you will see that those objects can go down
to negative balances after withdrawls.
