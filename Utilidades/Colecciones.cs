using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace Utilidades
{
    public class Colecciones
    {

        public static float[] BubbleSort(float[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        // Swap arr[j] and arr[j+1]
                        float temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }

            return arr;

        }

        public static List<TResult> Map<T, TResult>(List<T> list, Func<T, TResult> func)
        {
            List<TResult> result = new List<TResult>();
            foreach (T item in list)
            {
                TResult mappedItem = func(item);
                result.Add(mappedItem);
            }
            return result;
        }

        public static int CustomReduce(List<int> numbers, Func<int, int, int> reducer, int initialValue)
        {
            int result = initialValue;
            foreach (int number in numbers)
            {
                result = reducer(result, number);
            }
            return result;
        }

        public static List<T> Filter<T>(List<T> list, Func<T, bool> predicate)
        {
            List<T> result = new List<T>();
            foreach (T item in list)
            {
                if (predicate(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public static int Search<T>(T[] arr, T target)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Equals(target))
                {
                    return i;
                }
            }
            return -1;
        }


    }
}
