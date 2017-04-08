using AutoMapper;
using AutoMapper.QueryableExtensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Demo
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //JavaScriptSerializer serializer = new JavaScriptSerializer();
            //var product = new Product()
            //{
            //    Name = "Washer Fluid",
            //    Cost = 10m
            //};

            //var dog = new Dog()
            //{
            //    Name = "balkan",
            //    Age = 6
            //};
            //var person = new Person()
            //{
            //    Name = "atanas",
            //    Age = 54,
            //    Dog=dog
            //};

            //var jsonProduct=serializer.Serialize(person);
            //Console.WriteLine(jsonProduct);

            //string json = "{'Name':'Milko','Age':15,'Dog':null}";
            //var persObj= serializer.Deserialize<Person>(json);

            Mapper.Initialize(cfg => cfg.CreateMap<Product, ProductDto>());

            //string jsonFromDict = "{\"Oil Pump\":{\"Name\":\"Oil Pump\",\"Cost\":25.00},\"Product 2\":{\"Name\":\"Product 2\",\"Cost\":30.00}}";
            //using (var context=new Context())
            //{
            //    var products = context.Products.ProjectTo<ProductDto>().ToList();
            //    var productsDict = new Dictionary<string, ProductDto>();

            //    foreach (var prod in products)
            //    {
            //        productsDict.Add(prod.Name, prod);
            //    }

            //    //var jsonProducts = serializer.Serialize(products);
            //    var jsonDict = serializer.Serialize(productsDict);
            //    Console.WriteLine(jsonDict);

            //    var dict=serializer.Deserialize<Dictionary<string, ProductDto>>(jsonFromDict);
            //    Console.WriteLine();

            //JSON.NET - Second Part of Presentation

            //using (var context = new Context())
            //{
            //    var product = context.Products.ProjectTo<ProductDto>().ToList();
            //    string jsonProduct=JsonConvert.SerializeObject(product,Formatting.Indented);
            //    Console.WriteLine(jsonProduct);
            //}

            //string jsonFromProd = "{\"Name\":\"Oil Pump\",\"Cost\":25.00}";
            //var objProduct= JsonConvert.DeserializeObject<ProductDto>(jsonFromProd);
            //Console.WriteLine();

            //string jsonFromDict = "{\"Oil Pump\":{\"Name\":\"Oil Pump\",\"Cost\":25.00},\"Product 2\":{\"Name\":\"Product 2\",\"Cost\":30.00}}";

            //var Dict = JsonConvert.DeserializeObject<Dictionary<string, ProductDto>>(jsonFromDict);
            //string jsonProducts = JsonConvert.SerializeObject(Dict, Formatting.Indented);
            //Console.WriteLine(jsonProducts);

            //Uknown OBJ
            //var json = @"{ 'firstName': 'Vladimir','lastName': 'Georgiev','jobTitle':'Technical Trainer' }";
            //var template = new
            //{
            //    FirstName = string.Empty,
            //    LastName = string.Empty,
            //    JobTitle = string.Empty
            //};
            //var person = JsonConvert.DeserializeAnonymousType(json, template);
            //Console.WriteLine(person);

            //LinqToJson

            //var product = new ProductDto
            //{
            //    Name = "Washer Fluid",
            //    Cost = 10m
            //};

            //string json= "{\"Name\":\"Oil Pump\",\"Cost\":25.00}";
            //JObject jObj = JObject.Parse(json);
            //Console.WriteLine(jObj["Name"]);

            //XML
            //XDocument xmlDoc = XDocument.Parse(@"<?xml version=""1.0""?><Root><Child>Value</Child></Root>");


            //XDocument xmlDoc = XDocument.Load("../../Import/cars.xml");

            //var cars = xmlDoc.Root.Elements();

            //foreach (var car in cars)
            //{
            //    var make = car.Element("make").Value;
            //    var model = car.Element("model").Value;
            //    Console.WriteLine($"{make}-{model}");
            //}

            //Atributes
            //XDocument xmlDoc = XDocument.Load("../../Import/customers.xml");

            //var customers = xmlDoc.Root.Elements();

            //foreach (var c in customers)
            //{
            //    Console.WriteLine(c.Attribute("name").Value);
            //}

            //var youndDrivers = xmlDoc.Root.Elements()
            //    .Where(d => d.Element("is-young-driver").Value == "true")
            //    .Select(d => d.Attribute("name").Value)
            //    .ToList();
            //foreach (var y in youndDrivers)
            //{
            //    Console.WriteLine(y);
            //}

            //XDocument xmlDoc = new XDocument();
            //xmlDoc.Add(
            //  new XElement("books",
            //    new XElement("book",
            //      new XElement("author", "Don Box"),
            //      new XElement("title", "ASP.NET", new XAttribute("lang", "en"))
            //)));
            //Console.WriteLine(xmlDoc);

            //xmlDoc.Save("../../Import/book.xml");

            //var product = new ProductDto
            //{
            //    Name = "Transmition",
            //    Cost = 800m
            //};

            //var serializer = new XmlSerializer(product.GetType());
            var serializer = new XmlSerializer(typeof(ProductDto));
            //var writer = new StreamWriter("../../Import/products.xml");

            //using (writer)
            //{
            //    serializer.Serialize(writer, product);
            //}
            //var reader = new StreamReader("../../Import/products.xml");
            //var product = (ProductDto)serializer.Deserialize(reader);
            //Console.WriteLine(product.Name);
            //Console.WriteLine(product.Cost);
        }
    }
}

public class Dog
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person Owner { get; set; }
}

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public Dog Dog { get; set; }
}

public class ProductDto
{
    public string Name { get; set; }

    public decimal Cost { get; set; }

}

