using CV10Library;
using System;
using System.Collections.Generic;

namespace CV10
{
    class Program
    {
        static void Main(string[] args)
        {
            Contact c1 = new Contact() { Name = "Contact 1", Age = 25, Email = "c1@vsb.cz", Weight = 85, IsMarried = true };
            Contact c2 = new Contact() { Name = "Contact 2", Age = 90, Email = "c2@vsb.cz", Weight = 70, IsMarried = false };
            Contact c3 = new Contact() { Name = "Contact 3", Age = 30, Email = "c3@vsb.cz", Weight = 105, IsMarried = true };

            

            List<Contact> contacts = new List<Contact>() { c1, c2, c3 };

            Contact.SerializeToXmlFile(contacts);
            Contact.SerializeToBinaryFile(contacts);

            List<Contact> xmlContacts = Contact.DeserializeFromXmlFile();
            List<Contact> sbinaryContacts = Contact.DeserializeFromBinaryFile();

            foreach (Contact contact in xmlContacts)
            {
                Console.WriteLine(contact.Name + " " + contact.Email);
            }

            foreach (Contact contact in sbinaryContacts)
            {
                Console.WriteLine(contact.Name + " " + contact.Age);
            }
        }
    }
}
