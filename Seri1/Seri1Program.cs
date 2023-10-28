namespace Seri1
{
    internal class Seri1Program
    {
        abstract class Seri
        {
            protected double _sayi;
            public double ILK { get; set; }
            public double ADIM { get; set; }

            public Seri(double ilk, double adim)
            {
                _sayi = ILK = ilk;
                ADIM = adim;
            }

            public double SAYI
            { get {  return _sayi; } }

            public abstract void Sonraki();
        }

        class AritmetikSeri : Seri
        {
            public AritmetikSeri(double ilk, double adim)
                : base(ilk, adim)
            {

            }

            public override void Sonraki()
            { _sayi += ADIM; }
        }

        class GeometrikSeri : Seri
        {
            public GeometrikSeri(double ilk, double adim)
                : base(ilk, adim)
            {

            }

            public override void Sonraki()
            { _sayi *= ADIM; }
        }

        static void Main(string[] args)
        {
            Seri seri1 = new AritmetikSeri(1, 2);
            Seri seri2 = new GeometrikSeri(1, 2);

            Console.WriteLine("İlk elemanı 1 ve adımı 2 olan aritmetik ve geometrik seriler:");
            for(int i=0; i <= 10; i++, seri1.Sonraki(), seri2.Sonraki())
            {
                Console.WriteLine("{0,6}\t{1,6}\t{2,6}", i, seri1.SAYI, seri2.SAYI);
            }
        }
    }
}