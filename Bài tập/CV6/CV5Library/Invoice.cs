using System;

namespace CV5Library
{
    public class Invoice : Subject
    {
        public float Amount { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime DueDate { get; set; }

        public void Paid()
        {
            PaidDate = DateTime.Now;
            Notify();
        }

        public override string ToString()
        {
            return String.Format("Invoice with due date {0} and amount {1} paid on {2}", DueDate, Amount, PaidDate);
        }
    }
}
