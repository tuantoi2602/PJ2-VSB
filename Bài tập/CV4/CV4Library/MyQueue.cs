using System;
using System.Text;

namespace CV4Library
{
    public class MyQueue<T> : IMyQueue<T>
    {
        private T[] array;
        private int last = 0; // Pointer to the last added element
        private int first = 0; // Pointer to the first added element
        private int size = 0; // Number of stored items

        public MyQueue(int size)
        {
            array = new T[size];
        }

        public bool IsEmpty
        {
            get
            {
                return size == 0;
            }
        }

        public bool IsFull
        {
            get
            {
                return size == array.Length;
            }
        }

        public T[] Elements
        {
            get
            {
                T[] result = new T[size];

                for (int i = 0; i < size; i++)
                {
                    result[i] = array[(first + i) % array.Length];
                }

                return result;
            }
        }

        public MyCollectionState State
        {
            get
            {
                if (IsEmpty)
                    return MyCollectionState.Empty;
                if (IsFull)
                    return MyCollectionState.Full;

                return MyCollectionState.PartiallyFull;
            }
        }

        public int Size
        {
            get
            {
                return array.Length;
            }
            set
            {
                if (value > array.Length)
                    Array.Resize(ref array, value);
                else if (value < array.Length)
                    throw new ApplicationException("You are attempting to shrink the collection!");
            }
        }

        public T this[int index]
        {
            get
            {
                if (index >= Size)
                    Size = index * 2;

                return array[(first + index) % array.Length];
            }
            set
            {
                if (index >= Size)
                    Size = index * 2;

                array[(first + index) % array.Length] = value;
            }
        }

        public void Add(T item)
        {
            array[last++] = item;
            size++;

            if (last == array.Length)
                last = 0;
        }

        public void Clear()
        {
            last = 0;
            first = 0;
            size = 0;
        }

        public T Get()
        {
            T result = array[first++];
            size--;

            if (first == array.Length)
                first = 0;

            return result;
        }

        public void Sum(out int result)
        {
            if (typeof(T) == typeof(int))
            {
                result = 0;

                for (int i = 0; i < size; i++)
                {
                    result += Convert.ToInt32(array[(first + i) % array.Length]);
                }
            }
            else
            {
                throw new InvalidOperationException("This operation can be done only on integer collection!");
            }
        }

        public void Add(ref int number, int index)
        {
            if (typeof(T) == typeof(int))
            {
                number += Convert.ToInt32(this[index]);
            }
            else
            {
                throw new InvalidOperationException("This operation can be done only on integer collection!");
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < array.Length; i++)
            {
                if (i != 0)
                    result.Append(' ');

                if (i < size)
                    result.Append("'" + array[(first + i) % array.Length] + "'");
                else
                    result.Append(array[(first + i) % array.Length]);
            }

            return result.ToString();
        }
    }
}
