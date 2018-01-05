//
// (c) 2018 Maxim Korolkov
//
// Theory project
//

using System;
using System.Linq;

namespace Theory
{
    class Program
    {
        static void Main(string[] args)
        {
            var unsorted = new [] { 12, 5, 3, 14, 8, 11, 7, 4, 89, 12, 13, 24, 5, 78 };
            var sorted = Sort<int>.Quick(unsorted.ToArray());
            
            PrintArray(unsorted, nameof(unsorted));
            PrintArray(sorted, nameof(sorted));
        }

        private static void PrintArray<T>(T[] array, string message = "")
        {
            Console.WriteLine("--- " + message + " ---");

            for (var i = 0; i < array.Length; ++i)
            {
                Console.Write(array[i].ToString() + " ");
            }

            Console.WriteLine();
        }
    }
}
