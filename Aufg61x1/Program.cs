internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("-----------");
        Console.WriteLine("Kleines 1x1");
        Console.WriteLine("-----------");
        Console.WriteLine();
        for (int i = 1; i <= 10; i++)
        {
            int factor1 = i;
            for (int i2 = 1; i2 <= 10; i2++)
            {
                int factor2 = i2;
                Console.Write(factor1 * factor2 + "\t");
            }
            Console.WriteLine();
        }
    }
}