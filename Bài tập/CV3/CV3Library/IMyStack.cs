namespace CV3Library
{
    public interface IMyStack : IMyCollection
    {
        void Push(int item);
        int Pop();
        int Top { get; }
    }
}
