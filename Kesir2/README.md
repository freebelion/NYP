## Kesir2
Bu ikinci projede iki ayrı kesir nesnesini
temsil eden iki `pay` ve iki `payda` değişkeni
tanımladım.
Kesirlerin ondalıklı eşdeğerlerini
de iki ayrı `double` türü değişkene
aktardım.
> In this project, I defined two `pay` (numerator)
and two `payda` (denominator) variables
which represent two separate fractions.<br>
I have then assigned the decimal equivalents of
the two fractions to two separate `double` variables.

Birden fazla kesiri oluşturan pay ve payda
değişkenlerinin ayrı tanımlanmalarının
yaratacağı zorlukları görmek zor değildir.
> It is not hard to see the difficulties which will arise
from separately defining numerator and denominator
variables representing more than one fraction.

Bir programda çok sayıda kesir nesnesi
oluşturulacaksa, daha da kötüsü,
kaç tane kesir nesnesinin olacağı
bilinmiyorsa, pay ve paydaların ayrı
tanımlanması mantıksız olacaktır.
> If there is going to be many more fraction objects,
and what's worse, if the number of those fractions
are not known ahead of time, defining the numerator
and denominator variables will not be a sensible choice.