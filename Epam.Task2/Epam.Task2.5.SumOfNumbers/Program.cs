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

                Console.WriteLine("Сумма всех чисел кратных 3 или 5 и меньше 1000 = "+Sum);
            }
        static void Main(string[] args)
        {
        SumOfNumbers();
        }
    }
}
