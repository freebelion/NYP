## Mat1
Bu projede bir arabirim (`interface`) tanımlaycağım
ve onu uyarlayan sınıf tanımları oluşturacağım.

### Arabirim (`interface`) tanımlamak
Ortaöğrenim yıllarınızda veya üniversite birinci sınıfta bazı
matematiksel fonksiyonların belli noktalardaki değerlerini
veya türevlerini hesaplamışsınızdır.

O işlemlerde kullandığınız fonksiyonların türleri veya
yazılışları birbirlerinden çok farklıydı belki,
ama hepsi için yaptığınız o iki işlem aynıydı.

Bu fonksiyonların içeriklerini değil de, yaptıkları
ortak işlemleri bir "arabirim" (`interface`) tanımında
toparlayabilirsiniz:
```
public interface Fonksiyon
{
    public double Deger { get; }
    public double Turev { get; }
}
```
> *interface terimi görsel işletim sistemlerinde "arayüz"
  diye çevrilir, ama nesneye yönelik programlamadaki
  karşılığı "arabirim"dir.*

Bu bir sınıf tanımı değildir. İçeriğinde üye değişken
tanımları yoktur ve olamaz da. Yalnızca özellik veya
fonksiyon tanımları içerir, onların da kod blokları olamaz.

### Arabirim tanımını uyarlamak
Yukarıdaki arabirim tanımını bu projedeki **Siniflar.cs**
adlı kod dosyasına koymuştum.

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
Bu tanım başlıklarını yazınca, Visual Studio derleyicisi
oluşturduğum sınıfların `Fonksiyon` arabiriminde tanımlanmış
ortak fonksiyonları uyarlamamış diye uyardı beni.
Hata mesajının sunduğu onarma seçeneklerinden birisi
*implement the interface* idi, yani VS benim için arabirimi
uyarlayacak kodları eklemeyi öneriyordu.

Bu yardım önerisini kabul edince VS sınıf tanımlarına
aşağıdaki eklemeleri yaptı:

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

### Sınıf tanımları
Benim tanımladığım haliyle, `Polinom` sınıfı kurucu fonksiyonu
bildiğiniz bir polinomun üslü terimlerinin katsayılarını
0'ıncı üsten, yani normalde sonda gelen sabit terimden başlarak
istiyor. İstediği argüman sayısı belirsiz olduğu için
argüman listesinde `params` terimini kullanıyorum.

Bu kurucu fonksiyonun argümanlarını fonksiyon çağrısında,
yani yeni bir `Polinom` nesnesi oluşturan `new` çağrısında
virgüllerle ayırarak iletiyorum. Örneğin,
```
Polinom pol1 = new Polinom(1, 3, 2);
```
komutuyla oluşturduğum nesne aşağıdaki polinomu;<br>
2 x<sup>2</sup> + 3 x + 1<br>
temsil etmektedir.

Öte yandan, `TrigPolinom` sınıfı ise bir üslü **sin**
fonksiyonu ile yine üslü bir **cos** fonksiyon teriminin
toplamıyla oluşturulan bir trigonometrik polinomu temsil ediyor.

Bu sınıfın kurucu fonksiyonu polinomdaki iki trigonometrik
fonksiyonun katsayılarını ve üslerini istiyor. Örneğin,
```
TrigPolinom trpol1 = new TrigPolinom(1, 2, -1, 2);
```
komutuyla oluşturduğum nesne aşağıdaki<br>
[sin(x)]<sup>2</sup> - [cos(x)]<sup>2</sup><br>
trigonometrik polinomu temsil etmektedir.

> *DİKKAT! :Matematik bilgilerim çok da taze olmadığı
   için, sırf arabirim uyarlamak için örnek olsun
   diye uydurduğum bu sınıflarda değer ve türev
   hesaplayan fonksiyonların kodlarını pek de doğru
   yazmamış olabilirim. Netekim `TrigPolinom` sınıfı
   için türev hesabının nasıl yapılacağını bile
   anlayamayıp fonksiyon kod blokunu boş bıraktım.*

### Arabirimler ile soyut sınıfların farkları
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
    tanımları àbstract` etiketi gerektirmezler;
    zaten soyutturlar.**