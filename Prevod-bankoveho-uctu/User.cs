using System;
using System.Collections.Generic;
using System.IO;

namespace Prevod_bankoveho_uctu
{
    internal class User
    {
        public void Main()
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string inputFileName = "uzivatelske ucty.txt";
            string outputFileName = "info. o uzivatelovi.txt";

            string inputFile = Path.Combine(folder, inputFileName);
            string outputFile = Path.Combine(folder, outputFileName);

            string[] accounts = File.ReadAllLines(inputFile);

            if (accounts.Length == 0)
            {
                Console.WriteLine("Súbor je prázdny.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Dostupné bankové účty:");
            for (int i = 0; i < accounts.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + accounts[i]);
            }

            int choice = 0;

            while (true)
            {
                Console.WriteLine("\nVyberte číslo účtu (1 - 5): ");
                Console.Write("> ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out choice))
                {
                    Console.WriteLine("Nesprávny účet, skús to znova.");
                    continue;
                }

                if (choice < 1 || choice > 5)
                {
                    Console.WriteLine("Nesprávny účet, skús to znova.");
                    continue;
                }

                break;
            }

            string selectedAccount = accounts[choice - 1];
            Console.WriteLine("Vybrali ste účet: " + selectedAccount);

            Console.WriteLine("Zadajte CVC: ");
            Console.Write("> ");
            string cvc = Console.ReadLine();

            Console.WriteLine("Zadajte zostatok na účte (EUR): ");
            Console.Write("> ");
            string balanceText = Console.ReadLine();

            Console.WriteLine("Zadajte e-mail: ");
            Console.Write("> ");
            string email = Console.ReadLine();

            if (cvc == "" || balanceText == "" || email == "")
            {
                Console.WriteLine("Musíte vyplniť všetky údaje.");
                Console.ReadKey();
                return;
            }

            double balance;
            if (!double.TryParse(balanceText, out balance))
            {
                Console.WriteLine("Zostatok musí byť číslo.");
                Console.ReadKey();
                return;
            }

            List<string> zapis = new List<string>();
            zapis.Add("----- ÚDAJE O POUŽÍVATEĽOVI -----");
            zapis.Add("Účet: " + selectedAccount);
            zapis.Add("CVC: " + cvc);
            zapis.Add("Zostatok na účte: " + balance + " EUR");
            zapis.Add("E-mail: " + email);
            zapis.Add("Dátum: " + DateTime.Now);
            zapis.Add("");

            File.AppendAllLines(outputFile, zapis);

            Console.WriteLine("\nÚdaje boli uložené.");

            while (true)
            {
                Console.WriteLine("\nNapíšte 'moje udaje' pre zobrazenie údajov alebo 'esc' pre ukončenie.");
                Console.Write("> ");

                string prikaz = Console.ReadLine();
                string prikaz1 = prikaz.ToLower();

                if (prikaz1 == "moje udaje")
                {
                    if (File.Exists(outputFile))
                    {
                        Console.WriteLine("\n--- ULOŽENÉ ÚDAJE ---");
                        string[] data = File.ReadAllLines(outputFile);
                        for (int i = 0; i < data.Length; i++)
                        {
                            Console.WriteLine(data[i]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Súbor s údajmi neexistuje.");
                    }
                    break;
                }
                else if (prikaz == "esc")
                {
                    Console.WriteLine("Program bol ukončený.");
                    break;
                }
                else
                {
                    Console.WriteLine("Neznámy príkaz, skúste znova.");
                }
            }

            Console.ReadKey();
        }
    }
}