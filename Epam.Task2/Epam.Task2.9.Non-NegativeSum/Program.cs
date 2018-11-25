using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2._9.Non_NegativeSum
{
    class Program
    {
        private static void FNonNegativeSum()
        {
            //Запускаем цикл программы
            while (true)
            {
                //объявляем объекты и переменные
                Random RandomNumber = new Random();
                int[] ArrayOfNumbers = new int[RandomNumber.Next(1,20)];
                int Sum = 0;

                //Задаём значения элементам массива, выводим их в консоль и считаем сумму 
                for (int i = 0; i < ArrayOfNumbers.Length; i++)
                {
                    ArrayOfNumbers[i] = RandomNumber.Next(-100, 100);
                    Sum = ArrayOfNumbers[i] > 0 ? (Sum+ArrayOfNumbers[i]) : Sum;

                    if (i < ArrayOfNumbers.Length)
                    {
                        Console.Write(ArrayOfNumbers[i] + ", ");
                    }
                    else
                    {
                        Console.Write(ArrayOfNumbers[i]);
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Сумма не отрицательных элементов массива равна "+Sum);
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
            FNonNegativeSum();
        }
    }
}
