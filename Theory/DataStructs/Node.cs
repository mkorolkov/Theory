//
// (c) 2018 Maxim Korolkov
//
// Theory project
//

namespace Theory
{
    internal class Node<T>
    {
        private T data;
        private Node<T> next;

        public T Data
        {
            get => data;
            set => data = value;
        }

        public Node<T> Next
        {
            get => next;
            set => next = value;
        }

        public Node(T data) : this(data, null) { }

        public Node(T data, Node<T> next)
        {
            this.data = data;
            this.next = next;
        }
    }
}
