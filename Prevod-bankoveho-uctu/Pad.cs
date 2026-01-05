using System;

namespace BankAccountTransfer
{
    internal class Pad
    {
        public string Movie { get; set; }
        public decimal MoviePrice { get; set; }
        public Dictionary<string, int> Snacks { get; set; }
        public decimal SnacksPrice { get; set; }
        public decimal TotalPrice { get; set; }

        public void PrintReceipt()
        {
            Console.Clear();
            ui();

            int row = 13;

            Console.SetCursorPosition(12, row);
            Console.Write("Film: " + Movie);
            Console.SetCursorPosition(50, row);
            Console.Write(MoviePrice + " €");
            row++;

            if (Snacks != null && Snacks.Count > 0)
            {
                foreach (var snack in Snacks)
                {
                    Console.SetCursorPosition(12, row);
                    Console.Write("Občerstvenie: " + snack.Key + " (" + snack.Value + " ks)");
                    row++;
                }
            }
            else
            {
                Console.SetCursorPosition(12, row);
                Console.Write("Bez občerstvenia");
                row++;
            }

            Console.SetCursorPosition(11, row);
            Console.Write(new string('-', 80));
            row++;

            Console.SetCursorPosition(12, row);
            Console.Write("Spolu");
            Console.SetCursorPosition(50, row);
            Console.Write(TotalPrice + " €");
        }

        public void ui()
        {
            // horný ľavý roh
            Console.SetCursorPosition(10, 2);
            Console.Write("╔");
            Console.Write(new string('╔', +1));

            // horný pravý roh
            Console.SetCursorPosition(92, 2);
            Console.Write("╗");

            // horná stena
            Console.SetCursorPosition(11, 2);
            Console.Write("═");
            Console.Write(new string('═', 80));

            // dolný ľavý roh
            Console.SetCursorPosition(10, 30);
            Console.Write("╚");

            // dolný pravý roh
            Console.SetCursorPosition(92, 30);
            Console.Write("╝");

            // dolná stena
            Console.SetCursorPosition(11, 30);
            Console.Write("═");
            Console.Write(new string('═', 80));

            // ľavá a pravá stena
            for (int i = 0; i < 27; i++)
            {
                Console.SetCursorPosition(10, 3 + i);
                Console.Write("║");
                Console.SetCursorPosition(92, 3 + i);
                Console.Write("║");
            }

            // hlavička pokladničného dokladu
            Console.SetCursorPosition(40, 4);
            Console.Write("KinoLogy s.r.o.");
            Console.SetCursorPosition(29, 5);
            Console.Write("Nábrežná 1325, 023 14 Kysucké Nové Mesto");
            Console.SetCursorPosition(39, 6);
            Console.Write("IČO: 51906201");
            Console.SetCursorPosition(39, 7);
            Console.Write("DIČ: 2120827291");
            Console.SetCursorPosition(37, 8);
            Console.Write("IČ DPH: SK2120827291");
            Console.SetCursorPosition(40, 9);
            Console.Write("www.KinoLogy.sk");

            Console.SetCursorPosition(12, 10);
            Console.WriteLine("Dátum: ");
            Console.SetCursorPosition(50, 10);
            Console.WriteLine("Čas: ");

            Console.SetCursorPosition(11, 11);
            Console.Write("-");
            Console.Write(new string('-', 80));

            Console.SetCursorPosition(12, 13);
            Console.Write("Film: ");
            Console.SetCursorPosition(50, 13);
            Console.WriteLine("Cena: ");
            Console.SetCursorPosition(12, 14);
            Console.Write("Občerstvenie: ");
            Console.SetCursorPosition(50, 14);
            Console.WriteLine("Cena: ");

            if (true)
            {
                Console.SetCursorPosition(12, 15);
                Console.Write("Produkt: ");
                Console.SetCursorPosition(50, 15);
                Console.WriteLine("Cena: ");
            }

            Console.SetCursorPosition(11, 15);
            Console.Write("-");
            Console.Write(new string('-', 80));

            Console.SetCursorPosition(12, 17);
            Console.Write("Spolu ");
            Console.SetCursorPosition(50, 17);
            Console.WriteLine("Cena: ");

            Console.SetCursorPosition(11, 18);
            Console.Write("=");
            Console.Write(new string('=', 80));

            Console.SetCursorPosition(12, 20);
            Console.Write("Prijatá hotovosť ");
            Console.SetCursorPosition(50, 20);
            Console.WriteLine("Suma: ");

            Console.SetCursorPosition(12, 21);
            Console.Write("Vydané ");
            Console.SetCursorPosition(50, 21);
            Console.WriteLine("Suma: ");

            Console.SetCursorPosition(34, 28);
            Console.Write("Ďakujeme za Vašu návštevu!");

            Console.ReadKey();
        }
    }
}