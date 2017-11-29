using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Solution
{
    public class ToHtmlConvertor : IConvertor
    {
        public string ConvertBoldText(BoldText text)
        {
            return "<b>" + text.Text + "</b>";
        }

        public string ConvertHyperlink(Hyperlink text)
        {
            return "<a href=\"" + text.Url + "\">" + text.Text + "</a>";
        }

        public string ConvertPlainText(PlainText text)
        {
            return text.Text;
        }
    }
}
