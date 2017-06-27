using System;
using System.Collections;
using System.Collections.Generic;

namespace LinearDataStructures.List
{
    public class List<T> : IEnumerable<T>
    {
        private T[] buffer;
        private int size;
        private readonly int minCapacity = 4;

        public List()
        {
            buffer = null;
            size = 0;
        }

        public List(int size)
        {
            if (size < minCapacity)
            {
                throw new ArgumentException("Cant create list");
            }
            this.size = 0;
            Reserve(size);
        }
        //Returns last element
        public T Last
        {
            get
            {
                return buffer[size - 1];
            }
            set
            {
                buffer[size - 1] = value;
            }
        }

        //Indexer
        public T this[int index]
        {
            get
            {
                return buffer[index];
            }
            set
            {
                buffer[index] = value;
            }
        }

        //Adds element at the end
        public void Add(T value)
        {
            if (buffer == null)
            {
                buffer = new T[minCapacity];
            }
            else if (size == buffer.Length)
            {
                Reserve(size * 2);
            }

            buffer[size] = value;
            ++size;
        }

        //Adds element at index 
        public void AddElementAt(int index, T value)
        {
            if (index == size)
            {
                Add(value);
                return;
            }

            for (int i = size - 2; i > index; --i)
            {
                buffer[i] = buffer[i - 1];
            }

            buffer[index] = value;

        }

        //Remove last element
        public void RemoveLast()
        {
            if (size == 0)
            {
                throw new IndexOutOfRangeException("Empty list");
            }

            --size;
            buffer[size] = default(T);
        }

        //Remove at index
        public void RemoveAt()
        {
            for (int i = 0; i < size - 1; ++i)
            {
                buffer[i] = buffer[i + 1];
            }

            RemoveLast();
        }

        //Remove range
        public void RemoveRange(int from, int to)
        {
            int range = from - to;
            for (int i = from; i < size - range; ++i)
            {
                buffer[i] = buffer[i + range];
            }

            for (int i = 0; i < range; ++i)
            {
                RemoveLast();
            }
        }

        //Shrink buffer
        public void Shrink()
        {
            Reserve(size);
        }

        //Allocate memory
        private void Reserve(int newSize)
        {
            if (newSize < size)
            {
                return;
            }

            var newBuffer = new T[newSize];
            for (int i = 0; i < size; i++)
            {
                newBuffer[i] = buffer[i];
            }

            buffer = newBuffer;
        }

        //Clear
        public void Clear()
        {
            size = 0;
            buffer = new T[minCapacity];
        }

        //IEnumberable implementation
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < size; i++)
            {
                yield return buffer[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
