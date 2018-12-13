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
            Console.WriteLine(dynamicArray[0]);
            dynamicArray[1] = "5454";
            Console.WriteLine(dynamicArray[0]);
            dynamicArray.Capacity = 12;
            Console.WriteLine(dynamicArray[0]);
            dynamicArray.Add("jkdsnv");

            for (int i = 0; i < dynamicArray.Capacity; i++)
            {
                dynamicArray[i] = i.ToString();
            }
            dynamicArray.Capacity = 21;
            dynamicArray.Insert(21, "dvsdv");
            dynamicArray.Insert(20, "dvsdv");
            List<string> jhjkj = new List<string>();
            dynamicArray.Capacity = 21;
            dynamicArray.Capacity = 22;
            dynamicArray.Capacity = 23;
            jhjkj.Add("fgfd");
            dynamicArray.AddRange(jhjkj);
            foreach(var element in dynamicArray)
            {
                Console.WriteLine(element);
            }
            Console.WriteLine("Final");
        }
    }
}
