## Mat1
Bu projede bir arabirim (`interface`) tanımlaycağım
ve onu ""uyarlayan"" sınıf tanımları oluşturacağım.
> In this project, I will define an `interface`
and define classes which "implement" that interface.

Matematiksel fonksiyonlar birbirlerinden çok faklıdırlar,
ama sürekli fonksiyonların hepsi için belli noktalardaki
değerlerini veya türevlerini hesaplamak mümkündür.
Yani, fonksiyonların hepsinde kullanılabilecek
belli katsayılar veya üsler, vs. yoktur,
ama değer ve türev fonksiyonların ortak davranışlarıdır.
Fonksiyonların bu ortak davranışlarını
"arabirim" (`interface`) tanımında toparlayabiliriz:
```
public interface Fonksiyon
{
    public double Deger { get; }
    public double Turev { get; }
}
```
> Mathematical functions are very different from each other,
but for continuous functions, it is possible to calculate
their values and derivatives at certain points.
In other words, there are no common coefficients, exponents, etc.
found in all the functions, but values and derivatives
are common behaviors of the functions.
We can package these common behaviors of functions
in an "interface" definition like the one above.

**Bu bir sınıf tanımı değildir.**
İçeriğinde üye değişken tanımları yoktur ve olamaz da.
Yalnızca özellik veya fonksiyon tanımları içerebilir,
onların da kod blokları olamaz.
Bir arabirimi üye değişkenlerde saklanacak ortak bilgileri
olmayan farklı sınıfların ortak davranışlarını "dikte etmek"
için tanımlarız.
> **This is not a class definition.**
It doesn't have member variable declarations
and neither can it have.
It can only contain property and function definitions,
but they cannot have code blocks.
We define an interface only to dictate the common behaviors
of different classes which don't have common attributes.

Yukarıdaki arabirim tanımını bu projedeki **Siniflar.cs**
adlı kod dosyasına koydum.
Aynı kod dosyasına arabirimi uyarlayan iki sınıf tanımı da
ekledim. Sınıf tanım başlıklarından anlayacağınız gibi,
arabirim "uyarlamak" tıpkı sınıf türetmek gibidir:
```
public class Polinom : Fonksiyon
{
    
}

public class TrigPolinom : Fonksiyon
{
    
}
```
> I put the above interface definition in the code file
named **Siniflar.cs**.
In that same code file, I also put the definition of
the two classes which implemented that interface.
As you can see from the class definition headers above,
implementing an interface is just like deriving a class.

Ben bu tanım başlıklarını yazınca, Visual Studio
`Fonksiyon` arabiriminin gerektirdiği fonksiyonlar
eksik diye beni uyardı.
Kurtarma seçeneklerine bakarak,
eksik tanımları Visual Studıo'nun eklemesini sağladım:

```
    public double Deger()
    {
        throw new NotImplementedException();
    }

    public double Turev()
    {
        throw new NotImplementedException();
    }
```
> When I wrote those class definition headers,
Visual Studio gave me a warning indicating that the
functions required by the `Function` interface were missing.
By looking through the options to fix, I had Visual Studio
add the missing definitions, like I show above.

Benim tanımladığım haliyle, `Polinom` sınıfı kurucu fonksiyonu
bildiğiniz bir polinomun üslü terimlerinin katsayılarını
0'ıncı üsten, yani normalde sonda gelen sabit terimden başlarak
istiyor. İstediği argüman sayısı belirsiz olduğu için
argüman listesinde `params` terimini kullanıyorum.
> In the way I have defined it, the constructor function
of the class `Polinom` asks for the coefficients
of the terms with different power in the increasing order,
starting with the constant term (the coefficients of the 
term with power 0). Since the number of arguments
will be unknown, I use the term `params` in the
list of arguments.

Bu kurucu fonksiyonun argümanlarını fonksiyon çağrısında,
yani yeni bir `Polinom` nesnesi oluşturan `new` çağrısında
virgüllerle ayırarak iletiyorum. Örneğin,
```
Polinom pol1 = new Polinom(1, 3, 2);
```
komutuyla oluşturduğum nesne aşağıdaki polinomu;<br>
2 x<sup>2</sup> + 3 x + 1<br>
temsil etmektedir.
> I pass on the arguments to that constructor
in the call to the `new()` operator which creates
a new object of `Polinom` type.
For example, the `Polinom` object created
with the statement above
represents the polynomial\
2 x<sup>2</sup> + 3 x + 1

Öte yandan, `Ustel` sınıfı c x<sup>a formunda
bir üstel fonksiyonu temsil ediyor.
Bu sınıfın kurucu fonksiyonu fonksiyon katsayısını,
üssü alınacak sayıyı ve üs değerini istiyor.
Örneğin,
```
Ustel ustl1 = new Ustel(2, 3, -0.5);
```
komutuyla oluşturduğum nesne<br>
2*3<sup>-0.5</sup><br>
fonksiyonunu temsil etmektedir.
> On the other hand, the class `Ustel` represents
an exponential function with given parameters.
The constructor of this class asks for
the coefficient of the function,
the term whose power will be calculated,
and the value of its exponent.
For example, the object created with the statement above
will represent the exponential function
2*3<sup>-0.5</sup>.

Bir arabirim tanımında özellik veya fonksiyonların
kod blokları olmadığı için bir soyut sınıf tanımı
gibidir. İki tür tanım arasında başka benzerlikler
ve bazı önemli farklar vardır:
- **Arabirim türünden bir değişken tanımlayabiliriz.**
    - Benzer olarak, soyut sınıf türünden
      bir değişken tanımlayabiliriz.
- **Arabirim türünden bir nesne oluşturamayız.
    Ancak arabirimi uyarlamış bir sınıf türünden
    bir nesne oluşturabiliriz.**
    - Bu durum bir soyut sınıf için de aynen doğrudur.
- **Arabirim tanımında üye değişken tanımları olamaz.**
    - Bir soyut sınıf tanımında üye değişken tanımları olabilir.
      Soyut sınıftan türetilmiş sınıflar o değişken tanımlarını
      miras alacaktır.
- **Arabirim tanımında özellik tanımları olabilir,
    ama bunların `get` ve `set` bloklarında kodlar olamaz.**
    - Bir soyut sınıf tanımında özellik tanımları olabilir.
      ama`abstract` etiketiyle soyutlaştırılmamış
      özelliklerin `get` ve `set` bloklarında kodlar olabilir.
- **Arabirim tanımında fonksiyon tanımları olabilir,
    ama bunların kod blokları olamaz.**
    - Bir soyut sınıf tanımında fonksiyon tanımları olabilir.
      ama`abstract` etiketiyle soyutlaştırılmamış
      fonksiyonların kod blokları olabilir.
- **Arabirim tanımlarındaki özellik veya fonksiyon
    tanımları `abstract` etiketi gerektirmezler;
    zaten soyutturlar.**

An interface definition is similar to
an abstract class definition because its properties
and functions do not have code blocks.
There are indeed similarities, but also some
important differences between the two types of definitions:
- **We can define a reference variable of an interface type.**
    - Similarly, we can also define a reference fariable
      of the type of an abstract class.
- **We cannot create an object of an interface type.
    We can only create an object of a class
    which implements that interface.**
    - This is also the case with an abstract class.
- **There cannot be member variable declarations
    in an interface definition.**
    - An abstract class definition can contain
      member variable declarations.
      Classes derived from the abstract class
      will inherit those member variables.
- **An interface definition can contain property definitions,
    but their `get` and `set` blocks will not have any code.**
    - An abstract class, too, can contain property definitions;
      however, the ones without the `abstract` label
      can have code in their `get` ve `set` blocks.
- **There can be member function definitions in an interface definition,
    but they cannot have code blocks.**
    - There can be member function definitions in
      in an abstract class definition,
      but the non-abstract functions
      can have code blocks.
- **The property and function definitions in an interface
    do not need to have the label `abstract`;
    they are by -by default- abstract.**