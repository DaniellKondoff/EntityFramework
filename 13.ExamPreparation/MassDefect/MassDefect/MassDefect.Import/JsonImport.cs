using MassDefect.Data;
using MassDefect.Data.DTO;
using MassDefect.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassDefect.Import
{
    public static class JsonImport
    {
        private const string SolarSystemsPath = "../../../datasets/solar-systems.json";

        private const string StarsPath = "../../../datasets/stars.json";

        private const string PlanetsPath = "../../../datasets/planets.json";

        private const string PersonsPath = "../../../datasets/persons.json";

        private const string AnomaliesPath = "../../../datasets/anomalies.json";

        private const string AnomalyVictimsPath = "../../../datasets/anomaly-victims.json";


        public static void ImportSolarSystem()
        {
            string solarSystemJson = File.ReadAllText(SolarSystemsPath);
            var solarSystems = JsonConvert.DeserializeObject<IEnumerable<SolarSystemDTO>>(solarSystemJson);
            using (var context=new MassDefectContext())
            {
                foreach (var solarSystemDto in solarSystems)
                {
                    if (solarSystemDto.Name==null)
                    {
                        Console.WriteLine("Error: Invalid data.");
                        continue;
                    }

                    var SolarSystemEntity = new SolarSystem()
                    {
                        Name = solarSystemDto.Name
                    };
                    context.SolarSystems.Add(SolarSystemEntity);
                    Console.WriteLine($"Successfully imported SolarSystem {SolarSystemEntity.Name}");
                }
                context.SaveChanges();
            }

        }

        public static void ImportStarst()
        {
            string starsJson = File.ReadAllText(StarsPath);
            var starsDto = JsonConvert.DeserializeObject<IEnumerable<StarDTO>>(starsJson);
            using (var context = new MassDefectContext())
            {
                foreach (var starDto in starsDto)
                {
                    if (starDto.Name==null || starDto.SolarSystem==null)
                    {
                        Console.WriteLine("Error: Invalid data.");
                        continue;
                    }

                    SolarSystem solarSystem = GetSolarSystemByname(starDto.SolarSystem, context);
                    if (solarSystem==null)
                    {
                        Console.WriteLine("Error: Invalid data.");
                        continue;
                    }

                    var starEntity = new Star()
                    {
                        Name = starDto.Name,
                        SolarSystemId = solarSystem.Id
                    };
                    context.Stars.Add(starEntity);
                    Console.WriteLine($"Successfully imported Star {starEntity.Name}");
                }

                context.SaveChanges();
                
            }
        }

        public static void ImportPlanets()
        {
            string jsonPlanet = File.ReadAllText(PlanetsPath);
            var planetsDto = JsonConvert.DeserializeObject<IEnumerable<PlanetDTO>>(jsonPlanet);

            using (var context=new MassDefectContext())
            {
                foreach (var planetDto in planetsDto)
                {
                    if (planetDto.Name==null || planetDto.Sun==null || planetDto.SolarSystem==null)
                    {
                        Console.WriteLine("Error: Invalid data.");
                        continue;
                    }

                    SolarSystem solarSystem = GetSolarSystemByname(planetDto.SolarSystem, context);
                    Star star = GetStarByName(planetDto.Sun, context);

                    if (solarSystem==null || star==null)
                    {
                        Console.WriteLine("Error: Invalid data.");
                        continue;
                    }

                    Planet planetEntity = new Planet()
                    {
                        Name = planetDto.Name,
                        SunId = star.Id,
                        SolarSystemId = solarSystem.Id
                    };
                    context.Planets.Add(planetEntity);
                    Console.WriteLine($"Successfully imported Planet {planetEntity.Name}");
                }
                context.SaveChanges();
            }
        }

        public static void ImportPersons()
        {
            string jsonPerson = File.ReadAllText(PersonsPath);
            var peopleDto = JsonConvert.DeserializeObject<IEnumerable<PersonDTO>>(jsonPerson);

            using (var context=new MassDefectContext())
            {
                foreach (var personDto in peopleDto)
                {
                    if (personDto.Name==null || personDto.Name==null)
                    {
                        Console.WriteLine("Error: Invalid data.");
                        continue;
                    }

                    Planet homePlanet = GetPlanetByName(personDto.HomePlanet, context);
                    if (homePlanet==null)
                    {
                        Console.WriteLine("Error: Invalid data.");
                        continue;
                    }

                    Person personEntity = new Person()
                    {
                        Name = personDto.Name,
                        HomePlanetId = homePlanet.Id
                    };
                    context.Persons.Add(personEntity);
                    Console.WriteLine($"Successfully imported person {personEntity.Name}");
                }

                context.SaveChanges();
            }
        }

        public static void ImportAnomalies()
        {
            string jsonAnomalies = File.ReadAllText(AnomaliesPath);
            var anomaliesDto = JsonConvert.DeserializeObject<IEnumerable<AnomalyDTO>>(jsonAnomalies);

            using (var context=new MassDefectContext())
            {
                foreach (var anomalyDto in anomaliesDto)
                {
                    if (anomalyDto.OriginPlanet == null || anomalyDto.TeleportPlanet == null)
                    {
                        Console.WriteLine("Error: Invalid data.");
                        continue;
                    }

                    Planet originPlanet = GetPlanetByName(anomalyDto.OriginPlanet, context);
                    Planet teleportPlanet = GetPlanetByName(anomalyDto.TeleportPlanet, context);

                    if (originPlanet==null || teleportPlanet==null)
                    {
                        Console.WriteLine("Error: Invalid data.");
                        continue;
                    }

                    Anomaly anomalyEntity = new Anomaly()
                    {
                        OriginPlanetId = originPlanet.Id,
                        TeleportPlanetId = teleportPlanet.Id
                    };
                    context.Anomalies.Add(anomalyEntity);
                    Console.WriteLine($"Successfully imported anomaly.");
                }
                context.SaveChanges();
            }
        }

        public static void ImportAnomalyVictims()
        {
            string json = File.ReadAllText(AnomalyVictimsPath);
            var anomalyVictimsDTO = JsonConvert.DeserializeObject<IEnumerable<AnomalyVictimDTO>>(json);

            using (var context=new MassDefectContext())
            {
                foreach (var avDto in anomalyVictimsDTO)
                {
                    if (avDto.Id==null || avDto.Person==null)
                    {
                        Console.WriteLine("Error: Invalid data.");
                        continue;
                    }

                    Anomaly anomalyEntity = GetAnomalyById(avDto.Id, context);
                    Person personEntity = GetPersonByName(avDto.Person, context);

                    if (anomalyEntity==null || personEntity==null)
                    {
                        Console.WriteLine("Error: Invalid data.");
                        continue;
                    }

                    anomalyEntity.Victims.Add(personEntity);
                    
                }
                context.SaveChanges();
            }
        }

        private static Person GetPersonByName(string person, MassDefectContext context)
        {
            return context.Persons.FirstOrDefault(p => p.Name == person);
        }

        private static Anomaly GetAnomalyById(int? id, MassDefectContext context)
        {
            return context.Anomalies.Find(id);
        }

        private static Planet GetPlanetByName(string homePlanet, MassDefectContext context)
        {
            return context.Planets.FirstOrDefault(p => p.Name == homePlanet);
        }

        private static Star GetStarByName(string sun, MassDefectContext context)
        {
            return context.Stars.FirstOrDefault(s => s.Name == sun);
        }

        private static SolarSystem GetSolarSystemByname(string solarSystem, MassDefectContext context)
        {
            return context.SolarSystems.FirstOrDefault(s => s.Name == solarSystem);
        }
    }
}
