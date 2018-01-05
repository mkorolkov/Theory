//
// (c) 2018 Maxim Korolkov
//
// Theory project
//

using System;

namespace Theory
{
    internal class LinkedList<T> where T : IComparable<T>
    {
        private const string OutOfRangeMsg = "LinkedList: index={0} out of range or list is empty.";

        private Node head;
        private int count;
        
        public int Count => count;

        private class Node
        {
            private T data;
            private Node next;
            
            public T Data
            {
                get => data;
                set => data = value;
            }

            public Node Next
            {
                get => next;
                set => next = value;
            }

            public Node(T data) : this(data, null) {}

            public Node(T data, Node next)
            {
                this.data = data;
                this.next = next;
            }
        }
        
        public void Add(T data)
        {
            if (head == null)
            {
                head = new Node(data);
            }
            else
            {
                var currentNode = head;

                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }

                currentNode.Next = new Node(data);
            }

            ++count;
        }

        public void Remove(T data)
        {
            if (head == null)
            {
                return;
            }

            var currentNode = head;
            Node previousNode = null;
            
            while (currentNode != null && currentNode.Data.CompareTo(data) != 0)
            {
                previousNode = currentNode;
                currentNode = currentNode.Next;
            }

            if (currentNode != null)
            {
                if (previousNode != null)
                {
                    previousNode.Next = currentNode.Next;
                }
                else
                {
                    head = currentNode.Next;
                }

                --count;
            }
        }

        public void Insert(int index, T data)
        {
            if (index - 1 < 0)
            {
                head = new Node(data, head);
            }
            else
            {
                var node = GetNodeAt(index - 1);
                node.Next = new Node(data, node.Next);
            }

            ++count;
        }

        public T this[int index]
        {
            get => GetNodeAt(index).Data;
            set => GetNodeAt(index).Data = value;
        }

        private Node GetNodeAt(int index)
        {
            if (index >= count || index < 0 || head == null)
            {
                throw (new IndexOutOfRangeException(String.Format(OutOfRangeMsg, index)));
            }

            var currentNode = head;
            var currentCount = 0;

            while (currentNode != null && currentCount != index)
            {
                currentNode = currentNode.Next;
                ++currentCount;
            }

            return currentNode;
        }
    }
}
