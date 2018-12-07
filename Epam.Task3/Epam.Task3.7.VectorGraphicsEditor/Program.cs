using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3._7.VectorGraphicsEditor
{
    class Program
    {
        [Flags]
        private enum ListOfFiguers
        {
            None = 0,
            Line = 1,
            Circle = 2,
            Rectangle = 4,
            Round = 8,
            Ring = 16,
        }
        private static ListOfFiguers listOfFiguers = ListOfFiguers.None;

        private static Random RandomNumber = new Random();

        private static Line line = new Line();
        private static Circle circle = new Circle();
        private static Rectangle rectangle = new Rectangle();
        private static RoundForTask7 round = new RoundForTask7();
        private static RingForTask7 ring = new RingForTask7();
        static void Main(string[] args)
        {
            VectorGraficsEditor();
        }
        static void VectorGraficsEditor()
        {
            while (true)
            {
                MenuOfFigures();
                try
                {
                    CreateTheShapes();
                    PrintTheShapes();
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e.Message + Environment.NewLine);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"The entered data of the wrong format.{Environment.NewLine}");
                }
                Console.WriteLine("Input '0' for exit or else for repeat.");
                if(Console.ReadLine()=="0")
                {
                    break;
                }
            }
        }
        static void MenuOfFigures()
        {
            int NumbersOfFiguers;
            while(true)
            {
                try
                {
                    Console.WriteLine("Enter the number of the shape you want to add (remove) to (from) the list of shapes to be " +
                        $"created:"+Environment.NewLine+ $"0. Create the following shapes: {listOfFiguers};" + Environment.NewLine + 
                        $"1. Line;" + Environment.NewLine + $"2. Circle;" + Environment.NewLine + $"3. Rectangle;" + Environment.NewLine +
                        $"4. Round;" + Environment.NewLine + $"5. Ring." + Environment.NewLine + Environment.NewLine);

                    Line line = new Line();
                    Circle circle = new Circle();
                    Rectangle rectangle = new Rectangle();
                    RoundForTask7 round = new RoundForTask7();
                    RingForTask7 ring = new RingForTask7();

                    NumbersOfFiguers = int.Parse(Console.ReadLine());
                    if (NumbersOfFiguers == 0)
                    {
                        break;
                    }
                    else if(NumbersOfFiguers<0 | NumbersOfFiguers>5)
                    {
                        throw new ArgumentOutOfRangeException("Not an integer entered. Enter an integer between 0 and 5.");
                    }
                    switch (NumbersOfFiguers)
                    {
                        case 1:
                            if ((listOfFiguers & ListOfFiguers.Line) == ListOfFiguers.Line)
                            {
                                listOfFiguers = listOfFiguers ^ ListOfFiguers.Line;
                            }
                            else
                            {
                                listOfFiguers = listOfFiguers | ListOfFiguers.Line;
                            }
                            break;
                        case 2:
                            if ((listOfFiguers & ListOfFiguers.Circle) == ListOfFiguers.Circle)
                            {
                                listOfFiguers = listOfFiguers ^ ListOfFiguers.Circle;
                            }
                            else
                            {
                                listOfFiguers = listOfFiguers | ListOfFiguers.Circle;
                            }
                            break;
                        case 3:
                            if ((listOfFiguers & ListOfFiguers.Rectangle) == ListOfFiguers.Rectangle)
                            {
                                listOfFiguers = listOfFiguers ^ ListOfFiguers.Rectangle;
                            }
                            else
                            {
                                listOfFiguers = listOfFiguers | ListOfFiguers.Rectangle;
                            }
                            break;
                        case 4:
                            if ((listOfFiguers & ListOfFiguers.Round) == ListOfFiguers.Round)
                            {
                                listOfFiguers = listOfFiguers ^ ListOfFiguers.Round;
                            }
                            else
                            {
                                listOfFiguers = listOfFiguers | ListOfFiguers.Round;
                            }
                            break;
                        case 5:
                            if ((listOfFiguers & ListOfFiguers.Ring) == ListOfFiguers.Ring)
                            {
                                listOfFiguers = listOfFiguers ^ ListOfFiguers.Ring;
                            }
                            else
                            {
                                listOfFiguers = listOfFiguers | ListOfFiguers.Ring;
                            }
                            break;
                    }
                    Console.WriteLine(Environment.NewLine + Environment.NewLine);
                }
                catch
                {
                    Console.WriteLine("Not an integer entered. Enter an integer between 0 and 5." + Environment.NewLine + Environment.NewLine);
                }
            }
        }
        static void CreateTheShapes()
        {
            if ((listOfFiguers & ListOfFiguers.Line) == ListOfFiguers.Line)
            {
                line.X = (float)RandomNumber.NextDouble() * RandomNumber.Next(-1000, 1000);
                line.Y = (float)RandomNumber.NextDouble() * RandomNumber.Next(-1000, 1000);
                line.Length = (float)RandomNumber.NextDouble() * RandomNumber.Next(1000);
            }
            if ((listOfFiguers & ListOfFiguers.Circle) == ListOfFiguers.Circle)
            {
                circle.X = (float)RandomNumber.NextDouble() * RandomNumber.Next(-1000, 1000);
                circle.Y = (float)RandomNumber.NextDouble() * RandomNumber.Next(-1000, 1000);
                circle.Radius = (float)RandomNumber.NextDouble() * RandomNumber.Next(1000);
            }
            if ((listOfFiguers & ListOfFiguers.Rectangle) == ListOfFiguers.Rectangle)
            {
                rectangle.X = (float)RandomNumber.NextDouble() * RandomNumber.Next(-1000, 1000);
                rectangle.Y = (float)RandomNumber.NextDouble() * RandomNumber.Next(-1000, 1000);
                rectangle.SideA = (float)RandomNumber.NextDouble() * RandomNumber.Next(1000);
                rectangle.SideB = (float)RandomNumber.NextDouble() * RandomNumber.Next(1000);
            }
            if ((listOfFiguers & ListOfFiguers.Round) == ListOfFiguers.Round)
            {
                round.X = (float)RandomNumber.NextDouble() * RandomNumber.Next(-1000, 1000);
                round.Y = (float)RandomNumber.NextDouble() * RandomNumber.Next(-1000, 1000);
                round.Radius = (float)RandomNumber.NextDouble() * RandomNumber.Next(1000);
            }
            if ((listOfFiguers & ListOfFiguers.Ring) == ListOfFiguers.Ring)
            {
                ring.X = (float)RandomNumber.NextDouble() * RandomNumber.Next(-1000, 1000);
                ring.Y = (float)RandomNumber.NextDouble() * RandomNumber.Next(-1000, 1000);
                ring.Radius = (float)RandomNumber.NextDouble() * RandomNumber.Next(1000);
                ring.InnerRadius = (float)RandomNumber.NextDouble() * RandomNumber.Next(1000);
            }
        }
        static void PrintTheShapes()
        {
            if ((listOfFiguers & ListOfFiguers.Line) == ListOfFiguers.Line)
            {
                Console.WriteLine("Line:" + Environment.NewLine + Environment.NewLine + $"Coordinate X - {line.X}" + Environment.NewLine +
                $"Coordinate Y - {line.Y}" + Environment.NewLine + $"Length - {line.Length}" + Environment.NewLine + Environment.NewLine);
            }
            if ((listOfFiguers & ListOfFiguers.Circle) == ListOfFiguers.Circle)
            {
                Console.WriteLine("Circle:" + Environment.NewLine + Environment.NewLine + $"Coordinate X - {circle.X}" + Environment.NewLine +
                $"Coordinate Y - {circle.Y}" + Environment.NewLine + $"Radius - {circle.Radius}" + Environment.NewLine + Environment.NewLine);
            }
            if ((listOfFiguers & ListOfFiguers.Rectangle) == ListOfFiguers.Rectangle)
            {
                Console.WriteLine("Rectangle:" + Environment.NewLine + Environment.NewLine + $"Coordinate X - {rectangle.X}" + Environment.NewLine +
                $"Coordinate Y - {rectangle.Y}" + Environment.NewLine + $"Side A - {rectangle.SideA}" + Environment.NewLine
                + $"Side B - {rectangle.SideB}" + Environment.NewLine + $"Perimetr - {rectangle.Perimetr}" + Environment.NewLine
                + $"Area - {rectangle.Area}" + Environment.NewLine + Environment.NewLine);
            }
            if ((listOfFiguers & ListOfFiguers.Round) == ListOfFiguers.Round)
            {
                Console.WriteLine("Round:" + Environment.NewLine + Environment.NewLine + $"Coordinate X - {round.X}" + Environment.NewLine +
                $"Coordinate Y - {round.Y}" + Environment.NewLine + $"Radius - {round.Radius}" + Environment.NewLine
                 + $"Length of the circumscribed circle - {round.LengthOfTheCircumscribedCircle}" + Environment.NewLine
                 + $"The area of a circle - {round.TheAreaOfACircle}" + Environment.NewLine + Environment.NewLine);
            }
            if ((listOfFiguers & ListOfFiguers.Ring) == ListOfFiguers.Ring)
            {
                Console.WriteLine("Ring:" + Environment.NewLine + Environment.NewLine + $"Coordinate X - {ring.X}" + Environment.NewLine +
                $"Coordinate Y - {ring.Y}" + Environment.NewLine + $"Outer radius - {ring.Radius}" + Environment.NewLine
                 + $"Inner radius - {ring.InnerRadius}" + Environment.NewLine + $"Total length of outer and inner circumference - " +
                 $"{ring.LengthOuterInnerCircumference}" + Environment.NewLine + $"Area of ring - {ring.AreaOfRing}" + Environment.NewLine
                 + Environment.NewLine);
            }
        }
    }
}
