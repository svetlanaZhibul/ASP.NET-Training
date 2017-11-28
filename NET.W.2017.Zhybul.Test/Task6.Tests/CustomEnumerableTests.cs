using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Test6.Solution;

namespace Task6.Tests
{
    [TestFixture]
    public class CustomEnumerableTests
    {
        [Test]
        public void Generator_ForSequence1()
        {
            int length = 10;

            SequenceGenerator<int> generator = new SequenceGenerator<int>(1, 1, 1, 1);
            int[] actual = new int[length];
            int i = 0;
            foreach (int member in generator.GetStaticCoefSequence(length))
            {
                actual[i++] = member;
            }

            int[] expected = { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55 };

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Generator_ForSequence2()
        {
            int length = 10;

            SequenceGenerator<int> generator = new SequenceGenerator<int>(6, -8, 1, 2);
            int[] actual = new int[length];
            int i = 0;
            foreach (int member in generator.GetStaticCoefSequence(length))
            {
                actual[i++] = member;
            }

            int[] expected = { 1, 2, -10, 92, -796, 6920, -60136, 522608, -4541680, 39469088 };

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Generator_ForSequence3()
        {
            int length = 10;

            SequenceGenerator<double> generator = new SequenceGenerator<double>(1, 1, 1, 2);
            int[] actual = new int[length];
            int i = 0;
            foreach (int member in generator.GetNonStaticCoefSequence(length, new CoeffincientGenerator<double>().Generate))
            {
                actual[i++] = member;
            }

            double[] expected = { 1, 2, 3, 3.5, 4.16666666666667, 4.69047619047619, 5.29238095238095, 5.81880106357264, 6.39184849183592, 6.91728310858544 };

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
