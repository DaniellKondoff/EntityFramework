using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Employees_full_information
{
    class AddAddressUpdEmp
    {
        public static void AddingAdressUpdateEmp(SoftUniContext context)
        {
            Address adress = new Address();
            adress.AddressText = "Vitoshka 15";
            adress.TownID = 4;
            context.Addresses.Add(adress);
            
            var employee = context.Employees.FirstOrDefault(e=>e.LastName=="Nakov");
            employee.Address = adress;
            context.SaveChanges();

            var adresses = context.Employees.OrderByDescending(e => e.AddressID).Take(10).Select(e=>e.Address.AddressText).ToList();
            foreach (var adr in adresses)
            {
                Console.WriteLine(adr);
            }
        }
    }
}
