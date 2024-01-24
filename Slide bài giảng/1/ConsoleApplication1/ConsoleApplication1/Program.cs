using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    [Flags]
    enum EAccess { Personal = 1, Group = 2, All = 4 }

    class Program
    {
        static void Main(string[] args)
        {
            EAccess en = EAccess.Group | EAccess.Personal;
            Console.WriteLine(en);
        }
    }
}
