using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryConvertor
{
    public static class DoubleConvertor
    {
        // silly binary convertor using inbuild convertors

        ////public static string ToString(this double number)
        ////{
        //    long bits = BitConverter.DoubleToInt64Bits(Double.Epsilon);
        //    string s = Convert.ToString(bits, 2);

        ////    int diff = 64 - s.Length;
        //    StringBuilder ss = FillWithZeros(s, diff);
        //    //Console.WriteLine(ss);

        ////    return ss
        ////}
        ////private static StringBuilder FillWithZeros(string number, int size)
        ////{
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append('0', size);
        //    sb.Append(number);
        //    return sb;
        ////}
    }
}
