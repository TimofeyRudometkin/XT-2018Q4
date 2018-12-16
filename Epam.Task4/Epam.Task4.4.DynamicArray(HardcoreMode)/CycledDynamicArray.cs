using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epam.Task4._4.DynamicArray_HardcoreMode_
{
    class CycledDynamicArray<T> : DynamicArrayHardcoreMode<T>
    {
        public CycledDynamicArray()
        {
            Array = new T[8];
            Capacity = 8;
            Length = 0;
        }
        public CycledDynamicArray(int capacity)
        {
            if (Capacity < 0)
            {
                throw new ArgumentOutOfRangeException("You cannot create an array with a negative number of elements");
            }
            else
            {
                Capacity = capacity;
                Array = new T[Capacity];
                Length = 0;
            }
        }
        public CycledDynamicArray(IEnumerable<T> collection)
        {
            Array = new T[collection.Count()];
            Length = 0;
            Capacity = collection.Count();
            foreach (T element in collection)
            {
                Add(element);
            }
        }
        public override IEnumerator<T> GetEnumerator()
        {
            return new GetEnumerator<T>(this);
        }
    }
}
