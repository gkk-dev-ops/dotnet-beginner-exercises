// MSNET2022_NST_praca_własna_ćw3.cs
using System;
using System.Collections;
using System.Text;

namespace MyApp
{
    internal class Program
    {
        // 20. Kurs C# dla początkujących - Kolekcje (ArrayList)
        static void showList(ArrayList list) {
            foreach (var item in list) {
                Console.WriteLine(item);
            }
        }
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList();
            list.Add("Bartek");
            list.Add(2);
            list.Add(new Auto("Fiat", 1990));
            Console.WriteLine(list.Count);
            foreach (var item in list) {
                Console.WriteLine(item);
            }
            list.Insert(0, "Pierwszy");

            // 21. Kurs C# dla początkujących - Kolekcje (List)
            List<Auto> list2 = new List<Auto>();
            list2.Add(new Auto("Wzium", 2010));
            list2.Add(new Auto("Wołga", 2022));
            list2.Add(new Auto("Fiat", 2017));
            Console.WriteLine(list2.Count);
            foreach (Auto item in list2) {
                Console.WriteLine(item.Nazwa);
            }
            // 22. Kurs C# dla początkujących - Kolekcje (Dictionary)
            Dictionary<string, Auto> dict = new Dictionary<string, Auto>();
            dict.Add("Wzium-1", new Auto("Wzium", 1890));
            dict.Add("Wołga-1", new Auto("Wołga", 1945));

            Console.WriteLine(dict["Wzium-1"].Nazwa);
            Console.WriteLine(dict["Wołga-1"].Nazwa);

            foreach (var item in dict) {
                Console.WriteLine(item.Key + " " + item.Value.Nazwa);
            }
            // 23. Kurs C# dla początkujących - Kolekcje (Queue & Stack)
            Queue<Auto> kolejka = new Queue<Auto>();
            kolejka.Enqueue(new Auto("Wzium", 1938));
            kolejka.Enqueue(new Auto("Wołga", 1938));
            kolejka.Enqueue(new Auto("Fiat", 1938));
            kolejka.Enqueue(new Auto("Fiat", 1938));
            kolejka.Enqueue(new Auto("Mercejdes", 1938));

            Console.WriteLine(kolejka.Peek().ToString());

            Console.WriteLine(kolejka.Dequeue().Nazwa);
            Console.WriteLine(kolejka.Dequeue().Nazwa);

            Stack<Auto> stos = new Stack<Auto>();
            stos.Push(new Auto("Wzium", 1985));
            stos.Push(new Auto("Wołga", 1985));
            stos.Push(new Auto("Fiat", 1985));
            stos.Push(new Auto("Fiat", 1985));

            Console.WriteLine(stos.Pop().Nazwa);
            Console.WriteLine(stos.Pop().Nazwa);

            foreach (var item in stos) {
                Console.WriteLine(item.Nazwa);
            }
            // 24. Kurs C# dla początkujących - Equals
            Auto auto1 = new Auto("Fiat", 1899);
            Auto auto2 = new Auto("Fiat", 1899);
            Console.WriteLine(auto1.Equals(auto2));
            Console.WriteLine(auto1 == auto2);
            Console.WriteLine(auto1 != auto2);
            // 25. Kurs C# dla początkujących - Compare
            Console.WriteLine(auto1.CompareTo(auto2));

            // 17. Kurs C# dla początkujących - Operacje na Stringach (params i object)
            string[] tab = { "Ala", "ma", "kota" };
            Console.WriteLine(string.Join(" ", tab));
            Console.WriteLine(string.Join(" ", "Ala", "ma", "kota"));
            Console.WriteLine(string.Join(" ", new object[] { "Ala", "ma", "kota" }));

            Console.WriteLine(GenerujTekst("Hello {0} {1}", "World", "!!!"));

            // 18. Kurs C# dla początkujących - Operacje na Stringach (StringBuilder)
            StringBuilder sb = new StringBuilder();
            sb.Append("Ala");
            sb.Append(" ma");
            sb.Append(" kota");
            sb.Append(" a");
            sb.Append(" kot");
            sb.Append(" ma");
            sb.Append(" Alę");
            Console.WriteLine(sb.ToString());

            Console.ReadKey();
        }
        class Auto: IComparable {
            public string Nazwa { get; set; }
            public int Rocznik { get; set; }
            public Auto(string marka, int rocznik) {
                Nazwa = marka;
                Rocznik = rocznik;
            }
            public override string ToString() {
                return $"[Auto]: {Nazwa}";
            }
            public bool Equals(Auto obj)
            {
                return this.Nazwa == obj.Nazwa;
            }
            public int CompareTo(object obj) {
                var arg = obj as Auto;
                if (arg == null) {
                    throw new ArgumentException("Nie można porównać");
                }
                return this.Rocznik.CompareTo(arg.Rocznik);
            }
        }
        static string GenerujTekst(string text, params object[] args) {
            for(int i = 0; i < args.Length; i++) {
                text = text.Replace("{" + i + "}", args[i].ToString());
            }
            return text;
        }
    }
}