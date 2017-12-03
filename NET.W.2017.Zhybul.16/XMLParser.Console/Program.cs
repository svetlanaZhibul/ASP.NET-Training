using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static XMLParser.FileParser;

namespace XMLParser.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\datafiles\input.txt";

            UrlAddressParser parser = new UrlAddressParser(path);

            Parse(parser);

            System.Console.WriteLine("XML was written to XMLParser.Console/datafiles directory");

            System.Console.ReadKey();
        }
    }
}
