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
                Console.WriteLine("The file is empty.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Available movies:");
            for (int i = 0; i < movies.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + movies[i]);
            }

            int choice = 0;

            while (true)
            {
                Console.Write("\nSelect a movie number (1 - 20): ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out choice))
                {
                    Console.WriteLine("Invalid movie, please try again.");
                    continue;
                }

                if (choice < 1 || choice > 20)
                {
                    Console.WriteLine("Invalid movie, please try again.");
                    continue;
                }

                break;
            }

            string[] movieData = movies[choice - 1].Split(';');

            string selectedMovie = movieData[0];
            decimal moviePrice = decimal.Parse(movieData[1]);

            Console.WriteLine("You selected the movie: " + selectedMovie);
            Console.WriteLine("Movie price: " + moviePrice + " €");

            Console.WriteLine("If you want, we also offer snacks.");
            Console.WriteLine("Enter 'A' for a snack, or 'N' for no snack.");
            Console.Write("> ");

            decimal price1 = 2;
            decimal price2 = 2.5m;
            decimal price3 = 1;
            decimal price4 = 2.5m;

            string inputSnack = Console.ReadLine();
            Dictionary<string, int> selectedSnacks = new Dictionary<string, int>();

            if (inputSnack.ToUpper() == "A")
            {
                Console.WriteLine("We offer these snacks:");
                Console.WriteLine($"1. Popcorn - {price1}");
                Console.WriteLine($"2. Nachos - {price2}");
                Console.WriteLine($"3. Sweets - {price3}");
                Console.WriteLine($"4. Drinks - Coca Cola, Nestea, Mineral Water - {price4}");
                Console.WriteLine("Enter the snack number or type 'that's all'.");

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
                            snackName = "Sweets";
                            break;
                        case "4":
                            snackName = "Drinks";
                            break;
                        default:
                            Console.WriteLine("Invalid choice, please try again.");
                            continue;
                    }

                    Console.Write("Enter quantity: ");
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

                        Console.WriteLine($"{snackName} – added {count} pcs.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid quantity.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Okay, no snacks.");
            }

            Console.WriteLine("\nYou selected these snacks:");

            if (selectedSnacks.Count == 0)
            {
                Console.WriteLine("No snacks.");
            }
            else
            {
                foreach (var snack in selectedSnacks)
                {
                    Console.WriteLine($"- {snack.Key}: {snack.Value} pcs");
                }
            }

            Calculator calculator = new Calculator();
            decimal snacksPrice = calculator.CalculateSnacks(selectedSnacks);
            decimal totalPrice = calculator.CalculateTotal(moviePrice, selectedSnacks);

            Console.WriteLine("\n--- SUMMARY ---");
            Console.WriteLine("Movie: " + selectedMovie);
            Console.WriteLine("Movie price: " + moviePrice + " €");
            Console.WriteLine("Snacks price: " + snacksPrice + " €");
            Console.WriteLine("TOTAL TO PAY: " + totalPrice + " €");

            Console.ReadKey();
        }
    }
}

