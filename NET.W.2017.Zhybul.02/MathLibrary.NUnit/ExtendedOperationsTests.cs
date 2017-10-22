using NUnit.Framework;
using System;
using static MathLibrary.ExtendedOperations;

namespace MathLibrary.NUnit
{
    [TestFixture]
    public class ExtendedOperationsTests
    {

        [TestCase( 15, 8, 0, 0, ExpectedResult = 14)]
        [TestCase( 16, 3, 2, 3, ExpectedResult = 28)]
        [TestCase( 7, 8, 1, 5, ExpectedResult = 17)]

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
        
    }
}
