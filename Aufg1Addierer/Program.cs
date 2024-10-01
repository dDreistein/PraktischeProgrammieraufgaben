using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufg1Addierer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Die Methode WriteLine() fügt am Ende einen Zeilenumbruch ein
            Console.WriteLine("Dieses Programm berechnet die Summe von zwei Zahlen.");
            Console.WriteLine();
            // Die Methode Write() fügt KEINEN Zeilenumbruch ein
            Console.Write("Zahl 1: ");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Zahl 2: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Summe: {num1 + num2}");

            Console.ReadKey();
        }
    }
}
