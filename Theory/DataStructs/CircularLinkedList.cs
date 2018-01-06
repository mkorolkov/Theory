//
// (c) 2018 Maxim Korolkov
//
// Theory project
//

using System;

namespace Theory
{
    internal class CircularLinkedList<T> where T : IComparable<T>
    {
        private const string OutOfRangeMsg = "CircularLinkedList: index={0} out of range or list is empty.";

        private Node<T> head;
        private int count;

        public int Count => count;
        
        public void Add(T data)
        {
            if (head == null)
            {
                head = new Node<T>(data);
                head.Next = head;
            }
            else
            {
                var lastNode = GetNodeAt(count - 1);
                lastNode.Next = new Node<T>(data, lastNode.Next);
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
            var previousNode = GetNodeAt(count - 1);

            for (var i = 0; i < count; ++i)
            {
                if (currentNode.Data.CompareTo(data) == 0)
                {
                    if (count == 1)
                    {
                        head = null;
                    }
                    else
                    {
                        previousNode.Next = currentNode.Next;

                        if (i == 0)
                        {
                            head = currentNode.Next;
                        }
                    }

                    --count;
                    break;
                }

                previousNode = currentNode;
                currentNode = currentNode.Next;
            }
        }

        public void Insert(int index, T data)
        {
            if (index == 0)
            {
                var lastNode = GetNodeAt(count - 1);
                lastNode.Next = new Node<T>(data, head);

                head = lastNode.Next;
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

        private Node<T> GetNodeAt(int index)
        {
            if (index < 0 || index >= count || head == null)
            {
                throw (new IndexOutOfRangeException(String.Format(OutOfRangeMsg, index)));
            }

            var currentNode = head;

            for (var i = 0; i < count && i != index; ++i)
            {
                currentNode = currentNode.Next;
            }

            return currentNode;
        }
    }
}
