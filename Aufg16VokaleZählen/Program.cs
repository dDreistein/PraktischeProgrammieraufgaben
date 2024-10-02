namespace Aufg16VokaleZählen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] vocals = { 'a', 'e', 'i', 'o', 'u', 'ä', 'ö', 'ü' };

            Console.WriteLine("Deine Eingabe: ");
            string input = Console.ReadLine().ToLower();

            for (int i = 0; i < vocals.Length; i++)
            {
                if (input.Contains(vocals[i]))
                {
                    Console.WriteLine($"Der Buchstabe '{vocals[i]}' kommt {CountLetter(input, vocals[i])} mal vor.");
                }
            }
        }

        static int CountLetter(string input, char toFind)
        {
            return input.Count(t  => t == toFind);
        }
    }
}