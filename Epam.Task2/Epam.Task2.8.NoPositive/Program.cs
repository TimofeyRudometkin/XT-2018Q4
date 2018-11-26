using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2._8.NoPositive
{
    class Program
    {
        private static void FNoPositive()
        {
            while (true)
            {
                Random RandomNumber = new Random();
                int Length1ArrayOfNumbers = RandomNumber.Next(1,5);
                int Length2ArrayOfNumbers = RandomNumber.Next(1, 5);
                int Length3ArrayOfNumbers = RandomNumber.Next(1, 5);
                int[,,] ArrayOfNumbers = new int[Length1ArrayOfNumbers, Length2ArrayOfNumbers, Length3ArrayOfNumbers];

                Console.WriteLine("Array[" + Length1ArrayOfNumbers + "," + Length2ArrayOfNumbers + "," + Length3ArrayOfNumbers + "]");

                for (int i = 0; i < Length1ArrayOfNumbers; i++)
                {
                    for (int j = 0; j < Length2ArrayOfNumbers; j++)
                    {
                        for (int k = 0; k < Length3ArrayOfNumbers; k++)
                        {
                            ArrayOfNumbers[i, j, k] = RandomNumber.Next(-100, 100);
                            if (k < Length3ArrayOfNumbers)
                            {
                                Console.Write(ArrayOfNumbers[i, j, k] + ", ");
                            }
                            else
                            {
                                Console.Write(ArrayOfNumbers[i, j, k]);
                            }
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("The original array, but the positive values of the elements are replaced by zeros:");

                for (int i = 0; i < Length1ArrayOfNumbers; i++)
                {
                    for (int j = 0; j < Length2ArrayOfNumbers; j++)
                    {
                        for (int k = 0; k < Length3ArrayOfNumbers; k++)
                        {
                            if (k < Length3ArrayOfNumbers)
                            {
                                if (ArrayOfNumbers[i, j, k] > 0)
                                {
                                    ArrayOfNumbers[i, j, k] = 0;
                                }
                                Console.Write(ArrayOfNumbers[i, j, k] + ", ");
                            }
                            else
                            {
                                if (ArrayOfNumbers[i, j, k] > 0)
                                {
                                    ArrayOfNumbers[i, j, k] = 0;
                                }
                                Console.Write(ArrayOfNumbers[i, j, k]);
                            }
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("Enter something to continue, or ' 0 ' to exit the program.");
                try
                {
                    if(int.Parse(Console.ReadLine())==0)
                    {
                        break;
                    }
                }
                catch(FormatException)
                {
                    continue;
                }
            }
        }
        static void Main(string[] args)
        {
            FNoPositive();
        }
    }
}
