using ExamPrep.Data.DTO;
using ExamPrep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPrep.Data.Store
{
    public static class PlanetStore
    {
        public static void AddPlanets(IEnumerable<PlanetDto> planets)
        {
            using (var context = new MassDefectContext())
            {
                foreach (var planetDto in planets)
                {

                    if (planetDto.Name == null || planetDto.Sun == null || planetDto.SolarSystem == null)
                    {
                        Console.WriteLine("Error: Invalid data");
                    }

                    else
                    {
                        var solarSystem = SolarSystemStore.GetSystemByName(planetDto.SolarSystem);
                        var sun = StarsStore.GetStarByName(planetDto.Sun);

                        if (solarSystem == null || sun == null)
                        {
                            Console.WriteLine("Error: Invalid data");
                        }
                        else
                        {
                            var planet = new Planet()
                            {
                                Name = planetDto.Name,
                                SolarSystemId = solarSystem.Id,
                                SunId = sun.Id
                            };

                            context.Planets.Add(planet);
                            Console.WriteLine($"Successfully imported Planet {planet.Name}.");
                        }
                    }
                }
                context.SaveChanges();
            }
        }

        public static Planet GetPlanetByName(string name)
        {
            using (var context = new MassDefectContext())
            {
                return context.Planets.FirstOrDefault(p => p.Name == name);
            }
        }

        public static IEnumerable<PlanetExportDto> GetPlanetWithNoVictims()
        {
            using (var context=new MassDefectContext())
            {
                var planets =context.Planets
                    .Where(p => p.OriginAnomalies.All(a => a.Victims.Count == 0))
                    .Select(p=> new  PlanetExportDto
                    {
                        Name = p.Name
                    })
                    .ToList();

                return planets;
            }
        }
    }
}
