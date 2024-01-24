using System;
using System.Collections.Generic;

namespace CV10Library
{
    // Implementation is in CV8
    public class BinaryContactDAO : IContactDAO
    {
        public void CreateContact(Contact c)
        {
            // Writes the contact into a binary file
            throw new NotImplementedException();
        }

        public void DeleteContact(Contact c)
        {
            // Deleted the contact from a binary file
            throw new NotImplementedException();
        }

        public IEnumerable<Contact> FindAllContacts()
        {
            // Reads all contacts from a binary file
            throw new NotImplementedException();
        }

        public void SaveContact(Contact c)
        {
            // Updates the contact in a binary file
            throw new NotImplementedException();
        }
    }
}
