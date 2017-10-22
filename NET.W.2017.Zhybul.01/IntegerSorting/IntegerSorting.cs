using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegerLibrary
{
    public class IntegerSorting
    {

        public static void MergeSort(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length < 2)
            {
                return;
            }

            MergeSort(array, 0, array.Length - 1);
        }
        public static void MergeSort(int[] array, int left, int right)
        {
            if (right - left < 1)
            {
                return;
            }

            int delimiter = left + (right - left + 1) / 2;

            MergeSort(array, left, delimiter - 1);
            MergeSort(array, delimiter, right);

            Merge(array, left, right, delimiter);
        }
        public static void QuickSort(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length < 2)
            {
                return;
            }

            QuickSort(array, 0, array.Length - 1);
        }
        public static void QuickSort(int[] arr, int left, int right)
        {
            int index = Partition(arr, left, right);
            if (left < index - 1)
                QuickSort(arr, left, index - 1);
            if (index < right)
                QuickSort(arr, index, right);
        }

        private static void Merge(int[] array, int left, int right, int delimiter)
        {
            int[] arrayCopy = new int[right - left + 1];

            for (int i = left; i <= right; i++)
            {
                arrayCopy[i - left] = array[i];
            }

            int l1 = left, r1 = delimiter;
            int currentIndex = left;

            while (l1 < delimiter && r1 <= right)
            {
                if (arrayCopy[l1 - left] < arrayCopy[r1 - left])
                {
                    array[currentIndex++] = arrayCopy[l1++ - left];
                }
                else
                {
                    array[currentIndex++] = arrayCopy[r1++ - left];
                }
            }

            for (int i = l1; i < delimiter; i++)
            {
                array[currentIndex++] = arrayCopy[i - left];
            }

            for (int i = r1; i <= right; i++)
            {
                array[currentIndex++] = arrayCopy[i - left];
            }

        }

        private static int Partition(int[] arr, int left, int right)
        {
            int i = left, j = right;
            int tmp;
            int middle = arr[(left + right) / 2];

            while (i <= j)
            {
                while (arr[i] < middle)
                    i++;
                while (arr[j] > middle)
                    j--;
                if (i <= j)
                {
                    tmp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = tmp;
                    i++;
                    j--;
                }
            };

            return i;
        }

    }
}
