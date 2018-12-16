using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Epam.Task4._3.DynamicArray
{
    public class DynamicArray<T> : IEnumerable, IEnumerable<T>
    {
        private int m_capacity;
        private int m_length;
        private T[] m_array;
        public int Length
        {
            get => m_length;
            protected set
            {
                if (value > m_capacity)
                {
                    m_length = value;
                    Capacity = value;
                }
                else if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Length of the array must be greater or equally zero");
                }
                else
                {
                    m_length = value;
                }
            }
        }

        public virtual int Capacity
        {
            get => m_capacity;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Capacity of the array must be greater or equally zero");
                }
                else if (value != m_capacity)
                {
                    m_capacity = value;
                    T[] array = new T[m_capacity];
                    for (int i = 0; i < value; i++)
                    {
                        array[i] = m_array.ElementAtOrDefault(i);
                    }
                    m_array = array;
                    if (m_length > m_capacity)
                    {
                        Length = m_capacity;
                    }
                }
            }
        }
        public virtual T this[int index]
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
                    throw new ArgumentOutOfRangeException("Array has no elements with index less than zero");
                }
            }
            set
            {
                if (index >= 0)
                {
                    if (index < m_capacity)
                    {
                        if (index >= m_length)
                        {
                            m_length = index + 1;
                        }
                        m_array[index] = value;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException($"The number of array elements cannot be greater than its capacity({m_capacity}" +
                            $" elementes)");
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Index of the array can not be less than zero");
                }
            }
        }
        public T[] Array
            {
            get { return m_array; }
            set { m_array = value; }
            }
        public DynamicArray()
        {
            m_array = new T[8];
            m_capacity = 8;
            m_length = 0;
        }
        public DynamicArray(int capacity)
        {
            if (m_capacity < 0)
            {
                throw new ArgumentOutOfRangeException("You cannot create an array with a negative number of elements");
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
            if(m_length >= m_capacity)
            {
                Capacity *= 2;
            }
            m_length++;
            m_array[m_length-1] = element;
        }
        public void AddRange(IEnumerable<T> collection)
        {
            if ((collection.Count<T>() + m_length) > m_capacity)
            {
                Capacity = collection.Count<T>() + m_length;
            }
            foreach(T elements in collection)
            {
                Add(elements);
            }
        }
        public bool Remove(int index)
        {
            if(index>=0 && index<m_length)
            {
                m_array[index] = default(T);
                if((index+1)==m_length)
                {
                    m_length--;
                }
                return true;
            }
            return false;
        }
        public bool Insert(int IndexOfAddElement, T ValueOfAddElement)
        {
            if(IndexOfAddElement >= 0 && IndexOfAddElement < m_capacity)
            {
                if (m_length == m_capacity)
                {
                    m_capacity*=2;
                    m_length++;
                }
                else if((m_length - 1) < IndexOfAddElement)
                {
                    m_length = IndexOfAddElement;
                }
                else if((m_length - 1)>= IndexOfAddElement)
                {
                    m_length++;
                }
                T[] array = new T[m_capacity];
                for (int i = 0; i < m_length;i++)
                {
                    if (i < IndexOfAddElement)
                    {
                        array[i] = m_array.ElementAtOrDefault(i);
                    }
                    else if (i == IndexOfAddElement)
                    {
                        array[i] = ValueOfAddElement;
                    }
                    else
                    {
                        array[i] = m_array.ElementAtOrDefault(i - 1);
                    }
                }
                m_array = array;
                return true;
            }
            else
            {
                return false;
                throw new ArgumentOutOfRangeException("The array has no elements with this index.");
            }
        }
        public virtual IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)m_array).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)m_array).GetEnumerator();
        }
    }
}
