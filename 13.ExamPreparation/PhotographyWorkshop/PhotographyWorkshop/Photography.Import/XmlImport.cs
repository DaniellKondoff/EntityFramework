using Photography.Data;
using Photography.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Photography.Import
{
    public static class XmlImport
    {
        private const string AccessoariesPath = "../../../datasets/accessories.xml";
        private const string WorkshopPath = "../../../datasets/workshops.xml";
        internal static void ImporAccessories()
        {
            XDocument xml = XDocument.Load(AccessoariesPath);
            var accessoriess = xml.Root.Elements();

            using (PhotoWorkContext context=new PhotoWorkContext())
            {
                foreach (var access in accessoriess)
                {
                    var acc = new Accessory()
                    {
                        Name = access.Attribute("name").Value
                    };
                    Photographer Owner = GetRandomOwner(context);
                    acc.OwnerId = Owner.Id;
                    context.Accessories.Add(acc);
                    Console.WriteLine($"Succesfully imported {acc.Name}");
                }
                context.SaveChanges();
            }
        }

        internal static void ImportWorkshop()
        {
            XDocument xml = XDocument.Load(WorkshopPath);
            var workshops = xml.XPathSelectElements("workshops/workshop");

            using (PhotoWorkContext context= new PhotoWorkContext())
            {
                foreach (var workshopXml in workshops)
                {
                    var name = workshopXml.Attribute("name");
                    var startdate = workshopXml.Attribute("start-date");
                    var enddate = workshopXml.Attribute("end-date");
                    var location = workshopXml.Attribute("location");
                    var price = workshopXml.Attribute("price");
                    var trainerName = workshopXml.XPathSelectElement("trainer");

                    if (name == null ||location==null || price==null || trainerName == null)
                    {
                        Console.WriteLine("Error! Invalid Data");
                        continue;
                    }
                    DateTime? StartdateCheck;
                    if (startdate==null)
                    {
                        StartdateCheck = null;
                    }
                    else
                    {
                        StartdateCheck = DateTime.Parse(startdate.Value);
                    }
                    DateTime? EndDateCheck;
                    if (enddate == null)
                    {
                        EndDateCheck = null;
                    }
                    else
                    {
                        EndDateCheck = DateTime.Parse(enddate.Value);
                    }
                    var trainer = context.Photographers.Where(p => p.FirstName + " " + p.LastName == trainerName.Value).FirstOrDefault();

                    if (trainer==null)
                    {
                        Console.WriteLine("Error! Invalid Data");
                        continue;
                    }

                    var workshopEntity = new Workshop()
                    {
                        Name=name.Value,
                        StartDate= StartdateCheck,
                        EndDate = EndDateCheck,
                        Location=location.Value,
                        PricePerParticipant=decimal.Parse(price.Value),
                        Trainer=trainer
                    };

                    var participantsXml = workshopXml.XPathSelectElements("participants/participant");
                    foreach (var p in participantsXml)
                    {
                        var firstName = p.Attribute("first-name").Value;
                        string lastName = p.Attribute("last-name").Value;

                        var participantEntity = context.Photographers.Where(ph=>ph.FirstName==firstName && ph.LastName==lastName).FirstOrDefault();
                        workshopEntity.Participants.Add(participantEntity);
                    }

                    try
                    {
                        context.Workshops.Add(workshopEntity);
                        Console.WriteLine("Success");
                    }
                    catch (DbEntityValidationException)
                    {
                        context.Workshops.Remove(workshopEntity);
                        Console.WriteLine("Error");
                    }

                }
                context.SaveChanges();
            }
        }

        private static DateTime? GetDateOrNull(XAttribute date)
        {
            DateTime? dateCheck = null;
            if (date.Value !=null)
            {
                dateCheck = DateTime.Parse(date.Value);
            }
            return dateCheck;
        }

        private static Photographer GetRandomOwner(PhotoWorkContext context)
        {
            Random rdn = new Random();
            int onwerCount = context.Photographers.Count();
            int randomId = rdn.Next(1, onwerCount);
            return context.Photographers.Find(randomId);
        }

    }
}
