using System.Collections.Generic;

namespace CV10Library
{
    public interface IContactDAO
    {
        void CreateContact(Contact c);
        void DeleteContact(Contact c);
        IEnumerable<Contact> FindAllContacts();
        void SaveContact(Contact c);
    }
}
