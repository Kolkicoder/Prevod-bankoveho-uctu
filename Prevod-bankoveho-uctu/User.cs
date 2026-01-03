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
                Console.WriteLine("The file is empty.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Available bank accounts:");
            for (int i = 0; i < accounts.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + accounts[i]);
            }

            int choice = 0;

            while (true)
            {
                Console.WriteLine("\nSelect an account number (1 - 5): ");
                Console.Write("> ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out choice))
                {
                    Console.WriteLine("Invalid account, please try again.");
                    continue;
                }

                if (choice < 1 || choice > 5)
                {
                    Console.WriteLine("Invalid account, please try again.");
                    continue;
                }

                break;
            }

            string selectedAccount = accounts[choice - 1];
            Console.WriteLine("You selected account: " + selectedAccount);

            Console.WriteLine("Enter CVC: ");
            Console.Write("> ");
            string cvc = Console.ReadLine();

            Console.WriteLine("Enter account balance (EUR): ");
            Console.Write("> ");
            string balanceText = Console.ReadLine();

            Console.WriteLine("Enter e-mail: ");
            Console.Write("> ");
            string email = Console.ReadLine();

            if (cvc == "" || balanceText == "" || email == "")
            {
                Console.WriteLine("You must fill in all information.");
                Console.ReadKey();
                return;
            }

            if (!double.TryParse(balanceText, out double balance))
            {
                Console.WriteLine("Balance must be a number.");
                Console.ReadKey();
                return;
            }

            List<string> record = new List<string>();
            record.Add("----- USER INFORMATION -----");
            record.Add("Account: " + selectedAccount);
            record.Add("CVC: " + cvc);
            record.Add("Account balance: " + balance + " EUR");
            record.Add("E-mail: " + email);
            record.Add("Date: " + DateTime.Now);
            record.Add("");

            File.AppendAllLines(outputFile, record);

            Console.WriteLine("\nInformation has been saved.");

            while (true)
            {
                Console.WriteLine("\nType 'my info' to display information or 'esc' to exit.");
                Console.Write("> ");

                string command = Console.ReadLine().ToLower();

                if (command == "my info")
                {
                    if (File.Exists(outputFile))
                    {
                        Console.WriteLine("\n--- SAVED INFORMATION ---");
                        string[] data = File.ReadAllLines(outputFile);
                        foreach (var line in data)
                        {
                            Console.WriteLine(line);
                        }
                    }
                    else
                    {
                        Console.WriteLine("The data file does not exist.");
                    }
                    break;
                }
                else if (command == "esc")
                {
                    Console.WriteLine("Program terminated.");
                    break;
                }
                else
                {
                    Console.WriteLine("Unknown command, please try again.");
                }
            }

            Console.ReadKey();
        }
    }
}
