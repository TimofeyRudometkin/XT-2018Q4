using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2._3.AnotherTriangle
{
    class Program
    {
        private static void PaintAnotherTriangle()
        {
            int N=0;

            while (true)
            {
                Console.WriteLine("Введите положительное число N, которое должно быть целым или '0' для выхода из программы");

                try
                {
                    N = int.Parse(Console.ReadLine());
                    if (N == 0)
                    {
                        break;
                    }
                    else if (N < 0)
                    {
                        Console.WriteLine("Не могу нарисовать треугольник с отрицательным колиеством строк.");
                        continue;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введена строка не являющаяся целым числом, для прорисовки треугольника " +
                        "введите целое число");
                    continue;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Введите число поменьше, это для меня великовато");
                }

                for(int i=1;i<=N;i++)
                {
                    for(int j=1;j<N+N;j++)
                    {
                        if(((N-i)<j) & (j <(N+i)))
                        {
                            Console.Write("*");
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                    Console.WriteLine();
                }
            }

        }
        static void Main(string[] args)
        {
            PaintAnotherTriangle();
        }
    }
}
