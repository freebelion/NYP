namespace Kesir4
{
    internal class Kesir4Program
    {
        class Kesir
        {
            // data hiding (2nd principle of OOP)
            private int _pay;
            private int _payda;

            // constructor function (with parameters)
            public Kesir(int p, int q)
            { _pay = p; _payda = q; }

            // property definition
            public int Pay
            {
                // get block (helps learn hidden values)
                get { return _pay; }
            }

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
