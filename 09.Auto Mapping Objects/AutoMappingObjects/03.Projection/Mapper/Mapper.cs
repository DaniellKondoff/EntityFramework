using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Projection.Models;
using Projection.DTOs;

namespace Projection
{
    public static class MapperInit
    {
        public static void Init()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Employee, EmployeeDto>()
            .ForMember(dto => dto.ManagerLastName,
                        opt => opt.MapFrom(src => src.Manager.LastName)));
        }
    }
}
