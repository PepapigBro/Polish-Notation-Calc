using PolishCalcLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Введите выражение (e - exit)");
                string userInput = Console.ReadLine();

                //Пользовательсикй ввод, "- * / 15 - 7 + 1 1 3 + 2 + 1 1"
                //  -*/15- 7 2 3 + 2 2
                //  -*/15 5 3 4
                //   -* 3 3 4
                //   -9 4
                //   5
                if (userInput == "e") { break; }

                PolishCalc polishcalc = new PolishCalc(userInput);
                double? result = polishcalc.Calculate();

                if (result !=null)
                {
                    Console.WriteLine("Result: {0}", result);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
        }
    }
}
