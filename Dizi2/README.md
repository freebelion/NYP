## Dizi2
Bu projede, **Dizi1** projesindeki esnek dizi sınıfını
bir şablon sınıfa dönüştürdüm.
Tek yaptığım şey, dizi elemanlarının türü olan
`double` yerine, sınıfı hazır kullanacak olan programcının
kendi belirleyeceği türü temsilen **T** karakterini koymaktı.
> In this project, I converted the flexible array class
of the **Dizi1** project into a template class.
The only thing I did was to put the **T** character,
representing the type of the array elements
to be determined by programmers who would
use the class as-is, instead of `double` type
in the original form of the class.

Bir şablon sınıfın tanım başlığının sonunda,
**<** ve **>** sembolleri arasında, sonradan belirlenecek
türleri temsil eden yer tutucu karakterler içerir:\
`public class SablonSinif<T,G>`
> At the end of the definition header of a template class,
between the **<** and **>** symbols,
there will be the characters representing the
element types which will be specified later.

Örnek program kodlarında bu şablon sınıf türünden
bir nesneyi `string` türü elemanlar içerecek
bir esnek dizi oluşturmak ve sonra onları
sırayla yazdırmak için kullandım.
> In the sample program code, I used an object of
this template class as a flexible array of `string`
type objects and then have them printed in order.
