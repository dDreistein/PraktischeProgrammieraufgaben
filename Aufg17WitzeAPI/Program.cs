namespace Aufg17WitzeAPI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exitKeyEntered = false;

            while (!exitKeyEntered)
            {
                Console.WriteLine("...");
                makeParagraph(1);
                Console.Write("Nächsten Witz holen? [y/n] ");
                exitKeyEntered = detectExitKey();
                makeParagraph(2);
            }
        }

        static bool detectExitKey()
        {
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                return false;
            }
            else 
            { 
                return true;
            }
        }

        static void makeParagraph(int num)
        {
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine();
            }
        }
    }
}
