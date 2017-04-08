using ExamPrep.Data;
using ExamPrep.Data.DTO;
using ExamPrep.Data.Store;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace ExamPrep.Import
{
    public static class JsonImport
    {
        public static void ImportSolarSystem()
        {
            var json = File.ReadAllText("../../../datasets/solar-systems.json");
            var systems = JsonConvert.DeserializeObject<IEnumerable<SolarSystemDto>>(json);
            SolarSystemStore.AddSolarSystems(systems);
        }

        internal static void ImportVictims()
        {
            var json = File.ReadAllText("../../../datasets/anomaly-victims.json");
            var victims = JsonConvert.DeserializeObject<IEnumerable<VictimDto>>(json);
            AnomalyStore.AddVictimsToAnomaly(victims);
        }

        internal static void ImportAnomalies()
        {
            var json = File.ReadAllText("../../../datasets/anomalies.json");
            var anomalies = JsonConvert.DeserializeObject<IEnumerable<AnamalyDto>>(json);
            AnomalyStore.AddAnomalies(anomalies);
        }

        public static void ImportStars()
        {
            var json = File.ReadAllText("../../../datasets/stars.json");
            var stars = JsonConvert.DeserializeObject<IEnumerable<StartDto>>(json);
            StarsStore.AddStars(stars);
        }

        public static void ImportPlanets()
        {
            var json = File.ReadAllText("../../../datasets/planets.json");
            var planets = JsonConvert.DeserializeObject<IEnumerable<PlanetDto>>(json);
            PlanetStore.AddPlanets(planets);
        }

        public static void ImportPeople()
        {
            var json = File.ReadAllText("../../../datasets/persons.json");
            var people = JsonConvert.DeserializeObject<IEnumerable<PeopleDto>>(json);
            PeopleStore.AddPeople(people);
        }
    }
}
