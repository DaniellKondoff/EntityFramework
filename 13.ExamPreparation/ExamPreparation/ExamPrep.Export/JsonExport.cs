using ExamPrep.Data;
using ExamPrep.Data.Store;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPrep.Export
{
    public class JsonExport
    {
        public static void ExportTopAnomaly(MassDefectContext context)
        {
            var exportedAnomalies = context.Anomalies
                .OrderByDescending(a => a.Victims.Count)
                .Take(1)
                .Select(a => new
                {
                    id = a.Id,
                    originPlaten = new
                    {
                        name = a.OriginPlanet.Name
                    },
                    teleportPlanet = new
                    {
                        name = a.TeleportPlanet.Name
                    },
                    victimsCount = a.Victims.Count
                });

            var anomalyAsJson = JsonConvert.SerializeObject(exportedAnomalies, Formatting.Indented);
            Console.WriteLine(anomalyAsJson);

        }

        public static void ExportPeopleNoVictims(MassDefectContext context)
        {
            var exportedPeople = context.Persons
                .Where(p => !p.Anomalies.Any())
                .Select(p => new
                {
                    name = p.Name,
                    homePlanet = new
                    {
                        name = p.HomePlanet.Name
                    }
                });
            var personAsJason = JsonConvert.SerializeObject(exportedPeople, Formatting.Indented);
            Console.WriteLine(personAsJason);
        }

        public static void ExportPlanetsWithNotAnomalyOrigins(MassDefectContext context)
        {
            var exportetPlanets = context.Planets
                .Where(p => p.OriginAnomalies.All(a => a.Victims.Count == 0))
                .Select(p => new
                {
                    name = p.Name
                });

            var planetAsJson = JsonConvert.SerializeObject(exportetPlanets, Formatting.Indented);
            Console.WriteLine(planetAsJson);
        }
    }
}
