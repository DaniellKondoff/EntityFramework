using MassDefect.Data;
using MassDefect.Data.DTO;
using MassDefect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MassDefect.Import
{
    public static class XmlImportDTO
    {
        private const string NewAnomaliesPath = "../../../datasets/new-anomalies.xml";

        internal static void ImportNewAnomaliesXML()
        {
            var context = new MassDefectContext();

            XDocument xml = XDocument.Load(NewAnomaliesPath);
            var anomalies = xml.Root.Elements();
            var result = new List<AnomaliesWithVictimsDtoXML>();

            foreach (var anomaly in anomalies)
            {
                try
                {
                    var anomalyDto = new AnomaliesWithVictimsDtoXML()
                    {
                        OriginPlanet = anomaly.Attribute("origin-planet").Value,
                        TeleportPlanet = anomaly.Attribute("teleport-planet").Value,
                        Victims = anomaly.Element("victims").Elements().Select(e => e.Attribute("name").Value).ToList()
                    };
                    
                    result.Add(anomalyDto);
                }
                catch (Exception)
                {

                    Console.WriteLine("Error! Invalid data.");
                }
            }
            AddAnomaliesWithVictims(result, context);
           
        }

        private static void AddAnomaliesWithVictims(List<AnomaliesWithVictimsDtoXML> anomalies, MassDefectContext context)
        {
            foreach (var anomalyDto in anomalies)
            {
                Planet originPlanetEntity = GetPlanetByName(anomalyDto.OriginPlanet, context);
                Planet teleportPlanetEntity = GetPlanetByName(anomalyDto.TeleportPlanet, context);

                if (originPlanetEntity==null || teleportPlanetEntity==null)
                {
                    Console.WriteLine("Error: Invalid data.");
                    continue;
                }

                var anomalyEntity = new Anomaly()
                {
                    OriginPlanetId = originPlanetEntity.Id,
                    TeleportPlanetId = teleportPlanetEntity.Id
                };

                context.Anomalies.Add(anomalyEntity);
                Console.WriteLine("Successfully imported AnomalyXML.");
                foreach (var victimname in anomalyDto.Victims)
                {
                    Person victim = context.Persons.FirstOrDefault(p => p.Name == victimname);
                    if (victim!= null)
                    {
                        anomalyEntity.Victims.Add(victim);
                    }
                }
            }
            context.SaveChanges();
        }

        private static Planet GetPlanetByName(string planetName, MassDefectContext context)
        {
            return context.Planets.FirstOrDefault(p => p.Name == planetName);
        }
    }
}
