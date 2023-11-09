using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kart1
{
    public static class ListeKaristirici
    {// https://stackoverflow.com/questions/108819/best-way-to-randomize-an-array-with-net
        private static Random rng = new Random();

        public static void Karistir<T>(this List<T> liste)
        {
            rng = new Random();
            int n = liste.Count;
            while (n > 1)
            {
                int k = rng.Next(n);
                n--;
                T temp = liste[n];
                liste[n] = liste[k];
                liste[k] = temp;
            }
        }
    }
}
