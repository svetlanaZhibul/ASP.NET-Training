using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLParser
{
    public class UrlAddress
    {
        private string hostname;
        private string[] uri;
        private Dictionary<string, string> parameters = new Dictionary<string, string>();

        public UrlAddress()
        {
        }

        public UrlAddress(string hostname, string[] uri, string[] parameters)
        {
            this.hostname = hostname;
            this.uri = uri;
            foreach (string pair in parameters)
            {
                if (!string.IsNullOrEmpty(pair))
                {
                    this.parameters.Add(pair.Split('=')[0], pair.Split('=')[1]);
                }
            }
        }

        internal string Hostname
        {
            get
            {
                return this.hostname;
            }

            set
            {
                this.hostname = value;
            }
        }

        internal string[] Uri
        {
            get
            {
                return this.uri;
            }

            set
            {
                this.uri = value;
            }
        }

        internal Dictionary<string, string> Parameters
        {
            get
            {
                return this.parameters;
            }

            set
            {
                this.parameters = value;
            }
        }
    }
}
