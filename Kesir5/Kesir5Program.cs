namespace Kesir5
{
    internal class Kesir5Program
    {
        static void Main(string[] args)
        {
            Kesir k1 = new Kesir(); k1.Pay = 2; k1.Payda = 5;
            Console.WriteLine("Kesir[{0}/{1}] = {2}", k1.Pay, k1.Payda, (double)k1);

            Kesir k2 = new Kesir(); k2.Pay = 3; k2.Payda = -5;
            Console.WriteLine("Kesir[{0}/{1}] = {2}", k2.Pay, k2.Payda, (double) k2);

            Console.WriteLine("{0} = {1}", (string)k1, (double)k1);
        }
    }
}
