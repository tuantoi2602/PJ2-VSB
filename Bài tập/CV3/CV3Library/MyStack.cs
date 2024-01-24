using System;

namespace CV3Library
{
    public class MyStack : IMyStack
    {
        private int[] array = new int[5];
        private int index = -1; // Pointer to top of the stack

        public int[] Emelents
        {
            get
            {
                int[] result = new int[index + 1];
                Array.Copy(array, result, index + 1);
                return result;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return index == -1;
            }
        }

        public bool IsFull
        {
            get
            {
                return index == array.Length - 1;
            }
        }

        public int Top
        {
            get
            {
                return array[index];
            }
        }

        public void Clear()
        {
            index = -1;
        }

        public int Pop()
        {
            //int result = array[index];
            //index--;
            //return result;

            return array[index--];
        }

        public void Push(int item)
        {
            //array[index] = item;
            //index++;

            array[++index] = item;
        }
    }
}
