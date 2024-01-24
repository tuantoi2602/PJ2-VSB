namespace CV10Library
{
    public class BinaryDBFactory : IContactDBFactory
    {
        public IContactDAO CreateContactDAO()
        {
            return new BinaryContactDAO();
        }
    }
}
