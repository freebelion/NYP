## Fabrika1
Bu proje Fabrika (**Factory**) tasarım deseninin tanıtımındaki ilk örnektir.
Bu açıklamaları okuyanlar projenin son halini görecektir tabi ki,
ve o yüzden de programı geliştirme aşamalarını görmeyeceklerdir. 
Projeyi daha anlaşılır kılmak için, kodları yazarken
neyi neden nasıl yaptığımı adım adım açıklamaya çalışacağım:

- Projeyi ticaret odasının veya bir meslek odasının kullabileceği
  bir firma kayıt takip programıymış gibi oluşturuyorum.
- `Oda` adlı sınıf kayıt/takip işlerini yürütecek olan odayı temsil ediyor.
- `Firma` adlı sınıf daaaa, ... evet, bir firmayı temsil ediyor.
- Projeyle oluşturduğum program aslında bir konsol uygulaması.
  Yani kodları sırayla işleme koyup tamamladıktan sonra sona erecek.
  Halbuki gerçek bir kayıt/takip programını bir görsel masaüstü uygulaması,
  veya yine bir görsel arayüz aracılığıyla erişilen
  web tabanlı bir uygulama olurdu.
  Öyle bir program da sürekli tekrarlanan bir döngü içinde
  işlemlerini yapardı.
- Bu taklit program da o şekilde çalışsın diye,
  `Oda` sınıfına `KayitTakip` adlı bir metod ekledim.
  Gerçek bir kayıt takip uygulamasındaki gibi, o metotda bir döngü olacak.
  O döngü de kullanıcı (yeni deneme yapan ben) ENTER tuşuna bastıkça
  tekrarlanacak:
  ```
        public void KayitTakip()
        {
            string? cevap;
            
            // Türkçe karakterler doğru gözüksün diye bu komutla konsol penceresine ayar çekelim.
            Console.OutputEncoding = Encoding.UTF8;

            do
            {// Bu döngü gerçek bir kayıt/takip uygulamasının sürekli çalışmasını taklit ediyor.
                
                cevap = Console.ReadLine();
            } while (string.IsNullOrEmpty(cevap));
        }
  ```
- Konsol uygulamasının giriş noktası olan `Main`fonksiyonu
  hayali ticaret odasını temsil edecek olan `Oda` türü bir nesne oluşturuyor
  ve onun kayıt/takip işlemlerini başlatıyor:
  ```
        static void Main(string[] args)
        {
            Oda ticaretOdasi = new Oda();

            ticaretOdasi.KayitTakip();
        }
  ```
- Gerçek bir uygulamada firma kayıt başvuruları alınır, başvurudaki bilgiler
  incelenerek, onaylanan firmalar kayıt edilirdi.
  Bu taklit programda bir kayıt başvurusunu temsil edecek olan
  şu sınıfı tanımladım:
  ```
    internal class Basvuru
    {
        public string FirmaAdi { get; private set; }

        public Basvuru()
        { FirmaAdi = Guid.NewGuid().ToString().Substring(0, 8); }
    }
  ```
  Bu sınıfın kurucu fonksiyonu teklif edilen adı rasgele oluşturmak için
  uzun bir tamsayı değer olarak düşüneceğimiz bir `Guid` değeri oluşturuyor,
  onun metin eşdeğerinin ilk 8 karakterini `FirmaAdi` olarak kaydediyor.
- `Oda` sınıfına eklediğim şu metod firma kayıt başvuruları alıyormuş gibi,
  rasgele sayıda `Basvuru` nesnesi oluşturacak, onları direkt onaylamış gibi
  teklif edilen adlarla yeni `Firma` nesneleri oluşturup listesine ekleyecek:
  ```
        public void BasvurulariAl()
        {
            int basvuruSayisi = RND.Next(6);

            for(int i=0; i <basvuruSayisi; i++)
            {
                Basvuru firmaBasvuru = new Basvuru();
                Firma yeniFirma = FirmaKayit(firmaBasvuru);
                firmalar.Add(yeniFirma);
            }
        }
  ```
- Yukarıdaki bu metod yeni bir `Firma` nesnesi oluşturma işini
  şu kayıt fonksiyonuna havale ediyor:
  ```
        public Firma FirmaKayit(Basvuru firmaBasvuru)
        {
            FirmaSayisi++;
            string sicilNo = string.Format("{0}_{1}", DateTime.Today.ToString("yyyy"), FirmaSayisi.ToString("0000"));
            return new Firma(firmaBasvuru.FirmaAdi, sicilNo);
        }
  ```
  Bu projedeki "fabrika" aslında bu fonksiyon.
- Nesne oluşturma işini ayrı bir fonksiyonda yaptırarak
  bu işin gerektirdiği tüm işlemleri belli bir yere toplamış oldum.
  Gerçek hayattaki bir kayıt/takip programında firma kaydı
  başvuruda belirtilen firma sermayesine, faliyet sektörüne, 
  ortak sayısına, vb. göre incelenir ve uygun görülürse onaylanırdı.
  Başvurunun onaylanması halinde de yeni kayıt edilen firma için
  geçerli olacak vergi oranları, teşvik birimleri vb. belirlenirdi.
  Tüm bu onay ve değer atama işlemleri zaman zaman değişebilen
  resmi düzenlemelere bağlı olacağı için,
  ara ara o kodları bulup değiştirmek gerekirdi.<br>
  Gerçi ben bu taklit programda herhangi bir onay incelemesi
  yaptırmıyorum, ama nesne oluşturma işini bu fabrika fonksiyonunda
  toplamış olduğum için, değişiklik gerekmesi halinde 
  dönüp değiştireceğim kodların nerede olduklarını biliyorum.
- Hayali ticaret odası kaydettiği firmalardan düzenli raporlar isteyecektir.
  Bu programda bu raporlama işlemini aşağıdaki gibi taklit ediyorum:

  -`Oda` sınıfının kayıt/takip döngüsü programın çalıştırıldığı günden
    başlayarak, sonraki her ay için kayıtlı firmalardan raporlar
    alacak bir metodu çaırıyor:
  ```
            DateTime raporTarih = DateTime.Today;
            do
            {// Bu döngü gerçek bir kayıt/takip uygulamasının sürekli çalışmasını taklit ediyor.
                
                BasvurulariAl();

                raporTarih = raporTarih.AddMonths(1);
                RaporlariAl(raporTarih);

                cevap = Console.ReadLine();
            } while (string.IsNullOrEmpty(cevap));
  ```
   -`RaporlariAl` metodu da tarih bilgisini gönderek, kayıtlı firmaları
   temsil eden `firmalar`listesinin her üyesinden rapor talep ediyor:
  ```
        public void RaporlariAl(DateTime raporTarih)
        {
            for (int i = 0; i < firmalar.Count; i++)
            {
                Console.WriteLine(firmalar[i].Rapor(raporTarih));
            }
            Console.WriteLine();
        }
  ```
  - `firmalar`listesinin her üyesi aslında `Firma`türü bir nesne.
    Onlar da kendi `Rapor` fonksiyonları aracılığıyla rasgele belirlenmiş
    bir kazanç değeri içeren uydurma bir metin gönderiyor:
  ```
        public string Rapor(DateTime raporTarih)
        {
            // Rapor dediğimiz şey de aslında rasgele belirlenen bir kar7zarar bildirimi:
            decimal bilanco = (decimal)(-5E6 + 10E6 * Oda.RND.NextDouble());

            return string.Format("{0} {1} bilançosu: {2}", Ad, raporTarih.ToString("yyyy MMMM"), bilanco.ToString("C2"));
        }
  ```