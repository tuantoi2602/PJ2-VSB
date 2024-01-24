namespace CV2Library
{
    public interface IMyCollection
    {
        bool IsEmpty { get; }
        bool IsFull { get; }
        void Clear();
    }
}
