## Dizi3
Bu projede numara ve 0 ile 100 (ikisi de dahil) arasında
not bilgisi içeren `Ogrenci` sınıfı türünden nesneler
oluşturuyor ve onları bir jenerik listeye ekliyorum.
> In this project, I am creating objects of a class
`Ogrenci` with grades between 0 and 100 (inclusive)
and adding them to a generic collection.

Öğrenci numaralarını oluştururken,
(20)19 ve (20)24 (dahil değil) arasında
rasgele bir yıl bilgisi ile
`bolumKodlari` dizisinden rasgele seçilmiş bölüm kodu
ve üç haneli bir rasgele sayıyı birleştiriyorum.
> While I create the student ID numbers,
I combine a random year value between (20)19 ve (20)24
(inclusive), a department code randomly selected
from the array `bolumKodlari` and a three-digit random
integer.

Orijinal liste elemanlarını yazdırdıktan sonra,
LINQ ad uzayında tanımlanmış hazır fonksiyonları kullanarak
birkaç sıralama yaptırdım.\
Son olarak da, `IComparer<Ogrenci>` arabirimini uyarlayan
bir sınıf tanımladım ve orijinal listeyi numaraya göre
sıralanmış düzene soktum.
> After having the collection elements in their original order,
I had the collection sorted by using certain ready functions
defined in LINQ namespace.\
Lastly, I defined another class which implements
the `IComparer<Ogrenci>` interface and put the collection
in the order of student IDs.

Sınıf tanımınızda `IComparable` arabirimini uyarlamışsanız,
C# dilinin otomatik sıralama  fonksiyonlarını kullanabilirsiniz,
ama yalnızca ilk düşündüğünüz yöntemle sıralama yapabilirsiniz.\
`IComparer` arabirimini uyarlayan bir sıralayıcı sınıf
nesne sınıfı tanımlandıktan sonra düşündüğünüz
veya değiştirdiğiniz yeni sıralama yöntemlerini
uygulamanızı sağlar.
> If you have implemented the `IComparable` interface
in your class, you can make use of automatic sorting
functions of C#, but you can only sort with
the first method you had thought of.\
A sorting class which implements the `IComparer` interface
will enable you to implement the new sorting methods
which you have thought or changed later.