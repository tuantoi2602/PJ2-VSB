using CV10Library;
using System;

namespace CV10
{
    public class ContactListener
    {
        public void ContactStateChanged(object sender, EventArgs e)
        {
            Console.WriteLine(((Contact)sender).Name + " - changed weight!");
        }
    }
}
