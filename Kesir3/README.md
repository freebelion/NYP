## Kesir3
Bu üçüncü projede bir kesir nesnesinin
nasıl bir şey olduğunu açıklayacak
bir sınıf tanımı, yani bir nesne kalıbı
oluşturdum. Böyle bir sınıf tanımı
gerçek hayattaki bir nesneyi temsil eden
birden fazla bilgiyi o nesneyi
tarif edecek bir pakette toplayacak,
yani "kapsüllemiş" olacaktır.<br>
<u>*Kapsülleme (**encapsulation**) nesneye
yönelik programlamanın birinci önemli
prensibidir.*</u>

> In this third project, I have constructed 
a class definition, an object template in a sense,
which will explain what a fraction object
is like. A class definition like that
will bring together more than one information
which represent a real-world object in a package,
in other words, it will have "encapsulated" them.<br>
<u>*Encapsulation is the first important principle
    of object-oriented programming.*</u>

`class Kesir` tanımı bir kesir nesnesinin
`pay` ve `payda` adlı iki tamsayı
değişkenden oluştuğunu gösteriyor
ve kesrin ondalıklı eşdeğerini
hesaplayan `Oran` adlı fonksiyonu da
barındırıyor.
> The class `Kesir` (Fraction) demonstrates that
a fraction object consists of two integer variables
name `pay` (numerator) and `payda` (denominator),
and also contains the function named `Oran` (Ratio)
that calculates the decimal equivalent of the fraction.

Bu sefer projenin adını da eklediğim
**Kesir3Program** kod dosyasında
bu sınıf türünden iki `Kesir` nesnesi
oluşturuyorum ve önceki projelerdeki
gibi iki kesrin pay ve payda bölümleriyle
ondalıklı eşdeğerlerini yazdırıyorum.
> In this case, I create two `Kesir` objects 
in the program code file **Kesir3Program**
named after the project, and get the two fractions
and their decimal equivalents written,
as was done in the earlier projects.

Yeni oluşturduğum `Kesir` sınıfı
benim kendi kodlarımda kullanabileceğim yeni
bir değişken türüdür.<br>
`Kesir k1;` şeklinde bir bildirim ile bu türden
bir değişken tanımlamış olurum.
Ama dikkat edin, bu değişken yalnızca ileride
bilgisayar belleğinde oluşturacağım bir nesnenin
adresini taşıyabilecek bir "referans değişkeni"dir.
Kendisi `Kesir` türü bir nesne değildir.

> The `Kesir` that I have just created
is a new variable type that I can use in my code.<br>
With a declaration like `Kesir k1;`
I will have defined a variable of that type.
However, pay attention, this variable is just a
"reference variable" which can store the address
of an object which I can later create
in the computer memory. It is *not*, by itself,
is a an object of `Kesir` type.

`Kesir k1 = new Kesir();` gibi bir komut ile
sağ taraftaki `new` işlemcisi ile bilgisayar belleğinde
`Kesir` türü bir nesne oluşturmuş,
ve bu nesnenin bellekteki adresini
`k1` adlı referans değişkenine aktarmış olurum.
> With a command like `Kesir k1 = new Kesir();`,
I will have created an object of `Kesir` type
in the computer memory with the `new` operator
on the right, and transferred the memory address
of this object to the reference variable named `k1`.

Yukarıdaki gibi bir komutla oluşturacağım 
her `Kesir` nesnesi aslında gerçek hayattaki
bir kesir nesnesini oluşturan pay ve payda değerini
taşıyan iki tamsayı değişken üyesi olan bir pakettir.
Sınıf tanımındaki bu tamsayı değişkenlere
"üye değişkenler" diyoruz.
> A `Kesir` type object which I can create in the
computer memory with a command like the one above
is actually a package with two integer members 
that store the numerator and denominator values
which would have formed a fraction object in real life.
We call these two integer variables the class definition
"member variables".

Sınıf tanımında bu üye değişkenleri `public` etiketiyle
dışarı açık olarak tanımladım.
Böylelikle, **Kesir3Program** kodlarında
`Kesir` türü `k1` ve `k2` nesnelerinin
`pay` ve `payda` üyelerine doğrudan değer
aktarılabiliyor veya onların değerleri
doğrudan yazdırılabiliyor.
> I have left these member variables in the class definition
open to outside access with the `public` labels.
Thus, in the codes of **Kesir3Program**,
values can be directly assigned to `pay` and `payda`
members of `Kesir` type objects `k1` ve `k2`
and the member values can be written directly.

Sınıf türü bir nesnenin üye değişkenlerine
erişmek için nesneyi temsil eden referans değişkeni
adından sonra üye erişim işlemcisi . (nokta)
ve ardından üye değişken adını yazıyoruz.
> In order to access the member variables of a class
type object, we write the name of the reference variable
representing the object, followed by the member access
operator . (dot) and the member variable's name.

`Kesir` sınıfının bir başka önemli özelliği de
temsil ettiği kesir nesnesinin ondalıklı sayı
eşdeğerini hesaplacayacak olan `Oran()` fonksiyonudur.
Sınıf tanımında yer alan böyle bir fonksiyona
"üye fonksiyon" denir.<br>
Bir üye fonksiyon nesnenin kendine ait üye değişkenleri
üzerinde yapılması gereken özelleştirilmiş işlemleri
gerçekleştirir. Gerçek hayattaki bir profesyonel
elemanı düşünecek olursanız, bir üye fonksiyon onun 
"meslek sırrı" olarak gizli tuttuğu özel işlemleri
gerçekleştirecek olan bir komutlar dizisidir.
> Another important feature of the `Kesir` class
is its `Oran()` function which will calculate the
rational number equivalent of the fraction object.
Such a function found in a class definition
is called a "member function".<br>
A member function performs the  specialized operations
which will need to be done on the member variables
belonging to the object itself.
If you think of a professional worker in the real life,
a member function is a series of commands which will
perform the special operations that the worker hides
as his/her "trade secrets".