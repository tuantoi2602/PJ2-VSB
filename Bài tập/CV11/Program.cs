using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;

namespace CV11
{
    class Program
    {
        static void Main(string[] args)
        {
            string xml = DownloadXml();

            //ProcessXmlDocument(xml);
            ProcessXmlReaderWriter(xml);
        }

        static string DownloadXml()
        {
            using (WebClient wc = new WebClient())
            {
                return wc.DownloadString("http://feeds.bbci.co.uk/news/health/rss.xml");
            }
        }

        static void ProcessXmlDocument(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.NodeRemoved += XmlDocumentNodeRemoved;
            doc.LoadXml(xml);

            // Write all titles that start with VIDEO
            foreach (XmlNode node in doc.GetElementsByTagName("item"))
            {
                string title = node["title"].InnerText;

                if (title.StartsWith("VIDEO"))
                {
                    Console.WriteLine(title);
                }
            }

            // Remove items without title containing VIDEO
            List<XmlNode> nodesWithoutVideo = new List<XmlNode>();

            foreach (XmlNode node in doc.GetElementsByTagName("item"))
            {
                if (!node["title"].InnerText.Contains("VIDEO"))
                {
                    nodesWithoutVideo.Add(node);
                }
            }

            foreach (XmlNode node in nodesWithoutVideo)
            {
                doc["rss"]["channel"].RemoveChild(node);
            }

            doc.Save("rssXmlDocument.xml");
        }

        private static void XmlDocumentNodeRemoved(object sender, XmlNodeChangedEventArgs e)
        {
            Console.WriteLine("Removed node: " + e.Node["title"].InnerText);
        }

        static void ProcessXmlReaderWriter(string xml)
        {
            // Context is necessary when reading XML from string and not from file
            XmlParserContext context = new XmlParserContext(null, null, null, XmlSpace.None);

            using (XmlTextReader reader = new XmlTextReader(xml, XmlNodeType.Document, context))
            using (XmlTextWriter writer = new XmlTextWriter("rssXmlTextReaderWriter.xml", Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();
                writer.WriteStartElement("rss");

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "title")
                    {
                        string title = reader.ReadElementContentAsString();

                        if (title.StartsWith("VIDEO"))
                        {
                            Console.WriteLine(title);
                            writer.WriteElementString("title", title);
                        }
                    }
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
    }
}
