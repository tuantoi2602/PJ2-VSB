using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV9Library
{
    public class EvenOddSizeComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x % 2 == 0 && y % 2 != 0)
                return -1;
            if (x % 2 != 0 && y % 2 == 0)
                return 1;

            return x.CompareTo(y);
        }
    }

    public class OddEvenSizeDescComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x % 2 == 0 && y % 2 != 0)
                return 1;
            if (x % 2 != 0 && y % 2 == 0)
                return -1;

            return y.CompareTo(x);
        }
    }
}
