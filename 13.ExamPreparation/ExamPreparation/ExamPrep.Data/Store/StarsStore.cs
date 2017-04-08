using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamPrep.Data.DTO;
using ExamPrep.Models;

namespace ExamPrep.Data.Store
{
    public static class StarsStore
    {
        public static void AddStars(IEnumerable<StartDto> stars)
        {
            using (var context = new MassDefectContext())
            {
                foreach (var starDto in stars)
                {
                    if (starDto.Name == null || starDto.SolarSystem==null)
                    {
                        Console.WriteLine("Error: Invalid data.");
                    }
                    else
                    {
                        var solarSystem = SolarSystemStore.GetSystemByName(starDto.SolarSystem);
                        if (solarSystem == null)
                        {
                            Console.WriteLine("Error: Invalid data.");
                        }
                        else
                        {
                            var star = new Star()
                            {
                                Name = starDto.Name,
                                SolarSystemId = solarSystem.Id
                            };
                            context.Stars.Add(star);
                            Console.WriteLine($"Successfully imported Star {star.Name}.");
                        }
                                             
                    }
                }
                context.SaveChanges();
            }
            
        }

        public static Star GetStarByName(string name)
        {
            using (var context=new MassDefectContext())
            {
                return context.Stars.FirstOrDefault(s => s.Name == name);
            }
        }
    }
}
