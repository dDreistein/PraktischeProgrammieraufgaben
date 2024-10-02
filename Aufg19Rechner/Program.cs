using System.Net.Security;
using System.Runtime.InteropServices;

namespace Aufg19Rechner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exitKeyEntered = false;

            while (!exitKeyEntered)
            {
                Console.WriteLine("Make your calculation (or enter Q to quit): ");
                string input = Console.ReadLine();
                if (input.Contains("+") || input.Contains("-") || input.Contains("/") || input.Contains("*"))
                {
                    Console.WriteLine(DoBasicOperations(input));
                    makeParagraph(1);
                }
                else if (input.ToLower() == "q")
                {
                    exitKeyEntered = true;
                }
                else
                {
                    Console.WriteLine("Input must contain +, -, / or *.");
                    makeParagraph(1);
                }
            }
        }

        static string DoBasicOperations(string input)
        {
            if (input.Contains("+"))
            {
                string[] inputArray = input.Split("+");
                if (int.TryParse(inputArray[0], out int num1) && int.TryParse(inputArray[1], out int num2))
                {
                    return Convert.ToString(num1 + num2);
                } 
                else
                {
                    return "Invalid Input.";
                }
            }
            else if (input.Contains("-"))
            {
                string[] inputArray = input.Split("-");
                if (int.TryParse(inputArray[0], out int num1) && int.TryParse(inputArray[1], out int num2))
                {
                    return Convert.ToString(num1 - num2);
                }
                else
                {
                    return "Invalid Input.";
                }
            }
            else if (input.Contains("/"))
            {
                string[] inputArray = input.Split("/");
                if (int.TryParse(inputArray[0], out int num1) && int.TryParse(inputArray[1], out int num2))
                {
                    return Convert.ToString(num1 / num2);
                }
                else
                {
                    return "Invalid Input.";
                }
            }
            else if (input.Contains("*"))
            {
                string[] inputArray = input.Split("*");
                if (int.TryParse(inputArray[0], out int num1) && int.TryParse(inputArray[1], out int num2))
                {
                    if (num2 != 0)
                    {
                        return Convert.ToString(num1 * num2);
                    }
                    else
                    {
                        return "Can't divide by 0.";
                    }
                }
                else
                {
                    return "Invalid Input.";
                }
            }
            else
            {
                return "Error.";
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
