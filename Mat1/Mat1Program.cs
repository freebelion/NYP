namespace Mat1
{
    internal class Mat1Program
    {
        static void Main(string[] args)
        {
            Polinom pol1 = new Polinom(1, 3, 2);
            Polinom pol2 = new Polinom(2, -1, 1);
            Ustel ust1 = new Ustel(1, 2, -0.5);
            Ustel ust2 = new Ustel(2.5, 1, 3);

            List<Fonksiyon> fonksiyonlar = new List<Fonksiyon>();
            fonksiyonlar.Add(pol1);
            fonksiyonlar.Add(pol2);
            fonksiyonlar.Add(ust1);
            fonksiyonlar.Add(ust2);

            for(double x = 0; x < 10; x+= 0.1)
            {
                for(int i=0; i < fonksiyonlar.Count; i++)
                {
                    Console.Write("{0,8}\t\t", Math.Round(fonksiyonlar[i].Deger(x), 4));
                }
                Console.WriteLine();
            }
        }
    }
}