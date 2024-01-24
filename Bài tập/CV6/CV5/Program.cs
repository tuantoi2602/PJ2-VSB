using CV5Library;
using System;

namespace CV5
{
    class Program
    {
        static void Main(string[] args)
        {
            Invoice inv = new Invoice();
            inv.Amount = 666;
            inv.DueDate = DateTime.Now.AddDays(1);

            SMSGate gate1 = new SMSGate("123456789");
            inv.Attach(gate1);
            SMSGate gate2 = new SMSGate("112233445");
            inv.Attach(gate2);
            inv.Detach(gate2); // Test Detach
            PaymentMonitor monitor = new PaymentMonitor();
            inv.Attach(monitor);

            inv.Paid();
        }
    }
}
