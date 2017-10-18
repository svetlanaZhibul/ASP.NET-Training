using System;
using System.Collections.Generic;
using System.Linq;
using IntegerLibrary;

namespace SortTestClass
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 10;
            int[] array = new int[size];

            Random r = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = (r.Next(10, 1000));
            }
            
            int[] sorted = IntegerSorting.MergeSort(array);
            Console.WriteLine("MergeSort:");
            for (int i = 0; i < sorted.Length; i++)
            {
                Console.Write(sorted[i] + " ");
            }

            IntegerSorting.QuickSort(array, 0, array.Length - 1);
            Console.WriteLine("\nQuickSort:");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(sorted[i] + " ");
            }

            Console.ReadKey();
        }
    }
}
