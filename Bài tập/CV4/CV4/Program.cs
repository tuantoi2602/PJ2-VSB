using CV4Library;
using System;

namespace CV4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testing generics with int collection
            MyQueue<int> qInt = new MyQueue<int>(3);
            qInt.Add(2);
            qInt.Add(6);
            qInt.Add(1);
            Console.WriteLine(qInt.Get() * qInt.Get());

            // Testing generics with string collection
            MyQueue<string> qString = new MyQueue<string>(8);
            qString.Add("Item 1");
            qString.Add("Item 2");
            Console.WriteLine("First item: " + qString.Get());

            // Resize test
            Console.WriteLine(qInt.Size); // 3
            qInt.Size = 5;
            Console.WriteLine(qInt.Size); // 5

            try
            {
                qInt.Size = 3;
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.WriteLine(qInt.Size); // 5 (not 3!)

            // Indexer test
            Console.WriteLine(qInt[1]); // 0 (not set yet)
            qInt[1] = 42;
            Console.WriteLine(qInt[1]); // 42
            qInt[10] = 2; // Size of the collection should be extended
            Console.WriteLine(qInt.Size); // 20

            // Testing collection state
            MyStack<int> stack = new MyStack<int>(5);
            ShowCollectionState(stack);
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            ShowCollectionState(stack);
            stack.Push(4);
            stack.Push(5);
            ShowCollectionState(stack);
            stack.Pop();
            stack.Pop();

            // ToString test
            Console.WriteLine(stack);

            // Out parameter test
            int sum;
            stack.Sum(out sum);
            Console.WriteLine(sum);

            // Ref parameter test
            Console.WriteLine(stack[2]); // 3
            int number = 4;
            stack.Add(ref number, 2);
            Console.WriteLine(number); // 3 + 4 = 7
        }

        static void ShowCollectionState<T>(IMyCollection<T> collection)
        {
            switch (collection.State)
            {
                case MyCollectionState.Empty:
                    Console.WriteLine("Collection is empty.");
                    break;
                case MyCollectionState.Full:
                    Console.WriteLine("Collection is full.");
                    break;
                case MyCollectionState.PartiallyFull:
                    Console.WriteLine("Collection is neither empty nor full.");
                    break;
            }
        }
    }
}
