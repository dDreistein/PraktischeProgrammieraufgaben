internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Wie lang soll die Linie sein?");
        Console.Write("Deine Eingabe: ");
        int lineLength = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();
        for (int i = 1; i <= lineLength; i++)
        {
            for (int j = 1; j <= lineLength; j++)
            {
                if (j - i == 0)
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.Write("*");
                }
            }
            Console.WriteLine();
        }
    }
}