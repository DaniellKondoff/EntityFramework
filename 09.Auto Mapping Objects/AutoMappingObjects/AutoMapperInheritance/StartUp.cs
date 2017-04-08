namespace AutoMapperInheritance
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    class StartUp
    {
        static void Main(string[] args)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Order, OrderDto>()
                .Include<OnlineOrder, OnlineOrderDto>()
                .Include<MailOrder, MailOrderDto>();
                cfg.CreateMap<OnlineOrder, OnlineOrderDto>();
                cfg.CreateMap<MailOrder, MailOrderDto>();
            });

            Order order = new OnlineOrder()
            {
                TrackingInfo = "hashhsa",
                BrowserVersion="Mozila"        
            };

           var dto = Mapper.Map<OnlineOrderDto>(order);
           
            
        }
    }
}
