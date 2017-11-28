using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Solution;

namespace Task2.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfFiles = 1;
            int contentLength = 10;

            new RandomCharsFileGenerator().GenerateFiles(numberOfFiles, contentLength);
            new RandomBytesFileGenerator().GenerateFiles(numberOfFiles, contentLength);
        }
    }
}
