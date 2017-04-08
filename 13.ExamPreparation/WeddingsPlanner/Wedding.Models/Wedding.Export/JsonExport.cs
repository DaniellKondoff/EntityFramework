using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wedding.Data;
using Wedding.Models.Enums;

namespace Wedding.Export
{
    public static class JsonExport
    {
        internal static void ExportAdancies()
        {
            using (WeddingContext context=new WeddingContext())
            {
                var agancies = context.Agency
                    .Select(a => new
                    {
                        name = a.Name,
                        count = a.EmployeesCount,
                        town = a.Town
                    })
                    .OrderByDescending(a => a.count)
                    .ThenBy(a => a.name)
                    .ToList();

                var agenciesAsJson = JsonConvert.SerializeObject(agancies, Formatting.Indented);
                Console.WriteLine(agenciesAsJson);
            }
        }

        internal static void ExportGuestList()
        {
            using (WeddingContext context=new WeddingContext())
            {
                var guestList = context.Weddings
                    .Select(w => new
                    {
                        bride = w.Bride.FullName,
                        bridegroom = w.Bridegroom.FullName,
                        agency = new
                        {
                            name = w.Agency.Name,
                            town = w.Agency.Town
                        },
                        invitedGuests = w.Invitations.Count(),
                        brideGuests = w.Invitations.Where(i => i.Family == Family.Bride).Count(),
                        bridegroomGuests = w.Invitations.Where(i => i.Family == Family.Bridegroom).Count(),
                        attendingGuests = w.Invitations.Where(i => i.IsAttending).Count(),
                        guest = w.Invitations.Where(i => i.IsAttending).Select(i => i.Guest.FullName)
                    })
                    .OrderByDescending(w => w.invitedGuests)
                    .ThenBy(w => w.attendingGuests)
                    .ToList();
            }
        }
    }
}
