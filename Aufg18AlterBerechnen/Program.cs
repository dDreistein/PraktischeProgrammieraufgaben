using System.ComponentModel;

namespace Aufg18AlterBerechnen
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Bitte gib ein Geburtsdatum ein [DD.MM.YYYY]: ");
            string input = Console.ReadLine();

            if (DateTime.TryParse(input, out DateTime dateOfBirth))
            {
                TimeSpan age = DateTime.Today - dateOfBirth;

                int ageInYears = Convert.ToInt32(age.TotalDays / 365.2425);
                int ageInMonths = Convert.ToInt32(age.TotalDays / 30.4583);
                int ageInWeeks = Convert.ToInt32(age.TotalDays / 7);
                int ageInDays = Convert.ToInt32(age.TotalDays);

                Console.WriteLine($"Alter in Jahren: {ageInYears}");
                Console.WriteLine($"Alter in Monaten: {ageInMonths}");
                Console.WriteLine($"Alter in Wochen: {ageInWeeks}");
                Console.WriteLine($"Alter in Tagen: {ageInDays}");
            }
            else
            {
                Console.WriteLine("Bitte gib das Geburtsdatum in einem Gültigen format an [DD.MM.YYYY]: ");
            }
        }
    }
}
