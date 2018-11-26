using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1.Sequence
{
    class Program
    {
        private static void Task0_1(int N)
        {
            Console.Write(1);

            for (int i = 2; i <= N; i++)
            {
                Console.Write(", " + i);
            }

            Console.WriteLine();
            Console.WriteLine("Enter a positive number to continue, '0' or a negative number to exit the program.");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a positive number to continue, '0' or a negative number to exit the program.");

            while (true)
            {
                try
                {
                    int NumberToCheck = int.Parse(Console.ReadLine());

                    if (NumberToCheck <= 0)
                    {
                        break;
                    }
                    Task0_1(NumberToCheck);
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
