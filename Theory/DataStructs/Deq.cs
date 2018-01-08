//
// (c) 2018 Maxim Korolkov
//
// Theory project
//

using System;

namespace Theory
{
    internal sealed class Deq<T>
    {
        private const string EmptyMsg = "Deq is empty.";

        private DoubleNode<T> first;
        private DoubleNode<T> last;
        private int count;

        public int Count => count;

        // add element to end of queue
        public void WriteLast(T data)
        {
            var node = new DoubleNode<T>(data);

            if (first == null)
            {
                first = node;
            }
            else
            {
                last.Next = node;
                node.Previous = last;
            }

            last = node;
            ++count;
        }

        // add element to head of queue
        public void WriteFirst(T data)
        {
            var node = new DoubleNode<T>(data);

            if (last == null)
            {
                last = node;
            }
            else
            {
                first.Previous = node;
                node.Next = first;
            }

            first = node;
            ++count;
        }

        // get element from end of queue
        public T ReadLast()
        {
            if (count == 0)
            {
                first = last = null;

                throw (new InvalidOperationException(EmptyMsg));
            }

            var node = last;
            last = last.Previous;
            
            node.Next = node.Previous = null;
            --count;

            return node.Data;
        }

        // get element from head of queue
        public T ReadFirst()
        {
            if (count == 0)
            {
                first = last = null;

                throw (new InvalidOperationException(EmptyMsg));
            }

            var node = first;
            first = first.Next;
           
            node.Next = node.Previous = null;
            --count;

            return node.Data;
        }
    }
}
