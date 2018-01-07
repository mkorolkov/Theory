//
// (c) 2018 Maxim Korolkov
//
// Theory project
//

using System;

namespace Theory
{
    internal sealed class Stack<T>
    {
        private const string EmptyMsg = "Stack is empty.";

        private Node<T> head;
        private int count;

        public int Count => count;
        
        public void Push(T data)
        {
            head = new Node<T>(data, head);
            ++count;
        }

        public T Pop()
        {
            ThrowIfEmpty();

            var node = head;
            head = node.Next;
            --count;

            return node.Data;
        }

        public T Peek()
        {
            ThrowIfEmpty();

            return head.Data;
        }

        private void ThrowIfEmpty()
        {
            if (head == null)
            {
                throw (new InvalidOperationException(EmptyMsg));
            }
        }
    }
}
