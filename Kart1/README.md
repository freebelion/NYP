## Kart1
O kadar ağır(!) iş(!!) yaptıktan sonra, sıra geldi oyun oynamaya!
Bu programdaki `Kart` sınıfı bir iskambil kartını temsil ediyor.
Kart renklerini (İngilizce termiyle *suit*) bir seçenekler grubu,
`Enum KartRenk` altında topladım. Kartların sayı (veya resim) değerlerini
ise `Kart` sınıfına ait karakter dizgisi `KartDegerleri`nde saklıyorum.
Her `Kart` nesnesi renk değeri için bir seçenek adı ve kart değeri
için de bu karakter dizgisinden alınacak değerin sıra numarasını
saklıyor.

### Diziler ve listelerde otomatik sıralama
Bu projedeki yenilik, temsil ettiği kartları sıralayabilmek için
hazır bir fonksiyon kullanıyor olmam.
`Array` türüyle temsil edilen diziler için `Array.Sort()` 
fonksiyonuyla, `List<>` türü jenerik listeler için de o sınıfa
ait `Sort()` fonksiyonuyla otomatik sıralama yaptırabiliriz.
Sayı türü değerler (`int`, `double` vb.) veya karakter dizgisi
(`string`) gibi bilenen türler için bu sıralama fonksiyonları
başka bir ek bilgi olmaksızın küçükten büyüğe doğru sıralama
yapacaklardır.

### Otomatik sıralama için arabirim uyarlamak
Kendi tanımladığımız sınıf türünden  elemanlar içeren dizi veya
listelerde otomatik sıralama yaptırmak istersek, o sınıf tanımında
`IComparable<T>` arabirimini uyarlamamız gerekir. Ben de `Kart`
sınıfında bir `Kart` nesnesini bir başka `Kart` nesnesi ile
karşılaştırma yeteneği ekleyen `IComparable<Kart>` arabirimini
uyarladım.

.NET platformunun ilk sunduğu `IComparable` arabirimini
uyarlamak için bir sınıf tanımında nesneyi `object` türünden,
yani en genel türden bir başka nesne ile karşılaştıran 
`CompareTo(object diger)` fonksionu olmalıdır.
Nesne kendisi diğer nesneden daha büyükse bu fonksiyon +1,
kendisi daha küçükse -1 gönderecektir. Nesne diğer nesne ile
aynıysa `CompareTo` sonucu 0 olacaktır.
> *Yani, tabi ki bu sonuçlar olgun meyve gibi ağaçtan
   düşmeyecektir; sonuçlar böyle olsun diye kod yazmamız gerekir.*

Ben argüman olarak genel nesne türü `object` değil de,
`diger`adlı bir başka `Kart` nesnesi alan bir karşılaştırma
fonksiyonu yazdım. Hangi renk ve sayının hangisinden üstün olduğuna
dair bilgileri taradıktan sonra, bu fonksiyondan beklenen sonuçları
üretecek kodları yazdım.

### Başka yenilikler
Deneme kodlarını içeren ana program kodlarına bakarsanız,
`Kart` türü elemanlardan oluşan `deste` listesini önce
ilk sıralı haliyle yazdırıyorum.

Kartların oyun öncesi karılmasını temsilen, `ListeKaristirici`
adlı bir sınıf tanımında jenerik bir listeye elemanların
sırasını karıştırma yeteneği ekleyen bir fonksiyon tanımı ekledim.
Ana programda bu karıştırma fonksiyonunu `deste` üzerinde kullandım,
ve kartları karıştırılmış sırayla yeniden listelettim.
> *Bu eklentiyi yazarken örnek aldığım bir forum cevabının
   linkini ekledim, ama yöntemin orijinal kaynağı o değil.*

Sonra da `List<>` şablon sınıfının hazır sunduğu
otomatik sıralama fonksiyonu `Sort()` ile sıralama yaptırdım.
Bu sıralama fonksiyonu benim sınıf tanımımdaki
`CompareTo(Kart diger)` fonksiyonunu kullanarak
küçükten büyüğe doğru sıralama yaptı.
Son olarak, kartları sıralanmış halleriyle yeniden
listelettim.