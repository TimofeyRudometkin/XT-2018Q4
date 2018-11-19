using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1.Square
{
    class Program
    {
        private static void Task0_3(int N)
        {
            if (N % 2 == 0)
            {
                Console.WriteLine("Введено чётное число, поэтому центр будет смещён вверх и влево.");
            }

            for (int TheWidthOfTheSquare = 1; TheWidthOfTheSquare <= N; TheWidthOfTheSquare++)
            {
                for (int TheHeightOfTheSquare = 1; TheHeightOfTheSquare <= N; TheHeightOfTheSquare++)
                {
                    if ((TheHeightOfTheSquare == ((N + 1) / 2)) & (TheWidthOfTheSquare == ((N + 1) / 2)))
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("*");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("Введите положительное нечётное число равное длине стороны квадрата, чтобы продолжить,'0' или отрицательное число для выхода из программы");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите положительное нечётное число равное длине стороны квадрата, чтобы продолжить,'0' или отрицательное число для выхода из программы");

            while (true)
            {
                try
                {
                    int TheLengthOfASideOfASquare = int.Parse(Console.ReadLine());

                    if (TheLengthOfASideOfASquare <= 0)
                    {
                        break;
                    }
                    Task0_3(TheLengthOfASideOfASquare);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введена строка не являющаяся положительным нечётным числом, повторите ввод положительного нечётного числа равного длине стороны квадрата, '0' или отрицательное число для выхода из программы.");
                }
                catch(OverflowException)
                {
                    Console.WriteLine("Введённое число для меня крутова-то, ведите число поменьше.");
                }
            }
        }
    }
}
