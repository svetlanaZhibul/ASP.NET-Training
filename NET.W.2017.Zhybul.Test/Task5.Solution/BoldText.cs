using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Solution
{
    public class BoldText : DocumentPart
    {
        public override string Convert(IConvertor convertor)
        {
            return convertor.ConvertBoldText(this);
        }
    }
}
