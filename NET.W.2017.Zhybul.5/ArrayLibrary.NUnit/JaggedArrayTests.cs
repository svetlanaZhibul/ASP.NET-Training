using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ArrayLibrary.JaggedArray;
using NUnit.Framework;

namespace ArrayLibrary.NUnit
{
    [TestFixture]
    public class JaggedArrayTests
    {
        ////public int[][] array = new int[4][];
        
        ////public JaggedArrayTests()
        ////{
        ////    array[0] = new int[] { 5, 0, -1, 1, 6 };
        ////    array[1] = new int[] { 22, -17, 3, 1 };
        ////    array[2] = new int[] { 2, 8 };
        ////    array[3] = new int[] { 1, 3, 3 };
        ////}
        
        ////[Test]
        ////public void SortBySumAsc_array_sorted()
        ////{
        ////    JaggedArrayTests jat = new JaggedArrayTests();
        ////    int[][] array = jat.array;
        ////    SortBySumAsc(array);
        ////    int[][] actual = new int[4][];
        ////    actual[0] = new int[] { 1, 3, 3 }; 
        ////    actual[1] = new int[] { 22, -17, 3, 1 };
        ////    actual[2] = new int[] { 2, 8 };
        ////    actual[3] = new int[] { 5, 0, -1, 1, 6 };
        ////    CollectionAssert.AreEqual(array, actual);
        ////}

        ////[Test]
        ////public void SortBySumDesc_array_sorted()
        ////{
        ////    JaggedArrayTests jat = new JaggedArrayTests();
        ////    int[][] array = jat.array;
        ////    SortBySumDesc(array);
        ////    int[][] actual = new int[4][];
        ////    actual[0] = new int[] { 5, 0, -1, 1, 6 };
        ////    actual[1] = new int[] { 2, 8 };
        ////    actual[2] = new int[] { 22, -17, 3, 1 };
        ////    actual[3] = new int[] { 1, 3, 3 };
        ////    CollectionAssert.AreEqual(array, actual);
        ////}

        ////[Test]
        ////public void SortByMaxElementAsc_array_sorted()
        ////{
        ////    JaggedArrayTests jat = new JaggedArrayTests();
        ////    int[][] array = jat.array;
        ////    SortByMaxElementAsc(array);
        ////    int[][] actual = new int[4][];
        ////    actual[0] = new int[] { 1, 3, 3 };
        ////    actual[1] = new int[] { 5, 0, -1, 1, 6 };
        ////    actual[2] = new int[] { 2, 8 };
        ////    actual[3] = new int[] { 22, -17, 3, 1 };
        ////    CollectionAssert.AreEqual(array, actual);
        ////}

        ////[Test]
        ////public void SortByMaxElementDesc_array_sorted()
        ////{
        ////    JaggedArrayTests jat = new JaggedArrayTests();
        ////    int[][] array = jat.array;
        ////    SortByMaxElementDesc(array);
        ////    int[][] actual = new int[4][];
        ////    actual[0] = new int[] { 22, -17, 3, 1 };
        ////    actual[1] = new int[] { 2, 8 };
        ////    actual[2] = new int[] { 5, 0, -1, 1, 6 };
        ////    actual[3] = new int[] { 1, 3, 3 };
        ////    CollectionAssert.AreEqual(array, actual);
        ////}

        ////[Test]
        ////public void SortByMinElementAsc_array_sorted()
        ////{
        ////    JaggedArrayTests jat = new JaggedArrayTests();
        ////    int[][] array = jat.array;
        ////    SortByMinElementAsc(array);
        ////    int[][] actual = new int[4][];
        ////    actual[0] = new int[] { 22, -17, 3, 1 };
        ////    actual[1] = new int[] { 5, 0, -1, 1, 6 };
        ////    actual[2] = new int[] { 1, 3, 3 };
        ////    actual[3] = new int[] { 2, 8 };
        ////    CollectionAssert.AreEqual(array, actual);
        ////}

        ////[Test]
        ////public void SortByMinElementDesc_array_sorted()
        ////{
        ////    JaggedArrayTests jat = new JaggedArrayTests();
        ////    int[][] array = jat.array;
        ////    SortByMinElementDesc(array);
        ////    int[][] actual = new int[4][];
        ////    actual[0] = new int[] { 2, 8 };
        ////    actual[1] = new int[] { 1, 3, 3 }; 
        ////    actual[2] = new int[] { 5, 0, -1, 1, 6 };
        ////    actual[3] = new int[] { 22, -17, 3, 1 };
        ////    CollectionAssert.AreEqual(array, actual);
        ////}
    }
}
