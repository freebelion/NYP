## Kart1
Bu programdaki `Kart` sınıfı bir iskambil kartını temsil ediyor.
Kart renklerini (İngilizce termiyle *suit*) bir seçenekler grubu,
`Enum KartRenk` altında topladım.
Kartların sayı (veya resim) değerlerini ise
`Kart` sınıfına ait karakter dizgisi `KartDegerleri`nde saklıyorum.
Her `Kart` nesnesi renk değeri için bir seçenek adı
ve kart değeri için de bu karakter dizgisinden alınacak
değerin sıra numarasını saklıyor.
> The `Kart` class in this program represents a playing card.
I grouped the card suits under the `Enum KartRenk`,
which is a sort of a collection of named option values.
The rank (or face) values of the cards are stored
in the character string `KartDegerleri`.
Each `Kart` object holds a suit value as an option name
and the index number for the character representing
the card rank.

Bu projedeki yenilik, temsil ettiği kartları sıralayabilmek için
hazır bir fonksiyon kullanıyor olmam.
`Array` türüyle temsil edilen diziler için `Array.Sort()` 
fonksiyonuyla, `List<>` türü jenerik listeler için de o sınıfa
ait `Sort()` fonksiyonuyla otomatik sıralama yaptırabiliriz.
Sayı türü değerler (`int`, `double` vb.) veya karakter dizgisi
(`string`) gibi bilenen türler için bu sıralama fonksiyonları
başka bir ek çaba gerektirmeden küçükten büyüğe doğru sıralama
yapacaklardır.
> The novelty in this project is that it uses a built-in function
to sort the card collection it represents.
We can use the `Array.Sort()` function for arrays represented
by the `Array` type, and the `Sort()` function belonging to the
`List<>` generic list type for lists.
For the knwon types such as numeric data types (`int`, `double` etc.)
and character strings (`string`), these sorting functions will
sort in ascending order without any additional effort.

Kendi tanımladığımız sınıf türünden  elemanlar içeren dizi veya
listelerde otomatik sıralama yaptırmak istersek, o sınıf tanımında
`IComparable<T>` arabirimini uyarlamamız gerekir.
Ben de `Kart` sınıfında aynen bunu yaptım.
> If we want to do an automatic sort on arrays of collections
containing the objects of the classes we defined ourselves,
we will need to implement the `IComparable<T>` in those classes.
I have done exactly that in the `Kart` class.


.NET platformunun ilk sunduğu `IComparable` arabirimini
uyarlamak için bir sınıf tanımında nesneyi `object` türünden,
yani en genel türden bir başka nesne ile karşılaştıran 
`CompareTo(object diger)` fonksionu olmalıdır.
Nesne kendisi diğer nesneden daha büyükse bu fonksiyon +1,
kendisi daha küçükse -1 gönderecektir. Nesne diğer nesne ile
aynıysa `CompareTo` sonucu 0 olacaktır.\
`Kart` sınıfında bu karşılaştırma görevini
`CompareTo(Kart diger)` fonksiyonu yapıyor.
> To implement the original `IComparable` interface,
a class definition must have a `CompareTo(object diger)`
function that compares the object to another object.
If the object itself is greater than the other object,
this function will return +1; if it is smaller, -1.
If the object is the same as the other object,
the `CompareTo` result will be 0.,
In the `Kart` class, this comparison task is performed
by the `CompareTo(Kart diger)` function.



Örnek program kodlarına bakarsanız,
`Kart` türü elemanlardan oluşan `deste` listesini önce
ilk sıralı haliyle yazdırıyorum.
> If you look at the sample program code,
I first print the `deste` list
containing elements of type `Kart`
in its originally ordered form.

Kartların oyun öncesi karılmasını temsilen, `ListeKaristirici`
adlı bir sınıf tanımında jenerik bir listeye elemanların
sırasını karıştırma yeteneği ekleyen bir fonksiyon tanımı ekledim.\
Örnek programda bu karıştırma fonksiyonunu `deste` üzerinde kullandım,
ve kartları karıştırılmış sırayla yeniden listelettim.
> In a way to simulate the shuffling of cards before a game,
I added a function definition in the class  named `ListeKaristirici`
which will enable a generic `List<T>` collection
to shuffle its elements.\
In the sample program, I used this shuffle function
on the `deste` list, and had the elements listed
in their shuffled order.


Sonra da `List<>` şablon sınıfının hazır sunduğu
otomatik sıralama fonksiyonu `Sort()` ile sıralama yaptırdım.
Bu sıralama fonksiyonu benim sınıf tanımımdaki
`CompareTo(Kart diger)` fonksiyonunu kullanarak
küçükten büyüğe doğru sıralama yaptı.
Son olarak, kartları sıralanmış halleriyle yeniden listelettim.
> I then used the built-in automatic sorting function `Sort()`
of the `List<>` template class to perform sorting.
This sorting function used the `CompareTo(Kart diger)` function
in my class definition to sort in ascending order.