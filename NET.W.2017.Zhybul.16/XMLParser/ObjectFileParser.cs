using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLParser
{
    public abstract class ObjectFileParser
    {
        protected string filepath;

        protected ObjectFileParser(string filepath)
        {
            this.filepath = filepath;
        }

        internal string Filepath
        {
            get
            {
                return this.filepath;
            }
        }

        public abstract void ParseToXml();
    }
}
