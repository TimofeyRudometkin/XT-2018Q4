using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task5._5.ToIntOrNotToInt
{
    class Program
    {
        static void Main(string[] args)
        {
            string Number1 = "0";
            string Number2 = "1";
            string Number3 = "23.43";

            Console.WriteLine($"{Number1} - positive integer - { Number1.PositiveInteger()}"+Environment.NewLine+
                $"{Number2} - positive integer - { Number2.PositiveInteger()}" + Environment.NewLine +
                $"{Number3} - positive integer - { Number3.PositiveInteger()}");
        }
    }
}
