﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Solution
{
    public class PlainText : DocumentPart
    {
        public override string Convert(IConvertor convertor)
        {
            return convertor.ConvertPlainText(this);
        }
    }
}
