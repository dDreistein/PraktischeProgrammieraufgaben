using System.Globalization;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Wie viele Kilometer möchtest du rennen?");
        int kilometersToRun = Convert.ToInt32(Console.ReadLine());
        if (kilometersToRun > 42)
        {
            Console.WriteLine("Das schaffst du nicht!");
        }
        else
        {

            int n = kilometersToRun * 1000 / 400;

            Console.WriteLine($"Das sind {n} Runden. Bereit für den Lauf?");
            Console.WriteLine("Ja/Nein");
            if (Console.ReadLine() == "Ja")
            {
                for (int i = 1; i <= n; i++)
                {
                    Console.WriteLine($"Du läufst Runde {i}");
                }
                Console.WriteLine("Du hast es geschafft!");
            }
        }
    }
}