## Kesir5
**Kesir4** projesinde, programın ana fonksiyonu
**Main** içinde<br>
`Kesir k3 = new Kesir();`<br>
komutunu ekleyin.<br>
Üye değişkenlerin alacağı ilk değerleri iletmediğinizi
bildiren aşağıdaki hata mesajıyla karşılaşacaksınız:
```
There is no argument given that corresponds
to the required parameter 'p' of
'Kesir4Program.Kesir.Kesir(int, int)'
```
> In **Kesir4** project, in **Main** function
of the program, add the command
`Kesir k3 = new Kesir();`<br>
You will be faced with the above error message
indicating that you have not passed the initial
values for the member variables.

**Kesir3** projesindeki sınıf tanımında
hiç kurucu fonksiyon olmadığı halde
iki `Kesir` nesnesini de ilk değer argümanları
iletmeden oluşturmuştuk.
O zaman sorun çıkmamıştı,
çünkü <u>bir C# .NET projesindeki
bir sınıf tanımında kurucu fonksiyon
olması zorunlu değildir</u>.
> In **Kesir3** project, we had created both
`Kesir` objects without passing initial values,
even though the class definition did not contain
a constructor function.
Back then, there was no problem, because,
<u>a class definition in a C# .NET project
does not have to have a constructor function</u>.

Bir C# sınıf tanımında hiç bir kurucu fonksiyon yoksa,
üye değişkenler türlerine göre .NET platformunda varsayılan
ilk değerleri alırlar.
Tamsayı değişkenler `_pay` ve `_payda` için
varsayılan ilk değer 0 olacaktır.
> If there is no constructor function in a
C# class definition, member variables,
depending on their types,
take on the default initial values
assigned by the .NET framework.
For the integer variables `_pay` and `_payda`,
these values will be zero.

**Kesir4** projesindeki `Kesir` sınıf tanımında
dışarıdan iletilen ilk değerleri parametreler
aracılığıyla alan bir kurucu fonksiyon vardı.
Bu tek kurucu fonksiyon argüman istediği
için de ilk değer iletmeden yeni bir
`Kesir` nesnesi oluşturamazdık.
> In the `Kesir` class definiton in **Kesir4** project,
there was a constructor function which received
the initial values passed from outside
through the parameters.
Since this single constructor required arguments,
we could not create a new `Kesir` object
without passing initial values.

Bu projede sınıf tanımına argüman almayan
bir "boş kurucu fonksiyon" (*default constructor*)
ekliyoruz:
```
public Kesir()
{ _pay = 0; _payda = 1; }
```
ve iyi de oluyor, çünkü kurucu fonksiyon
`_payda` üye değişkeni için varsayılan ilk değer
0 olsa sorun olurdu.
> In this project, we add an "empty constructor"
(*default constructor*) in the class definition
(see above)
and that turns out to be a good thing,
because the default value of zero would be
a problem for the member variable `_payda`.

Paydaya 0 değeri atanmasından kaçınmamız
gerektiğini anlayınca, aslında argüman alan
kurucu fonksiyonda da gevşek davrandığımızı
da anlarız. İkinci argüman `q` değerini
kontrol etmeden üye değişken `_payda`ya
aktarıyorduk.
> When we understand we should avoid assigning
a value of 0 to the denominator,
we also realize that we had been rather loose
in the constructor function with parameters.
We had assigned the second argument `q`
to the member variable `_payda` without checking.

Üye değişkenlere her durumda kontrollü erişim sağlamak için,
bu projede `Kesir` sınıf tanımını yeniden düzenledim.<br>
Kısacası, `_pay` ve `_payda` üye değişkenlerine doğrudan
değer aktarmıyorum; yalnızca kontrollü erişim sağlayan
özellikler aracılığıyla değer aktarıyorum.
Böylece özellik tanımlarındaki değer kontrolü yapan kodları
gerektikleri yerde yeniden kullanıyorum.<br>
*"Kodların yeniden kullanımı" (code reuse) nesneye yönelik
  programlamanın bir başka önemli prensidir.*
> In order to ensure controlled access to member variables
in every situation, I have redesigned the `Kesir` class
definition in this project.
In short, I am not directly assigning values
to member variables` _pay` and `_payda`;
I am only assigning values through the properties
which provide controlled access.
Thus I am reusing the value-checking statements
in property definitions wherever they are needed.<br>
*Reusing codes (code reuse) is another important principle
of object-oriented programming.*

Bu arada, bir kesrin ondalıklı eşdeğerini
hesaplamak için de üye fonksiyon `Oran()` yerine
bir tür dönüşüm işlemcisi tanımladım:<br>
```
public static explicit operator double(Kesir k)
{ return (double)k.Pay / k.Payda; }
```
Tanım başlığındaki `operator` terimi bu özel fonksiyonun
bir "işlemci" olduğunu belirtiyor.
Bu tanım başlığında, fonksiyon adı yerine dönüştürmenin
hedef türünün adı (`double`), fonksiyon argümanı olarak da
dönüştürülecek türü (`Kesir`) var.
Tanım başlığındaki `explicit` terimi de dönüştürme işleminin
`(double)k1` şeklinde,
hedef tür belirterek yapılacağı anlamına geliyor.
> Meanwhile, I have also defined a conversion operator
to calculate the decimal equivalent of a fraction,
instead of the member function `Oran()` (see above).
In that definition header, there is the name of the targeted type
instead of a function name, and as the function argument,
there is the name of the type which will be converted.
The term `explicit` in the definiton header means that,
the conversion operation will be performed by specifying 
the targeted type, as in `(double)k1`.

Bir kesir nesnesini kendi belirlediğim şekilde yazdırmak için de
yukarıdaki yazılış şekline göre bir de karakter dizgisine
dönüştürme işlemcisi tanımladım:<br>
```
public static implicit operator string(Kesir k)
{ return "[" + k.Pay.ToString() + "/" + k.Payda.ToString() + "]"; }
```
> In order to have a fraction object written in the way I specify,
I have also defined an operator for converting into a string (see above).