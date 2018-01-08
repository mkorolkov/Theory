//
// (c) 2018 Maxim Korolkov
//
// Theory project
//

using System;

namespace Theory
{
    internal sealed class Queue<T>
    {
        private const string EmptyMsg = "Queue is empty.";

        Node<T> first;
        Node<T> last;
        private int count;

        public int Count => count;

        public void Write(T data)
        {
            var node = new Node<T>(data);

            if (first == null)
            {
                first = node;
            }
            else
            {
                last.Next = node;
            }

            last = node;
            ++count;
        }

        public T Read()
        {
            if (first == null)
            {
                throw (new InvalidOperationException(EmptyMsg));
            }

            var node = first;
            first = first.Next;

            if (first == null)
            {
                last = null;
            }

            node.Next = null;
            --count;

            return node.Data;
        }    
    }
}
