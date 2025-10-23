## Kesir3
Bu üçüncü projede bir kesir nesnesinin
nasıl bir şey olduğunu açıklayacak
bir sınıf tanımı, yani bir nesne kalıbı
oluşturdum. Böyle bir sınıf tanımı
gerçek hayattaki bir nesneyi temsil eden
birden fazla bilgiyi o nesneyi
tarif edecek bir pakette toplayacak,
yani "kapsüllemiş" olacaktır.<br>
<u>*Kapsülleme (**encapsulation**) nesneye
yönelik programlamanın birinci önemli
prensibidir.*</u>

> In this third project, I have constructed 
a class definition, an object template in a sense,
which will explain what a fraction object
is like. A class definition like that
will bring together more than one information
which represent a real-world object in a package,
in other words, it will have "encapsulated" them.<br>
<u>*Encapsulation is the first important principle
    of object-oriented programming.*</u>

`class Kesir` tanımı bir kesir nesnesinin
`pay` ve `payda` adlı iki tamsayı
değişkenden oluştuğunu gösteriyor
ve kesrin ondalıklı eşdeğerini
hesaplayan `Oran` adlı fonksiyonu da
barındırıyor.
> The class `Kesir` (Fraction) demonstrates that
a fraction object consists of two integer variables
name `pay` (numerator) and `payda` (denominator),
and also contains the function named `Oran` (Ratio)
that calculates the decimal equivalent of the fraction.

Bu sefer projenin adını da eklediğim
**Kesir3Program** kod dosyasında
bu sınıf türünden iki `Kesir` nesnesi
oluşturuyorum ve önceki projelerdeki
gibi iki kesrin pay ve payda bölümleriyle
ondalıklı eşdeğerlerini yazdırıyorum.
> In this case, I create two `Kesir` objects 
in the program code file **Kesir3Program**
named after the project, and get the two fractions
and their decimal equivalents written,
as was done in the earlier projects.