using System.ComponentModel.Design;

internal class Program
{
    private static void Main(string[] args)
    {
        bool exitKeyEntered = false;
        bool leapYear;
        Console.WriteLine("Schaltjahr Prüfer");
        Console.WriteLine("*****************");
        while (!exitKeyEntered)
        {
            //Eingabe
            Console.WriteLine();
            Console.Write("Eingabe Jahr (q to quit): ");
            
            string input = Console.ReadLine();

            Console.WriteLine();
            //Verarbeitung
            if (input.ToLower() != "q")
            {
                if (int.TryParse(input, out int year))
                {
                    if (year % 100 == 0)
                    {
                        if (year % 400 == 0)
                        {
                            leapYear = true;
                        } 
                        else
                        {
                            leapYear = false;
                        }
                        
                    }
                    else if (year % 4 != 0)
                    {
                        leapYear = false;
                    }
                    else
                    {
                        leapYear=true;
                    }

                    //Ausgabe
                    if (leapYear)
                    {
                        Console.WriteLine($"Das Jahr {year} ist ein Schaltjahr.");
                    }
                    else
                    {
                        Console.WriteLine($"Das Jahr {year} ist KEIN Schaltjahr.");
                    }

                }
                else
                {
                    Console.WriteLine("Ungültige Eingabe");
                }
            } else {
                exitKeyEntered = true;
            }
        }
    }
}