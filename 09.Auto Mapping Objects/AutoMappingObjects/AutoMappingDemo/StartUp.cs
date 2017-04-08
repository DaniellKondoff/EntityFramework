using AutoMapper;
using AutoMapper.QueryableExtensions;
using AutoMappingDemo.Data;
using AutoMappingDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMappingDemo
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var context = new MappingContext();
            MapperConfig.Init();

            //List<ProductDTO> ProductDtos;
            ////var product = context.Products.FirstOrDefault(p => p.Name == "Oil Pump");
            //var products = context.Products.ToArray();
            //ProductDtos = Mapper.Map<Product[], List<ProductDTO>>(products);//Mapping
            ////ProductDtos = context.Products.ProjectTo<ProductDTO>().ToList();

            //foreach (var product in ProductDtos)
            //{
            //    Console.WriteLine(product.Name);
            //    Console.WriteLine(product.Cost);
            //    Console.WriteLine(product.StockQuantity);
            //}

            OrderDTO orderDto;

            var order = context.Orders.FirstOrDefault();
            orderDto = Mapper.Map<OrderDTO>(order);

            Console.WriteLine(orderDto.ClientName);

        }

       
    }

    public class ProductDTO
    {
        public string Name { get; set; }
        public int StockQuantity { get; set; }
        public decimal Cost { get; set; }

    }

    public class OrderDTO
    {
        public string ClientName { get; set; }

        public decimal Total { get; set; }
    }
}
