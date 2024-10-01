namespace Aufg15ZahlenRaten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exitKeyEntered = false;

            while (!exitKeyEntered)
            {
                //Variablen zurücksetzen
                bool solved = false;
                int trys = 1;

                int randomNumber = Random.Shared.Next(2, 101);

                Console.WriteLine("Errate deine Zahl zwischen 1 und 100: ");

                //Überprüffen ob das Rätzel gelöst ist.
                while (!solved) {
                    if (int.TryParse(Console.ReadLine(), out int guess) && guess <= 100) {
                        //Versuch Auswerten.
                        if (guess > randomNumber)
                        {
                            Console.WriteLine("Zahl ist zu Gross! Nächster Versuch: ");
                        }
                        else if (guess < randomNumber)
                        {
                            Console.WriteLine("Zahl ist zu Klein! Nächster Versuch: ");
                        }
                        else
                        {
                            Console.WriteLine($"Die Zahl stimmt! Du hast {trys} Versuche benötigt. Noch einmal Spielen? [y/n]");

                            
                            if (Console.ReadLine() == "y") 
                            {
                                exitKeyEntered = false;
                            }
                            else
                            {
                                exitKeyEntered = true;
                            }
                            
                            solved = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ungültige Eingabe. Nächster Versuch: ");
                    }
                    trys++;
                }
                Console.Clear();

            }
        }
    }
}
