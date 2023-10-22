## Banka2
Bu projede sınıf türetmenin ilk örneğini sunuyorum.

### `KrediliHesap` sınıfı
Bu sınıfı daha önceki **Banka1** projesinden aynen
kopyaladığım `Hesap` sınıfından ürettim.
Sınıf tanım başlığındaki<br>
`class KrediliHesap : Hesap`<br>
ifadesi iki sınıf arasındaki türetme ilişkisini
gösteriyor. **:** sembolünün sağındaki `Hesap`
sınıfı bu ilişkideki "ata sınıf" (*ancestor class*)
veya "ana sınıf"tır (*parent class*).
**:** sembolünün solundaki `KrediliHesap` sınıfı
ise "türetilen sınıf" (*derived class*)
veya "çocuk sınıf"tır (*child class*).

Türetilmiş sınıf ata sınıfın tüm tanımlarını
"miras alır" (*inherit*). Yani, `KrediliHesap`
sınıfı türünden bir nesnede `Hesap` türü
bir nesnenin sahip olacağı her üye değişken,
özellik ve fonksiyon (`_bakiye`, `Bakiye`, `ParaEkle` vb.)
vardır. Ama türetilmiş sınıf ata sınıfın `private
`etiketli gizli değişken ve özelliklerine erişemez.
Bu nedenle, bir `KrediliHesap` nesnesi
`_bakiye` üzerinde kendi usulünde değişiklik
yapabilsin diye `Hesap` sınıfında o üye değişkeni
`private` etiketiyle tamamen gizlemek yerine
`protected` etiketiyle "çocuklar için" erişime açtım.

### Türetilmiş sınıfta yeniden tanımlama
Türetilmiş sınıf türünden bir nesne,
ata sınıftan miras aldığı her değişken ve özelliğe 
ek olarak, kendi tanımında yer alan değişken
ve özelliklere de sahip olacaktır.
Ata sınıfın belli bir davranışını belirleyen
bir özellik veya fonksiyon onu sanallaştıran
`virtual` etiketiyle tanımlanmışsa,
türetilmiş sınıf onu `override` etiketiyle
yeniden tanımlayabilir.Òrijinali `Hesap` sınıfında
yer alan `ParaCek` fonksiyonunda işte bunu gösteriyorum.
`KrediliHesap` sınıfı bu fonksiyonu yeniden
tanımlıyor ki hesap bakiyesi belli bir eksi limite
kadar düşebiliyor.

Deneme amaçlı program kodlarında `Hesap` türü
nesnelerin listeinde son beş eleman aslında
`KrediliHesap` türü nesnelerdir.
Programı çalıştırıp denerseniz,
1005 ila 1009 numaralı bu hesaplarda
bakiyenin eksiye düşebildiğini göreceksiniz.