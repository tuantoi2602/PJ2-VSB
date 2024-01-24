namespace CV3Library
{
    public interface IMyQueue : IMyCollection
    {
        void Add(int item);
        int Get();
    }
}
