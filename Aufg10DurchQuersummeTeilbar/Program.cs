using System.Runtime.InteropServices;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Zahl 1: ");
        string input1 = Console.ReadLine();

        Console.Write("Zahl 2: ");
        string input2 = Console.ReadLine();

        if (int.TryParse(input1, out int zahl1) && int.TryParse(input2, out int zahl2) && zahl1 < zahl2) {
            //Tabellentitel
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Zahl\t| Quersumme\t| Zahl / Quersumme");
            Console.WriteLine("------------------------------------------");

            //Inhalt
            for (int i = zahl1; i <= zahl2; i++){

                //Überprüffen ob die Zahl durch die Quersumme teilbar ist.
                if (i % CalculateCrossSum(i) == 0) {
                    //Inhalt schreiben.
                    Console.Write($"{i}\t| {CalculateCrossSum(i)}\t \t| {i / CalculateCrossSum(i)}");
                    Console.WriteLine();
                }
            }
        }
        else
        {
            //Fehlermeldung bei Ungültiger Eingabe.
            Console.WriteLine("Ungültige Eingabe.");
        }
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