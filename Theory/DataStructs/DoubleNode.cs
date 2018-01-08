//
// (c) 2018 Maxim Korolkov
//
// Theory project
//

namespace Theory
{
    internal sealed class DoubleNode<T> 
    {
        private  DoubleNode<T> next;
        private DoubleNode<T> previous;
        private T data;

        public DoubleNode<T> Next
        {
            get => next;
            set => next = value;
        }

        public DoubleNode<T> Previous
        {
            get => previous;
            set => previous = value;
        }

        public T Data => data;

        public DoubleNode(T data)
        {
            this.data = data;
        }
    }
}
