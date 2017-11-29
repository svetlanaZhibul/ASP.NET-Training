using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Solution
{
    public class ToLaTeXConvertor : IConvertor
    {
        public string ConvertBoldText(BoldText text)
        {
            return "\\textbf{" + text.Text + "}";
        }

        public string ConvertHyperlink(Hyperlink text)
        {
            return "\\href{" + text.Url + "}{" + text.Text + "}";
        }

        public string ConvertPlainText(PlainText text)
        {
            return text.Text;
        }
    }
}
