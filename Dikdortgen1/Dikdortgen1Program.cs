using System.Drawing;

namespace Dikdortgen1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dikdortgen rect1; // just a reference variable
            // a reference variable pointing to an empty Dikdortgen object
            Dikdortgen rect2 = new Dikdortgen(); 

            Nokta solust = new Nokta(540, 168);

            rect1 = new Dikdortgen(solust, 1670, 9023);
            rect1.SolUstKose.X = 1904;
            rect1.SolUstKose.Y = 8056;
            rect2.SolUstKose = new Nokta(300, 5190);

            Console.WriteLine("Plot top-left coordinates are: {0} {1}",
                rect1.SolUstKose.X, rect1.SolUstKose.Y);
            Console.WriteLine("Plot area is: {0}", rect1.Alan());
            Console.WriteLine("Plot circumference is: {0}", rect1.Cevre());
        }
    }
}
