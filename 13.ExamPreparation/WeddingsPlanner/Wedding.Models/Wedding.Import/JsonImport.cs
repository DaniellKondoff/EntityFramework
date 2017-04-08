using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wedding.Data;
using Wedding.Data.DTOs;
using Wedding.Models;

namespace Wedding.Import
{
    public static class JsonImport
    {
        internal static void ImportAgencies()
        {
            using (WeddingContext context=new WeddingContext())
            {
                var json = File.ReadAllText("../../../datasets/agencies.json");
                var agencies = JsonConvert.DeserializeObject<IEnumerable<Agency>>(json);

                foreach (var agency in agencies)
                {
                    context.Agency.Add(agency);
                    Console.WriteLine($"Succesfully imported {agency.Name}");
                }
                context.SaveChanges();
            }
        }

        internal static void ImportWeddingAndInvitation()
        {

            using (WeddingContext context=new WeddingContext())
            {
                var json = File.ReadAllText("../../../datasets/weddings1.json");
                var wedings = JsonConvert.DeserializeObject<IEnumerable<WeddingDto>>(json);

                foreach (var wedding in wedings)
                {
                    Person brideEntity = GetPersonByName(wedding.Bride, context);
                    Person bridegroomEntity= GetPersonByName(wedding.Bridegroom, context);
                    Agency agencyEntity = GetAgencyByName(wedding.Agency, context);
                    if (agencyEntity==null || brideEntity==null || bridegroomEntity==null || wedding.Date==null)
                    {
                        Console.WriteLine("Error. ");
                        continue;
                    }

                    Weding weddingEntity = new Weding()
                    {
                        Bride=brideEntity,
                        Bridegroom=bridegroomEntity,
                        Date=wedding.Date,
                        Agency=agencyEntity
                    };

                    if (wedding.Guests !=null)
                    {
                        foreach (var guest in wedding.Guests)
                        {
                            var guestEntity = context.People.FirstOrDefault(p => p.FirstName + " " + p.MiddleName + " " + p.LastName == guest.Name);
                            if (guestEntity!=null)
                            {
                                Invitation invite = new Invitation()
                                {
                                    Guest = guestEntity,
                                    IsAttending = guest.RSVP,
                                    Family = guest.Family
                                };
                                weddingEntity.Invitations.Add(invite);
                            }
                        }
                    }

                    context.Weddings.Add(weddingEntity);
                    context.SaveChanges();
                    Console.WriteLine($"Succesfully imported wedding of {brideEntity.FirstName} and {bridegroomEntity.FirstName}");
                    //try
                    //{
                    //    context.Weddings.Add(weddingEntity);
                    //    context.SaveChanges();
                    //    Console.WriteLine($"Succesfully imported wedding of {brideEntity.FirstName} and {bridegroomEntity.FirstName}");
                    //}
                    //catch (Exception e)
                    //{
                    //    context.Weddings.Remove(weddingEntity);
                    //    Console.WriteLine(e);
                    //    Console.WriteLine("Error. Invalid data provided");
                    //}
                }
            }
            
        }

        private static Person GetPersonByName(string personName, WeddingContext context)
        {
            return context.People.FirstOrDefault(p => p.FirstName + " " + p.MiddleName + " " + p.LastName == personName);
        }

        private static Agency GetAgencyByName(string agencyName, WeddingContext context)
        {
            return context.Agency.FirstOrDefault(a => a.Name == agencyName);
        }

        internal static void ImportPeople()
        {
            using (WeddingContext context=new WeddingContext())
            {
                var json = File.ReadAllText("../../../datasets/people.json");
                var people = JsonConvert.DeserializeObject<IEnumerable<PersonDto>>(json);

                foreach (var person in people)
                {
                    if (person.FirstName==null || person.LastName==null || person.MiddleInitial==null || person.MiddleInitial.Length!=1)
                    {
                        Console.WriteLine("Error. Invalid data provided");
                        continue;
                    }

                    Person personEntity = new Person()
                    {
                        FirstName = person.FirstName,
                        LastName = person.LastName,
                        MiddleName = person.MiddleInitial,
                        Gender = person.Gender,
                        Birthdate = person.BirthDay,
                        Phone = person.Phone,
                        Email = person.Email
                    };

                    try
                    {
                        context.People.Add(personEntity);
                        Console.WriteLine($"Succesfully imported {personEntity.FullName}");
                        context.SaveChanges();
                    }
                    catch (Exception)
                    {
                        context.People.Remove(personEntity);
                        Console.WriteLine("Error. Invalid data provided");
                    }

                }
                
            }
        }
    }
}
