using System;

namespace CV8Library
{
    public class PaymentMonitor
    {
        public void InvoiceIsPaid(object sender, InvoiceEventArgs args)
        {
            Console.WriteLine("Message from Invoice: " + args.Message);
        }
    }
}
