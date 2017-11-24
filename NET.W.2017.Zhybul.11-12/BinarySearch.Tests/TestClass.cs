using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArraySortLibrary;

namespace BinarySearch.Tests
{
    public class SomeClass
    {
        private int id;

        public SomeClass(int id)
        {
            this.id = id;
        }

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
    }

    class SomeClassComparer : ArraySortLibrary.Comparator.IComparable<SomeClass>
    {
        public int Compare(SomeClass lhs, SomeClass rhs)
        {
            return lhs.Id - rhs.Id;
        }
    }

    [TestFixture]
    public class TestClass
    {
        private static readonly SomeClass[] objArray = new SomeClass[5] { new SomeClass(2), new SomeClass(3), new SomeClass(0), new SomeClass(11), new SomeClass(55) };

        private static SomeClass[] getObject()
        {
            if (!ReferenceEquals(objArray, null))
                return objArray;

            throw new ArgumentException("Unknown key");
        }

        [TestCase(11, ExpectedResult = 3)]
        [TestCase(0, ExpectedResult = 0)]
        [TestCase(16, ExpectedResult = -1)]
        [TestCase(-10, ExpectedResult = -1)]
        [TestCase(55, ExpectedResult = 4)]
        [TestCase(2, ExpectedResult = 1)]
        [TestCase(12, ExpectedResult = -1)]
        public int FindSomeClassObjectIn_objArray(int init_value)
        {
            return ArraySortLibrary.BinarySearch.DoSearch<SomeClass>(getObject(), 0, getObject().Length, new SomeClass(init_value), new SomeClassComparer());
        }
    }
}
