using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamPrep.Data.DTO;
using ExamPrep.Models;

namespace ExamPrep.Data.Store
{
    public static class PeopleStore
    {
        public static void AddPeople(IEnumerable<PeopleDto> people)
        {
            using (var context = new MassDefectContext())
            {
                foreach (var personDto in people)
                {
                    if (personDto.Name==null || personDto.HomePlanet==null)
                    {
                        Console.WriteLine("Error: Invalid data.");
                    }
                    else
                    {
                        var planet = PlanetStore.GetPlanetByName(personDto.HomePlanet);

                        if (planet==null)
                        {
                            Console.WriteLine("Error: Invalid data.");
                        }
                        else
                        {
                            var person = new Person()
                            {
                                Name = personDto.Name,
                                HomePlanetId = planet.Id
                            };
                            context.Persons.Add(person);
                            Console.WriteLine($"Successfully imported Person {person.Name}.");
                        }
                    }
                }
                context.SaveChanges();
            }
        }

        public static object GetPersonWithNoVictims()
        {
            throw new NotImplementedException();
        }

        public static Person GetPersonByName(string name)
        {
            using (var context=new MassDefectContext())
            {
                return context.Persons.FirstOrDefault(p => p.Name == name);
            }
        }
    }
}
