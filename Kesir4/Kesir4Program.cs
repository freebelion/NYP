namespace Kesir4
{
    internal class Kesir4Program
    {
        class Kesir
        {
            private int _pay;
            private int _payda;

            public Kesir(int p, int q)
            { _pay = p; _payda = q; }

            public int Pay
            { get { return _pay; } }

            public int Payda
            { get { return _payda; } }

            public double Oran()
            { return (double)_pay / _payda; }
        }

        static void Main(string[] args)
        {
            Kesir k1 = new Kesir(2,5);
            Console.WriteLine("Kesir[{0}/{1}] = {2}", k1.Pay, k1.Payda, k1.Oran());

            Kesir k2 = new Kesir(3,5);
            Console.WriteLine("Kesir[{0}/{1}] = {2}", k2.Pay, k2.Payda, k2.Oran());
        }
    }
}
