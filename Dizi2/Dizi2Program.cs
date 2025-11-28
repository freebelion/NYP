namespace Dizi2
{
    internal class Dizi2Program
    {
        static void Main(string[] args)
        {
            SablonDizi<string> strings = new SablonDizi<string>();

            strings.Ekle("Recai");
            strings.Ekle("Sezai");
            strings.Ekle("Mesai");

            for (int i = 0; i < strings.ElemanSayisi; i++)
            {
                Console.WriteLine("{0}", strings[i]);
            }
        }
    }
}