## Seri1
Bu projede "soyut sınıf" kavramını tanıtıyorum.
> In this project, I am introducing the concept of
"abstract class".

Ortaokul veya ilkokulda aritmetik ve geometrik serileri
öğrenmiş olabilirsiniz. O serilerin iki ortak özelliği
vardı: Bir "ilk değer" ile başlıyorlardı ve her adımda
o değeri belli bir "adım değeri"ni kullanan bir ilerleme
formülü ile değiştiriyorlardı.
> In elementary school or in the middle school,
you may have learned about arithmetic and geometric series.
Those series had two common properties: They started with
an "initial value" and they changed that value with
a progression formula using a "step value".

Bu projedeki `Seri` sınıfı o serilerin iki ortak 
özelliğini `ILK` ve `ADIM` olarak tanımlıyor.
> The `Seri` class in this project define those two properties
common to the two types of series in its properties
`ILK` and `ADIM`.

`Seri` sınıfı ayrıca bir sonraki sayıyı hesaplacak
olan bir fonksiyona sahip olmalıdır.
Onu da `Sonraki()` adıyla tanımladım.
> The `Seri` class must also have a member function
to calculate the next value at every step.
I defined that function with the name
`Sonraki()` (Next).

Ama matematiksel serilerin sayı üretme yöntemi
(yani "dizi formülü") aynı değildir.
Hatta, benzer bile değildir.
> However, the way the mathematical series produce
the next value, in other words, their progression formula,
is not the same. They are not even similar.

Aritmetik bir seri sonraki sayıyı o an geçerli
sayıya adım değerini ekleyerek -ya da çıkartarak-
hesaplar, ama geometrik bir seri her adımda bir çarpma
işlemi yapar.
> An arithmetic series calculates the next value
by adding -or subtracting- the step value
to the current value,
but a geometric series does a multiplication
at every step.

Kısacası, matematiksel serilerin ortak özelliklerini
tanımlayan `Seri` sınıfı sonraki sayıyı hesaplamak
için belli bir formül dikte edemez. Bu fonksiyonun
içini boş bırakmalıdır.
> In short, the `Seri` class which defines the common
properties of the mathematical series cannot dictate
a specific formula to calculate the next value.
It must leave the code block of that function blank.

Ama o zaman da, `Seri` sınıfı türünden bir nesne
sonraki sayı istendiğinde hiç bir hesap yapmadan
boş oturacaktır. O da saçma olurdu tabi ki.
> But then an object of `Seri` type will do nothing
when the next value is demanded.
That would, of course, be silly.

Sonuç olarak, `Seri` sınıfını bir "soyut sınıf"
(*abstract class*) olarak tanımladım.
Bu da demek oluyor ki, bu sınıf
farklı türden matematiksel serilerin ortak
özelliklerini tanımlıyor, ama kendisi
gerçek bir nesneyi temsil etmiyor.
> At the end, I defined the `Seri` class
as an *abstract class*, meaning that,
this class defines the common properties
of different types of mathematical series,
but it does not represent a real object
by itself.

Dolayısıyla, program kodlarında <br>
`Seri s = new Seri();` <br>
gibi bir komutla bu türden bir nesne tanımlayamam.
Bu sınıf ancak tanımladığı ortak özelliklere
sahip olacak başka sınıflar türetmek içindir.
Gerçek matematiksel serileri temsil edecek sınıflar
türetilmiş sınıflardır.
> Consequently, I cannot define an object of
`Seri` type with a statement like:<br>
`Seri s = new Seri();` <br>
This class is only intended to derive other classes
which will have the common properties it defines.
It is those derived classes which will represent
the actual mathematical series.

Matematiksel serileri temsilen oluşturduğum
`AritmetikSeri`  ve `GeometrikSeri` sınıflarını
yukarıda anlattığım soyut `Seri` sınıfından türettim.
> To represent the actual mathematical series,
I derived the classes `AritmetikSeri` and `GeometrikSeri`
from the abstract `Seri` class I described above.

Türettiğim bu sınıflar soyut sınıftan miras aldıkları
`Sonraki()` fonksiyonunu kendi ilerleme formüllerini
uygulayacak şekilde tanımlıyorlar.
> The classes that I derived define the `Sonraki()`
function which they inherit from the abstract class
to implement their own progression formulas.

Ama şöyle bir durum var: Soyut `Seri` sınıfından
türetilmiş olan sınıflarda `Sonraki()` fonksiyonunu
yeniden tanımlamak zorunlu olmalıdır.
`Seri` sınıfı o fonksiyonun kod blokunu boş
bırakmakla yetinemez, çünkü bir programcı
yeni bir sınıf türetirken `Sonraki()` fonksiyonunu
yeniden tanımlamadan bırakabilir.
> However, there is a certain problem:
The classes derived from the abstract class
must be required to define the `Sonraki()` function.
It will not be sufficient for the `Seri` class to leave
the function's code block empty, because if a developer
may leave that function undefined while deriving a class
from the abstract class.

Kısacası, soyut sınıf `Seri` tanımındaki
`Sonraki()` fonksiyonu gerçek bir fonksiyon
bile olmamalıdır. Bu nedenle, onu da 
`abstract` etiketiyle, soyut bir fonksiyon olarak
tanımladım. Dikkat edin, bu fonksiyonun bir kod
bloku yok, ve olamaz da.
Fonksiyon tanım başlığı argüman listesini
içeren **()** parantez çiftinden sonra
bir noktalı birgül ile bitiyor.
Bu örnekteki soyut fonksiyon argüman almıyor,
ama başka soyut sınıflarda argüman alan
soyut fonksiyonlar da olabilir.
> In short, the function `Sonraki()` in the abstract
class `Seri` should not even be a real function.
For that reason, I defined that function asn an
abstract function with the label `abstract`.
Pay attention, this function does not have
a code block, and neither can it have.
The function definition header ends with a semicolon
after the pair of parantheses for the argument list.
In this example, this abstract function does not take
any arguments, but there could be abstract functions
whch take arguments in other abstract classes.

Bir soyut sınıfın içeriğini belirlemediği özellik
tanımları da olabilir. Onları da `abstract` etiketiyle
tanımlarız ve `get` ve `set` bloklarını kod yazmadan
bırakırız, tıpkı oto-özelliklerde yaptığımız gibi.
> An abstract class may also contain property definitions
with unspecified behavior. We define those, too,
with the label `abstract` and leave their `get` and `set`
blocks without code blocks, just like we do for
auto-properties.

Soyut sınıftan türetilen sınıflar ata sınıftaki
soyut fonksiyon ve özellikleri `override` etiketiyle
yeniden tanımlamak zorundadırlar.
> Classes derived from an abstract class has to define
the abstract functions and properties of the parent class
with the `override` label.

Şimdi soyut sınıflarla ilgili önemli noktaları sıralıyorum:
- Bir soyut sınıfı `class` teriminden önce gelen
  `abstract` etiketiyle tanımlanır.
- Soyut sınıf türünden bir nesne oluşturulamaz.
  Bu sınıf tanımı yalnızca ondan türetilecek
  başka sınıfların ortak özellik ve davranışlarını
  belirleyecektir.
- Soyut sınıf tanımında
    - üye değişken tanımları olabilir,
      ama bunlar soyut olamazlar,
      yani `abstract` etiketi alamazlar.
    - özellik tanımları olabilir,
      ki bunların bir veya daha fazlası soyut olabilir.
    - üye fonksiyon tanımları olabilir,
      ki bunların bir veya daha fazlası soyut olabilir.
- `abstract` etiketi taşıyan soyut özellik
  veya fonksiyon tanımları yalnızca `abstract`
  etiketi taşıyan bir soyut sınıf tanımında bulunurlar.
- Bununla birlikte, bir soyut sınıfın soyut fonksiyon
  veya özellik tanımları içermesi zorunlu değildir.
- Bir soyut sınıf tanımında argüman alan veya almayan
  kurucu fonksiyonlar olabilir. Türetilmiş sınıflar
  soyut sınıfın kurucu fonksiyonlarını aynı şekilde
  tanımlamış olmalıdır.

> Now, I am listing the important points about
  abstract classes:\
  \* An abstract classis defined with the label `abstract`
  before the term `class`.\
  \* An object of the abstract class type cannot be created;
  that class definition will only dictate the common
  properties and behaviors of real classes defined from it.
  \* In an abstract class definition,\
  \- there can be member variable definitions
  but those cannot be abstract,
  i.e. cannot carry the label `abstract`.\
  \- there can be property definitions,
  some of which can be abstract.\
  \- there can be member function definitions,
  some of which can be abstract.\
  \* Abstract properties or member functions
  with the label `abstract` can only be found
  in an abstract class carrying the label `abstract`.\
  \* However, an abstract class does not have to contain
  abstract property or function definitions.\
  \* An abstract class may contain constructor functions
  with or without parameters. Derived classes have to define
  the abstract class' constructors with the same signatures.
  