namespace CV4Library
{
    public interface IMyStack<T> : IMyCollection<T>
    {
        void Push(T item);
        T Pop();
        T Top { get; }
    }
}
