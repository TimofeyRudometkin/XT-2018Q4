using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2._7.ArrayProcessing
{
    class Program
    {
        private static void FArrayProcessing()
        {
            while (true)
            {
                Random RandomNumber = new Random();
                int[] ArrayOfNumbers = new int[RandomNumber.Next(30)];
                int MinValue;
                int MaxValue;

                Console.WriteLine("Unsorted array");

                for (int i = 0; i < ArrayOfNumbers.Length; i++)
                {
                    ArrayOfNumbers[i] = RandomNumber.Next(-100,100);
                    if (i < ArrayOfNumbers.Length - 1)
                    {
                        Console.Write(ArrayOfNumbers[i] + ", ");
                    }
                    else
                    {
                        Console.Write(ArrayOfNumbers[i]);
                    }
                }

                Console.WriteLine();

                for (int i = ArrayOfNumbers.Length; i > 1; i--)
                {
                    for (int j = 1; j < i; j++)
                    {
                        if (ArrayOfNumbers[j - 1] > ArrayOfNumbers[j])
                        {
                            int TemporaryVariable = ArrayOfNumbers[j];
                            Console.WriteLine($"Swap array elements with indexes {j - 1} = " +
                                $"'{ArrayOfNumbers[j - 1]}'и {j} = '{ArrayOfNumbers[j]}'");
                            ArrayOfNumbers[j] = ArrayOfNumbers[j - 1];
                            ArrayOfNumbers[j - 1] = TemporaryVariable;
                            }
                    }
                }

                MinValue = ArrayOfNumbers[0];
                MaxValue = ArrayOfNumbers[0];

                Console.WriteLine("Sorted array:");

                foreach (int element in ArrayOfNumbers)
                {
                    MinValue = MinValue > element ? element : MinValue;
                    MaxValue = MaxValue < element ? element : MaxValue;
                    Console.Write(element+", ");
                }

                Console.WriteLine();
                Console.WriteLine("The minimum value of the array element '" + MinValue + "';");
                Console.WriteLine("The maximum value of the array element '" + MaxValue + "';");
                
                Console.WriteLine("Enter something to continue, or ' 0 ' to exit the program");
                try
                {
                    if (int.Parse(Console.ReadLine()) == 0)
                    {
                        break;
                    }
                }
                catch (FormatException)
                {
                    continue;
                }
            }
        }
        static void Main(string[] args)
        {
            FArrayProcessing();
        }
    }
}
