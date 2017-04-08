using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photography.Data;
using Photography.Models;
using Newtonsoft.Json;

namespace Photography.Export
{
    public static class JsonExport
    {
        internal static void GetOrderedPhotographers()
        {
            using (PhotoWorkContext context=new PhotoWorkContext())
            {
                var photographers = context.Photographers
                    .Select(p => new 
                    {
                        FirstName=p.FirstName,
                        LastName = p.LastName,
                        Phone=p.Phone
                    })
                    .OrderBy(p=>p.FirstName)
                    .ThenByDescending(p=>p.LastName)
                    .ToList();

                var phographersAsJson = JsonConvert.SerializeObject(photographers, Formatting.Indented);
                Console.WriteLine(phographersAsJson);
            }
        }

        internal static void GetLandscapePhotographers()
        {
            using (PhotoWorkContext context=new PhotoWorkContext())
            {
                var photographers = context.Photographers
                    .Where(p => p.PrimeryCamera is DslrCamera && p.Lenses.Count() > 0 && p.Lenses.All(l => l.FocalLength <= 30))
                    .Select(p => new
                    {
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                        CameraMake = p.PrimeryCamera.Make,
                        LensesCount = p.Lenses.Count
                    })
                    .OrderBy(p => p.FirstName)
                    .ToList();

                var phAsJson = JsonConvert.SerializeObject(photographers, Formatting.Indented);
                Console.WriteLine(phAsJson);

            }
        }
    }
}
