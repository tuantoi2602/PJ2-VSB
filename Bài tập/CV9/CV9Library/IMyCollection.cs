using System.Collections.Generic;

namespace CV9Library
{
    public interface IMyCollection<T> : IEnumerable<T>
    {
        bool IsEmpty { get; }
        bool IsFull { get; }
        T this[int index] { get; set; }
        T[] Elements { get; }
        MyCollectionState State { get; }
        int Size { get; set; }
        void Clear();
        void Sum(out int result);
        void Add(ref int number, int index);
    }
}
