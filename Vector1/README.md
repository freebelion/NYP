## Vector1
Bu projede fizik derslerinde öğrendiğim
türden bir vektörü temsil edecek `Vector` sınıf
tanımı oluşturdum.
Yeri belli olsun diye de bu tanımı aynı adı taşıyan
ayrı bir kod dosyasına koydum.
> In this project,I created a `Vector` class
which will represent a vector like the kind I learned
in physics classes.
To make it clear where it is, I placed this definition
in a separate code file with the same name.

Vektör bileşenlerinin alabileceği
değerler için bir ön kontrol gerekmiyordu.
Bu nedenle, vektör bileşenlerine erişim sağlayan
özellikleri **get** ve **set** blokları boş olan
iki oto-özellik (*auto-property*) olarak tanımladım.<br>
*Bir bakıma bu oto-özellikler dışarı açık üye değişkenler gibidir.*
> For the values that the vector components can take,
there was no need to do any checking.
Therefore, I have defined the properties providing
access to component values as *auto-properties*
with empty **get** and **set** blocks.<br>
*In a sense, these auto-properties are like member variables
open to outside access.*

`Vector` sınıfına iki kurucu fonksiyon ekledim.<br>
Biri bileşenler için varsayılan 0 değerlerini
atayan boş kurucu fonksiyon,<br>
İkincisi de dışarıdan iletilecek ilk değerleri
atayan argüman alan bir kurucu fonksiyon.
> I have added two constructor function
to the `Vector` class.<br>
One is the default (empty) constructor which assigns
zero values to the components,<br>
The second is the constructor function which assigns
the initial values passed from outside.

Fizikte vektörlerin toplanması kuralını
(iki vektörün toplamı, bileşenleri
o iki vektör bileşenlerinin karşılıklı
toplamlarına eşit olan üçüncü bir vektördür)
uygulayan bir de toplama işlemcisi tanımladım.
> I have also defined an addition operator
which implemented the physics rule stating that
the sum of two vectors is a third vector with
components equal to the sums of corresponding
components of the two vectors.

Gerçek hayatta normal aritmetik işlemlere
tabi tutulan türden nesneleri
(vektör, karmaşık sayı, kesir, vb.)
temsil eden sınıf tanımlarında
işlemci tanımları yapılabilir.
> The classes representing real-life objects
which can be subject to arithmetic operations
can contain arithmetic operator definitions.

İşlemci tanımı aynı bu örnekteki gibi olmalıdır:<br>
-İşlemcinin nesnenin kendisine ait
  değil de sınıfa ait olduğunu belirten
  **static** etiketi.<br>
-İşlemcinin elde edeceği sonucun türü
  (bu örnekte `Vector`, çünkü iki vektör
  toplanıyorsa sonuç yine bir vektördür)<br>
-Bir işlemci tanımladığımızı belirten
  **operator** terimi.<br>
-İşlemcinin alacağı argümanlar listesi
  (toplama, çarpma, vb. ikili aritmetik
  işlemciler için iki adet).<br>
> An operator definition must be just like 
the one in this example here.<br>
-The **static** label which indicates that the operator
definiton belongs to the class, rather than the object.<br>
-The type of the result from the operator
(which is `Vector` in this example, because the result
is a vector if two vectors are being added).<br>
-The term **operator** because we are defining an operator.<br>
-The list of the arguments for the operation
(two arguments for the binary operators like
addition, multiplication, etc.)

Sınıf tanımını kullanan programın ana fonksiyonunda
bu sınıf türünden 5 elemanlı bir `vektorler` adlı
diziyi tanımladım.
Bu dizinin her elemanı ileride oluşturacağım
bir `Vector` nesnesinin adresini saklayacak
olan bir "referans değişkeni" (*reference variable*) idi.
> In the **Main** function of the program which makes
use of this class definition, I have defined an array
named `vektorler` of 5 elements of this type.
Every element of this array was a *reference variable*
which could store the address of a `Vector` object
which I would create in future.

Dizi tanımını izleyen döngüyle, dizi elemanlarının
her birisi için bir `Vector` nesnesi oluşturdum ve adresini
dizi elemanına aktardım.<br>
Bu nesneleri oluştururken argüman alan
kurucu fonksiyon aracılığıyla kullandım;
bileşenlere -10 ile +10 arasında değişen
ondalıklı ilk değerler atadım.
> In the loop following the array definition,
I have created a `Vector` object for every array element
and assigned its address to the element.<br>
While creating those objects, I have used the constructor
function accepting arguments;
I have assigned initial values to components randing
from -10 to +10.


Bu ilk komutlardan sonraki döngülerde ise
dizi elemanlarına karşılık gelen `Vector`
nesnelerinin toplamını aldım,
nesnelerin her birinin gösteren toplama işlemini
yazdırdıktan sonra sonucu yazdırdım.
> In the loops following these initial commands,
I summed up the `Vector` objects now stored in array elements
and had the objects and their final sum written.