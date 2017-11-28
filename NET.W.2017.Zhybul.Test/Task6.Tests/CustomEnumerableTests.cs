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

            int[] actual = new int[length];
            int i = 0;
            foreach (int member in SequenceGenerator<int>.GetSequence(1, 1, length, new CommonMemberGenerator<int>().GenerateForSequence1))
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

            int[] actual = new int[length];
            int i = 0;
            foreach (int member in SequenceGenerator<int>.GetSequence(1, 2, length, new CommonMemberGenerator<int>().GenerateForSequence2))
            {
                actual[i++] = member;
            }

            int[] expected = { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512 };

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Generator_ForSequence3()
        {
            int length = 10;

            double[] actual = new double[length];
            int i = 0;
            foreach (double member in SequenceGenerator<double>.GetSequence(1, 2, length, new CommonMemberGenerator<double>().GenerateForSequence3))
            {
                actual[i++] = Math.Round(member, 10);
            }

            double[] expected = { 1, 2, 2.5, 3.3, 4.0575757576, 4.8708692602, 5.7038983441, 6.5578527743, 7.4276341708, 8.3105334390 };

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
