using Newtonsoft.Json;
using ProductsShop.Data;
using ProductsShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //ProductInRange(context);
            //SoldProducts(context);
            //CategoryByProductsCount(context);
            //UserAndProducts(context);
        }

        private static void UserAndProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Count > 0)
                .OrderByDescending(u => u.ProductsSold.Count)
                .ThenBy(u => u.LastName)
                .Select(u => new
                {
                    
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new
                    {
                        Count=u.ProductsSold.Count,
                        Products=u.ProductsSold.Select(p=>new
                        {
                            Name=p.Name,
                            Price=p.Price
                        })
                    }
                }).ToList();

            string jsonUsers = JsonConvert.SerializeObject(new { usersCount=users.Count,users },Formatting.Indented);
            Console.WriteLine(jsonUsers);
            File.WriteAllText("../../../JsonResult/UserAndProducts.json", jsonUsers);

        }

        private static void CategoryByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Where(c=>c.Products.Count>0)
                .OrderBy(c => c.Name)              
                .Select(c => new
                {
                    CategoryName=c.Name,
                    ProductsCount=c.Products.Count,
                    AveragePrice=c.Products.Average(p=>p.Price),
                    totalRevenue=c.Products.Sum(p=>p.Price)
                });

            string jsonCategories = JsonConvert.SerializeObject(categories, Formatting.Indented);
            Console.WriteLine(jsonCategories);
            File.WriteAllText("../../../JsonResult/CategoryByProductsCount.json", jsonCategories);

        }

        private static void SoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Count(p => p.BuyerId != null) > 0)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    FirstName=u.FirstName,
                    LastName=u.LastName,
                    SoldProducts=u.ProductsSold
                    .Where(p=>p.BuyerId != null)
                    .Select(p=> new
                    {
                        Name=p.Name,
                        Price=p.Price,
                        BuyerFirstName=p.Buyer.FirstName??"",
                        BuyerLastName=p.Buyer.LastName
                    })
                }).ToList();

            string jsonUsers = JsonConvert.SerializeObject(users, Formatting.Indented);
            Console.WriteLine(jsonUsers);
            File.WriteAllText("../../../JsonResult/SuccessfullySoldProducts.json", jsonUsers);
        }

        private static void ProductInRange(ProductShopContext context)
        {
            var products = context.Products.Include("Seller")
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    Name = p.Name,
                    Price = p.Price,
                    SellerName = p.Seller.FirstName + " " + p.Seller.LastName
                }).ToList();

            string jsonProducts = JsonConvert.SerializeObject(products, Formatting.Indented);
            Console.WriteLine(jsonProducts);
            File.WriteAllText("../../../JsonResult/ProductsInRange.json", jsonProducts);
        }

        private static void ImportCategories(ProductShopContext context)
        {
            string categoriesJson = File.ReadAllText("../../Import/categories.json");
            List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(categoriesJson);

            int number = 0;
            int productsCount = context.Products.Count();
            foreach (Category c in categories)
            {
                int categoryProductsCount = number % 3;
                for (int i = 0; i <categoryProductsCount; i++)
                {
                    c.Products.Add(context.Products.Find((number % productsCount) + 1));
                }
                number++;
            }
            context.Categories.AddRange(categories);
            context.SaveChanges();
        }

        private static void ImportProduct(ProductShopContext context)
        {
            string productsJson = File.ReadAllText("../../Import/products.json");
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(productsJson);

            int number = 0;
            int usersCount = context.Users.Count();
            foreach (var product in products)
            {
                product.SellerId = (number % usersCount) + 1;
                if (number % 3 !=0)
                {
                    product.BuyerId= (number * 2 % usersCount) + 1;
                }
                number++;
            }
            context.Products.AddRange(products);
            context.SaveChanges();
        }

        private static void ImportUsers(ProductShopContext context)
        {
            string userJson = File.ReadAllText("../../Import/users.json");
            List<User> users = JsonConvert.DeserializeObject<List<User>>(userJson);

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}
