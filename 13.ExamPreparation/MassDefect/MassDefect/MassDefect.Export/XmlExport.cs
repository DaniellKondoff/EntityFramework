using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassDefect.Data;
using System.Xml.Linq;
using System.Xml;

namespace MassDefect.Export
{
    public static class XmlExport
    {
        internal static void ExportAnomaliesXml(MassDefectContext context)
        {
            var exportedAnomalies = context.Anomalies
                .Select(a => new
                {
                    id = a.Id,
                    originPlanet = a.OriginPlanet.Name,
                    teleportPlane = a.TeleportPlanet.Name,
                    Vitims = a.Victims.Select(v => v.Name)
                })
                .OrderBy(a => a.id)
                .ToList();

            XDocument xml = new XDocument();
            XElement anomalyXml = new XElement("anomalies");

            foreach (var anomaly in exportedAnomalies)
            {
                XElement anomalyElement = new XElement("anomaly");
                anomalyElement.SetAttributeValue("id", anomaly.id);
                anomalyElement.SetAttributeValue("origin-planet", anomaly.originPlanet);
                anomalyElement.SetAttributeValue("teleport-planet", anomaly.teleportPlane);

                XElement victimsElement = new XElement("victims");
                foreach (var victim in anomaly.Vitims)
                {
                    XElement vicimtElement = new XElement("victim");
                    vicimtElement.SetAttributeValue("name", victim);
                    victimsElement.Add(vicimtElement);
                }
                anomalyElement.Add(victimsElement);
                anomalyXml.Add(anomalyElement);
            }
            xml.Add(anomalyXml);
            Console.WriteLine(xml);

        }
    }
}
