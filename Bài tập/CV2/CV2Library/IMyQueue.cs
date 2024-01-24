namespace CV2Library
{
    public interface IMyQueue : IMyCollection
    {
        void Add(int item);
        int Get();
    }
}
