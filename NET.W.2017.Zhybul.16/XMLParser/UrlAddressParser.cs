using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace XMLParser
{
    public class UrlAddressParser : ObjectFileParser
    {
        private List<UrlAddress> urls = new List<UrlAddress>(6);

        public UrlAddressParser(string filepath) : base(filepath) { }

        public override void ParseToXml()
        {
            DeserializeOnFile(this.Filepath);
            WriteToXml();
        }

        private void WriteToXml()
        {
            using (XmlWriter writer = XmlWriter.Create(Path.GetDirectoryName(this.Filepath) + @"\Urls.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("urlAddresses");

                foreach (UrlAddress url in urls)
                {
                    writer.WriteStartElement("urlAddress");

                    writer.WriteElementString("hostname", url.Hostname);

                    if (url.Uri != null)
                    {
                        writer.WriteStartElement("uri");
                        foreach (string uri in url.Uri)
                        {
                            writer.WriteElementString("segment", uri);
                        }

                        writer.WriteEndElement();

                        if (url.Parameters.Count != 0 && url.Parameters != null)
                        {
                            writer.WriteStartElement("parameters");
                            foreach (KeyValuePair<string, string> param in url.Parameters)
                            {
                                writer.WriteStartElement("parameter");
                                writer.WriteAttributeString(param.Key, param.Value);
                                writer.WriteEndElement();
                            }

                            writer.WriteEndElement();  
                        }
                    }

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        private void DeserializeOnFile(string path)
        {
            string line;
            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    if (IsValid(line))
                    {
                        urls.Add(DeserializeOnLine(line));
                    }
                    else
                    {
                        //Log.Warn();
                    }
                }
            }
        }
        
        private UrlAddress DeserializeOnLine(string line)
        {
            string[] parts;
            string parameters;

            if (line.Contains("?")) {
                parameters = line.Split('?')[1];
                parts = Regex.Split(line.Split('?')[0], @"\:?\/+");
            }
            else
            {
                parameters = "";
                parts = Regex.Split(line, @"\:?\/+");
            }

            parts = parts.Where(str => str != string.Empty).ToArray();
            string hostname = parts[1];
            string[] uri = new string[parts.Length - 2];

            for (int i = 2; i < parts.Length; i++)
            {
                uri[i - 2] = parts[i];
            }

            return new UrlAddress(hostname, uri, parameters.Split('&'));
        }

        private bool IsValid(string url)
        {
            string pattern = @"(https?)\:\/\/((\w+\.)*(\w+))(\/([\w\-\.]+))*(\?(\w+\=\w+)(\&\w+\=\w+)*)?\/?";
            return Regex.IsMatch(url, pattern);
        }
    }
}
