using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ArrayLibrary.ArrayComparisonCreteriaLogic;

namespace ArrayLibrary
{
    public interface IComparer<T1, T2>
    {
        bool CompareTo(T1 lhs, T2 rhs);
    }

    public class SortBySumAsc : IComparer<int[], int[]>
    {
        public bool CompareTo(int[] lhs, int[] rhs)
        {
            return (SumByLine(rhs) - SumByLine(lhs)) < 0;
        }
    }

    public class SortBySumDesc : IComparer<int[], int[]>
    {
        public bool CompareTo(int[] lhs, int[] rhs)
        {
            return (SumByLine(rhs) - SumByLine(lhs)) > 0;
        }
    }

    public class SortByMaxElementAsc : IComparer<int[], int[]>
    {
        public bool CompareTo(int[] lhs, int[] rhs)
        {
            return (MaxElementByLine(rhs) - MaxElementByLine(lhs)) < 0;
        }
    }

    public class SortByMaxElementDesc : IComparer<int[], int[]>
    {
        public bool CompareTo(int[] lhs, int[] rhs)
        {
            return (MaxElementByLine(rhs) - MaxElementByLine(lhs)) > 0;
        }
    }

    public class SortByMinElementAsc : IComparer<int[], int[]>
    {
        public bool CompareTo(int[] lhs, int[] rhs)
        {
            return (MinElementByLine(rhs) - MinElementByLine(lhs)) < 0;
        }
    }

    public class SortByMinElementDesc : IComparer<int[], int[]>
    {
        public bool CompareTo(int[] lhs, int[] rhs)
        {
            return (MinElementByLine(rhs) - MinElementByLine(lhs)) > 0;
        }
    }
}
