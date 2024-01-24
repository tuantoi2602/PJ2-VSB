using CV2Library;
using System;

namespace CV2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Uncomment arbitrary line

            //TestStack();
            //TestQueue();
        }

        static void TestQueue()
        {
            IMyQueue queue = new MyQueue();

            // Queue should be empty after init
            ShowCollectionState(queue);

            queue.Add(1); // 1
            queue.Add(2); // 1 2
            queue.Add(3); // 1 2 3

            // Queue should be neither empty nor full now
            ShowCollectionState(queue);

            queue.Add(4); // 1 2 3 4
            queue.Add(5); // 1 2 3 4 5

            // Queue should be full now
            ShowCollectionState(queue);

            // Get 3 items
            Console.WriteLine(queue.Get()); // 2 3 4 5
            Console.WriteLine(queue.Get()); // 3 4 5
            Console.WriteLine(queue.Get()); // 4 5

            // Enqueue another 3 items to check circularity
            queue.Add(6); // 4 5 6
            queue.Add(7); // 4 5 6 7
            queue.Add(8); // 4 5 6 7 8

            // Empty the queue
            Console.WriteLine(queue.Get()); // 5 6 7 8
            Console.WriteLine(queue.Get()); // 6 7 8
            Console.WriteLine(queue.Get()); // 7 8
            Console.WriteLine(queue.Get()); // 8
            Console.WriteLine(queue.Get());

            // Queue should be empty now
            ShowCollectionState(queue);
        }

        static void TestStack()
        {
            IMyStack stack = new MyStack();

            // Stack should be empty after init
            ShowCollectionState(stack);

            stack.Push(1); // 1
            stack.Push(2); // 1 2
            stack.Push(3); // 1 2 3

            // Stack should be neither empty nor full now
            ShowCollectionState(stack);

            stack.Push(4); // 1 2 3 4
            stack.Push(5); // 1 2 3 4 5

            // Stack should be full now
            ShowCollectionState(stack);

            // Write only the last added item (remove nothing)
            Console.WriteLine(stack.Top); // 1 2 3 4 5

            // Empty the stack
            Console.WriteLine(stack.Pop()); // 1 2 3 4
            Console.WriteLine(stack.Pop()); // 1 2 3
            Console.WriteLine(stack.Pop()); // 1 2
            Console.WriteLine(stack.Pop()); // 1
            Console.WriteLine(stack.Pop());

            // Stack should be empty now
            ShowCollectionState(stack);
        }

        static void ShowCollectionState(IMyCollection collection)
        {
            Console.WriteLine(collection.IsEmpty);
            Console.WriteLine(collection.IsFull);
        }
    }
}
