using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task4._3.DynamicArray
{
    class DynamicArray<T>:IEnumerable<T>
    {
        private int m_capacity;
        private int m_length;
        private T[] m_array;
        private int m_index;
        public T[] Array
        {
            get;
            set;
        }
        public int Length
        {
            get => m_length;
            private set => m_length = value;
        }

        public int Capacity
        {
            get => m_capacity;
            set
            {
                if (value > m_capacity)
                {
                    this.IncreaseInTheCapacity(value);
                }
                else if (value < m_capacity)
                {
                    this.DecreaseInTheCapacity(value);
                }
                else
                {
                    throw new ArgumentException("Capacity of the array must be greater or equally zero");
                }
            }
        }
        public T this [int index]
        {
            get { return m_array[m_index]; }
            set { m_array[m_index] = value; }
        }

        public DynamicArray()
        {
            this.Array = new T[m_capacity];
            this.Capacity = m_capacity;
            this.Length = 0;
        }
        public DynamicArray(int m_capacity)
        {
            if (m_capacity < 0)
            {
                throw new FormatException("You cannot create an array with a negative number of elements");
            }
            this.Array = new T[m_capacity];
            this.Capacity = m_capacity;
            this.Length = 0;
        }
        public DynamicArray(IEnumerable<T> collection)
        {
            this.Array = new T[collection.Count()];
            this.Length = 0;
            this.Capacity = collection.Count();
            foreach(T element in collection)
            {
                this.Add(element);
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
        private void IncreaseInTheCapacity(int NewCapacity)
        {
            T[] array = new T[m_length];

            for(int i=0; i<m_length; i++)
            {
                array[i] = m_array[i];
            }
            m_array = array;
            m_capacity = m_length = m_array.Length;
        }
        private void DecreaseInTheCapacity(int NewCapacity)
        {
            T[] array = new T[m_length];

            for (int i = 0; i < m_length; i++)
            {
                array[i] = m_array[i];
            }
            m_array = array;
            m_capacity = m_length = m_array.Length;
        }
    }
}
