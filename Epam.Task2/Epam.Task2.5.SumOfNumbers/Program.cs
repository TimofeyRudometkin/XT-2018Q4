using System;

namespace Epam.Task2._5.SumOfNumbers
{
    class Program
    {
        private static void SumOfNumbers()
        {
                int Sum = 0;
                
                for (int i = 1; i < 1000; i++)
                {
                    if ((i % 3 == 0) | (i % 5 == 0))
                    {
                        Sum +=i;
                    }
                }

                Console.WriteLine("Sum of all multiples of 3 or 5 and less than 1000 = " + Sum);
            }
        static void Main(string[] args)
        {
        SumOfNumbers();
        }
    }
}
