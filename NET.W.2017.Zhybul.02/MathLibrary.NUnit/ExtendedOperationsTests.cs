using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using static MathLibrary.ExtendedOperations;

namespace MathLibrary.NUnit
{
    [TestFixture]
    public class ExtendedOperationsTests
    {

        [TestCase(15, 8, 0, 0, ExpectedResult = 14)]
        [TestCase(16, 3, 2, 3, ExpectedResult = 28)]
        [TestCase(7, 8, 1, 5, ExpectedResult = 17)]

        public int InsertNumber_source_In_number_From_byte1_To_byte2_With_ExpectedResult
            (int number, int source, int byte1, int byte2)
        {
            return InsertNumber(number, source, byte1, byte2);
        }

        [TestCase(8, 15, -7, -5)]
        [TestCase(8, 15, 9, 0)]

        public void InsertNumber_source_In_number_From_byte1_To_byte2_ArgumentException
            (int number, int source, int byte1, int byte2)
        {
            Assert.Throws<ArgumentException>(() => InsertNumber(number, source, byte1, byte2));
        }

        [TestCase(215, ExpectedResult = 251)]
        [TestCase(767, ExpectedResult = 776)]
        [TestCase(1111611, ExpectedResult = 1116111)]
        [TestCase(123456, ExpectedResult = 123465)]
        [TestCase(87654, ExpectedResult = -1)]
        [TestCase(11, ExpectedResult = -1)]
        [TestCase(10, ExpectedResult = -1)]

        public long NextBiggerNumber_number_IsExpected(long number)
        {
            return NextBiggerNumber(number);
        }

        [TestCase(-15)]
        [TestCase(0)]

        public void NextBiggerNumber_number_DoesNotExist(long number)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => NextBiggerNumber(number));
        }

        [TestCase(25, 52)]

        public void NextBiggerNumberAndTimeWithList_Checker(long number, long expected)
        {
            decimal assumedTimeCeil = 30;

            List<object> list = NextBiggerNumberAndTimeWithList(number);
            Assert.AreEqual(expected, list[0]);
            Assert.LessOrEqual((int)list[1], assumedTimeCeil);
        }

        [TestCase(73, -1)]

        public void NextBiggerNumberAndTimeWithYield_Checker(long number, long expected)
        {
            decimal assumedTimeCeil = 30;

            List<object> list = new List<object>();
            foreach (object item in NextBiggerNumberAndTimeWithYield(number))
            {
                list.Add(item);
            }

            Assert.AreEqual(expected, list[0]);
            Assert.GreaterOrEqual(assumedTimeCeil, (int)list[1]);
        }

        [TestCase(16, 61)]

        public void NextBiggerNumberAndTimeWithTuple_Checker(long number, long expected)
        {
            decimal assumedTimeCeil = 30;

            Tuple<long, int> tuple = NextBiggerNumberAndTimeWithTuple(number);

            Assert.AreEqual(expected, tuple.Item1);
            Assert.GreaterOrEqual(assumedTimeCeil, (decimal)tuple.Item2);
        }
    }
}
