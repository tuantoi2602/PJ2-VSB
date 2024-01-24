using System;

namespace CV8Library
{
    public class Invoice : ISubject
    {
        public float Amount { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime DueDate { get; set; }

        public event EventHandler<InvoiceEventArgs> InvoicePaid;

        public void Paid()
        {
            PaidDate = DateTime.Now;
            Notify();
        }

        public void Notify()
        {
            if (InvoicePaid != null)
            {
                InvoiceEventArgs args = new InvoiceEventArgs();
                args.Message = String.Format("Invoice with due date {0} and amount {1} paid on {2}", DueDate, Amount, PaidDate);
                InvoicePaid(this, args);
            }
        }
    }
}
