using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1.Sequence
{
    class Program
    {
        private static string Task0_1(int N)
        {
            string TheGeneratedString = "";
            //Ноль не является положительным числом, но добавим проверку
            if (N < 1)
                return TheGeneratedString = "Введённое число не является положительным числом, возможно вы ввели '0'.";

            //Добавляем в строку первое число
            TheGeneratedString = "1";

            //Если в строке содержится болше одного числа
            if (N > 1)
            {
                //Формируем строку до значения N-1
                for (int i = 2; i < N; i++)
                {
                    TheGeneratedString = TheGeneratedString + ", " + i;
                }
                //Добавляем в строку число N и возвращаем полученную строку
                TheGeneratedString = TheGeneratedString + ", " + N;
            }
            return TheGeneratedString;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите положительное число.");
            string Result = Task0_1(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine(Result);
        }
    }
}
