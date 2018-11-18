using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task1.Simple
{
    class Program
    {
        private static string Task0_2(int N)
        {
            int TheNumberOfTheDivisionsWithoutRemainder = 0;

            for (int i = 1; i <= N; i++)
            {
                if ((N % i) == 0)
                    TheNumberOfTheDivisionsWithoutRemainder = TheNumberOfTheDivisionsWithoutRemainder + 1;
            }
            if (TheNumberOfTheDivisionsWithoutRemainder > 2)
                return "Введённое число не является простым.";
            return "Введённое число является простым.";
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите положительное целое число.");
            string Result = Task0_2(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine(Result);
        }
    }
}
