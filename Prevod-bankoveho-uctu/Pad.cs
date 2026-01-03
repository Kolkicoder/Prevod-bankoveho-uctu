using System;

namespace BankAccountTransfer
{
    internal class Pad
    {
        public void ui()
        {
            // top left corner
            Console.SetCursorPosition(10, 2);
            Console.Write("╔");
            Console.Write(new string('╔', +1));

            // top right corner
            Console.SetCursorPosition(92, 2);
            Console.Write("╗");

            // top wall
            Console.SetCursorPosition(11, 2);
            Console.Write("═");
            Console.Write(new string('═', 80));

            // bottom left corner
            Console.SetCursorPosition(10, 30);
            Console.Write("╚");

            // bottom right corner
            Console.SetCursorPosition(92, 30);
            Console.Write("╝");

            // bottom wall
            Console.SetCursorPosition(11, 30);
            Console.Write("═");
            Console.Write(new string('═', 80));

            // left and right walls
            for (int i = 0; i < 27; i++)
            {
                Console.SetCursorPosition(10, 3 + i);
                Console.Write("║");
                Console.SetCursorPosition(92, 3 + i);
                Console.Write("║");
            }

            // receipt header
            Console.SetCursorPosition(40, 4);
            Console.Write("KinoLogy Ltd.");
            Console.SetCursorPosition(29, 5);
            Console.Write("Nábrežná 1325, 023 14 Kysucké Nové Mesto");
            Console.SetCursorPosition(41, 6);
            Console.Write("Company ID: 51906201");
            Console.SetCursorPosition(40, 7);
            Console.Write("Tax ID: 2120827291");
            Console.SetCursorPosition(37, 8);
            Console.Write("VAT ID: SK2120827291");
            Console.SetCursorPosition(40, 9);
            Console.Write("www.KinoLogy.sk");
            Console.SetCursorPosition(12, 10);
            Console.WriteLine("Date: ");
            Console.SetCursorPosition(50, 10);
            Console.WriteLine("Time: ");

            Console.SetCursorPosition(11, 11);
            Console.Write("-");
            Console.Write(new string('-', 80));

            Console.SetCursorPosition(12, 13);
            Console.Write("Your movie: ");
            Console.SetCursorPosition(50, 13);
            Console.WriteLine("Price: ");
            Console.SetCursorPosition(12, 14);
            Console.Write("Snack: ");
            Console.SetCursorPosition(50, 14);
            Console.WriteLine("Price: ");

            if (true)
            {
                Console.SetCursorPosition(12, 15);
                Console.Write("Product: ");
                Console.SetCursorPosition(50, 15);
                Console.WriteLine("Price: ");
            }

            Console.SetCursorPosition(11, 15);
            Console.Write("-");
            Console.Write(new string('-', 80));

            Console.SetCursorPosition(12, 17);
            Console.Write("Total ");
            Console.SetCursorPosition(50, 17);
            Console.WriteLine("Price: ");

            Console.SetCursorPosition(11, 18);
            Console.Write("=");
            Console.Write(new string('=', 80));

            Console.SetCursorPosition(12, 20);
            Console.Write("Cash received ");
            Console.SetCursorPosition(50, 20);
            Console.WriteLine("Price: ");

            Console.SetCursorPosition(12, 21);
            Console.Write("Change returned ");
            Console.SetCursorPosition(50, 21);
            Console.WriteLine("Price: ");

            Console.SetCursorPosition(37, 28);
            Console.Write("Thank you for your visit!");

            Console.ReadKey();
        }
    }
}