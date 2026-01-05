using Prevod_bankoveho_uctu;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Channels;

namespace BankAccountTransfer
{
    internal class Movies
    {
        public void Main()
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fileName = "Movie.txt";
            string filePath = Path.Combine(folder, fileName);

            string[] movies = File.ReadAllLines(filePath);

            if (movies.Length == 0)
            {
                Console.WriteLine("Súbor je prázdny.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Dostupné filmy:");
            for (int i = 0; i < movies.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + movies[i]);
            }

            int choice = 0;

            while (true)
            {
                Console.Write("\nVyber číslo filmu (1 - 20): ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out choice))
                {
                    Console.WriteLine("Neplatný výber filmu, skúste znova.");
                    continue;
                }

                if (choice < 1 || choice > 20)
                {
                    Console.WriteLine("Neplatný výber filmu, skúste znova.");
                    continue;
                }

                break;
            }

            string[] movieData = movies[choice - 1].Split(';');

            string selectedMovie = movieData[0];
            decimal moviePrice = decimal.Parse(movieData[1]);

            Console.WriteLine("Vybrali ste film: " + selectedMovie);
            Console.WriteLine("Cena filmu: " + moviePrice + " €");

            Console.WriteLine("Ak chcete, ponúkame aj občerstvenie.");
            Console.WriteLine("Zadajte 'A' pre občerstvenie alebo 'N' ak nechcete.");
            Console.Write("> ");

            decimal price1 = 2;
            decimal price2 = 2.5m;
            decimal price3 = 1;
            decimal price4 = 2.5m;

            string inputSnack = Console.ReadLine();
            Dictionary<string, int> selectedSnacks = new Dictionary<string, int>();

            if (inputSnack.ToUpper() == "A")
            {
                Console.WriteLine("Ponúkame toto občerstvenie:");
                Console.WriteLine($"1. Popcorn - {price1} €");
                Console.WriteLine($"2. Nachos - {price2} €");
                Console.WriteLine($"3. Sladkosti - {price3} €");
                Console.WriteLine($"4. Nápoje - Coca Cola, Nestea, Minerálna voda - {price4} €");
                Console.WriteLine("Zadajte číslo občerstvenia alebo napíšte 'that's all'.");

                while (true)
                {
                    Console.Write("> ");
                    string snackChoice = Console.ReadLine();

                    if (snackChoice.ToLower() == "that's all")
                    {
                        break;
                    }

                    string snackName = "";

                    switch (snackChoice)
                    {
                        case "1":
                            snackName = "Popcorn";
                            break;
                        case "2":
                            snackName = "Nachos";
                            break;
                        case "3":
                            snackName = "Sladkosti";
                            break;
                        case "4":
                            snackName = "Nápoje";
                            break;
                        default:
                            Console.WriteLine("Neplatná voľba, skúste znova.");
                            continue;
                    }

                    Console.Write("Zadajte množstvo: ");
                    if (int.TryParse(Console.ReadLine(), out int count) && count > 0)
                    {
                        if (selectedSnacks.ContainsKey(snackName))
                        {
                            selectedSnacks[snackName] += count;
                        }
                        else
                        {
                            selectedSnacks.Add(snackName, count);
                        }

                        Console.WriteLine($"{snackName} – pridané množstvo: {count} ks.");
                    }
                    else
                    {
                        Console.WriteLine("Neplatné množstvo.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Dobre, bez občerstvenia.");
            }

            Console.WriteLine("\nVybrali ste tieto položky občerstvenia:");

            if (selectedSnacks.Count == 0)
            {
                Console.WriteLine("Žiadne občerstvenie.");
            }
            else
            {
                foreach (var snack in selectedSnacks)
                {
                    Console.WriteLine($"- {snack.Key}: {snack.Value} ks");
                }
            }

            Calculator calculator = new Calculator();
            decimal snacksPrice = calculator.CalculateSnacks(selectedSnacks);
            decimal totalPrice = calculator.CalculateTotal(moviePrice, selectedSnacks);

            Console.WriteLine("\n--- ZHRNUTIE ---");
            Console.WriteLine("Film: " + selectedMovie);
            Console.WriteLine("Cena filmu: " + moviePrice + " €");
            Console.WriteLine("Cena občerstvenia: " + snacksPrice + " €");
            Console.WriteLine("CELKOM NA ZAPLATENIE: " + totalPrice + " €");

            Console.ReadKey();
        }
    }
}

