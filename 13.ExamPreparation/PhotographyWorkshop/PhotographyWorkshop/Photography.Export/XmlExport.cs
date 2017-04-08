using Photography.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Photography.Models;

namespace Photography.Export
{
    public static class XmlExport
    {
        internal static void GetPhWithSameCamera()
        {
            using (PhotoWorkContext context=new PhotoWorkContext())
            {
                var ph = context.Photographers
                    .Where(p => p.PrimeryCamera.Make == p.SecondaryCamera.Make)
                    .Select(p => new
                    {
                        FullName = p.FirstName + " " + p.LastName,
                        Primarycamera = p.PrimeryCamera.Make + " " + p.PrimeryCamera.Model,
                        Lenses = p.Lenses
                    }).ToList();

                XDocument phDoc = new XDocument();
                XElement phElement = new XElement("photographers");

                foreach (var p in ph)
                {
                    XElement currentPh = new XElement("photographer");
                    currentPh.SetAttributeValue("name", p.FullName);
                    currentPh.SetAttributeValue("primary-camera", p.Primarycamera);

                    if (p.Lenses.Count>0)
                    {
                        XElement lensElement = new XElement("lenses");
                        foreach (var lens in p.Lenses)
                        {
                            XElement len = new XElement("lens");
                            len.Value = $"{lens.Make} {lens.FocalLength}mm f{lens.MaxAperture}";
                            lensElement.Add(len);
                        }
                        currentPh.Add(lensElement);
                    }
                    phElement.Add(currentPh);
                }
                phDoc.Add(phElement);
                Console.WriteLine(phDoc);
            }
        }

        internal static void GetWorkshopsByLocation()
        {
            using (PhotoWorkContext context=new PhotoWorkContext())
            {
                var workshopsEnt = context.Workshops.GroupBy(w => w.Location, ws => ws, (location, workshop) => new
                {
                    Location = location,
                    WorkShops = workshop.Where(ws => ws.Participants.Count >= 5)
                })
                .Where(ws => ws.WorkShops.Count() > 0)
                .Select(wsp => new
                {
                    Location = wsp.Location,
                    Workshops = wsp.WorkShops
                }).ToList();

                var xml = new XElement("locations");

                foreach (var location in workshopsEnt)
                {
                    XElement locationElement = new XElement("location");
                    locationElement.SetAttributeValue("name", location.Location);

                    foreach (var ws in location.Workshops)
                    {
                        XElement wselement = new XElement("workshop");
                        wselement.SetAttributeValue("name", ws.Name);
                        wselement.SetAttributeValue("total-profit", CalculateTotalPorofit(ws));

                        XElement participantEelement = new XElement("participants");
                        participantEelement.SetAttributeValue("count", ws.Participants.Count);

                        foreach (var part in ws.Participants)
                        {
                            var participantNode = new XElement("participant");
                            participantNode.Value = part.FirstName + " " + part.LastName;
                            participantEelement.Add(participantNode);
                        }
                        wselement.Add(participantEelement);
                        locationElement.Add(wselement);
                    }
                    xml.Add(locationElement);
                }
                Console.WriteLine(xml);
            }
        }

        private static object CalculateTotalPorofit(Workshop ws)
        {
            var totalProfit = (ws.Participants.Count * ws.PricePerParticipant - ((ws.Participants.Count * ws.PricePerParticipant)) * 0.2m);
            return totalProfit;
        }
    }
}
