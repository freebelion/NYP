namespace Kesir5
{
    internal class Kesir5Program
    {
        class Kesir
        {
            private int _pay;
            private int _payda;

            // default (empty) constructor
            public Kesir()
            { Pay = 0; Payda = 1; }

            public Kesir(int p, int q)
            { Pay = p; Payda = q; }

            public int Pay
            {
                get { return _pay; }
                set { _pay = value; }
            }

            public int Payda
            {
                get { return _payda; }
                set
                {
                    if (value > 0)
                    { _payda = value; }
                    else if (value < 0)
                    { _payda = -value; _pay = -_pay; }
                    else
                    { throw new ApplicationException("_payda değeri 0 olamaz!"); }
                }
            }

            public static explicit operator double(Kesir k)
            { return (double)k.Pay / k.Payda; }

            public static implicit operator string(Kesir k)
            { return "[" + k.Pay.ToString() + "/" + k.Payda.ToString() + "]"; }
        }

        static void Main(string[] args)
        {
            Kesir k1 = new Kesir(); k1.Pay = 2; k1.Payda = 5;
            Console.WriteLine("Kesir[{0}/{1}] = {2}", k1.Pay, k1.Payda, (double)k1);

            Kesir k2 = new Kesir(); k2.Pay = 3; k2.Payda = -5;
            Console.WriteLine("Kesir[{0}/{1}] = {2}", k2.Pay, k2.Payda, (double) k2);

            // "implicit" olarak etiketlediğim string dönüştürücü işlemcisinin
            // sonucunu test etmek için.
            Console.WriteLine("{0} = {1}", (string)k1, (double)k1);
        }
    }
}
