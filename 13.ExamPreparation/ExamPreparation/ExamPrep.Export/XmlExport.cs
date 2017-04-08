using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamPrep.Data;
using System.Xml.Linq;

namespace ExamPrep.Export
{
    public static class XmlExport
    {
        public static void ExportAnomaliesXml(MassDefectContext context)
        {
            var exportedAnomalies = context.Anomalies
                .Select(a => new
                {
                    id=a.Id,
                    originPlanetName=a.OriginPlanet.Name,
                    teleportPlanetName=a.TeleportPlanet.Name,
                    Victims=a.Victims.Select(v=>v.Name)
                })
                .OrderBy(a=>a.id);

            var xmlDocument = new XElement("anomalies");
            foreach (var anomaly in exportedAnomalies)
            {
                var anomalyNode = new XElement("anomaly");
                anomalyNode.Add(new XAttribute("id", anomaly.id));
                anomalyNode.Add(new XAttribute("origin-planet", anomaly.originPlanetName));
                anomalyNode.Add(new XAttribute("teleport-planet", anomaly.teleportPlanetName));
                var victimsNode = new XElement("victims");
                foreach (var victim in anomaly.Victims)
                {
                    var victimNode = new XElement("victim");
                    victimNode.Add(new XAttribute("name", victim));
                    victimsNode.Add(victimNode);
                }
                anomalyNode.Add(victimsNode);
                xmlDocument.Add(anomalyNode);
            }
            Console.WriteLine(xmlDocument);
        }
    }
}
