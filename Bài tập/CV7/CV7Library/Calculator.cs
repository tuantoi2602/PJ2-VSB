using System;

namespace CV7Library
{
    public delegate int Operation(int x, int y);

    public class Calculator
    {
        public event EventHandler<SetXYEventArgs> OnSetXY;

        public int X { get; private set; }
        public int Y { get; private set; }

        public void SetXY(int x, int y)
        {
            X = x;
            Y = y;

            if (OnSetXY != null)
            {
                SetXYEventArgs args = new SetXYEventArgs();
                args.Date = DateTime.Now;
                args.Message = String.Format("X = {0}; Y = {1}", x, y);

                OnSetXY(this, args);
            }
        }

        public void Write(int x, int y, Operation op)
        {
            Console.WriteLine("Result is {0}", op(x, y));
        }
    }
}
