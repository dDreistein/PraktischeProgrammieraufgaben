internal class Program
{
    private static void Main(string[] args)
    {
        //Monatsnamen in String speichern.
        string[] monthNames = { "Januar", "Februar", "März", "April", "May", "Juni", "Juli", "August", "September", "Oktober", "November", "Dezember" };

        Console.Write("Monat (Zahl): ");
        string input = Console.ReadLine();
        //Ungültige eingaben Filtern
        if (input == null || !int.TryParse(input, out int monthInNumber) || monthInNumber > 12)
        {
            Console.WriteLine("Ungültige Eingabe");
        }
        else
        {
            //Monatsname ausgeben.
            Console.WriteLine($"Monat (Name): {monthNames[monthInNumber - 1]}");
        }
    }
}