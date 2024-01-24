using CV7Library;
using System;

namespace CV7
{
    class Program
    {
        static int Plus(int x, int y)
        {
            return x + y;
        }

        static int Minus(int x, int y)
        {
            return x - y;
        }

        static void MyMethod(object sender, SetXYEventArgs args)
        {
            Console.WriteLine("On {0} was set {1}", args.Date, args.Message);
        }

        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            calc.SetXY(2, 3);
            calc.Write(5, 3, Plus);
            calc.Write(5, 3, Minus);

            calc.OnSetXY += MyMethod;

            calc.SetXY(666, 42);
        }
    }
}
