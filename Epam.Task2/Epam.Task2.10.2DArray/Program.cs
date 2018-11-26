using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2._10._2DArray
{
    class Program
    {
        private static void F2dArray()
        {
            while (true)
            {
                Random RandomNumber = new Random();
                int Length1ArrayOfNumbers = RandomNumber.Next(2, 10);
                int Length2ArrayOfNumbers = RandomNumber.Next(2, 10);
                int Sum = 0;
                int[,] ArrayOfNumbers = new int[Length1ArrayOfNumbers, Length2ArrayOfNumbers];

                Console.WriteLine("Enter something to continue, or ' 0 ' to exit the program");

                for(int i=0;i<Length1ArrayOfNumbers;i++)
                {
                    for(int j=0;j<Length2ArrayOfNumbers;j++)
                    {
                        ArrayOfNumbers[i, j] = RandomNumber.Next(-100, 100);
                        Sum = (((i+j)%2)==0) ? (Sum + ArrayOfNumbers[i,j]) : Sum;

                        if (j < (Length2ArrayOfNumbers-1))
                        {
                            Console.Write(ArrayOfNumbers[i,j] + ", ");
                        }
                        else
                        {
                            Console.Write(ArrayOfNumbers[i,j]);
                        }
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("The sum of the array elements standing on even positions is equal to " + Sum);
                Console.WriteLine("Enter anything to continue or ' 0 ' to exit the program");

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
            F2dArray();
        }
    }
}
