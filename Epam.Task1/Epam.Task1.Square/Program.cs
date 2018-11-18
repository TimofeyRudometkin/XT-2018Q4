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
                Console.WriteLine("Введено чётное число, поэтому центр будет смещён вверх и влево.");
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
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите положительное нечётное число равное длине стороны квадрата.");
            Task0_3(Convert.ToInt32(Console.ReadLine()));
        }
    }
}
