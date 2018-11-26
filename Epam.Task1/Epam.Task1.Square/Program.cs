using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1.Square
{
    class Program
    {
        private static void Task0_3(int N)
        {
            if (N % 2 == 0)
            {
                Console.WriteLine("An even number is entered, the center is shifted up and left.");
            }

            for (int TheWidthOfTheSquare = 1; TheWidthOfTheSquare <= N; TheWidthOfTheSquare++)
            {
                for (int TheHeightOfTheSquare = 1; TheHeightOfTheSquare <= N; TheHeightOfTheSquare++)
                {
                    if ((TheHeightOfTheSquare == ((N + 1) / 2)) & (TheWidthOfTheSquare == ((N + 1) / 2)))
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("*");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("Enter a positive odd number equal to the length of the side of the square to continue," +
                "'0' or a negative number to exit the program");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a positive odd number equal to the length of the side of the square to continue," +
                "'0' or a negative number to exit the program");

            while (true)
            {
                try
                {
                    int TheLengthOfASideOfASquare = int.Parse(Console.ReadLine());

                    if (TheLengthOfASideOfASquare <= 0)
                    {
                        break;
                    }
                    Task0_3(TheLengthOfASideOfASquare);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Entered a string that is not a positive odd number, repeat the input of a " +
                        "positive odd number equal to the length of the side of the square, '0' or a negative number" +
                        " to exit the program.");
                }
                catch(OverflowException)
                {
                    Console.WriteLine("The number entered is large for me, enter a number less.");
                }
            }
        }
    }
}
