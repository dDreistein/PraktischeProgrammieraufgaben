
internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Zahl: ");
        int zahl = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"Die Quersumme von {zahl} ist: {CalculateCrossSum(zahl)}");
    }

    static int CalculateCrossSum(int zahl)
    {
        int crossSum = 0;
        while (zahl != 0)
        {
            crossSum += (zahl % 10);
            zahl /= 10;
        }
        return crossSum;
    }
}