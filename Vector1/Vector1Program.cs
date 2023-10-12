namespace Vector1
{
    internal class Vector1Program
    {
        static void Main(string[] args)
        {
            int i;
            Random rnd = new Random((int) DateTime.Now.Ticks);
            Vector[] vektorler = new Vector[5];

            for(i=0; i<vektorler.Length; i++)
            {
                vektorler[i] =
                    new Vector(10 * rnd.NextDouble() - 10,
                               10 * rnd.NextDouble() - 10);
            }

            Vector toplam = new Vector();
            foreach(Vector v in vektorler)
            { toplam = toplam + v; }

            for(i= 0; i < vektorler.Length - 1; i++)
            { Console.Write("{0} + ", vektorler[i]); }

            Console.WriteLine("{0} = {1}", vektorler[i], toplam);
        }
    }
}
