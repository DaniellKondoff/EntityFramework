using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamPrep.Data.DTO;
using ExamPrep.Models;

namespace ExamPrep.Data.Store
{
    public static class AnomalyStore
    {
        public static void AddAnomalies(IEnumerable<AnamalyDto> anomalies)
        {
            using (var context = new MassDefectContext())
            {
                foreach (var anomalyDto in anomalies)
                {
                    if (anomalyDto.OriginPlanet==null || anomalyDto.TeleportPlanet==null)
                    {
                        Console.WriteLine("Error: Invalid data");
                    }
                    else
                    {
                        var originPlanet = PlanetStore.GetPlanetByName(anomalyDto.OriginPlanet);
                        var teleportPlanet = PlanetStore.GetPlanetByName(anomalyDto.TeleportPlanet);

                        if (originPlanet==null||teleportPlanet==null)
                        {
                            Console.WriteLine("Error: Invalid data");
                        }
                        else
                        {
                            Anomoly anomaly = new Anomoly()
                            {
                                 OriginPlanetId=originPlanet.Id,
                                 TeleportPlanetId=teleportPlanet.Id
                            };
                            context.Anomalies.Add(anomaly);
                            Console.WriteLine($"Successfully imported Anomaly between {originPlanet.Name} and {teleportPlanet.Name}.");
                        }
                    }
                }
                context.SaveChanges();
            }
        }

        public static void AddAnomaliesWithVicitms(List<AnomalyWithVictimsDto> anomalies)
        {
            using (var context=new MassDefectContext())
            {
                foreach (var anomalyDto in anomalies)
                {
                    var originPlanet = PlanetStore.GetPlanetByName(anomalyDto.OriginPlanet);
                    var teleportPlanet = PlanetStore.GetPlanetByName(anomalyDto.TeleportPlanet);

                    if (originPlanet==null || teleportPlanet==null)
                    {
                        Console.WriteLine("Error: Invalid data");
                    }
                    else
                    {
                        var anomaly = new Anomoly()
                        {
                            OriginPlanetId = originPlanet.Id,
                            TeleportPlanetId = teleportPlanet.Id
                        };
                        context.Anomalies.Add(anomaly);
                        
                        foreach (var victimName in anomalyDto.Victims)
                        {
                            var victim = context.Persons.FirstOrDefault(p => p.Name == victimName);

                            if (victim !=null)
                            {
                                anomaly.Victims.Add(victim);
                            }
                        }
                    }
                }
                context.SaveChanges();
            }
        }

        public static Anomoly GetAnomalyById(int Id)
        {
            using (var context=new MassDefectContext())
            {
                return context.Anomalies.FirstOrDefault(a => a.Id == Id);
            }
        }

        public static void AddVictimsToAnomaly(IEnumerable<VictimDto> victims)
        {
            using (var context=new MassDefectContext())
            {
                foreach (var victimDto in victims)
                {
                    if (victimDto.Person==null)
                    {
                        Console.WriteLine("Error: Invalid data");
                    }
                    else
                    {
                        var person = context.Persons.FirstOrDefault(p => p.Name == victimDto.Person);
                        var anomaly = context.Anomalies.Find(victimDto.Id);

                        if (person==null || anomaly==null)
                        {
                            Console.WriteLine("Error: Invalid data");
                        }
                        else
                        {
                            anomaly.Victims.Add(person);

                            Console.WriteLine($"Sucessfully imported victem{person.Name} to anomaly {anomaly.Id}");
                        }
                    }
                }
                context.SaveChanges();
            }
            
        }
    }
}
