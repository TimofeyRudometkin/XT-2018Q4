using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task5._4.NumberArraySum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intarray = { 1, 2, 3, 4, 5 };
            double[] doublearray = { 1.2, 2.2, 3.4, 5.6 };
            Console.WriteLine(intarray.SumIntNumbers());
            Console.WriteLine(doublearray.SumDoublesNumbers());
        }
    }
}
