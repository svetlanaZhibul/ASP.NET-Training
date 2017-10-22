using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static MathLibrary.ExtendedOperations;

namespace MathLibrary.Tests
{
    [TestClass]
    public class ExtendedOperationsTests
    {
        [TestMethod]
        public void InsertNumber_15_In_8_From_0_To_0_Bytes()
        {
            //Arrange
            int numberToBeSet = 8;
            int source = 15;
            int byte1 = 0;
            int byte2 = 0;

            int expected = 9;
            //Act
            int actual = InsertNumber(numberToBeSet, source, byte1, byte2);
            //Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void InsertNumber_15_In_8_From_3_To_8_Bytes()
        {
            //Arrange
            int numberToBeSet = 8;
            int source = 15;
            int byte1 = 3;
            int byte2 = 8;

            int expected = 120;
            //Act
            int actual = InsertNumber(numberToBeSet, source, byte1, byte2);
            //Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertNumber_11_In_9_From_minus1_To_4_Bytes()
        {
            //Arrange
            int numberToBeSet = 9;
            int source = 11;
            int byte1 = -1;
            int byte2 = 4;
            //Act
            int actual = InsertNumber(numberToBeSet, source, byte1, byte2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertNumber_11_In_9_From_5_To_4_Bytes()
        {
            //Arrange
            int numberToBeSet = 9;
            int source = 11;
            int byte1 = 5;
            int byte2 = 4;
            //Act
            int actual = InsertNumber(numberToBeSet, source, byte1, byte2);
        }

        [TestMethod]
        public void FindDigit_3_InArray_12_33_143_17_55_11_99_54321()
        {
            //Arrange
            int digit = 3;
            int[] array = { 12, 33, 143, 17, 55, 11, 99, 54321 };
            int[] expected = { 33, 143, 54321};
            //Act
            int[] actual = FilterDigit(digit, array);
            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindDigit_0_InArray_0_10_505_91_11_()
        {
            //Arrange
            int digit = 0;
            int[] array = { 0, 10, 505, 91, 11 };
            int[] expected = { 0, 10, 505};
            //Act
            int[] actual = FilterDigit(digit, array);
            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FindDigit_13_InArray_9_19_59_91_99_()
        {
            //Arrange
            int digit = 13;
            int[] array = { 9, 19, 59, 91, 99 };
            int[] expected = array;
            //Act
            int[] actual = FilterDigit(digit, array);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindDigit_1_InNullableArray()
        {
            //Arrange
            int digit = 1;
            int[] array = null;
            //Act
            int[] actual = FilterDigit(digit, array);
        }

        [TestMethod]
        public void FindNthRootOf_minus0008_N_is3_eps01()
        {
            //Arrange
            int basis = 3;
            double number = -0.008;
            double eps = 0.1;
            double expected = -0.2;
            //Act
            double actual = FindNthRoot(number, basis, eps);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindNthRootOf_00279936_N_is7_eps00001()
        {
            //Arrange
            int basis = 7;
            double number = 0.0279936;
            double eps = 0.0001;
            double expected = 0.6;
            //Act
            double actual = FindNthRoot(number, basis, eps);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FindNthRootOf_minus4_N_is2_eps01()
        {
            //Arrange
            int basis = 2;
            double number = -4;
            double eps = 0.1;
            //Act
            double actual = FindNthRoot(number, basis, eps);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FindNthRootOf_4_N_is2_eps_minus01()
        {
            //Arrange
            int basis = 2;
            double number = 4;
            double eps = -0.1;
            //Act
            double actual = FindNthRoot(number, basis, eps);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FindNthRootOf_4_N_minus2_eps_01()
        {
            //Arrange
            int basis = -2;
            double number = 4;
            double eps = 0.1;
            //Act
            double actual = FindNthRoot(number, basis, eps);
        }
    }
}
