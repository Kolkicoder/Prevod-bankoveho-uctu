using System;
using System.IO;

class User
{
    public void Run()
    {
        string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string inputFile = Path.Combine(folder, "user_accounts.txt");
        string outputFile = Path.Combine(folder, "user_info.txt");

        if (!File.Exists(inputFile))
        {
            Console.WriteLine("Súbor s účtami používateľov neexistuje.");
            return;
        }

        string[] accounts = File.ReadAllLines(inputFile);

        Console.WriteLine("Dostupné účty:");
        for (int i = 0; i < accounts.Length; i++)
        {
            Console.WriteLine((i + 1) + ". " + accounts[i]);
        }

        int choice = 0;
        while (true)
        {
            Console.Write("Vyber číslo účtu: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out choice) && choice >= 1 && choice <= accounts.Length)
                break;
            Console.WriteLine("Neplatný výber, skúste znova.");
        }

        string selectedAccount = accounts[choice - 1];

        Console.Write("Zadajte CVC: ");
        string cvc = Console.ReadLine();

        Console.Write("Zadajte zostatok na účte (EUR): ");
        string balanceText = Console.ReadLine();

        Console.Write("Zadajte e-mail: ");
        string email = Console.ReadLine();

        if (cvc == "" || balanceText == "" || email == "")
        {
            Console.WriteLine("Musíte vyplniť všetky údaje.");
            return;
        }

        double balance = 0;
        if (!double.TryParse(balanceText, out balance))
        {
            Console.WriteLine("Zostatok musí byť číslo.");
            return;
        }

        string[] record = {
            "----- INFORMÁCIE O POUŽÍVATEĽOVI -----",
            "Účet: " + selectedAccount,
            "CVC: " + cvc,
            "Zostatok: " + balance + " EUR",
            "E-mail: " + email,
            "Dátum: " + DateTime.Now,
            ""
        };

        File.AppendAllLines(outputFile, record);
        Console.WriteLine("Informácie boli uložené.\n");
    }
}
