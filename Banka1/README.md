## Banka1
Bu projede `static` terimiyle sınıfa ait ortak
değişkenler tanımlamayı gösteriyorum.
> In this project, I am showing how to declare
variables for common use that belong to class.

`Hesap` sınıf tanımı gerçek hayattaki bir bankanın yönetim
sisteminde oluşturulacak bir hesabı temsil ediyor.
Gerçek hayatta, bir banka oluşturacağı her hesaba türüne
göre, birbirleriyle çakışmayacak hesap numaraları verirdi.
Belki bu hesap numaraları bankanın kendi kodunu da içerirdi.
Ben bu ilkel örnekte yalnızca oluşturulan `Hesap` nesnelerini
sayarak onlara otomatik artan numaralar vermeyi tercih ettim.
> `Hesap` class represents an account which could be
in the management system of a real-life bank.
In real life, a bank would assign non-duplicate numbers
to every account it creates, according to the type of
the account. Maybe those numbers would also contain
the bank's own code number.
In this crude example, I preferred to assign incrementing
numbers to `Hesap` objects by counting how many objects
were created.

`Hesap` nesneleri, tabi ki birbirlerinden habersiz olacaklar.
Yani sınıf tanımındaki bir üye değişken ile hesap nesnelerini
sayamazdım. Sonuç olarak, `hesapIndeks` değişkenini
-sınıfa ait olsun diye- `static` etiketiyle tanımladım.
`Hesap` sınıfının boş kurucu fonksiyonuna bir arttırma komutu
ekledim ki her nesne oluşturulurken bu sayı bir artsın.
Her nesne arttırılmış bu sayıyı kendi numarası olarak saklayacak. 
> `Hesap` objects will, of course, be unaware of each other.
In other words, I could not count account objects with a member
variable in the class definition.
Consequently, I declared the `hesapIndeks` (account index) variable
with the `static` label so that it would belong to the class.
In the empty constructor of the `Hesap` class,
I added an incrementing command so that this index
would increase by one every time a new object was created.
Very new object will be storing this incremented number
as its own account number.

Ortak değişken `hesapIndeks` için ilk değer atamasını
bu değişkenin tanım satırında yapabilirdim.
Sırf örnek olsun diye, bu ilk değer atamasını
`static` etiketli ayrı bir kurucu fonksiyon tanımladım.
Sınıf tanımındaki bir kurucu fonksiyon her yeni nesne
için işleme konur. Sınıfa ait `static` kurucu fonksiyon
sınıf tanımının kullanıldığı bir program ilk çalıştığında,
yalnızca bir kez işleme konacaktır.
Bu örnekte hesap numaraları 1000'den başlasın diye
ilk değer olarak 1000 atadım.
> I could have assigned an initial value to  the common variable
`hesapIndeks` right in the same line of its declaration.
Just to have an example of how it should be done,
I created a separate constructor function with the label `static`.
A constructor function in the class definition will be executed
once for every new object. However, a `static` constructor
which belongs to the class will be executed only once,
when a program using the class definition starts running.
In this example, I assigned the initial value of 1000
to `hesapIndeks` variable so the account numbers would
starts from 1001.

Bu sınıf tanımındaki diğer önemli özellik ve fonksiyonlar şunlardır:
- `Bakiye` özelliği hesap bakiyesinin dışarıdan değiştirilmeden
  öğrenilmesini sağlıyor.
- `ParaEkle` fonksiyonu argüman olarak iletilen tutarı
  hesap bakiyesine ekliyor.
- `ParaCek` fonksiyonu argüman olarak iletilen tutarı
  *bakiye yeterliyse* hesap bakiyesinden düşüyor.

> Here are the other important properties and functions
in the class definition:
> - `Bakiye` (Balance) property helps learn the account balance
    from outside, without letting it be changed.
> - `ParaEkle` (DepositMoney) function adds the amount passed
    as the argument to the account balance.
> - `ParaCek` (WithdrawMoney) function subtracts the amount passed
    as the argument from the account balance
    *if the balance is sufficient.*

Para işlemlerini yapan iki fonksiyon argüman olarak gelen tutar
pozitif olacacağı kesinmiş gibi işlem yapıyorlar,
ama durum bu mudur diye kontrol etmiyorlar.
Yani o iki fonksiyon aşırı basit yazılmışlar.
Öğrenciler sınıf tanımını daha güvenilir yapacak
başka değişiklikleri düşünmelidir. 
> These two functions which handle the money trasactions
operate as if it were certain that the amount passed
as the argument would be positive, but they don't check
whether this is actually the case.
Students should think of other changes to make this class
definition more reliable.

Program kodlarında `Hesap` türü 10 adet nesne içeren
bir esnek liste oluşturuyorum.
İzleyen döngüde ise, kullanıcı ENTER tuşuna her bastığında
rasgele seçilmiş bir hesap üstünde hayali bir işlem yaptırıyorum.
> In the program code, I create a generic list containing
10 objects of `Hesap` type.
In the following loop, I perform an imaginary transaction
on a randomly selected account object, every time the user
presses the ENTER key.