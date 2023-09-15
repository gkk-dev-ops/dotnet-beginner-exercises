using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyApp
{
    internal class Program
    {
        static int kumulacja;
        static int START = 30;
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            int pieniadze = START;
            int dzien = 0;
            do
            {
                pieniadze = START;
                dzien = 0;
                ConsoleKey wybor;
                do
                {
                    kumulacja = rnd.Next(2, 37) * 1000000;
                    dzien++;
                    int losow = 0;
                    List<int[]> kupon = new List<int[]>();
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Dzień {0}.", dzien);
                        Console.WriteLine("Witaj w grze LOTTO, dziś do wygrania jest: {0} zł", kumulacja);
                        Console.WriteLine("Masz {0} zł.", pieniadze);
                        WyswietlKupon(kupon);
                        if (pieniadze >= 3 && losow < 8) {
                            Console.WriteLine("1. Postaw los - 3 zł [{0}/8]", losow);
                        }
                        Console.WriteLine("2. Sprawdź kupon - losowanie");
                        Console.WriteLine("3. Zakończ grę");
                        // MENU
                        wybor = Console.ReadKey().Key;
                        if (wybor == ConsoleKey.D1 && pieniadze >= 3 && losow < 8){
                            kupon.Add(PostawLos());
                            pieniadze -= 3;
                            losow++;
                        }
                    } while (wybor == ConsoleKey.D1);
                    Console.Clear();
                    if (kupon.Count > 0) {
                        int wygrana = Sprawdz(kupon);
                        if (wygrana > 0) {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Gratulacje, wygrałeś {0} zł", wygrana);
                            Console.ResetColor();
                            pieniadze += wygrana;
                        } else {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Niestety, nic nie wygrałeś.");
                            Console.ResetColor();
                        }
                    } else {
                        Console.WriteLine("Nie miałeś losów w tym losowaniu.");
                    }
                    Console.WriteLine("Naciśnij ENTER aby kontynuować.");
                    Console.ReadKey();
                } while (pieniadze > 3 && wybor != ConsoleKey.D3);
                Console.Clear();
                Console.WriteLine("Dzień {0}.\n Koniec gry, twój wynik to: {1} zł", dzien, pieniadze - START);
            } while (Console.ReadKey().Key == ConsoleKey.Enter);
        }
        private static int Sprawdz(List<int[]> kupon){
            int wygrana = 0; 
            int[] wylosowane = new int[6];
            for (int i = 0; i < wylosowane.Length; i++) {
                int los = rnd.Next(1, 50);
                if (!wylosowane.Contains(los)) {
                    wylosowane[i] = los;
                } else {
                    i--;
                }
            }
            Array.Sort(wylosowane);
            System.Console.WriteLine("Wylosowane liczby: ");
            foreach (int l in wylosowane) {
                System.Console.Write("{0}, ", l);
            }
            int[] trafione = SprawdzTrafienia(kupon, wylosowane);
            int wartosc = 0;
            System.Console.WriteLine();
            if (trafione[0] > 0) {
                wartosc = trafione[0] * 24;
                System.Console.WriteLine("3 trafienia: {0} + {1} zł", trafione[0], wartosc);
                wygrana += wartosc;
            }
            if (trafione[1] > 0) {
                wartosc = trafione[1] * rnd.Next(100, 301);
                System.Console.WriteLine("4 trafienia: {0} + {1} zł", trafione[1], wartosc);
                wygrana += wartosc;
            }
            if (trafione[2] > 0) {
                wartosc = trafione[2] * rnd.Next(4000, 8001);
                System.Console.WriteLine("5 trafień: {0} + {1} zł", trafione[2], wartosc);
                wygrana += wartosc;
            }
            if (trafione[3] > 0) {
                wartosc = trafione[3] * kumulacja / (trafione[3] + rnd.Next(0, 5));
                System.Console.WriteLine("5 trafień: {0} + {1} zł", trafione[2], wartosc);
                wygrana += wartosc;
            }
            return wygrana;
        }
        private static int[] SprawdzTrafienia(List<int[]> kupon, int[] wylosowane){
            int[] wygrane = new int[4];
            int i = 0;
            System.Console.WriteLine("Twój Kupon: ");
            foreach (int[] los in kupon)
            {
                i++;
                System.Console.WriteLine("{0}. ", i);
                int trafien = 0;
                foreach (int liczba in los)
                {
                    if (wylosowane.Contains(liczba)) {
                        Console.ForegroundColor = ConsoleColor.Green;
                        System.Console.Write(liczba + ", ");
                        Console.ResetColor();
                        trafien++;
                    } else {
                        System.Console.Write(liczba + ", ");
                    }
                }
                switch (trafien) {
                    case 3:
                        wygrane[0]++;
                        break;
                    case 4:
                        wygrane[1]++;
                        break;
                    case 5:
                        wygrane[2]++;
                        break;
                    case 6:
                        wygrane[3]++;
                        break;
                }
                System.Console.WriteLine("- Trafiono {0}/6 liczb.", trafien);
            }
            return wygrane;
        }
        private static int[] PostawLos() {
            int[] liczby = new int[6];
            int liczba = -1;
            for(int i=0; i < liczby.Length; i++) {
                Console.Clear();
                System.Console.WriteLine("Postawione liczby: ");
                foreach (int l in liczby) {
                    if(l > 0) {
                    System.Console.WriteLine("{0} ", l);
                    }
                }
                System.Console.WriteLine("\n\nWybierz liczbę od 1 do 49: ");
                System.Console.Write("{0}/6: ", i+1);
                bool prawidlowa = int.TryParse(Console.ReadLine(), out liczba);
                if (prawidlowa && liczba >= 1 && liczba <= 49 && !liczby.Contains(liczba)) {
                    liczby[i] = liczba;
                } else {
                    System.Console.WriteLine("Nieprawidłowa liczba, spróbuj ponownie.");
                    i--;
                    Thread.Sleep(500);
                }
            }
            Array.Sort(liczby);
            return liczby;
        }
        private static void WyswietlKupon(List<int[]> kupon) {
            if (kupon.Count == 0) {
                Console.WriteLine("Nie masz żadnych losów.");
            } else {
                int i = 0;
                Console.WriteLine("Twój kupon:");
                foreach (int[] los in kupon) {
                    i++;
                    Console.Write("{0}. ", i);
                    foreach (int liczba in los)
                    {
                        System.Console.WriteLine("{0} ", liczba);
                    }
                    Console.WriteLine();
                }
            } 
        }
    }
}