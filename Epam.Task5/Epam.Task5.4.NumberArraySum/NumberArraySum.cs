using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task5._4.NumberArraySum
{
    static class NumberArraySum
    {
        public static int SumIntNumbers(this int[] array)
        {
            int sum=0;
            foreach (int element in array)
            {
                sum += element;
            }
            return sum;
        }
        public static double SumDoublesNumbers(this double[] array)
        {
            double sum=0.0;
            foreach (double element in array)
            {
                sum += element;
            }
            return sum;
        }
    }
}