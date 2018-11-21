using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2._5.SumOfNumbers
{
    class Program
    {
        private static void SumOfNumbers()
        {
            while (true)
            {
                int N = int.Parse(Console.ReadLine());

                if(N==0)
                {
                    break;
                }
                for (int i = 1; i < N; i++)
                {
                    if ((i % 3 == 0) | (i % 5 == 0))
                    {
                        Console.Write(i+"  ");
                    }
                }

                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            SumOfNumbers();
        }
    }
}
