using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task5._6.ISeekYou
{
    class Program
    {
        delegate string Conditions(double[] array);

        static void Main(string[] args)
        {
            double[] array = { 1, 2, 3, 4, 5, -5, -6, 9, -34, 0, 65 };
            Console.WriteLine(ConditionDelegate(array, AllPositive));
            Conditions conditions = delegate (double[] array1)
            {
                string AP = "";
                foreach (double element in array1)
                {
                    if (element > 0)
                    {
                        AP += $"Element equal {element.ToString()} is positive. ";
                    }
                }
                return AP;
            };
            Console.WriteLine(conditions(array));
            Conditions conditions = (array1)=>
        }
        private static string AllPositive1(double[] array)
        {
            string AP = "";
            foreach (double element in array)
            {
                if (element > 0)
                {
                    AP += $"Element equal {element.ToString()} is positive. ";
                }
            }
            return AP;
        }
        private static string ConditionDelegate(double[] array, Func<double[], string> condition)
        {
            return condition(array);
        }
        private static string AllPositive(double[] array)
        {
            string AP = "";
            foreach (double element in array)
            {
                if (element > 0)
                {
                    AP += $"Element equal {element.ToString()} is positive. ";
                }
            }
            return AP;
        }
    }
}
