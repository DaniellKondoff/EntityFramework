using ExamPrep.Data.DTO;
using ExamPrep.Data.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ExamPrep.Import
{
    public static class XmlImport
    {
        public static void ImportAnomalies()
        {
            XDocument xml = XDocument.Load("../../../datasets/new-anomalies.xml");
            var anomalyXml= xml.Root.Elements();
            var result = new List<AnomalyWithVictimsDto>();

            foreach (var anomaly in anomalyXml)
            {
                try
                {
                    var anomalyDto = new AnomalyWithVictimsDto
                    {
                        OriginPlanet = anomaly.Attribute("origin-planet").Value,
                        TeleportPlanet = anomaly.Attribute("teleport-planet").Value,
                        Victims = anomaly.Element("victims").Elements().Select(e => e.Attribute("name").Value).ToList()
                    };
                    result.Add(anomalyDto);
                }
                catch (Exception)
                {

                    Console.WriteLine("Error: Invalid data.");
                }

            }

            AnomalyStore.AddAnomaliesWithVicitms(result);
        }
    }
}
