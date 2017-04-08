using CarDealer.Data;
using CarDealer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var context = new CarContext();
            context.Database.Initialize(true);
            //5.ImportData
            //ImportSuppliers(context);
            //InportParts(context);
            //ImportCars(context);
            //ImportCustomers(context);
            //SeedSales(context);
            //Query
            //OrderCustomers(context);
            //CarsFromToyota(context);
            //LocalSuplliers(context);
            //CarsWithParts(context);
            //TotalSalesByCustomer(context);
            //SalesAppliedDiscount(context);
        }

        private static void SalesAppliedDiscount(CarContext context)
        {
            var sales = context.Sales
                .Select(s => new
                {
                    car = new
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    CustomerName = s.Customer.Name,
                    Discount = s.Discaunt,
                    Price = s.Car.Parts.Sum(p => p.Price),
                    PriceWithDiscount = s.Car.Parts.Sum(p => p.Price) *(1-s.Discaunt)
                }).ToList();

            string salesJson = JsonConvert.SerializeObject(sales, Formatting.Indented);
            Console.WriteLine(salesJson);
            File.WriteAllText("../../../JsonResult/salesJson.json", salesJson);

        }

        private static void TotalSalesByCustomer(CarContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Count >= 1)
                .Select(c => new
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales.Sum(s => s.Car.Parts.Sum(p => p.Price))
                })
                .OrderByDescending(c => c.SpentMoney)
                .ThenByDescending(c => c.BoughtCars)
                .ToList();

            string customersJson = JsonConvert.SerializeObject(customers,Formatting.Indented);
            Console.WriteLine(customersJson);
            File.WriteAllText("../../../JsonResult/customersJson.json", customersJson);

        }

        private static void CarsWithParts(CarContext context)
        {
            var cars = context.Cars
                .Select(c=> new
                {
                    car=new
                    {
                        Make=c.Make,
                        Model=c.Model,
                        TravelledDistance=c.TravelledDistance
                    },
                    parts=c.Parts.Select(p=> new
                    {
                        Name=p.Name,
                        Price=p.Price
                    })

                })
                .ToList();

            string carJson = JsonConvert.SerializeObject(cars, Formatting.Indented);
            Console.WriteLine(carJson);
            File.WriteAllText("../../../JsonResult/carJson.json", carJson);
        }

        private static void LocalSuplliers(CarContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    Id=s.Id,
                    Name=s.Name,
                    PartsCount=s.Parts.Count
                })
                .ToList();

            string jsonSuppliers = JsonConvert.SerializeObject(suppliers, Formatting.Indented);
            Console.WriteLine(jsonSuppliers);
            File.WriteAllText("../../../JsonResult/jsonSuppliers.json", jsonSuppliers);
        }

        private static void CarsFromToyota(CarContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToList();

            string jsonCars = JsonConvert.SerializeObject(cars,Formatting.Indented);
            Console.WriteLine(jsonCars);
            File.WriteAllText("../../../JsonResult/CarsFromToyota.json", jsonCars);
        }

        private static void OrderCustomers(CarContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .ToList();

            string jsonCustomers = JsonConvert.SerializeObject(customers, Formatting.Indented);
            Console.WriteLine(jsonCustomers);
            File.WriteAllText("../../../JsonResult/OrderedCustomers.json", jsonCustomers);
        }

        private static void SeedSales(CarContext context)
        {
            Random rnd = new Random();
            var cars = context.Cars.ToList();
            int carsCount = cars.Count();
            var customers = context.Customers.ToList();
            int customersCount = customers.Count();
            decimal[] discountArr = new decimal[] { 0m, 0.05m, 0.1m, 0.15m, 0.2m, 0.3m, 0.4m, 0.5m };

            for (int i = 0; i < 150; i++)
            {
                int carId = rnd.Next(1, carsCount);
                //Car car = cars.FirstOrDefault(c => c.Id == carId);

                int customerId = rnd.Next(1, customersCount);
                Customer customer = customers.FirstOrDefault(c => c.Id == customerId);

                int discountIndex = rnd.Next(0, discountArr.Length);
                decimal discaountRate = discountArr[discountIndex];
                if (customer.IsYoungDriver)
                {
                    discaountRate += 0.5m;
                }

                Sale sale = new Sale
                {
                    CarId = carId,
                    CustomerId = customerId,
                    Discaunt = discaountRate
                };

                context.Sales.Add(sale);
            }
            context.SaveChanges();
        }

        private static void ImportCustomers(CarContext context)
        {
            string customerJson = File.ReadAllText("../../Import/customers.json");
            List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(customerJson);
            context.Customers.AddRange(customers);
            context.SaveChanges();
        }

        private static void ImportCars(CarContext context)
        {
            string carsJson = File.ReadAllText("../../Import/cars.json");
            List<Car> cars = JsonConvert.DeserializeObject<List<Car>>(carsJson);
            
            int partsCount = context.Parts.Count();
            Random rnd = new Random();

            foreach (var car in cars)
            {
                int numberOfPartsToAdd = rnd.Next(10, 21);

                for (int i = 0; i < numberOfPartsToAdd; i++)
                {
                    int partId = rnd.Next(0, partsCount)+1;
                    var part = context.Parts.Find(partId);
                    car.Parts.Add(part);
                    //part.Cars.Add(car);
                }
            }
            context.Cars.AddRange(cars);
            context.SaveChanges();
        }

        private static void InportParts(CarContext context)
        {
            string partsJson = File.ReadAllText("../../Import/parts.json");
            List<Part> parts = JsonConvert.DeserializeObject<List<Part>>(partsJson);

            int number = 0;
            int supplierCount = context.Suppliers.Count();
            foreach (Part part in parts)
            {
                part.SupplierId = (number % supplierCount) + 1;
                number++;
            }
            context.Parts.AddRange(parts);
            context.SaveChanges();
        }

        private static void ImportSuppliers(CarContext context)
        {
            string supplierJson = File.ReadAllText("../../Import/suppliers.json");
            List<Supplier> suppliers = JsonConvert.DeserializeObject<List<Supplier>>(supplierJson);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();
        }
    }
}
