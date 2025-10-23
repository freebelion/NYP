namespace Vector1
{
    internal class Vector1Program
    {
        static void Main(string[] args)
        {
            int i; // value type
            Vector v; // reference type
            Random rnd = new Random((int) DateTime.Now.Ticks);
            // here, we define an array of 5 members
            Vector[] vektorler = new Vector[5];

            for(i=0; i<vektorler.Length; i++)
            {
                vektorler[i] =
                    new Vector(10 * rnd.NextDouble() - 5,
                               10 * rnd.NextDouble() - 5);
            }

            Vector toplam = new Vector();
            foreach(Vector vek in vektorler)
            { toplam = toplam + vek; }

            for(i= 0; i < vektorler.Length - 1; i++)
            { Console.Write("{0} + ", vektorler[i]); }

            Console.WriteLine("{0} = {1}", vektorler[i], toplam);
        }
    }
}
