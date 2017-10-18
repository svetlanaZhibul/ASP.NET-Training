using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegerLibrary
{
    public class IntegerSorting
    {

        public static int[] MergeSort(int[] m)
        {
            if (m.Length < 2)
            {
                return m;
            }

            return Merge(MergeSort(m.Take(m.Length / 2).ToArray()), MergeSort(m.Skip(m.Length / 2).ToArray()));
        }

        public static void QuickSort(int[] arr, int left, int right)
        {
            int index = Partition(arr, left, right);
            if (left < index - 1)
                QuickSort(arr, left, index - 1);
            if (index < right)
                QuickSort(arr, index, right);
        }

        private static int[] Merge(int[] left, int[] right)
        {
            List<int> result = new List<int>();
            int l1 = 0, r1 = 0;

            while (l1 < left.Length && r1 < right.Length)
            {
                if (left[l1] < right[r1])
                {
                    result.Add(left[l1++]);
                }
                else
                {
                    result.Add(right[r1++]);
                }
            }
            result.AddRange(left.Skip(l1));
            result.AddRange(right.Skip(r1));

            return result.ToArray<int>();
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
