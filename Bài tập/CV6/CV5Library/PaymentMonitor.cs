using System;

namespace CV5Library
{
    public class PaymentMonitor : IObserver
    {
        public void Display(Invoice invoice)
        {
            Console.WriteLine("Amount {0} was paid.", invoice.Amount);
        }

        public void Update(Subject subject)
        {
            if (subject is Invoice)
                Display((Invoice)subject);
        }
    }
}
