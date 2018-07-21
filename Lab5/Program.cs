using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Lab5
{
    class Program
    {
        private const int MAX_FACTORIAL_CALC = 100;
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Welcome to the Factorial Calculator!\n");
                int input = GetFactorialToCalculate();
                try
                {
                    long factorial = CalculateFactorial(input);
                    Console.WriteLine($"The factorial of {input} is {factorial:N}");
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine($"A normal long couldn't handle that calculation. Here's the exception:\n{ex.Message}\n\nBreaking out the big guns. \n");
                    var factorial = CalculateBigFactorial(input);
                    Console.WriteLine($"The factorial of {input} is {factorial:N}");
                }
                
                
                if (!ShouldContinue())
                {
                    break;
                }
            } while (true);
            Console.WriteLine("\nGoodbye!\n");

        }

        private static bool ShouldContinue()
        {
            do
            {
                Console.WriteLine("Would you like to calculate another factorial? y/n");
                var input = char.ToLower(Console.ReadKey().KeyChar);
                if (input != 'y' && input != 'n')
                {
                    continue;
                }

                return input == 'y';
            } while (true);

        }

        private static long CalculateFactorial(int input)
        {
            if (input == 1)
            {
                return input;
            }
            checked
            {
                return input * CalculateFactorial(input-1);
            }
        }

        private static BigInteger CalculateBigFactorial(int input)
        {
            var bigInt = new BigInteger(input);
            if (input == 1)
            {
                return input;
            }

            return input * CalculateBigFactorial(input-1);
        }

        private static int GetFactorialToCalculate()
        {
            do
            {
                Console.WriteLine($"Please enter an integer between 1 and {MAX_FACTORIAL_CALC}:");
                var input = Console.ReadLine();
                if (int.TryParse(input, out var inputAsInt) && inputAsInt >=1 && inputAsInt <= MAX_FACTORIAL_CALC)
                {
                    return inputAsInt;

                }
                else
                {
                    Console.WriteLine($"That is not a integer.\n");
                    continue;
                }
            } while (true);
        }
    }
}
