using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Wedding.Data;

namespace Wedding.Export
{
    public static class XmlExport
    {
        internal static void ExportVanues()
        {
            using (WeddingContext context = new WeddingContext())
            {
                var vanues = context.Venue
                    .Where(v => v.Town == "Sofia")
                    .OrderBy(c => c.Capacity).ToList();

                XDocument vanuesDoc = new XDocument();
                XElement vanuesElements = new XElement("venues");
                vanuesElements.SetAttributeValue("town", "Sofia");
                foreach (var v in vanues)
                {
                    XElement vanueEl = new XElement("vanue");
                    vanueEl.SetAttributeValue("name", v.Name);
                    vanueEl.SetAttributeValue("capacity", v.Capacity);
                    XElement weddingEl = new XElement("weddings-count", v.Weddings.Count);
                    vanueEl.Add(weddingEl);
                    vanuesElements.Add(vanueEl);
                }
                vanuesDoc.Add(vanuesElements);
                Console.WriteLine(vanuesDoc);
            }
        }
    }
}
