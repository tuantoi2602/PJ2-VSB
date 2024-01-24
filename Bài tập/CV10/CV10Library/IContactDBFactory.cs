namespace CV10Library
{
    public interface IContactDBFactory
    {
        IContactDAO CreateContactDAO();
    }
}
