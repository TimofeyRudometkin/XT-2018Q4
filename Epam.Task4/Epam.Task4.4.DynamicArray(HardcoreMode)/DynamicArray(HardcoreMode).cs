using Epam.Task4._3.DynamicArray;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task4._4.DynamicArray_HardcoreMode_
{
    class DynamicArrayHardcoreMode<T> : DynamicArray<T>, ICloneable
    {
        public override T this[int index]
        {
            get
            {
                if (index >= 0)
                {
                    if (index < Length)
                    {
                        return Array[index];
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Array has no count of elements more than his length");
                    }
                }
                else
                {
                    if (-index < Length)
                    {
                        return Array[Length - 1 + index];
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Array has no count of elements more than his length");
                    }
                }
            }
            set
            {
                if (index >= 0)
                {
                    if (index < Capacity)
                    {
                        if (index >= Length)
                        {
                            Length = index + 1;
                        }
                        Array[index] = value;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException($"The number of array elements cannot be greater than its capacity({Capacity}" +
                            $" elementes)");
                    }
                }
                else
                {
                    if (-index < Capacity)
                    {
                        if (-index >= Length)
                        {
                            Length = -index + 1;
                        }
                        Array[Capacity - 1 + index] = value;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException($"The number of array elements cannot be greater than its capacity({Capacity}" +
                            $" elementes)");
                    }
                }
            }
        }
        public override int Capacity
        {
            get => base.Capacity;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Capacity of the array must be greater or equally zero");
                }
                else if (value != base.Capacity)
                {
                    base.Capacity = value;
                    T[] array = new T[base.Capacity];
                    for (int i = 0; i < value; i++)
                    {
                        array[i] = Array.ElementAtOrDefault(i);
                    }
                    Array = array;
                    if (Length > base.Capacity)
                    {
                        Length = base.Capacity;
                    }
                }
            }
        }

        public object Clone()
        {
            DynamicArrayHardcoreMode<T> CopyOfTheArray = new DynamicArrayHardcoreMode<T>();
            for (int i = 0; i < Capacity; i++)
            {
                CopyOfTheArray[i] = Array[i];
            }
            return CopyOfTheArray;
        }
        public T[] ToArray
        {
            get
            {
                T[] array = new T[Capacity];
                for(int i=0; i<Capacity;i++)
                {
                    array[i] = Array[i];
                }
                return array;
            }
        }
    }
}
