using ExamPrep.Data.DTO;
using ExamPrep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPrep.Data.Store
{
    public static class SolarSystemStore
    {
        public static void AddSolarSystems(IEnumerable<SolarSystemDto> systems)
        {
            using (var context = new MassDefectContext())
            {
                foreach (var star in systems)
                {
                    if (star.Name == null)
                    {
                        Console.WriteLine("Invalid data.");
                    }
                    else
                    {
                        context.SolarSystems.Add(new SolarSystem { Name = star.Name });
                        Console.WriteLine($"Successfully imported Solar System {star.Name}");
                    }
                }
                context.SaveChanges();
            }
        }

        public static SolarSystem GetSystemByName(string name)
        {
            using (var context = new MassDefectContext())
            {
                var solarSystem = context.SolarSystems.Where(s => s.Name == name).FirstOrDefault();
                return solarSystem;
            }

        }

    }
}
