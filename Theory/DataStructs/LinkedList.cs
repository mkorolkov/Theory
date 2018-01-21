//
// (c) 2018 Maxim Korolkov
//
// Theory project
//

using System;

namespace Theory
{
    internal sealed class LinkedList<T> where T : IComparable<T>
    {
        private const string OutOfRangeMsg = "LinkedList: index={0} out of range or list is empty.";

        private Node<T> head;
        private int count;
        
        public int Count => count;
        
        public void Add(T data)
        {
            if (head == null)
            {
                head = new Node<T>(data);
            }
            else
            {
                var currentNode = head;

                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }

                currentNode.Next = new Node<T>(data);
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
            Node<T> previousNode = null;
            
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
            if (index == 0)
            {
                head = new Node<T>(data, head);
            }
            else
            {
                var node = GetNodeAt(index - 1);
                node.Next = new Node<T>(data, node.Next);
            }

            ++count;
        }

        public T this[int index]
        {
            get => GetNodeAt(index).Data;
            set => GetNodeAt(index).Data = value;
        }

        public void Reverse()
        {
            var current = head;
            Node<T> previous = null;

            while (current != null)
            {
                var next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }

            head = previous;
        }

        // just for test
        public void NotEffectiveReverse()
        {
            var i = 0;
            var j = count - 1;

            while (i < j)
            {
                var left = GetNodeAt(i);
                var right = GetNodeAt(j);

                Remove(left.Data);
                Remove(right.Data);

                Insert(i, right.Data);
                Insert(j, left.Data);

                ++i; --j;
            }
        }

        private Node<T> GetNodeAt(int index)
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
