namespace Aufg14Tannenbaum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Breite des Stammes: ");
            string input1 = Console.ReadLine();

            Console.Write("Höhe des Stammes: ");
            string input2 = Console.ReadLine();

            Console.Write("Höhe der Krone: ");
            string input3 = Console.ReadLine();

            if (int.TryParse(input1, out int trunkThickness) && int.TryParse(input2, out int trunkHeight) && int.TryParse(input3, out int crownHeight) && trunkThickness % 2 == 1)
            {
                DrawCrown(crownHeight);
                DrawTrunk(trunkThickness, trunkHeight, crownHeight);
            }
            else
            {
                Console.WriteLine("Ungültige eingabe.");
            }
        }

        static void DrawCrown(int crownHeight)
        {
            for (int i = 1; i <= crownHeight; i++)
            {
                for (int j = crownHeight - i; j >= 1; j--)
                {
                    Console.Write(" ");

                }
                for (int k = 1; k <= 2 * i - 1; k++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();

            }
        }

        static void DrawTrunk(int trunkThickness, int trunkHeight, int crownHeight)
        {
            int trunkCentered = crownHeight - 1 - (trunkThickness / 2);
            for (int i = 1; i <= trunkHeight; i++)
            {
                for (int j = 1; j <= trunkCentered; j++)
                {
                    Console.Write(" ");
                }
                for (int k = 1; k <= trunkThickness; k++)
                {
                    Console.Write("|");
                }
                Console.WriteLine();
            }
        }
    }
}
