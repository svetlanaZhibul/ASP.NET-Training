using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static IntegerLibrary.IntegerSorting;

namespace InregerLibrary.Tests
{
    [TestClass]
    public class IntegerSortingTests
    {
        [TestMethod]
        public void MergeSort_Correct()
        {
            //Arrange
            int[] array = { 1234, 65, 346, 921, 777, 101, 113, 55, 1000 };
            int[] expected = { 55, 65, 101, 113, 346, 777, 921, 1000, 1234 };
            //Act
            MergeSort(array);
            //Assert
            CollectionAssert.AreEqual(expected, array);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MergeSort_OnNullArray_Exception()
        {
            //Arrange
            int[] array = null;
            //Act
            MergeSort(array);
        }

        [TestMethod]
        public void QuickSort_Correct()
        {
            //Arrange
            int[] array = { 100, 115, 99, 100, 101, 111 };
            int[] expected = { 99, 100, 100, 101, 111, 115 };
            //Act
            QuickSort(array);
            //Assert
            CollectionAssert.AreEqual(expected, array);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void QuickSort_OnNullArray_Exception()
        {
            //Arrange
            int[] array = null;
            //Act
            QuickSort(array);
        }
    }
}
