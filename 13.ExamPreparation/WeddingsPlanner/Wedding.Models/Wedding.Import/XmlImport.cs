using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;
using Wedding.Data;
using Wedding.Models;

namespace Wedding.Import
{
    public static class XmlImport
    {
        internal static void ImportPresents()
        {
            using (WeddingContext context = new WeddingContext())
            {


                var xml = XDocument.Load("../../../datasets/presents.xml");
                var presentsXml = xml.XPathSelectElements("presents/present");

                foreach (var p in presentsXml)
                {
                    var typeAttribute = p.Attribute("type");
                    var invitationAttribute = p.Attribute("invitation-id");

                    if (typeAttribute == null || invitationAttribute == null)
                    {
                        Console.WriteLine("Error. Invalid data provided type");
                        continue;
                    }

                    var invitationId = int.Parse(invitationAttribute.Value);
                    if (invitationId <= 0 || invitationId > context.Invitations.Count())
                    {
                        Console.WriteLine("Error. Invalid data provided type");
                        continue;
                    }

                    if (typeAttribute.Value=="cache")
                    {
                        var amountAttribute = p.Attribute("amount");
                        if (amountAttribute==null)
                        {
                            Console.WriteLine("Error. Invalid data provided type");
                            continue;
                        }
                        var cash = new Cash()
                        {
                            Amount = decimal.Parse(amountAttribute.Value)
                        };
                        Invitation inv = context.Invitations.Find(invitationId);
                        inv.Present = cash;
                    }

                }
            }
        }

        internal static void ImportVanues()
        {
            var xml = XDocument.Load("../../../datasets/venues.xml");
            var venuesXml = xml.XPathSelectElements("venues/venue");

            using (WeddingContext context =new WeddingContext())
            {
                foreach (var venue in venuesXml)
                {
                    var name = venue.Attribute("name").Value;
                    var capacity = int.Parse(venue.XPathSelectElement("capacity").Value);
                    var town = venue.XPathSelectElement("town").Value;

                    Venue venueEntity = new Venue()
                    {
                        Name=name,
                        Capacity=capacity,
                        Town=town
                    };

                    context.Venue.Add(venueEntity);
                    context.SaveChanges();
                    Console.WriteLine($"Successfully imported {name}");
                }
            }
        }
    }
}
