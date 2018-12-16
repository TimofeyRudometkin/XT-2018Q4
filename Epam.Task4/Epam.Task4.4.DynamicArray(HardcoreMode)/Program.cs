using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task4._4.DynamicArray_HardcoreMode_
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicArrayHardcoreMode<int> dynamicarrayhardcoremode = new DynamicArrayHardcoreMode<int>();
            dynamicarrayhardcoremode[-7] = 8;
            DynamicArrayHardcoreMode<int> dynami;
            dynami = (DynamicArrayHardcoreMode<int>) dynamicarrayhardcoremode.Clone();
            
            for (int i = 0; i<dynamicarrayhardcoremode.Length;i++)
            {
                dynamicarrayhardcoremode[i] = i;
            }
            CycledDynamicArray<int> cycleddynamicarray = new CycledDynamicArray<int>();
            cycleddynamicarray[7] = 5;
            for (int i = 0; i < cycleddynamicarray.Length; i++)
            {
                cycleddynamicarray[i] = i;
            }
            Console.WriteLine();
            foreach (int element in cycleddynamicarray)
            {
                Console.WriteLine(element);
            }
            foreach (int element in dynamicarrayhardcoremode)
            {
                Console.WriteLine(element);
            }
            dynamicarrayhardcoremode[-7]=3;
            Console.WriteLine(dynamicarrayhardcoremode[-7]);
            dynamicarrayhardcoremode.Capacity = 20;
            Console.WriteLine(dynamicarrayhardcoremode.Capacity);
        }
    }
}
