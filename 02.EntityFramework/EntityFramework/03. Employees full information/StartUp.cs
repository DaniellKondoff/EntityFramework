using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _03.Employees_full_information
{
    class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();
            GringottsContext contextG = new GringottsContext();
            //AllEmployyes(context);
            //EmpWithSalaray.EmpWithSalara500(context);
            //EmpFromSeatle.EmpsFromSeattle(context);
            //AddAddressUpdEmp.AddingAdressUpdateEmp(context);
            //FindEmpPeriod.EmployeesInPeriod(context);
            //AdressesByTownName.GetAdressesByTownName(context);
            //EmployeesId147.GetEmployeeId(context);
            //DepartmentsMoreThan5Emp.GetDepartmentsMoreThan5Emp(context);
            //FindLatest10Projects.GetLatest10Projects(context);
            //IncreaseSalaries.GetIncreaseSalaries(context);
            //FIndEmpFirstName.GetEmpFirstNameSA(context);
            //FirstLetter.GetFirstName(contextG);
            //DeleteProejctById.GetDeletePrejctById(context);
            DeleteTown.GetDeleteTown(context);
            //NativSQL.GetNativeSql(context);

        }

        private static void AllEmployyes(SoftUniContext context)
        {
            var employyes = context.Employees.ToList().OrderBy(e => e.EmployeeID);
            foreach (var emp in employyes)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName} {emp.MiddleName} {emp.JobTitle} {emp.Salary:f4}");
            }
        }
    }
}
