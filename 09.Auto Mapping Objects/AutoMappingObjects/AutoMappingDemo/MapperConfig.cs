using AutoMapper;
using AutoMappingDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMappingDemo
{
   public static class  MapperConfig
    {
        public static void Init()
        {

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Product, ProductDTO>()
            .ForMember(dto => dto.StockQuantity,
             opt => opt.MapFrom(src => src
              .ProductStocks
              .Sum(p => p.Quantity)));
                cfg.CreateMap<Order, OrderDTO>();             
            });
            
        }
    }
}
