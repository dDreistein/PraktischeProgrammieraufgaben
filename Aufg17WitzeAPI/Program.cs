using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;

namespace Aufg17WitzeAPI
{
    internal class Program
    {
        
        static void Main(string[] args)
        {

            bool exitKeyEntered = false;

            while (!exitKeyEntered)
            {
                Console.WriteLine(GetJokesFromAPI());
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

        static string GetJokesFromAPI()
        {
            WebRequest request = WebRequest.Create("https://witzapi.de/api/joke/");

            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();

            if (responseStream != null)
            {
                string jsonResponse = new StreamReader(responseStream).ReadToEnd();

                JArray array = JArray.Parse(jsonResponse);

                return array[0]["text"].ToString();
            }

            return string.Empty;
        }
    }
}
