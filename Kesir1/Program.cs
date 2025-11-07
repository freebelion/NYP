namespace Kesir1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // two independent integer variables
            // numerator and denominator of a fraction
            int pay = 2, payda = 5;
            double Oran = (double)pay / payda;

            Console.WriteLine("Kesir[{0}/{1}] = {2}",
                pay, payda, Oran);
        }
    }
}
