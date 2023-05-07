using System;

namespace cwiczeniaDotnet
{
    public class Program
    {
        static void haltProgram()
        {
            if (Environment.OSVersion.Platform != PlatformID.MacOSX)
            {
                Console.Write("Press any key to continue...");
                Console.ReadKey();
            }
        }
        public static void cw1()
        {
#if DEBUG
            Console.WriteLine("WYSWIETL W KONSOLI PROSTOKAT O SZEROKOSCI X ORAZ WYSOKOSCI Y ");
            Console.WriteLine(" X ORAZ Y PODAJE UZYTKOWNIK, PROSTOKAT ZBUDOWANY JEST Z \"*\"");
#endif

            Console.Write("Podaj szerokość prostokąta: ");
            int szerokosc = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Podaj wysokość prostokąta: ");
            
            int wysokosc = int.Parse(Console.ReadLine() ?? "0");

            for (int i = 0; i < wysokosc; i++)
            {
                for (int j = 0; j < szerokosc; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            haltProgram();
        }
        public static void cw2()
        {
#if DEBUG
            Console.WriteLine("GRA W ZGADYWANIE LICZBY WYLOSOWANEJ PRZEZ KOMPUTER");
            Console.WriteLine("KOMPUTER LOSUJE LICZBE Z ZAKRESU 1 - 10");
            Console.WriteLine("UZYTKOWNIK PROBUJE ODGADNAC WYLOSOWANA LICZBE");
            Console.WriteLine("JEZELI PODANA LICZBA JEST MNIEJSZA LUB WIEKSZA OD WYLOSOWANEJ - WYSWIETL KOMUNIKAT");
            Console.WriteLine("KIEDY UZYTKOWNIK ODGADNIE LICZBE, WYSWIETL INFORMACJE O WYGRANEJ");
#endif
            Random random = new Random();
            int wylosowanaLiczba = random.Next(1, 11);

            Console.WriteLine("Komputer wylosował liczbę z zakresu 1-10. Odgadnij ją!");

            int propozycja = 0;
            while (propozycja != wylosowanaLiczba)
            {
                Console.Write("Podaj swoją propozycję: ");
                propozycja = int.Parse(Console.ReadLine() ?? "0");

                if (propozycja < wylosowanaLiczba)
                {
                    Console.WriteLine("Liczba jest za mała.");
                }
                else if (propozycja > wylosowanaLiczba)
                {
                    Console.WriteLine("Liczba jest za duża.");
                }
                else
                {
                    Console.WriteLine("Brawo, odgadłeś liczbę!");
                }
            }
            haltProgram();
        }
        static void Main(string[] args)
        {
            cw1();
            cw2();
        }
    }
}
