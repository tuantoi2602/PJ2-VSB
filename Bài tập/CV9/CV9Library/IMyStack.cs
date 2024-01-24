namespace CV9Library
{
    public interface IMyStack<T> : IMyCollection<T>
    {
        void Push(T item);
        T Pop();
        T Top { get; }
    }
}
