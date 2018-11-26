using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2._1.Rectangle
{
    class Program
    {
        private static void AreaOfARectungle()
        {
            int sidea;
            int sideb;

            while (true)
            {
                Console.WriteLine("Enter the length of the side 'a' of the rectangle.");

                while (true)
                {
                    try
                    {
                        sidea = int.Parse(Console.ReadLine());

                        if (sidea > 0)
                        {
                            break;
                        }

                        Console.WriteLine();
                        Console.WriteLine("Side lengths must be greater than 0. Re-enter the length of side 'a'.");
                    }
                    catch (FormatException) { }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Enter a smaller number, it's too big for me");
                    }
                }

                Console.WriteLine("Enter the length of the side 'b' of the rectangle.");

                while (true)
                {
                    try
                    {
                        sideb = int.Parse(Console.ReadLine());

                        if (sideb > 0)
                        {
                            break;
                        }

                        Console.WriteLine();
                        Console.WriteLine("Side lengths must be greater than 0. Re-enter the length of the side 'bc'.");

                    }
                    catch (FormatException) { }
                    catch (OverflowException)
                    {
                        Console.WriteLine("The number entered is large for me, enter a number less");
                    }
                }

                Console.WriteLine($"The area of a rectangle \"{sidea * sideb}\"");

                Console.WriteLine("Enter any characters to continue or an empty line to end the program");

                if (Console.ReadLine() == "")
                {
                    break;
                }
            }
            
        }
        static void Main(string[] args)
        {
            AreaOfARectungle();
        }
    }
}
