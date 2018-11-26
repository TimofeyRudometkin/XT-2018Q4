using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2._9.Non_NegativeSum
{
    class Program
    {
        private static void FNonNegativeSum()
        {
            while (true)
            {
                Random RandomNumber = new Random();
                int[] ArrayOfNumbers = new int[RandomNumber.Next(1,20)];
                int Sum = 0;

                for (int i = 0; i < ArrayOfNumbers.Length; i++)
                {
                    ArrayOfNumbers[i] = RandomNumber.Next(-100, 100);
                    Sum = ArrayOfNumbers[i] > 0 ? (Sum+ArrayOfNumbers[i]) : Sum;

                    if (i < ArrayOfNumbers.Length)
                    {
                        Console.Write(ArrayOfNumbers[i] + ", ");
                    }
                    else
                    {
                        Console.Write(ArrayOfNumbers[i]);
                    }
                }

                Console.WriteLine();
                Console.WriteLine("The sum of non-negative array elements is equal to " + Sum);
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
            FNonNegativeSum();
        }
    }
}
