using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV9Library
{
    public class MyQueue<T> : IMyQueue<T>
    {
        private LinkedList<T> array = new LinkedList<T>();

        public bool IsEmpty
        {
            get
            {
                return array.Count == 0;
            }
        }

        public bool IsFull
        {
            get
            {
                return false;
            }
        }

        public T[] Elements
        {
            get
            {
                T[] result = new T[array.Count];
                array.CopyTo(result, 0);
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
                return array.Count;
            }
            set
            {
                throw new InvalidOperationException("Set Queue size is not allowed!");
            }
        }

        public T this[int index]
        {
            get
            {
                return array.ElementAt(index);
            }
            set
            {
                LinkedListNode<T> node = array.First;

                for (int i = 1; i <= index; i++)
                    node = node.Next;

                node.Value = value;
            }
        }

        public void Add(T item)
        {
            array.AddLast(item);
        }

        public void Clear()
        {
            array.Clear();
        }

        public T Get()
        {
            LinkedListNode<T> result = array.First;
            array.RemoveFirst();
            return result.Value;
        }

        public void Sum(out int result)
        {
            if (typeof(T) == typeof(int))
            {
                result = 0;

                foreach (var item in array)
                {
                    result += Convert.ToInt32(item);
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

            for (int i = 0; i < Size; i++)
            {
                if (i != 0)
                    result.Append(' ');

                result.Append(this[i]);
            }

            return result.ToString();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in array)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
