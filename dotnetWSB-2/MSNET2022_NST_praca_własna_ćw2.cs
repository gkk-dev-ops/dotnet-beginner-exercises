namespace MyApp
{
    internal class Program
    {
        static void koniec_programu()
        {
            Console.Write("Nacisnij dowolny klawisz ...");
            Console.ReadKey();
        }
        static void Dodaj(int a, int b)
        {
            int wynik = a + b;
            Console.WriteLine("Wynik dodawania: " + wynik);
        }
        static void Dodaj(int a, int b, int c = 2)
        {
            int wynik = a + b + c;
            Console.WriteLine("Wynik dodawania: " + wynik);
        }
        static void Dodaj(int a, int b, int c = 2, string d = "prod")
        {
            int wynik = a + b + c;
            Console.WriteLine($"Wynik dodawania: {d} {wynik}");
        }
        static int Dodaj(int a, int b, int c, int d)
        {
            int wynik = a + b + c + d;
            Console.WriteLine($"Wynik dodawania: {wynik}");
            return wynik;
        }
        static void Test(ref int a)
        {
            a += 5;
            Console.WriteLine("W funkcji: " + a);
        }
        static void Test2(out int a)
        {
            a = 10;
            a += 5;
            Console.WriteLine("W funkcji: " + a);
        }
        static void Main(string[] args)
        {
            // 7. Instrukcje skoku
            int a = 0;
            while (true)
            {
                Console.WriteLine(a);
                a++;
                if(a>10){
                    break;
                }
            }
            for (int i = 0; i < 10; i++)
            {
                if(i % 2 == 1)
                { 
                    continue;
                }
                Console.WriteLine(i);
            }
            jeden:
                Console.WriteLine ("Jeden");
                goto trzy;
            dwa:
                Console.WriteLine("Dwa");
            trzy:
                Console.WriteLine("Trzy");
            // 8. Instrukcje Switch
            int liczba = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            switch(liczba)
            {
            case 1:
                Console.WriteLine ("Jeden"); break;
            case 2:
                Console.WriteLine ("Dwa"); break;
            case 3:
                Console.WriteLine("Trzy"); break;
            default:
                Console.WriteLine("Inna wartość"); break;
            }
            // 11. Kurs C# dla początkujących - Funkcje
            Dodaj(1, 2);
            Dodaj(1, 2, 3);
            Dodaj(1, 2, 4, "test");
            int w = Dodaj(1, 2, 4, 5);
            Console.WriteLine(w);
            Console.WriteLine("Przed: " + w);
            Test(ref w);
            int c;
            Test2(out c);
            Console.WriteLine ("Po: " + w);
            Console.ReadKey();
            // 9, 10. tablice
            int[] temperature = new int[365];
            string[] dniTygodnia = {"poniedziałek", "wtorek", "środa", "czwartek", "piątek", "sobota", "niedziela"};
            for (int i = 0; i < dniTygodnia.Length; i++)
            {
                Console.WriteLine (dniTygodnia[i]);
            }
            int[,] tab = new int [2,3];
            tab[0, 0] = 1;
            tab[0, 1] = 2;
            tab[0, 2] = 5;
            tab[1, 0] = 22;
            tab[1, 1] = 33;
            tab[1, 2] = 44;
            for (int i = 0; i < tab.GetLength(0); i++)
            {
            for (int j = 0; j < tab.GetLength (1); j++)
            {
                Console.Write(tab[i,j] + " ");
            }
                Console.WriteLine();
            }
            koniec_programu();
        }
    }
}