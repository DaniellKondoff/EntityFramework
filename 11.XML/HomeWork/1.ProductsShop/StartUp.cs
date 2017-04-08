using Newtonsoft.Json;
using ProductsShop.Data;
using ProductsShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace _1.ProductsShop
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var context = new ProductShopContext();
            //context.Database.Initialize(true);

            //2.ImportingData
            //ImportUsers(context);
            //ImportProduct(context);
            //ImportCategories(context);
            //3.Query and ExportData
            //GetProductsInRange(context);
            //GetSoldProducts(context);
            //GetCategoriesByProductCount(context);
            GetUsersAndProducts(context);
        }

        private static void GetUsersAndProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Count > 0)
                .OrderByDescending(u => u.ProductsSold.Count)
                .ThenBy(u => u.LastName)
                .Select(u => new
                {
                    FirstName=u.FirstName,
                    LastName=u.LastName,
                    Age=u.Age,
                    Product=u.ProductsSold
                        .Select(p=>new
                    {
                        Name=p.Name,
                        Price=p.Price
                    })
                }).ToList();

            XElement xmlDoc = new XElement("Users");
            xmlDoc.Add(new XAttribute("count", users.Count));

            foreach (var user in users)
            {
                XElement userNode = new XElement("user");
                if (user.FirstName!=null)
                {
                    userNode.Add(new XAttribute("first-name", user.FirstName));
                }
                userNode.Add(new XAttribute("last-name", user.LastName));
                if (user.Age!=0)
                {
                    userNode.Add(new XAttribute("age", user.Age));

                }

                XElement soldProductNode = new XElement("sold-products");
                soldProductNode.Add(new XAttribute("count", user.Product.Count()));
                foreach (var p in user.Product)
                {
                    XElement productNode = new XElement("product");
                    productNode.Add(new XAttribute("name", p.Name));
                    productNode.Add(new XAttribute("price", p.Price));
                    soldProductNode.Add(productNode);
                }
                userNode.Add(soldProductNode);
                xmlDoc.Add(userNode);
            }

            //Console.WriteLine(xmlDoc);
            xmlDoc.Save("../../Export/GetUsersAndProducts.xml");
        }

        private static void GetCategoriesByProductCount(ProductShopContext context)
        {
            var categories = context.Categories.Where(c=>c.Products.Count>0)
                .OrderBy(c => c.Products.Count)
                .Select(c => new
                {
                    Name = c.Name,
                    ProductCount = c.Products.Count,
                    AveragePrice = c.Products.Average(p => p.Price),
                    TotalRevenu = c.Products.Sum(p => p.Price)
                }).ToList();

            XElement xmlDoc = new XElement("categories");
            foreach (var category in categories)
            {
                XElement categoryNode = new XElement("category");

                categoryNode.Add(new XAttribute("name", category.Name));
                categoryNode.Add(new XElement("product-count", category.ProductCount));
                categoryNode.Add(new XElement("average-price", category.AveragePrice));
                categoryNode.Add(new XElement("total-revenue", category.TotalRevenu));

                xmlDoc.Add(categoryNode);
            }
            xmlDoc.Save("../../Export/GetCategoriesByProductCount.xml");

        }

        private static void GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                 .Where(u => u.ProductsSold.Count > 0)
                 .OrderBy(u => u.LastName)
                 .ThenBy(u => u.FirstName)
                 .Select(u => new
                 {
                     FirstName = u.FirstName,
                     LastName = u.LastName,
                     SoldProducts = u.ProductsSold
                     .Select(p => new
                     {
                         name=p.Name,
                         price=p.Price
                     })
                 }).ToList();

            XElement xmlDoc = new XElement("users");

            foreach (var user in users)
            {
                XElement userNode = new XElement("user");

                if (user.FirstName !=null)
                {
                    userNode.Add(new XAttribute("first-name", user.FirstName));
                }
                userNode.Add(new XAttribute("last-name", user.LastName));

                XElement soldProducts = new XElement("sold-products");
                foreach (var p in user.SoldProducts)
                {
                    XElement productNode = new XElement("product");

                    productNode.Add(new XElement("name", p.name));
                    productNode.Add(new XElement("price", p.price));
                    soldProducts.Add(productNode);
                }
                userNode.Add(soldProducts);
                xmlDoc.Add(userNode);
            }
            xmlDoc.Save("../../Export/GetSoldProducts.xml");

        }

        private static void GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 1000 && p.Price <= 2000 && p.BuyerId != null)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    ProductName=p.Name,
                    Price=p.Price,
                    Byuer=p.Buyer.FirstName +" "+p.Buyer.LastName
                }).ToList();

            XElement xmlDoc = new XElement("products");

            foreach (var p in products)
            {
                xmlDoc.Add(new XElement("product",
                    new XAttribute("name", p.ProductName),
                    new XAttribute("price",p.Price),
                    new XAttribute("buyer",p.Byuer)));
            }
            xmlDoc.Save("../../Export/ProductsInRange.xml");

        }

        private static void ImportCategories(ProductShopContext context)
        {
            XDocument xmlCategories = XDocument.Load("../../Import/categories.xml");
            var categories = xmlCategories.Root.Elements()
                .Select(c => new Category
                {
                    Name = c.Element("name").Value
                }).ToList();

            int number = 0;
            int productsCount = context.Products.Count();
            foreach (var category in categories)
            {
                int categoryProductsCount = number % 3;
                for (int i = 0; i < categoryProductsCount; i++)
                {
                    category.Products.Add(context.Products.Find((number % productsCount) + 1));
                }
                number++;
            }
            context.Categories.AddRange(categories);
            context.SaveChanges();
        }

        private static void ImportProduct(ProductShopContext context)
        {
            XDocument xmlproducts = XDocument.Load("../../Import/products.xml");
            var products = xmlproducts.Root.Elements()
                .Select(p => new Product
                {
                    Name = p.Element("name").Value,
                    Price = decimal.Parse(p.Element("price").Value)
                }).ToList();

            int number = 0;
            int usersCount = context.Users.Count();
            foreach (var product in products)
            {
                product.SellerId = (number % usersCount) + 1;
                if (number%3 != 0)
                {
                    product.BuyerId = (number * 2 % usersCount) + 1;
                }
                number++;
            }
            context.Products.AddRange(products);
            context.SaveChanges();
        }

        private static void ImportUsers(ProductShopContext context)
        {
            XDocument xmlUsers = XDocument.Load("../../Import/users.xml");
            var users = xmlUsers.Root.Elements();
            List<User> usersList = new List<User>();
            foreach (var user in users)
            {
                var firstName = user.Attribute("first-name");
                var lastName = user.Attribute("last-name");
                int age = 0;

                if (user.Attribute("age")!= null)
                {
                    age = int.Parse(user.Attribute("age").Value);
                }

                User userModel = new User();
                if (firstName==null)
                {
                    userModel.LastName = lastName.Value;
                    userModel.Age = age;
                }
                else
                {
                    userModel.FirstName = firstName.Value;
                    userModel.LastName = lastName.Value;
                    userModel.Age = age;
                }

                usersList.Add(userModel);
            }

            context.Users.AddRange(usersList);
            context.SaveChanges();
        }
    }
}
