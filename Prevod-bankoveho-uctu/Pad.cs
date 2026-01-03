using System.Diagnostics.Metrics;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace Prevod_bankoveho_uctu
{
    internal class Pad
    {
        public void ui()
        {
            // horny lavy roh
            Console.SetCursorPosition(10, 2);
            Console.Write("╔");
            Console.Write(new string('╔', +1));

            // horny pravy roh
            Console.SetCursorPosition(92, 2);
            Console.Write("╗");

            // horna stena
            Console.SetCursorPosition(11, 2);
            Console.Write("═");
            Console.Write(new string('═', 80));

            // dolny lavy roh
            Console.SetCursorPosition(10, 30);
            Console.Write("╚");

            // dolny pravy roh
            Console.SetCursorPosition(92, 30);
            Console.Write("╝");

            // dolna stena
            Console.SetCursorPosition(11, 30);
            Console.Write("═");
            Console.Write(new string('═', 80));

            // lava a prava stena
            for (int i = 0; i < 27; i++)
            {
                Console.SetCursorPosition(10, 3 + i);
                Console.Write("║");
                Console.SetCursorPosition(92, 3 + i);
                Console.Write("║");
            }

            //uctenka
            Console.SetCursorPosition(40, 4);
            Console.Write("KinoLogy s.r.o");
            Console.SetCursorPosition(29, 5);
            Console.Write("Nábrežná 1325, 023 14 Kysucké Nové Mesto");
            Console.SetCursorPosition(41, 6);
            Console.Write("IČO: 51906201");
            Console.SetCursorPosition(40, 7);
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
            Console.Write("Tvoj film: ");
            Console.SetCursorPosition(50, 13);
            Console.WriteLine("Cena: ");
            Console.SetCursorPosition(12, 14);
            Console.Write("Snack: ");
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
            Console.Write("Celkom ");
            Console.SetCursorPosition(50, 17);
            Console.WriteLine("Cena: ");

            Console.SetCursorPosition(11, 18);
            Console.Write("=");
            Console.Write(new string('=', 80));

            Console.SetCursorPosition(12, 20);
            Console.Write("Prijaté v hotovosti ");
            Console.SetCursorPosition(50, 20);
            Console.WriteLine("Cena: ");

            Console.SetCursorPosition(12, 21);
            Console.Write("Vrátené zákazníkovi ");
            Console.SetCursorPosition(50, 21);
            Console.WriteLine("Cena: ");

            Console.SetCursorPosition(37, 28);
            Console.Write("Ďakujeme za vašu návštevu!");


            Console.ReadKey();
        }
    }
}