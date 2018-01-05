//
// (c) 2018 Maxim Korolkov
//
// Theory project
//

using System;
using System.Collections.Generic;
using System.Linq;

namespace Theory
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedListDemo();
            ArrayDemo();
        }

        private static void LinkedListDemo()
        {
            var list = new LinkedList<string>();

            list.Add("Maxer");
            list.Add("Lomaster");
            list.Add("Flomaster");
            EnumerateLinkedList(list, "Original");

            list.Insert(0, "First");
            list.Insert(list.Count, "Last");
            EnumerateLinkedList(list, "Inserted: First, Last");

            list.Remove("Lomaster");
            EnumerateLinkedList(list, "Removed: Lomaster");

            list[2] = "Red Flomaster";
            EnumerateLinkedList(list, "Updated: Flomaster -> Red Flomaster");

            try
            {
                list.Insert(66, "");
            }
            catch (IndexOutOfRangeException err)
            {
                EnumerateLinkedList(list, "Exception was thrown");
                Console.WriteLine(err.Message);
            }
        }
        
        private static void ArrayDemo()
        {
            var unsorted = new[] { 12, 5, 3, 14, 8, 11, 7, 4, 89, 12, 13, 24, 5, 78 };
            var sorted = Sort<int>.Quick(unsorted.ToArray());

            PrintArray(unsorted, nameof(unsorted));
            PrintArray(sorted, nameof(sorted));
        }

        private static void EnumerateLinkedList<T>(LinkedList<T> list, string message = "")
            where T : IComparable<T>
        {
            Console.WriteLine("--- " + message + " ---");

            for (var i = 0; i < list.Count; ++i)
            {
                Console.WriteLine(list[i].ToString() + " ");
            }
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
