//
// (c) 2018 Maxim Korolkov
//
// Theory project
//

using System;

namespace Theory
{
    internal static class Sort<T> where T : IComparable<T>
    {
        // complexity = Θ(n^2)
        public static T[] Selection(T[] array, bool ascending = true)
        {
            for (var i = 0; i < array.Length; ++i)
            {
                var tempIndex = i;
                
                for (var j = i + 1; j < array.Length; ++j)
                {
                    var compare = array[j].CompareTo(array[tempIndex]);
                    
                    if ((ascending && compare < 0) || (!ascending && compare > 0))
                    {
                        tempIndex = j;
                    }
                }

                var tempValue = array[i];
                array[i] = array[tempIndex];
                array[tempIndex] = tempValue;
            }

            return array;
        }

        // complexity = Θ(n^2)
        public static T[] Buble(T[] array, bool ascending = true)
        {
            for (var i = 0; i < array.Length - 1; ++i)
            {
                for (var j = i + 1; j < array.Length; ++j)
                {
                    var compare = array[j].CompareTo(array[i]);

                    if ((ascending && compare < 0) || (!ascending && compare > 0))
                    {
                        var temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }

            return array;
        }

        // complexity = Θ(n^2)
        public static T[] Insertion(T[] array, bool ascending = true)
        {
            for (var i = 0; i < array.Length; ++i)
            {
                var temp = array[i];
                var j = i - 1;
                
                for (; j >= 0 && Compare(array[j], temp, ascending); --j)
                {
                    array[j + 1] = array[j];
                }

                array[j + 1] = temp;
            }

            return array;

            bool Compare(T a, T b, bool asc)
            {
                var compare = a.CompareTo(b);

                return (asc && compare > 0) || (!asc && compare < 0);
            }
        }

        // complexity = Θ(nlogn)
        public static T[] Quick(T[] array)
        {
            sort(array, 0, array.Length - 1);

            return array;

            void sort(T[] arr, int min, int max)
            {
                if (min < max)
                {
                    var med = partition(arr, min, max);
                    sort(arr, min, med - 1);
                    sort(arr, med, max);
                }
            }

            int partition(T[] arr, int min, int max)
            {
                var pivot = arr[(min + max) / 2];
                var i = min;
                var j = max;

                while (i <= j)
                {
                    while (arr[i].CompareTo(pivot) < 0) ++i;
                    while (arr[j].CompareTo(pivot) > 0) --j;

                    if (i <= j)
                    {
                        var temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;

                        ++i; --j;
                    }
                }

                return i;
            }
        }
    }
}
