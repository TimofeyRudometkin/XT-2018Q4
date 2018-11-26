using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1.Simple
{
    class Program
    {
        private static void Task0_2(int N)
        {
            int TheNumberOfTheDivisionsWithoutRemainder = 0;

            for (int i = 1; i <= N; i++)
            {
                if ((N % i) == 0)
                {
                    TheNumberOfTheDivisionsWithoutRemainder = TheNumberOfTheDivisionsWithoutRemainder + 1;
                }
            }
            if (TheNumberOfTheDivisionsWithoutRemainder > 2)
            {
                Console.WriteLine("The number entered is not a Prime.");
            }
            else
            {
                Console.WriteLine("The number entered is a Prime.");
            }

            Console.WriteLine("Enter a positive integer to continue, '0' or a negative number to exit the program.");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a positive integer to continue, '0' or a negative number to exit the program.");

            while (true)
            {
                try
                {
                    int NumberToCheck = int.Parse(Console.ReadLine());

                    if (NumberToCheck <= 0)
                    {
                        break;
                    }
                    Task0_2(NumberToCheck);
                }
                catch (FormatException)
                {
                    Console.WriteLine("You have entered a string that is not a positive integer, repeat the input " +
                        "of a positive integer, '0', or a negative number to exit the program.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("The number entered is large for me, enter a number less.");
                }
            }
        }
    }
}
