using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3._6.Ring
{
    class Program
    {
        static void Main(string[] args)
        {
            ring();
        }

        static void ring()
        {
            Random RandomNumber = new Random();

            Ring ring = new Ring();
            while (true)
            {
                try
                {
                    ring.X = (float)RandomNumber.NextDouble() * RandomNumber.Next(-1000, 1000);
                    ring.Y = (float)RandomNumber.NextDouble() * RandomNumber.Next(-1000, 1000);
                    ring.OuterRadius = (float)RandomNumber.NextDouble() * RandomNumber.Next(1000);
                    ring.InnerRadius = (float)RandomNumber.NextDouble() * RandomNumber.Next(1000);

                    Console.WriteLine("Ring:" + Environment.NewLine + Environment.NewLine + $"Coordinate X - {ring.X}" + Environment.NewLine +
                        $"Coordinate Y - {ring.Y}" + Environment.NewLine + $"Outer radius - {ring.OuterRadius}" + Environment.NewLine
                         + $"Inner radius - {ring.InnerRadius}" + Environment.NewLine + $"Total length of outer and inner circumference - " +
                         $"{ring.LengthOuterInnerCircumference}" + Environment.NewLine + $"Area of ring - {ring.AreaOfRing}" + Environment.NewLine
                         + Environment.NewLine);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e.Message + Environment.NewLine);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"The entered data of the wrong format.{Environment.NewLine}");
                }
                Console.WriteLine("Input '1' for exit or else for repeat.");
                if (Console.ReadLine() == "1")
                {
                    break;
                }
            }
        }
    }
}
