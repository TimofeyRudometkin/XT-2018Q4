using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2._7.ArrayProcessing
{
    class Program
    {
        private static void FArrayProcessing()
        {
            while (true)
            {
                Random RandomNumber = new Random();
                int[] ArrayOfNumbers = new int[RandomNumber.Next(30)];
                int MinValue;
                int MaxValue;

                Console.WriteLine("Неотсортированный массив");

                for (int i = 0; i < ArrayOfNumbers.Length; i++)
                {
                    ArrayOfNumbers[i] = RandomNumber.Next(-100,100);
                    if (i < ArrayOfNumbers.Length - 1)
                    {
                        Console.Write(ArrayOfNumbers[i] + ", ");
                    }
                    else
                    {
                        Console.Write(ArrayOfNumbers[i]);
                    }
                }

                Console.WriteLine();

                for (int i = ArrayOfNumbers.Length; i > 1; i--)
                {
                    for (int j = 1; j < i; j++)
                    {
                        if (ArrayOfNumbers[j - 1] > ArrayOfNumbers[j])
                        {
                            int TemporaryVariable = ArrayOfNumbers[j];
                            Console.WriteLine($"Поменяем местами элементы массива с индексами {j - 1} = " +
                                $"'{ArrayOfNumbers[j - 1]}'и {j} = '{ArrayOfNumbers[j]}'");
                            ArrayOfNumbers[j] = ArrayOfNumbers[j - 1];
                            ArrayOfNumbers[j - 1] = TemporaryVariable;
                            }
                    }
                }

                //Ищем минимальное и максимальное значения элементов массива, которые можно не искать,
                //а просто вывести на экран первыйй и последний элементы отсортированного массива. 
                MinValue = ArrayOfNumbers[0];
                MaxValue = ArrayOfNumbers[0];

                Console.WriteLine("Отсортированный массив:");

                foreach (int element in ArrayOfNumbers)
                {
                    MinValue = MinValue > element ? element : MinValue;
                    MaxValue = MaxValue < element ? element : MaxValue;
                    Console.Write(element+", ");
                }

                Console.WriteLine();
                Console.WriteLine("Минимальное значение элемента массива '" + MinValue + "';");
                Console.WriteLine("Максимальное значение элемента массива '" + MaxValue + "';");
                
                Console.WriteLine("Введите, что-нибудь для продолжения, или '0' для выхода из программы");
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
            FArrayProcessing();
        }
    }
}
