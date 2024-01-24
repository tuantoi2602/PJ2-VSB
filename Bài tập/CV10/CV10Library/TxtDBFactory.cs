namespace CV10Library
{
    public class TxtDBFactory : IContactDBFactory
    {
        public IContactDAO CreateContactDAO()
        {
            return new TxtContactDAO();
        }
    }
}
