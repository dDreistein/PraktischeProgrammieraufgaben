using System.Text;

namespace Waldbrand
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            bool doNewUpdate = true;

            Console.WriteLine("Funkenzündung (‰): ");
            //int sparkIgnition = Convert.ToInt32(Console.ReadLine());
            string input1 = Console.ReadLine();

            Console.WriteLine("Wachstum (%): ");
            //int growth = Convert.ToInt32(Console.ReadLine());
            string input2 = Console.ReadLine();

            Console.WriteLine("Breite: ");
            //int terrainWidth = Convert.ToInt32(Console.ReadLine());
            string input3 = Console.ReadLine();

            Console.WriteLine("Höhe: ");
            //int terrainHeight = Convert.ToInt32(Console.ReadLine());
            string input4 = Console.ReadLine();

            Console.WriteLine("Frames pro Minute: ");
            string input5 = Console.ReadLine();



            if (int.TryParse(input1, out int sparkIgnition) && int.TryParse(input2, out int growth) &&
                int.TryParse(input3, out int terrainWidth) && int.TryParse(input4, out int terrainHeight) && 
                int.TryParse(input5, out int framesPerMin) && terrainWidth <= 50 && terrainHeight <= 50)
            {
                string[,] terrain = SetupTerrain(terrainWidth, terrainHeight);
                string[,] prevTerrain = DeepCopy(terrain);

                while (true)
                {
                    //Verhindert.dass die Methode mehreremals in einem frame aufgeruffen wird.
                    if (doNewUpdate)
                    {
                        doNewUpdate = false;
                        //Debuging
                        //Console.WriteLine("doNewUpdate set to False.");

                        DrawTerrain(prevTerrain);

                        //Den vorgang pausieren.
                        Thread.Sleep(60000/framesPerMin);
                        //Console.ReadKey();

                        doNewUpdate = terrainUpdate(terrain, prevTerrain, terrainWidth, terrainHeight, growth, sparkIgnition);
                        if (doNewUpdate)
                        {
                            //Den vorherigen frame speichern
                            prevTerrain = DeepCopy(terrain);
                            //Debuging
                            //Console.WriteLine("prevTerrain set to Terrain");
                        }
                    }
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo key = Console.ReadKey(true);
                        break;
                    }
                }
            }
            else 
            {
                Console.WriteLine("Ungültige Eingabe: Nur in Ganzzahlen schreiben und Wald nicht grösser als 50x50");
            }
        }

        static string[,] DeepCopy(string[,] input)
        {
            string[,] deepCopy = new string[input.GetLength(0), input.GetLength(1)];

            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    deepCopy[i, j] = input[i, j]; // Copy each element
                }
            }
            return deepCopy;
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
            Console.Clear();
            Console.Write(terrainString);
            Console.WriteLine("Um zu beenden, drücke eine beliebige Taste");
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
                    else if (prevTerrain[j, i] == Fire())
                    {
                        terrain[j, i] = Embers();
                    }
                    else if (prevTerrain[j, i] == Embers())
                    {
                        terrain[j, i] = Ground();
                    }
                    else if (terrain[j, i] == Ground())
                    {
                        terrain[j, i] = GroundUpdate(w);
                    }
                    
                    //Debuging:
                    //Console.WriteLine($"Single Update for {j}, {i}.");
                }
            }
            //Debuging:
            //Console.WriteLine("Update.");
            return true;
        }

        static string treeUpdate(string[,] prevTerrain, int x, int y, int terrainWidth, int terrainHeight, int z)
        {
            if (AreSurroundElements(Fire(), prevTerrain, x, y, terrainWidth, terrainHeight))
            {
                return Fire();
            }else if (RandomBtw(1, 1000) <= z)
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
            else if (y > minY && prevTerrain[x, y - 1] == element)
            {
                return true;
            }
            else if(x < maxX && y > minY && prevTerrain[x + 1, y - 1] == element)
            {
                return true;
            }
            else if (x < maxX && prevTerrain[x + 1, y] == element)
            {
                return true;
            }
            else if (x < maxX && y < maxY && prevTerrain[x + 1, y + 1] == element)
            {
                return true;
            }
            else if (y < maxY && prevTerrain[x, y + 1] == element)
            {
                return true;
            }
            else if (x > minX && y < maxY && prevTerrain[x - 1, y + 1] == element)
            {
                return true;
            }
            else if (x > minX && prevTerrain[x - 1, y] == element)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static string GroundUpdate(int w)
        {
            if (RandomBtw(1, 100) <= w)
            {
                return Tree();
            }
            else
            {
                return Ground();
            }
        }
    }
}
