using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1.Simple
{
    class Program
    {
        private static void Task0_2(int N)
        {
            int TheNumberOfTheDivisionsWithoutRemainder = 0;

            for (int i = 1; i <= N; i++)
            {
                if ((N % i) == 0)
                {
                    TheNumberOfTheDivisionsWithoutRemainder = TheNumberOfTheDivisionsWithoutRemainder + 1;
                }
            }
            if (TheNumberOfTheDivisionsWithoutRemainder > 2)
            {
                Console.WriteLine("Введённое число не является простым.");
            }
            else
            {
                Console.WriteLine("Введённое число является простым.");
            }

            Console.WriteLine("Введите положительное целое число, чтобы продолжить, '0' или отрицательное число для выхода из программы.");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите положительное целое число, чтобы продолжить, '0' или отрицательное число для выхода из программы.");

            while (true)
            {
                try
                {
                    int NumberToCheck = int.Parse(Console.ReadLine());

                    if (NumberToCheck <= 0)
                    {
                        break;
                    }
                    Task0_2(NumberToCheck);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введена строка не являющаяся положительным целым числом, повторите ввод положительного целого числа, '0' или отрицательное число для выхода из программы.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Введённое число для меня крутова-то, ведите число поменьше.");
                }
            }
        }
    }
}
