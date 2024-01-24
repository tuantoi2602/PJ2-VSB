using System;

namespace CV3Library
{
    public class MyQueue : IMyQueue
    {
        private int[] array = new int[5];
        private int last = 0; // Pointer to the last added element
        private int first = 0; // Pointer to the first added element
        private int size = 0; // Number of stored items

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

        public int[] Emelents
        {
            get
            {
                int[] result = new int[size];

                for (int i = 0; i < size; i++)
                {
                    result[i] = array[(first + i) % array.Length];
                }

                return result;
            }
        }

        public void Add(int item)
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

        public int Get()
        {
            int result = array[first++];
            size--;

            if (first == array.Length)
                first = 0;

            return result;
        }
    }
}
