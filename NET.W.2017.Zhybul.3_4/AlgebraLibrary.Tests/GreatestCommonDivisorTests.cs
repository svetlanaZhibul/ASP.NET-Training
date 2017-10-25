using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static AlgebraLibrary.GreatestCommonDivisor;

namespace AlgebraLibrary.Tests
{
    [TestClass]
    public class GreatestCommonDivisorTests 
    {
        [TestMethod]
        public void Euclidean_Result_0 ()
        {
            int expected = 0;
            int actual = EuclideanAlgorithm(0, 0, 0);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Euclidean_Result_5()
        {
            int expected = 15;
            int actual = EuclideanAlgorithm(15, -30, 225, 45);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Euclidean_Result_1()
        {
            int expected = 1;
            int actual = EuclideanAlgorithm(0, 7, 29, -79, 14);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Euclidean_Result_Exception()
        {
            int[] array = new int[] { };
            int actual = EuclideanAlgorithm(array);
        }

        [TestMethod]
        public void Stein_Result_0()
        {
            int expected = 0;
            int actual = SteinsAlgorithm(0, 0, 0);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Stein_Result_5()
        {
            int expected = 15;
            int actual = SteinsAlgorithm(15, -30, 225, 45);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Stein_Result_2()
        {
            int expected = 2;
            int actual = SteinsAlgorithm(0, 6, -16, 10);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Stein_Result_Exception()
        {
            int[] array = new int[0];
            int actual = SteinsAlgorithm(array);
        }
    }
}
