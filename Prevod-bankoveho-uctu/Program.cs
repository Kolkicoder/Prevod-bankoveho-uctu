using BankAccountTransfer;
using System;

class Program
{
    static void Main()
    {        
        Cinema cinema = new Cinema();
        cinema.ShowInfo();
                
        User user = new User();
        user.Run();
                
        Movies movies = new Movies();
        movies.Run();
                
        Pad pad = new Pad();
        pad.PrintReceipt();

        Console.SetCursorPosition(36, 30);
        Console.WriteLine("\nĎakujeme za návštevu kina!");
        Console.ReadKey();
    }
}