using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photography.Data;
using System.IO;
using Newtonsoft.Json;
using Photography.Data.DTO;
using Photography.Models;
using System.Data.Entity.Validation;

namespace Photography.Import
{
    public static class JsonImport
    {
        private const string CamerasPath = "../../../datasets/cameras.json";
        private const string LensePath = "../../../datasets/lenses.json";
        private const string PhotographersPath = "../../../datasets/photographers.json";

        internal static void ImportCameras()
        {
            string camerasJson = File.ReadAllText(CamerasPath);
            var camerasDtos = JsonConvert.DeserializeObject<IEnumerable<CameraDto>>(camerasJson);
            using (PhotoWorkContext context = new PhotoWorkContext())
            {
                foreach (var cameraDto in camerasDtos)
                {
                    if (cameraDto.Type==null || cameraDto.Make==null || cameraDto.Model==null || cameraDto.MinISO<100)
                    {
                        Console.WriteLine("Error: Invalid data.");
                        continue;
                    }

                    try
                    {
                        if (cameraDto.Type == "DSLR")
                        {
                            DslrCamera dslEntity = new DslrCamera()
                            {
                                Make = cameraDto.Make,
                                Model = cameraDto.Model,
                                IsFullFrame = cameraDto.IsFullFrame,
                                MinIso = cameraDto.MinISO,
                                MaxIso = cameraDto.MaxISO,
                                MaxShutterSpeed = cameraDto.MaxShutterSpeed
                            };
                            context.Cameras.Add(dslEntity);
                            Console.WriteLine($"Successfully imported {cameraDto.Type} {dslEntity.Make} {dslEntity.Model}");
                        }
                        else
                        {
                            MirrorlesssCamera dslEntity = new MirrorlesssCamera()
                            {
                                Make = cameraDto.Make,
                                Model = cameraDto.Model,
                                IsFullFrame = cameraDto.IsFullFrame,
                                MinIso = cameraDto.MinISO,
                                MaxIso = cameraDto.MaxISO,
                                MaxFrameRate = cameraDto.MaxFrameRate,
                                MaxVideoResolution = cameraDto.MaxVideoResolution
                            };
                            context.Cameras.Add(dslEntity);
                            Console.WriteLine($"Successfully imported {cameraDto.Type} {dslEntity.Make} {dslEntity.Model}");
                        }
                    }
                    catch (DbEntityValidationException)
                    {
                        
                        Console.WriteLine("Error: Invalid data.");
                    }                 
                }
                context.SaveChanges();
            }
        }

        internal static void ImportLenses()
        {
            string lensJson = File.ReadAllText(LensePath);
            var lensesDtos = JsonConvert.DeserializeObject<IEnumerable<Lens>>(lensJson);

            using (PhotoWorkContext context=new PhotoWorkContext())
            {
                foreach (var lenseDto in lensesDtos)
                {
                    Lens lensEntity = new Lens()
                    {
                        Make = lenseDto.Make,
                        FocalLength = lenseDto.FocalLength,
                        MaxAperture = lenseDto.MaxAperture,
                        CompatibleWith = lenseDto.CompatibleWith
                    };
                    context.Lenses.Add(lensEntity);
                    Console.WriteLine($"Successfully imported {lensEntity.Make} {lensEntity.FocalLength}mm f{lensEntity.MaxAperture}");
                }
                context.SaveChanges();
            }
        }

        internal static void ImportPhotographers()
        {
            string photographJson = File.ReadAllText(PhotographersPath);
            var photographDtos = JsonConvert.DeserializeObject<IEnumerable<PhotographDto>>(photographJson);

            using (PhotoWorkContext context=new PhotoWorkContext())
            {
                foreach (var ph in photographDtos)
                {
                    Photographer photoEntity = new Photographer()
                    {
                        FirstName = ph.FirstName,
                        LastName = ph.LastName,
                        Phone = ph.Phone
                    };
                    Camera primeryCamera = GetRandomCamera(context);
                    Camera secondaryCamera = GetRandomCamera(context);
                    photoEntity.PrimeryCameraId = primeryCamera.Id;
                    photoEntity.SecondaryCameraId = secondaryCamera.Id;

                    foreach (var lens in ph.Lenses)
                    {
                        var lensEntity = context.Lenses.Find(lens);
                        if (lensEntity!=null)
                        {
                            photoEntity.Lenses.Add(lensEntity);
                        }
                    }

                    try
                    {
                        context.Photographers.Add(photoEntity);
                        context.SaveChanges();
                        Console.WriteLine($"Successfully imported {photoEntity.FirstName} {photoEntity.LastName} | Lenses: {photoEntity.Lenses.Count}");
                        
                    }
                    catch (DbEntityValidationException)
                    {
                        context.Photographers.Remove(photoEntity);
                        Console.WriteLine("Error");

                    }
                }
            }
        }

        private static Camera GetRandomCamera(PhotoWorkContext context)
        {
            Random rnd = new Random();
            int camerasCount = context.Cameras.Count();
            int randomId = rnd.Next(1, camerasCount);
            var camera = context.Cameras.Find(randomId);
            return camera;
        }
    }
}
