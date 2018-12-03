using System;

namespace Epam.Task2._5.SumOfNumbers
{
    class Program
    {
        private static void SumOfNumbers()
        {
            int Sum = 0;
            int limiter = 1000;
            int number1 = 3;
            int number2 = 5;
            int number12 = number1 * number2;

            limiter -= 1;

            Sum = (number1 + limiter / number1 * number1) * (limiter / number1) / 2
                + (number2 + limiter / number2 * number2) * (limiter / number2) / 2
                - (number12 + limiter / number12 * number12) * (limiter / number12) / 2;

            Console.WriteLine((number1 + limiter / number1 * number1) * (limiter / number1) / 2);
            Console.WriteLine((number2 + limiter / number2 * number2) * (limiter / number2) / 2);
            Console.WriteLine((number12 + limiter / number12 * number12) * (limiter / number12) / 2);
            Console.WriteLine(Sum);

            //Second variant
            //for (int i = 3; i < 1000; i++)
            //{
            //    if ((i % 3 == 0) || (i % 5 == 0))
            //    {
            //        Sum += i;
            //    }
            //}

            Console.WriteLine($"Sum of all multiples of 3 or 5 and less than 1000 = {Sum}");
        }
        static void Main(string[] args)
        {
        SumOfNumbers();
        }
    }
}
