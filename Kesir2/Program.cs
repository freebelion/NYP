namespace Kesir2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pay1 = 2, payda1 = 5;
            double Oran1 = (double)pay1 / payda1;

            Console.WriteLine("Kesir[{0}/{1}] = {2}", pay1, payda1, Oran1);

            int pay2 = 3, payda2 = 5;
            double Oran2 = (double)pay2 / payda2;

            Console.WriteLine("Kesir[{0}/{1}] = {2}", pay2, payda2, Oran2);
        }
    }
}
