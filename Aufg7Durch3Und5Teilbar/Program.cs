﻿internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Zahlen zwischen 1 und 30, die durch 5 und/oder 3 ohne Rest teilbar sind: ");
        for (int i = 1; i <= 30; i++)
        {
            if (i % 5 == 0 || i % 3 == 0)
            {
                Console.Write($"{i}");
                if (i < 30)
                {
                    Console.Write(", ");
                }
            }
        }
        Console.WriteLine();
    }
}