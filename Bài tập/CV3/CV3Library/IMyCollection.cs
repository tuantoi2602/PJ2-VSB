namespace CV3Library
{
    public interface IMyCollection
    {
        bool IsEmpty { get; }
        bool IsFull { get; }
        int[] Emelents { get; }
        void Clear();
    }
}
