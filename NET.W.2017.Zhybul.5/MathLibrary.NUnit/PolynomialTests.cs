using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MathLibrary.Polynomial;

namespace MathLibrary.NUnit
{
    [TestFixture]
    public class PolynomialTests
    {
        [Test]
        public void Sum()
        {
            Polynomial polynom1 = new Polynomial(2, new double[]{ 2.0, 0.0, 11.0});
            Polynomial polynom2 = new Polynomial(4, new double[] { 1d, 5.2, 0d, 4.3, 55d });
            Polynomial expected = new Polynomial(4, new double[] { 1d, 5.2, 2d, 4.3, 66d});
            Polynomial assert = polynom1 + polynom2;
            Assert.AreEqual(assert, expected);
        }

        [Test]
        public void Sum_Zero_Coef()
        {
            Polynomial polynom1 = new Polynomial(3, new double[] { -1d, 2d, 0d, 11d });
            Polynomial polynom2 = new Polynomial(3, new double[] { 1d, 5.2, 0d, 4.3 });
            Polynomial expected = new Polynomial(2, new double[] { 7.2, 0d, 15.3 });
            Polynomial assert = polynom1 + polynom2;
            Assert.AreEqual(assert, expected);
        }

        [Test]
        public void Difference()
        {
            Polynomial polynom1 = new Polynomial(2, new double[] { 2d, 2d, 31d });
            Polynomial polynom2 = new Polynomial(5, new double[] { 4d, -2d, 1.1, 0.2, 1.25, 4.3 });
            Polynomial expected = new Polynomial(5, new double[] { -4d, 2d, -1.1, 1.8, 0.75, 26.7 });
            Polynomial assert = polynom1 - polynom2;
            Assert.AreEqual(assert, expected);
        }

        [Test]
        public void Difference_Zero_Coef()
        {
            Polynomial polynom1 = new Polynomial(3, new double[] { 1d, 2.2, 0d, 11d });
            Polynomial polynom2 = new Polynomial(3, new double[] { 1d, 5.2, 0d, 4.3 });
            Polynomial expected = new Polynomial(2, new double[] { 3.0, 0d, 6.7 });
            Polynomial assert = polynom1 - polynom2;
            Assert.AreEqual(assert, expected);
        }

        [Test]
        public void Product()
        {
            Polynomial polynom1 = new Polynomial(2, new double[] { 1d, 2.2, 0d });
            Polynomial polynom2 = new Polynomial(1, new double[] { 1.1d, 4d });
            Polynomial expected = new Polynomial(3, new double[] { 1.1, 4d, 8.8, 0d });
            Polynomial assert = polynom1 - polynom2;
            Assert.AreEqual(assert, expected);
        }

        //[TestCase(new Polynomial(2, new double[] { 2, 0, 11 }),
        //          new Polynomial(4, new double[] { 1, 5.2, 0, 4.3, 55 }),
        //          ExpectedResult = new Polynomial(4, new double[] { 1, 5.2, 2, 4.3, 66 }))]
        //public Polynomial TestMethod(Polynomial p1, Polynomial p2)
        //{
        //    return p1 + p2;
        //}
    }
}
