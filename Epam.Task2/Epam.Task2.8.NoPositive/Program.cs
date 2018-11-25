using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2._8.NoPositive
{
    class Program
    {
        private static void FNoPositive()
        {
            //Запускаем цикл программы
            while (true)
            {
                //Объявляем объекты, переменные
                Random RandomNumber = new Random();
                int Length1ArrayOfNumbers = RandomNumber.Next(1,5);
                int Length2ArrayOfNumbers = RandomNumber.Next(1, 5);
                int Length3ArrayOfNumbers = RandomNumber.Next(1, 5);
                int[,,] ArrayOfNumbers = new int[Length1ArrayOfNumbers, Length2ArrayOfNumbers, Length3ArrayOfNumbers];

                //Показываем в консоль размерность массива
                Console.WriteLine("Массив[" + Length1ArrayOfNumbers + "," + Length2ArrayOfNumbers + "," + Length3ArrayOfNumbers + "]");

                //Заполняем массив значениями
                for (int i = 0; i < Length1ArrayOfNumbers; i++)
                {
                    for (int j = 0; j < Length2ArrayOfNumbers; j++)
                    {
                        for (int k = 0; k < Length3ArrayOfNumbers; k++)
                        {
                            ArrayOfNumbers[i, j, k] = RandomNumber.Next(-100, 100);
                            if (k < Length3ArrayOfNumbers)
                            {
                                Console.Write(ArrayOfNumbers[i, j, k] + ", ");
                            }
                            else
                            {
                                Console.Write(ArrayOfNumbers[i, j, k]);
                            }
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }

                //Меняем все положительные значения элементов массива на нули и выводим в консоль
                Console.WriteLine("Исходный массив, но положительные значения элементов заменены нолями:");

                for (int i = 0; i < Length1ArrayOfNumbers; i++)
                {
                    for (int j = 0; j < Length2ArrayOfNumbers; j++)
                    {
                        for (int k = 0; k < Length3ArrayOfNumbers; k++)
                        {
                            if (k < Length3ArrayOfNumbers)
                            {
                                if (ArrayOfNumbers[i, j, k] > 0)
                                {
                                    ArrayOfNumbers[i, j, k] = 0;
                                }
                                Console.Write(ArrayOfNumbers[i, j, k] + ", ");
                            }
                            else
                            {
                                if (ArrayOfNumbers[i, j, k] > 0)
                                {
                                    ArrayOfNumbers[i, j, k] = 0;
                                }
                                Console.Write(ArrayOfNumbers[i, j, k]);
                            }
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("Введите, что-нибудь для продолжения, или '0' для выхода из программы");
                try
                {
                    if(int.Parse(Console.ReadLine())==0)
                    {
                        break;
                    }
                }
                catch(FormatException)
                {
                    continue;
                }
            }
        }
        static void Main(string[] args)
        {
            FNoPositive();
        }
    }
}
