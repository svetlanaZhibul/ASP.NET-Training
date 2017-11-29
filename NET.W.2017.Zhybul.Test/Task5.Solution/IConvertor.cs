using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Solution
{
    public interface IConvertor
    {
        string ConvertBoldText(BoldText text);
        string ConvertPlainText(PlainText text);
        string ConvertHyperlink(Hyperlink text);
    }
}
