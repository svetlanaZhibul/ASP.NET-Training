using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLParser
{
    public class FileParser
    {
        public static void Parse(ObjectFileParser parser)
        {
            parser.ParseToXml();
        }
    }
}
