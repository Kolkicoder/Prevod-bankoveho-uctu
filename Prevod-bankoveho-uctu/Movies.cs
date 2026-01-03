using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Prevod_bankoveho_uctu
{
    internal class Movies
    {
        public void Main()
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fileName = "Movie.txt";
            string fileLocale = Path.Combine(folder, fileName);

            string[] movies = File.ReadAllLines(fileLocale);

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
                Console.Write("\nVyberte číslo filmu (1 - 20): ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out choice))
                {
                    Console.WriteLine("Nesprávny film, skúste to znova.");
                    continue;
                }

                if (choice < 01 || choice > 20)
                {
                    Console.WriteLine("Nesprávny film, skúste to znova.");
                    continue;
                }

                break;
            }

            string[] movieData = movies[choice - 1].Split(';');

            string selectedMovie = movieData[0];
            decimal cenaFilmu = decimal.Parse(movieData[1]);

            Console.WriteLine("Vybrali ste film: " + selectedMovie);
            Console.WriteLine("Cena filmu: " + cenaFilmu + " €");

            Console.WriteLine("Ak by ste chceli, tak ponúkame aj snacky.");
            Console.WriteLine("Pre snack zadajte 'A', pre žiadny snack zadajte 'N'.");
            Console.Write("> ");

            decimal num1 = 2;
            decimal num2 = 2.5m;
            decimal num3 = 1;
            decimal num4 = 2.5m;

            string input_ = Console.ReadLine();
            Dictionary<string, int> selectedSnacks = new Dictionary<string, int>();

            if (input_.ToUpper() == "A")
            {
                Console.WriteLine("Ponúkame tieto snacky: ");
                Console.WriteLine($"1. Popcorn - {num1}");
                Console.WriteLine($"2. Nachos - {num2}");
                Console.WriteLine($"3. Sladkosti - {num3}");
                Console.WriteLine($"4. Nápoje - Coca Cola, Nestea, Minerálka - {num4}");
                Console.WriteLine($"Zadajte číslo snacku alebo napíšte 'to je všetko'.");

                while (true)
                {
                    Console.Write("> ");
                    string snackChoice = Console.ReadLine();

                    if (snackChoice.ToLower() == "to je všetko")
                    {

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
                            Console.WriteLine("Neplatný výber, skúste znova.");
                            continue;
                    }

                    Console.Write("Zadajte počet kusov: ");
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

                        Console.WriteLine($"{snackName} – pridané {count} ks.");

                    }
                    else
                    {
                        Console.WriteLine("Neplatný počet.");

                    }
                }
            }
            else
            {
                Console.WriteLine("Rozumiem, žiadny snack.");

                Console.WriteLine("\nVybrali ste si tieto snacky:");

                if (selectedSnacks.Count == 0)
                {
                    Console.WriteLine("Žiadne snacky.");
                }
                else
                {
                    foreach (var snack in selectedSnacks)
                    {
                        Console.WriteLine($"- {snack.Key}: {snack.Value} ks");
                    }
                }

                Calculator kalkulacka = new Calculator();
                decimal cenaSnackov = kalkulacka.VypocitajSnacky(selectedSnacks);
                decimal cenaSpolu = kalkulacka.VypocitajSpolu(cenaFilmu, selectedSnacks);

                Console.WriteLine("\n--- REKAPITULÁCIA ---");
                Console.WriteLine("Film: " + selectedMovie);
                Console.WriteLine("Cena filmu: " + cenaFilmu + " €");
                Console.WriteLine("Cena snackov: " + cenaSnackov + " €");
                Console.WriteLine("CELKOM NA ZAPLATENIE: " + cenaSpolu + " €");

                Console.ReadKey();
            }
        }
    }
}