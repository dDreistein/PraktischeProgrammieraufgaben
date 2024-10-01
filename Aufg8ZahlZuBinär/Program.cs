internal class Program
{
    private static void Main(string[] args)
    {
        bool exitKeyEntered = false;
        while (!exitKeyEntered)
        {
            Console.WriteLine("Ganzzahlige Dezimalzahl (q to Quit):");
            string input = Console.ReadLine();

            if (input.ToLower() != "q")
            {
                int zahl = Convert.ToInt32(input);
                string bin = Convert.ToString(zahl, 2);
                Console.WriteLine($"Binär: {bin}");
                Console.WriteLine();
            }
            else
            {
                exitKeyEntered = true;
            }
        }
    }
}