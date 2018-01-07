//
// (c) 2018 Maxim Korolkov
//
// Theory project
//

using System;

namespace Theory
{
    internal sealed class FixedStack<T>
    {
        private const string OverflowMsg = "FixedStack is full. Max size={0}";
        private const string EmptyMsg = "FixedStack is empty.";

        private T[] array;
        private int count;

        public int Count => count;

        public FixedStack(int size)
        {
            array = new T[size];
        }

        public void Push(T data)
        {
            if (count >= array.Length)
            {
                throw (new InvalidOperationException(String.Format(OverflowMsg, array.Length)));
            }

            array[count++] = data;
        }

        public T Pop()
        {
            ThrowIfEmpty();

            var data = array[--count];
            array[count] = default(T);

            return data;
        }

        public T Peek()
        {
            ThrowIfEmpty();
            return array[count - 1];
        }

        private void ThrowIfEmpty()
        {
            if (count <= 0)
            {
                throw (new InvalidOperationException(EmptyMsg));
            }
        }
    }
}
