using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ConsoleApplicationForeach
{
    enum Color {Red, Blue, Green}
    // 1 - Red
    // 2 - Blue
    // 3 - Green

    [Flags]
    enum EAccess {Personal=1, Group=2, All=4}

    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine(EAccess.Group | EAccess.Personal );
            return;

            /*
            int[] arr = { 1, 3, 4, 4 };

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
            */

            //foreach (int item in arr)
            //{
            //    Console.WriteLine(item);
            //}

            //IEnumerator en = arr.GetEnumerator();
            //while (en.MoveNext())
            //{
            //    Console.WriteLine(en.Current);
            //}


        }
    }
}
