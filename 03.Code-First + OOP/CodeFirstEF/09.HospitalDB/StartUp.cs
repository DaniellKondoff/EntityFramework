using _09.HospitalDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.HospitalDB
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var context = new HospitalContext();

            //context.Database.Initialize(true);

            var patient = new Patient()
            {
                FirstName = "Marrika",
                LastName = "Obstova",
                Addres = "Luvov most No.1",
                Email = "marrika@abv.bg",
                BirthDate = new DateTime(1990, 05, 07)
            };

            var doctor = new Doctor()
            {
                Name = "DoctorName",
                Speciality = "GP"
            };

            var visitation = new Visitation()
            {
                Comments = "Mnoo zle",
                Patient = patient,
                VisitationDate = DateTime.Now,
                Doctor = doctor
            };

            patient.Visitations.Add(visitation);
            doctor.Visitations.Add(visitation);

            var diagnose = new Diagnose()
            {
                Name = "HIV",
                Comments = "Ot mangalite na luvov most",
                Patient = patient
            };
            patient.Diagnoses.Add(diagnose);

            var medicament = new Medicament()
            {
                Name = "Paracetamol",
            };
            patient.Medicaments.Add(medicament);
            medicament.Patients.Add(patient);

            context.Patients.Add(patient);
            context.Doctors.Add(doctor);
            context.Visitations.Add(visitation);
            context.Diagnoses.Add(diagnose);
            context.Medicaments.Add(medicament);
            context.SaveChanges();

        }
    }
}
