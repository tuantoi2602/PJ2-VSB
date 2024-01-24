using CV1Library;
using System;

namespace CV1
{
    class Program
    {
        static void Main(string[] args)
        {
            Greeter greeter = new Greeter();

            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine(greeter.SayHello(args[i]));
            }

            string input;

            while ((input = Console.ReadLine()) != "exit")
            {
                Console.WriteLine(greeter.SayHello(input));
            }
        }
    }
}
