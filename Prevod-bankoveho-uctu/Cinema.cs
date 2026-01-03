
namespace BankAccountTransfer
{
    internal class Cinema
    {
        public void CinemaInfo()
        {
            Console.WriteLine("This is information about the Cinema!");

            string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string fileName = "Cinema - account.txt";
            string filePath = Path.Combine(folder, fileName);

            string text = File.ReadAllText(filePath);
            Console.WriteLine($"Cinema account number - {text}");

            Console.ReadKey();
        }
    }
}