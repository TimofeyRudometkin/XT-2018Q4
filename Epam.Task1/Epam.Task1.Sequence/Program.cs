using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1.Sequence
{
    class Program
    {
        private static void Task0_1(int N)
        {
            Console.Write(1);

            //Формируем строку до значения N-1
            for (int i = 2; i <= N; i++)
            {
                Console.Write(", " + i);
            }

            Console.WriteLine();
            Console.WriteLine("Введите положительное число, чтобы продолжить, '0' или отрицательное число для выхода из программы.");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите положительное число, чтобы продолжить, '0' или отрицательное число для выхода из программы.");

            while (true)
            {
                try
                {
                    int NumberToCheck = int.Parse(Console.ReadLine());

                    if (NumberToCheck <= 0)
                    {
                        break;
                    }
                    Task0_1(NumberToCheck);
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
