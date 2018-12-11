using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Epam.Task4._3.DynamicArray
{
    class DynamicArray<T>: IEnumerable, IEnumerable<T>
    {
        private int m_capacity;
        private int m_length;
        private T[] m_array;
        public int Length
        {
            get => m_length;
            set
            {
                if (value > m_capacity)
                {
                    IncreaseInTheCapacity(m_length);
                }
                else
                {
                    m_length = value;
                }
            }
        }

        public int Capacity
        {
            get => m_capacity;
            set
            {
                if (value > m_capacity)
                {
                    IncreaseInTheCapacity(value);
                }
                else if (value < m_capacity)
                {
                    DecreaseInTheCapacity(value);
                }
                else
                {
                    throw new ArgumentException("Capacity of the array must be greater or equally zero");
                }
            }
        }
        public T this [int index]
        {
            get
            {
                if (index >= 0)
                {
                    if (index < m_length)
                    {
                        return m_array[index];
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Array has no count of elements more than his length");
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Array has elements with index less than zero");
                }
            }
                set 
                    {
                if (index >= 0)
                {
                    if (index < m_capacity)
                    {
                        m_array[index]=value;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("The number of array elements cannot be greater than its capacity");
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Index of the array can not be less than zero");
                }
            }
        }

        public DynamicArray()
        {
            m_array = new T[7];
            m_capacity = 8;
            m_length = 8;
        }
        public DynamicArray(int capacity)
        {
            if (m_capacity < 0)
            {
                throw new FormatException("You cannot create an array with a negative number of elements");
            }
            else
            {
                m_capacity = capacity;
                m_array = new T[m_capacity];
                m_length = 0;
            }
        }
        public DynamicArray(IEnumerable<T> collection)
        {
            m_array = new T[collection.Count()];
            Length = 0;
            Capacity = collection.Count();
            foreach(T element in collection)
            {
                Add(element);
            }
        }
        public void Add(T element)
        {
            m_length++;
            if(m_length >= m_capacity)
            {
                m_capacity *= 2;
            }
            m_array[m_length] = element;
        }
        public void AddRange(IEnumerable<T> collection)
        {
            int CountOfCollection=0;
            collection.GetEnumerator();
            foreach(IEnumerable<T> elements in collection)
            {
                CountOfCollection++;
            }
            if((CountOfCollection + m_length) > m_capacity)
            {
                IncreaseInTheCapacity(CountOfCollection + m_length);
            }
            foreach(T elements in collection)
            {
                Add(elements);
            }
        }
        private void IncreaseInTheCapacity(int NewCapacity)
        {
            m_capacity = NewCapacity;
            T[] array = new T[m_capacity];

            for(int i=0; i<m_length; i++)
            {
                array[i] = m_array[i];
            }
            m_array = array;
        }
        private void DecreaseInTheCapacity(int NewCapacity)
        {
            m_capacity = NewCapacity;
            T[] array = new T[m_capacity];

            for (int i = 0; i < m_length; i++)
            {
                array[i] = m_array[i];
            }
            m_array = array;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)m_array).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)m_array).GetEnumerator();
        }
    }
}
