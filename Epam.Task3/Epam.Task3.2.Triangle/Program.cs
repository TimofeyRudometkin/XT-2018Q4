using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3._2.Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangle();
        }
        private static void Triangle()
        {
            Triangle T = new Triangle();
            while (true)
            {
                try
                {
                    Console.WriteLine("Input a triangle side 'A' or zero to end the program.");
                    T.SideA = float.Parse(Console.ReadLine());
                    if (T.SideA == 0)
                    {
                        break;
                    }
                    Console.WriteLine("Input a triangle side 'B' or zero to end the program.");
                    T.SideB = float.Parse(Console.ReadLine());
                    if (T.SideB == 0)
                    {
                        break;
                    }
                    Console.WriteLine("Input a triangle side 'C'.");
                    T.SideC = float.Parse(Console.ReadLine());
                    if (T.SideC == 0)
                    {
                        break;
                    }
                    Console.WriteLine($"Perimetr of the triangle = {T.Perimetr}");
                    Console.WriteLine($"The area of the triangle = {T.Area + Environment.NewLine}");
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e.Message + Environment.NewLine);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"The number you enter must be integer or a float, not text.{Environment.NewLine}");
                }
            }
        }
    }
}
