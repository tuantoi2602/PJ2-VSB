using CV9Library;
using System;
using System.Collections.Generic;

namespace CV9
{
    class Program
    {
        static void Main(string[] args)
        {
            MyQueue<int> queue = new MyQueue<int>();
            queue.Add(1);   // 1
            queue.Add(2);   // 1 2
            queue.Add(3);   // 1 2 3
            queue.Add(4);   // 1 2 3 4
            queue.Add(5);   // 1 2 3 4 5
            queue.Get();    // 2 3 4 5
            ShowCollection(queue, "Queue");


            MyStack<string> stack = new MyStack<string>(10);
            stack.Push("A");    // A
            stack.Push("B");    // A B
            stack.Push("C");    // A B C
            stack.Push("D");    // A B C D
            stack.Push("E");    // A B C D E
            stack.Pop();        // A B C D

            ShowCollection(stack, "Stack");


            int[] items = { 1, 4, 7, 8, 5, 10, 2, 3, 6, 9 };

            Array.Sort(items, new EvenOddSizeComparer());
            ShowCollection(items, "OddEvenSizeComparer");

            Array.Sort(items, new OddEvenSizeDescComparer());
            ShowCollection(items, "OddEvenSizeDescComparer");

            ENCZTranslator translator = new ENCZTranslator();
            Console.WriteLine(translator.Translate("I like chips and beer or whiskey"));
        }

        static void ShowCollection<T>(IEnumerable<T> collection, string message)
        {
            Console.WriteLine(message);

            foreach (T item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
