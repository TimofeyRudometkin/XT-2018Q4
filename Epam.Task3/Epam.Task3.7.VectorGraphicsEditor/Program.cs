using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3._7.VectorGraphicsEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            VectorGraficsEditor();
        }
        static void VectorGraficsEditor()
        {
            Random RandomNumber = new Random();

            Line line = new Line();
            Circle circle = new Circle();
            Rectangle rectangle = new Rectangle();
            RoundForTask7 round = new RoundForTask7();
            RingForTask7 ring = new RingForTask7();
            while (true)
            {
                try
                {
                    line.X = (float)RandomNumber.NextDouble() * RandomNumber.Next(-1000, 1000);
                    line.Y = (float)RandomNumber.NextDouble() * RandomNumber.Next(-1000, 1000);
                    line.Length = (float)RandomNumber.NextDouble() * RandomNumber.Next(1000);

                    circle.X = (float)RandomNumber.NextDouble() * RandomNumber.Next(-1000, 1000);
                    circle.Y = (float)RandomNumber.NextDouble() * RandomNumber.Next(-1000, 1000);
                    circle.Radius = (float)RandomNumber.NextDouble() * RandomNumber.Next(1000);

                    rectangle.X = (float)RandomNumber.NextDouble() * RandomNumber.Next(-1000, 1000);
                    rectangle.Y = (float)RandomNumber.NextDouble() * RandomNumber.Next(-1000, 1000);
                    rectangle.SideA = (float)RandomNumber.NextDouble() * RandomNumber.Next(1000);
                    rectangle.SideB = (float)RandomNumber.NextDouble() * RandomNumber.Next(1000);

                    round.X = (float)RandomNumber.NextDouble() * RandomNumber.Next(-1000, 1000);
                    round.Y = (float)RandomNumber.NextDouble() * RandomNumber.Next(-1000, 1000);
                    round.Radius = (float)RandomNumber.NextDouble() * RandomNumber.Next(1000);

                    ring.X = (float)RandomNumber.NextDouble() * RandomNumber.Next(-1000, 1000);
                    ring.Y = (float)RandomNumber.NextDouble() * RandomNumber.Next(-1000, 1000);
                    ring.Radius = (float)RandomNumber.NextDouble() * RandomNumber.Next(1000);
                    ring.InnerRadius = (float)RandomNumber.NextDouble() * RandomNumber.Next(1000);

                    Console.WriteLine("Line:" + Environment.NewLine + Environment.NewLine + $"Coordinate X - {line.X}" + Environment.NewLine +
                        $"Coordinate Y - {line.Y}" + Environment.NewLine + $"Length - {line.Length}" + Environment.NewLine + Environment.NewLine);

                    Console.WriteLine("Circle:" + Environment.NewLine + Environment.NewLine + $"Coordinate X - {circle.X}" + Environment.NewLine +
                        $"Coordinate Y - {circle.Y}" + Environment.NewLine + $"Radius - {circle.Radius}" + Environment.NewLine + Environment.NewLine);

                    Console.WriteLine("Rectangle:" + Environment.NewLine + Environment.NewLine + $"Coordinate X - {rectangle.X}" + Environment.NewLine +
                        $"Coordinate Y - {rectangle.Y}" + Environment.NewLine + $"Side A - {rectangle.SideA}" + Environment.NewLine
                        + $"Side B - {rectangle.SideB}" + Environment.NewLine + $"Perimetr - {rectangle.Perimetr}" + Environment.NewLine
                        + $"Area - {rectangle.Area}" + Environment.NewLine + Environment.NewLine);

                    Console.WriteLine("Round:" + Environment.NewLine + Environment.NewLine + $"Coordinate X - {round.X}" + Environment.NewLine +
                        $"Coordinate Y - {round.Y}" + Environment.NewLine + $"Radius - {round.Radius}" + Environment.NewLine
                         + $"Length of the circumscribed circle - {round.LengthOfTheCircumscribedCircle}" + Environment.NewLine
                         + $"The area of a circle - {round.TheAreaOfACircle}" + Environment.NewLine + Environment.NewLine);

                    Console.WriteLine("Ring:" + Environment.NewLine + Environment.NewLine + $"Coordinate X - {ring.X}" + Environment.NewLine +
                        $"Coordinate Y - {ring.Y}" + Environment.NewLine + $"Outer radius - {ring.Radius}" + Environment.NewLine
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
                if(Console.ReadLine()=="1")
                {
                    break;
                }
            }
        }
    }
}
