using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassDefect.Data;
using Newtonsoft.Json;

namespace MassDefect.Export
{
    public class JsonExport
    {
        internal static void ExportPlanetsWithNotAnomalyOrigins(MassDefectContext context)
        {
            var exportedPlanets = context.Planets
                .Where(p => !p.OriginAnomalies.Any())
                .Select(p => new
                {
                    name = p.Name
                });
            var planetAsJson = JsonConvert.SerializeObject(exportedPlanets, Formatting.Indented);
            Console.WriteLine(planetAsJson);
        }

        internal static void ExportTopAnomaly(MassDefectContext context)
        {
            var exportedAnomaly = context.Anomalies
                .OrderByDescending(a => a.Victims.Count)
                .Take(1)
                .Select(a => new
                {
                    id=a.Id,
                    originPlanet=new
                    {
                        name=a.OriginPlanet.Name
                    },
                    teleportPlanet=new
                    {
                        name=a.TeleportPlanet.Name
                    },
                    victimsCount=a.Victims.Count()
                });

            var anomalyAsJson = JsonConvert.SerializeObject(exportedAnomaly, Formatting.Indented);
            Console.WriteLine(anomalyAsJson);
        }

        internal static void ExportPeopleNoVictims(MassDefectContext context)
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

            var peopleAsJson = JsonConvert.SerializeObject(exportedPeople, Formatting.Indented);
            Console.WriteLine(peopleAsJson);
        }
    }
}
