using System.Text;

namespace Waldbrand
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            bool runProgram = true;

            Console.WriteLine("Gib die Breite des Waldes an: ");
            int terrainWidth = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Gib die Höhe des Waldes an: ");
            int terrainHeight = Convert.ToInt32(Console.ReadLine());

            int terrainSize = terrainHeight*terrainWidth;

            string[,] terrain = SetupTerrain(terrainWidth, terrainHeight);
            
            DrawTerrain(terrain);

            while(runProgram)
            {
                
                DrawTerrain(terrain);
                string[,] previousTerrain = terrain;
                Thread.Sleep(100); 
            }
        }

        static string[,] SetupTerrain(int width, int height)
        {
            string[,] setupTerrain = new string[width, height];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    setupTerrain[j, i] = RandomTerrainElement();
                }
            }
            return setupTerrain;
        }

        static string Tree()
        {
            return "🌳";
        }

        static string Stone()
        {
            return "🪨";
        }

        static string Ground()
        {
            return "🟫";
        }

        static string RandomTerrainElement()
        {
            int random = new Random().Next(1, 101);

            if (random >= 1 && random <= 50)
            {
                return Tree();
            }
            else if (random >= 51 && random <= 75)
            {
                return Stone();
            }
            else
            {
                return Ground();
            }
        }

        static void DrawTerrain(string[,] terrain)
        {
            StringBuilder terrainString = new StringBuilder();
            
            for (int i = 0; i < terrain.GetLength(1); i++)
            {
                for (int j = 0; j < terrain.GetLength(0); j++)
                {
                    terrainString.Append(terrain[j, i]);
                }
                terrainString.AppendLine();
            }

            Console.Clear();

            Console.Write(terrainString.ToString());
        }

        static void makeParagraph(int num)
        {
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine();
            }
        }

        static void terrainUpdate()
        {

        }
    }
}
