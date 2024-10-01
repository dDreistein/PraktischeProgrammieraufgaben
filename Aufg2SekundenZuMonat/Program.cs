using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufg2SekundenZuMonat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Berechnung von Sekunden eines Monats in Abhängigkeit seiner Anzahl Tage");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("Wieviele Tage hat der Monat, für den Sie die Sekundenzahl berechnen wollen");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int daysOfMonth) == true)
            {
                if (daysOfMonth < 32)
                {
                    Console.WriteLine($"Ein Monat mit {daysOfMonth} tagen hat {86400 * daysOfMonth} Sekunden.");
                }
                else
                {
                    Console.WriteLine($"Ungültige Eingabe. Ein Monat mit {daysOfMonth} Tagen gibt es nicht.");
                }
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe. Bitte verwenden Sie Ganzzahlen.");
            }
            Console.ReadKey();
        }
    }
}
