using System.Collections;
using System.Collections.Generic;


namespace Epam.Task4._4.DynamicArray_HardcoreMode_
{
    class GetEnumerator<T> : DynamicArrayHardcoreMode<T>,IEnumerator<T>
    {
        private int index = -1;
        private CycledDynamicArray<T> collection;
        public GetEnumerator(CycledDynamicArray<T> collection)
        {
            this.collection=collection;
        }
        public T Current
        {
            get
            {
                return collection[index];
            }
        }
        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public void Dispose() {}

        public bool MoveNext()
        {
            index++;
            if(index>=collection.Length)
            {
                index = 0;
            }
            return true;
        }

        public void Reset()
        {
            index = 0;
        }
    }
}
