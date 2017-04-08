using CarDealer.Data;
using CarDealer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            //GetSalesWithAppliedDiscount(context);
            //GetCars(context);
            //CarMakeFromFerari(context);
            //GetLocalSuppliers(context);
            //GetCarWithPartsList(context);
            //GetTotalSalesByCustomer(context);
        }

        private static void GetTotalSalesByCustomer(CarContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Count > 0)
                .Select(c => new
                {
                    Name = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales.Sum(s => s.Car.Parts.Sum(p => p.Price))
                })
                .OrderByDescending(c => c.SpentMoney)
                .ThenByDescending(c => c.BoughtCars)
                .ToList();

            XDocument customerDoc = new XDocument();
            XElement customersXml = new XElement("customers");

            foreach (var customer in customers)
            {
                XElement customerElement = new XElement("customer");
                customerElement.SetAttributeValue("full-name", customer.Name);
                customerElement.SetAttributeValue("bought-cars", customer.BoughtCars);
                customerElement.SetAttributeValue("spent-money", customer.SpentMoney);

                customersXml.Add(customerElement);
            }
            customerDoc.Add(customersXml);
            Console.WriteLine(customerDoc);
            //carDoc.Save("../../GetTotalSalesByCustomer.xml");
        }

        private static void GetCarWithPartsList(CarContext context)
        {
            var cars = context.Cars.Include("Parts")
                .Select(c => new
                {
                    Make=c.Make,
                    Model=c.Model,
                    TravelledDistance=c.TravelledDistance,
                    Parts=c.Parts.Select(p=>new
                    {
                        PartName=p.Name,
                        Price=p.Price
                    })
                }).ToList();

            XDocument carDoc = new XDocument();
            XElement carXml = new XElement("cars");

            foreach (var car in cars)
            {
                XElement carElementXml = new XElement("car");
                carElementXml.SetAttributeValue("make", car.Make);
                carElementXml.SetAttributeValue("model", car.Model);
                carElementXml.SetAttributeValue("travelled-distance", car.TravelledDistance);

                XElement partsElement = new XElement("parts");

                foreach (var part in car.Parts)
                {
                    XElement partElement = new XElement("part");
                    partElement.SetAttributeValue("name", part.PartName);
                    partElement.SetAttributeValue("price", part.Price);
                    partsElement.Add(partElement);
                }

                carElementXml.Add(partsElement);
                carXml.Add(carElementXml);
            }
            
            carDoc.Add(carXml);
            Console.WriteLine(carDoc);
            //carDoc.Save("../../GetCarWithPartsList.xml");
        }

        private static void GetLocalSuppliers(CarContext context)
        {
            var suppliers = context.Suppliers
                .Where(c => c.IsImporter == false)
                .Select(c => new
                {
                    Id = c.Id,
                    Name = c.Name,
                    PartsCount = c.Parts.Count
                }).ToList();

            XDocument suppliersDoc = new XDocument();
            XElement suppliersXml = new XElement("suppliers");

            foreach (var supplier in suppliers)
            {
                XElement supplierElementXml = new XElement("suplier");
                supplierElementXml.SetAttributeValue("id", supplier.Id);
                supplierElementXml.SetAttributeValue("name", supplier.Name);
                supplierElementXml.SetAttributeValue("parts-count", supplier.PartsCount);

                suppliersXml.Add(supplierElementXml);
            }
            suppliersDoc.Add(suppliersXml);
            Console.WriteLine(suppliersDoc);
            //carDoc.Save("../../GetLocalSuppliers.xml");

        }

        private static void CarMakeFromFerari(CarContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "Ferrari")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToList();
            XDocument carDoc = new XDocument();
            XElement carXml = new XElement("cars");

            foreach (var car in cars)
            {
                XElement carElementXml = new XElement("car");
                carElementXml.SetAttributeValue("id", car.Id);
                carElementXml.SetAttributeValue("model", car.Model);
                carElementXml.SetAttributeValue("travelled-distance", car.TravelledDistance);

                carXml.Add(carElementXml);
            }
            carDoc.Add(carXml);
            Console.WriteLine(carDoc);
            //carDoc.Save("../../CarMakeFromFerari.xml");

        }

        private static void GetCars(CarContext context)
        {
            var cars = context.Cars
                .Where(c => c.TravelledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .ToList();
            XDocument carDoc = new XDocument();
            XElement carXml = new XElement("cars");

            foreach (var car in cars)
            {
                XElement carElementXml = new XElement("car");

                XElement makeElement = new XElement("make");
                makeElement.Value = car.Make;

                XElement modelElement = new XElement("model");
                modelElement.Value = car.Model;

                XElement distanceElement = new XElement("travelled-distance");
                distanceElement.Value = car.TravelledDistance.ToString();

                carElementXml.Add(makeElement);
                carElementXml.Add(modelElement);
                carElementXml.Add(distanceElement);

                carXml.Add(carElementXml);
            }
            carDoc.Add(carXml);
            carDoc.Save("../../GetCars.xml");
            //Console.WriteLine(carDoc);

        }

        private static void GetSalesWithAppliedDiscount(CarContext context)
        {
            var sales = context.Sales
                .Select(s => new
                {
                    car= new
                    {
                        Make=s.Car.Make,
                        Model=s.Car.Model,
                        TravelledDistance=s.Car.TravelledDistance
                    },
                    CustomerName=s.Customer.Name,
                    Price=s.Car.Parts.Sum(p=>p.Price),
                    Discount=s.Discaunt,
                    PriceWithDiscount= (s.Car.Parts.Sum(p => p.Price) * (1-s.Discaunt))
                }).ToList();

            XDocument saleDoc = new XDocument();
            XElement salesXml = new XElement("sales");


            foreach (var sale in sales)
            {
                XElement saleXMl = new XElement("sale");

                XElement car = new XElement("car");
                car.SetAttributeValue("make", sale.car.Make);
                car.SetAttributeValue("model", sale.car.Model);
                car.SetAttributeValue("travelled-distance", sale.car.TravelledDistance);

                XElement customer = new XElement("customer-name");
                customer.Value = sale.CustomerName;

                XElement discount = new XElement("discount");
                discount.Value = sale.Discount.ToString();

                XElement price = new XElement("price");
                price.Value = sale.Price.ToString();

                XElement priceWithDiscount = new XElement("price-with-discount");
                priceWithDiscount.Value = sale.PriceWithDiscount.ToString();

                saleXMl.Add(car);
                saleXMl.Add(customer);
                saleXMl.Add(discount);
                saleXMl.Add(price);
                saleXMl.Add(priceWithDiscount);

                salesXml.Add(saleXMl);
            }
            saleDoc.Add(salesXml);
            Console.WriteLine(saleDoc);
        }

        private static void SeedSales(CarContext context)
        {
            Random rnd = new Random();
            int carsCount = context.Cars.Count();
            int customersCount = context.Customers.Count();

            for (int i = 0; i < 100; i++)
            {
                Sale sale = new Sale()
                {
                    CarId = rnd.Next(1, carsCount+1),
                    CustomerId = rnd.Next(1, customersCount+1),
                    Discaunt = i % 2 == 0 ? 0.05M : 0.00M
                };

                context.Sales.Add(sale);
            }
            context.SaveChanges();
        }

        private static void ImportCustomers(CarContext context)
        {
            XDocument customerDoc = XDocument.Load("../../Import/customers.xml");
            XElement customerRoot = customerDoc.Root;

            foreach (XElement customerElement in customerRoot.Elements())
            {
                string name = customerElement.Attribute("name").Value;
                DateTime birthDate = DateTime.Parse(customerElement.Element("birth-date").Value);
                bool isYoungDriver = bool.Parse(customerElement.Element("is-young-driver").Value);

                Customer customer = new Customer()
                {
                    Name = name,
                    BirthDate = birthDate,
                    IsYoungDriver = isYoungDriver
                };

                context.Customers.Add(customer);
            }
            context.SaveChanges();
        }

        private static void ImportCars(CarContext context)
        {
            XDocument carsDoc = XDocument.Load("../../Import/cars.xml");
            XElement carsRoot = carsDoc.Root;

            foreach (XElement carElement in carsRoot.Elements())
            {
                string make = carElement.Element("make").Value;
                string model = carElement.Element("model").Value;
                long travellDistance = long.Parse(carElement.Element("travelled-distance").Value);

                Car car = new Car()
                {
                    Make = make,
                    Model = model,
                    TravelledDistance = travellDistance
                };
                int partsCount = context.Parts.Count();
                for (int i = 0; i < 10+(i%10); i++)
                {
                    Part part = context.Parts.Find((carElement.GetHashCode() +i %partsCount)+1);
                    car.Parts.Add(part);
                }

                context.Cars.Add(car);
            }
            context.SaveChanges();
        }

        private static void InportParts(CarContext context)
        {
            XDocument partsDoc = XDocument.Load("../../Import/parts.xml");
            XElement partsRoot = partsDoc.Root;
            //  <part name="Bonnet/hood" price="1001.34" quantity="10" />
            int number = 0;
            int suppliersCount = context.Suppliers.Count();
            foreach (var part in partsRoot.Elements())
            {
                string name = part.Attribute("name").Value;
                decimal price= decimal.Parse(part.Attribute("price").Value);
                int quantity = int.Parse(part.Attribute("quantity").Value);

                Part partNew = new Part()
                {
                    Name = name,
                    Price = price,
                    Quantity = quantity,
                    SupplierId= (number % suppliersCount)+1
                };
                context.Parts.Add(partNew);
                number++;
            }
            context.SaveChanges();
            
        }

        private static void ImportSuppliers(CarContext context)
        {
            XDocument supplierDoc = XDocument.Load("../../Import/suppliers.xml");
            XElement supplierRoot = supplierDoc.Root;

            foreach (var supplierElement in supplierRoot.Elements())
            {
                string name = supplierElement.Attribute("name").Value;
                bool isImportal = bool.Parse(supplierElement.Attribute("is-importer").Value);

                Supplier supp = new Supplier()
                {
                    Name = name,
                    IsImporter = isImportal
                };

                context.Suppliers.Add(supp);
            }
            context.SaveChanges();
        }
    }
}
