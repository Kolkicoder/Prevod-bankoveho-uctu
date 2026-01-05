
using System;
using System.IO;

class Cinema
{
    public void ShowInfo()
    {
        Console.WriteLine("Toto sú informácie o kine!");

        string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string fileName = "Cinema - account.txt";
        string filePath = Path.Combine(folder, fileName);

        if (File.Exists(filePath))
        {
            string account = File.ReadAllText(filePath);
            Console.WriteLine("Číslo účtu kina: " + account);
        }
        else
        {
            Console.WriteLine("Súbor s účtom kina neexistuje.");
        }

        Console.WriteLine();
        Console.WriteLine("Stlačte klavesu pre pokračovanie...");
        Console.ReadKey();
    }
}