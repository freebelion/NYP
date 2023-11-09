## Dizi2
Bu projede, **Dizi1** projesindeki esnek dizi sınıfını
bir şablon sınıfa dönüştürdüm.
Tek yaptığım şey, dizi elemanlarının türü olan
`double` yerine, sınıfı hazır kullanacak olan programcının
kendi belirleyeceği türü temsilen **T** karakteri koymaktı.

Bir şablon sınıfın tanım başlığının sonunda,
**<** ve **>** sembolleri arasında, sonradan belirlenecek
türleri temsil eden yer turucu karakterler içerir:<br>
`public class SablonSinif<T,G>`

Türleri temsil eden karakterlerin alfabeden harfler olması
dışında -benim bildiğim- herhangi bir sınırlama yoktur,
ama yukarıda kullandığım harfler geleneksel tercihlerdir.
> *Şablon sınıfların kendi kodlarında yeni eleman oluşturan
   komutlar varsa, sınıf tanımı yapılırken asıl eleman türü
   bilinmediği için bazı önlemler almak için özel işlemler
   gerekebilir. Fırsat oldukça onları sonraki sınıf tanımı
   örneklerinde göstermeye çalışacağım.*