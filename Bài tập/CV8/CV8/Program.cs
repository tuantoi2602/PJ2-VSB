using CV8Library;
using System;
using System.Collections.Generic;

namespace CV8
{
    class Program
    {
        static void Main(string[] args)
        {
            TestObserver();
            TestFile();
        }

        static void TestObserver()
        {
            PaymentMonitor monitor = new PaymentMonitor();

            Invoice invoice = new Invoice();
            invoice.Amount = 500;
            invoice.DueDate = DateTime.Now.AddDays(2);

            invoice.InvoicePaid += monitor.InvoiceIsPaid;

            invoice.Paid();
        }

        static void TestFile()
        {
            Contact c1 = new Contact() { Name = "Contact 1", Age = 25, Email = "c1@vsb.cz", Weight = 85, Alive = true };
            Contact c2 = new Contact() { Name = "Contact 2", Age = 90, Email = "c2@vsb.cz", Weight = 70, Alive = false };
            Contact c3 = new Contact() { Name = "Contact 3", Age = 30, Email = "c3@vsb.cz", Weight = 105, Alive = true };

            List<Contact> contacts = new List<Contact>() { c1, c2, c3 };

            Contact.SaveToTextFile(contacts);
            Contact.SaveToBinaryFile(contacts);

            List<Contact> textContacts = Contact.LoadFromTextFile();
            List<Contact> binaryContacts = Contact.LoadFromBinaryFile();

            foreach (Contact contact in textContacts)
            {
                Console.WriteLine(contact.Name + " " + contact.Email);
            }

            foreach (Contact contact in binaryContacts)
            {
                Console.WriteLine(contact.Name + " " + contact.Age);
            }
        }
    }
}
