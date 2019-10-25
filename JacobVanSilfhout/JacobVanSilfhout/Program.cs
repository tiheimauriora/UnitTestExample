/*
 * Developer: Jacob Van Silfhout
 * Purpose: Unit tests for converter application
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JacobVanSilfhout
{
    class Program
    {
        static void Main(string[] args)
        {
            bool extLoop = true;
            bool intLoop = true;
            double result;
            Converter c1 = new Converter();

            do
            {
                /*Obtain value*/
                DisplayHeading();
                Console.Write("Please enter your value to convert: ");
                intLoop = double.TryParse(Console.ReadLine(), out result);
                while (!intLoop)
                {
                    ErrorMsg();
                    Console.Write("Please enter your value to convert: ");
                    intLoop = double.TryParse(Console.ReadLine(), out result);
                }
                c1.ConVal = result;

                /*Obtain the users value units*/
                DisplayHeading();
                Console.WriteLine($"Current Value: {result}\n");
                DisplayUnits();
                Console.Write("\nPlease enter the values units: ");
                c1.Units = Console.ReadLine();

                Console.Write("What would you like to convert to: ");
                c1.ConTo = Console.ReadLine();

                if (c1.ValidConversion())
                {
                    Console.WriteLine($"{c1.ConVal}{c1.Units} converted to {c1.ConTo} is {c1.Conversion()}{c1.ConTo}\nPress ENTER to continue...");
                    Console.ReadLine();
                }
                else
                {
                    ErrorMsg();
                    Console.ReadLine();
                }
            } while (extLoop);
        }

        static void DisplayHeading()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("*****************************************************\n**************** ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Bluelab Application");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" ****************\n*****************************************************\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void ErrorMsg()
        {
            DisplayHeading();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nThere was an issue with your input, please try again.");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void DisplayUnits()
        {
            foreach (KeyValuePair<string, string> x in Converter.supported)
            {
                Console.WriteLine($"Enter ({x.Key}) for {x.Value}");
            }
        }
    }
}
