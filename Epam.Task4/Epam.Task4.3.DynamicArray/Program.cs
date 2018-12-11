using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task4._3.DynamicArray
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicArray<string> dynamicArray = new DynamicArray<string>();
            dynamicArray[1] = "dfdf";
            Console.WriteLine(dynamicArray[1]);
            dynamicArray[1] = "5454";
            Console.WriteLine(dynamicArray[1]);
        }
    }
}
