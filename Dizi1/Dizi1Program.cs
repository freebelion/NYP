namespace Dizi1
{
    internal class Dizi1Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Dizi d = new Dizi();
            
            for(int i=0; i < 20; i++)
            {
                d.Ekle(rnd.Next(10, 100));
                for(int j=0; j < d.ElemanSayisi; j++)
                { Console.Write("{0}\t", d[j]); }
            }
        }
    }
}
