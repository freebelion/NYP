namespace Kesir3
{
    internal class Kesir3Program
    {
        class Kesir
        {
            public int pay;
            public int payda;

            public double Oran()
            { return (double)pay / payda; }
        }

        static void Main(string[] args)
        {
            Kesir k1 = new Kesir(); k1.pay = 2; k1.payda = 5;
            Console.WriteLine("Kesir[{0}/{1}] = {2}", k1.pay, k1.payda, k1.Oran());

            Kesir k2 = new Kesir(); k2.pay = 3; k2.payda = 5;
            Console.WriteLine("Kesir[{0}/{1}] = {2}", k2.pay, k2.payda, k2.Oran());
        }
    }
}
