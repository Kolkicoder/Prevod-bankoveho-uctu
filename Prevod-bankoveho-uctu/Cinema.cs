
namespace BankAccountTransfer
{
    internal class Cinema
    {
        public void CinemaInfo()
        {
            Console.WriteLine("Toto sú informácie o kine!");

            string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fileName = "Cinema - account.txt";
            string filePath = Path.Combine(folder, fileName);

            string text = File.ReadAllText(filePath);
            Console.WriteLine($"Číslo účtu kina - {text}");

            Console.ReadKey();
        }
    }
}