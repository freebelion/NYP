using System.Text;

namespace Kart1
{
    internal class Kart1Program
    {
        static void Main(string[] args)
        {
            List<Kart> deste = new List<Kart>();
            
            Console.OutputEncoding = Encoding.UTF8;
            
            for (int i = 0; i < Enum.GetValues(typeof(KartRenk)).Length; i++)
            {
                for(int j = 1; j < Kart.KartDegerleri.Length; j++)
                {
                    Kart k = new Kart((KartRenk)i, j);
                    deste.Add(k);
                }
            }

            foreach(Kart k in deste)
            { Console.Write(k); Console.Write(" "); }
            Console.WriteLine("\n");

            deste.Karistir<Kart>();

            foreach (Kart k in deste)
            { Console.Write(k); Console.Write(" "); }
            Console.WriteLine("\n");

            deste.Sort();

            foreach (Kart k in deste)
            { Console.Write(k); Console.Write(" "); }
            Console.WriteLine("\n");
        }
    }
}