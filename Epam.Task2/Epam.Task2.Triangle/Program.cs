using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2._2.Triangle
{
    class Program
    {
        private static void triangle()
        {
            int N = 0;

            while (true)
            {
                Console.WriteLine("Enter a positive number N, which must be an integer or '0' to exit the program.");

                try
                {
                    N = int.Parse(Console.ReadLine());
                    if(N==0)
                    {
                        break;
                    }else if(N<0)
                    {
                        Console.WriteLine("Can't draw a triangle with a negative number of lines.");
                        continue;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("A non-integer string is entered, enter an integer to draw the triangle.");
                    continue;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("The number entered is large for me, enter a number less.");
                }

                for (int i = 1; i <= N; i++)
                {
                    for (int j = 1; j <= i; j++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                }
            }
        }
        static void Main(string[] args)
        {
            triangle();
        }
    }
}
