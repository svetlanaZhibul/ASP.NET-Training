using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Solution
{
    public class ToPlainTextConvertor : IConvertor
    {
        public string ConvertBoldText(BoldText text)
        {
            return "**" + text.Text + "**";
        }

        public string ConvertHyperlink(Hyperlink text)
        {
            return text.Text + " [" + text.Url + "]";
        }

        public string ConvertPlainText(PlainText text)
        {
            return text.Text;
        }
    }
}
