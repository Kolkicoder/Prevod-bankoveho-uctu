using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Channels;

namespace BankAccountTransfer
{
    internal class User
    {
        public void Main()
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string inputFileName = "user_accounts.txt";
            string outputFileName = "user_info.txt";

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
                    Console.WriteLine("Neplatný účet, skúste znova.");
                    continue;
                }

                if (choice < 1 || choice > 5)
                {
                    Console.WriteLine("Neplatný účet, skúste znova.");
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

            if (!double.TryParse(balanceText, out double balance))
            {
                Console.WriteLine("Zostatok musí byť číslo.");
                Console.ReadKey();
                return;
            }

            List<string> record = new List<string>();
            record.Add("----- INFORMÁCIE O POUŽÍVATEĽOVI -----");
            record.Add("Účet: " + selectedAccount);
            record.Add("CVC: " + cvc);
            record.Add("Zostatok na účte: " + balance + " EUR");
            record.Add("E-mail: " + email);
            record.Add("Dátum: " + DateTime.Now);
            record.Add("");

            File.AppendAllLines(outputFile, record);

            Console.WriteLine("\nInformácie boli uložené.");

            while (true)
            {
                Console.WriteLine("\nNapíšte 'moje info' pre zobrazenie údajov alebo 'esc' pre ukončenie.");
                Console.Write("> ");

                string command = Console.ReadLine().ToLower();

                if (command == "moje info")
                {
                    if (File.Exists(outputFile))
                    {
                        Console.WriteLine("\n--- ULOŽENÉ INFORMÁCIE ---");
                        string[] data = File.ReadAllLines(outputFile);
                        foreach (var line in data)
                        {
                            Console.WriteLine(line);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Súbor s údajmi neexistuje.");
                    }
                    break;
                }
                else if (command == "esc")
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
