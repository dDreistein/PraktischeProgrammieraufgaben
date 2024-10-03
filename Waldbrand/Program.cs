using System.Text;

namespace Waldbrand
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            bool runProgram = true;

            bool doNewUpdate = true;

            Console.WriteLine("Funkenzündung (‰): ");
            int sparkIgnition = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Wachstum: ");
            int growth = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Gib die Breite des Waldes an: ");
            int terrainWidth = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Gib die Höhe des Waldes an: ");
            int terrainHeight = Convert.ToInt32(Console.ReadLine());

            
            int terrainSize = terrainHeight*terrainWidth;
            
            string[,] terrain = SetupTerrain(terrainWidth, terrainHeight);

            string[,] prevTerrain = terrain;

            while(runProgram)
            {
                //Verhindert.dass die Methode mehreremals in einem frame aufgeruffen wird.
                if (doNewUpdate)
                { 
                    doNewUpdate = false;

                    //Console.ReadKey();
                    DrawTerrain(prevTerrain);

                    //Den vorherigen frame speichern
                    prevTerrain = terrain;

                    
                    doNewUpdate = terrainUpdate(terrain, prevTerrain, terrainWidth, terrainHeight, terrainSize, sparkIgnition);

                    //Den vorgang pausieren.
                    Thread.Sleep(500);
                    Console.ReadKey();
                }
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

        static string Fire()
        {
            return "🔥";
        }

        static string Embers()
        {
            return "🔺";
        }

        //Random zahl zwischen ... und ...
        static int RandomBtw(int min,  int max)
        {
            return new Random().Next(min, max + 1);
        }

        static string RandomTerrainElement()
        {
            int random = RandomBtw(1, 100);

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
            StringBuilder terrainStringBuilder = new StringBuilder();
            
            for (int i = 0; i < terrain.GetLength(1); i++)
            {
                for (int j = 0; j < terrain.GetLength(0); j++)
                {
                    terrainStringBuilder.Append(terrain[j, i]);
                }
                terrainStringBuilder.AppendLine();
            }
            string terrainString = terrainStringBuilder.ToString();
            //Console.Clear();
            makeParagraph(1);
            Console.Write(terrainString);
        }

        static void makeParagraph(int num)
        {
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine();
            }
        }

        static bool terrainUpdate(string[,] terrain, string[,] prevTerrain, int terrainWidth, int terrainHeight, int w, int z)
        {
            for (int i = 0; i < terrainHeight; i++)
            {
                for (int j = 0; j < terrainWidth; j++)
                {
                    if (prevTerrain[j, i] == Tree())
                    {
                        terrain[j, i] = treeUpdate(prevTerrain, j, i, terrainWidth, terrainHeight, z);
                    }
                    else if(prevTerrain[j, i] == Fire())
                    {
                        z = 0;
                    }
                }
            }
            Console.WriteLine("Update.");
            return true;
        }

        static string treeUpdate(string[,] prevTerrain, int x, int y, int terrainWidth, int terrainHeight, int z)
        {
            if (RandomBtw(1, 1000) <= z)
            {
                return Fire();
            }
            else if (AreSurroundElements(Fire(), prevTerrain, x, y, terrainWidth, terrainHeight))
            {
                return Fire();
            }
            else
            {
                return Tree();
            }
            
        }

        static bool AreSurroundElements(string element, string[,] prevTerrain, int x, int y, int terrainWidth, int terrainHeight)
        {
            int minX = 0;
            int minY = 0;
            int maxX = terrainWidth - 1;
            int maxY = terrainHeight - 1;

            if (x > minX && y > minY && prevTerrain[x - 1, y - 1] == element)
            {
                return true;
            }
            if (y > minY && prevTerrain[x, y - 1] == element)
            {
                return true;
            }
            if(x < maxX && y > minY && prevTerrain[x + 1, y - 1] == element)
            {
                return true;
            }
            if (x < maxX && prevTerrain[x + 1, y] == element)
            {
                return true;
            }
            if (x < maxX && y < maxY && prevTerrain[x + 1, y + 1] == element)
            {
                return true;
            }
            if (y < maxY && prevTerrain[x, y + 1] == element)
            {
                return true;
            }
            if (y < maxY && prevTerrain[x, y + 1] == element)
            {
                return true;
            }
            if (x > minX && y < maxY && prevTerrain[x - 1, y + 1] == element)
            {
                return true;
            }
            if (x > minX && prevTerrain[x - 1, y] == element)
            {
                return true; 
            }
            return false;
        }
    }
}
