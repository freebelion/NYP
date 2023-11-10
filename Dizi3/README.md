## Dizi3
Bu projede numara ve 0 ile 100 (ikisi de dahil) arasında
not bilgisi içeren `Ogrenci` sınıfı türünden nesneler oluşturuyor
ve onları bir listeye ekliyorum.

Öğrenci numaralarını (20)19 ve (20)24 (dahil değil) arasında
rasgele atılmış bir yıl bilgisi ile `bolumKodlari` dizisinden
rasgele seçilmiş bölüm kodu ve üç haneli bir rasgele sayıyı
birleştirerek uydurdum.

Orijinal liste elemanlarını yazdırdıktan sonra,
internetten yaptığım taramada bulduğum örnekleri
taklit ederek LINQ ile hazır sıralama fonksiyonlarını
kullanarak oluşturduğum sıralı listeleri yazdırdım.
Son olarak da, `IComparer<Ogrenci>` arabirimini uyarlayan
bir sınıf tanımladım ve orijinal listeyi numaraya göre
sıralanmış düzene soktum.
> Sınıf tanımınızda `IComparable` arabirimini uyarlamışsanız,
  C# jenerik listelerinin veya dizilerinin otomatik sıralama 
  fonksiyonlarını kullanabilirsiniz, ama yalnızca belli bir düzene
  göre sıralama yapabilirsiniz.<br>
  `IComparer` arabirimini uyarlayan bir kaç sınıfla,
  aynı sınıf türünden elemanlar içeren dizileri veya listeleri
  birden fazla düzene göre sıralatabilirsiniz.