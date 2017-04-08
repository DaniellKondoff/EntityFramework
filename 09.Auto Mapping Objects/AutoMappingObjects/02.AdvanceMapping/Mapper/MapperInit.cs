using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AdvanceMapping.Models;
using AdvanceMapping.Dto;

namespace AdvanceMapping
{
    public static class MapperInit
    {
        public static void Init()
        {
            Mapper.Initialize(cfg=> 
            {
                cfg.CreateMap<Employee, EmployeeDto>();
                cfg.CreateMap<Employee, ManagerDto>()
                .ForMember(dto => dto.EmployeesInCharge, opt => opt.MapFrom(src => src.Employees))
                .ForMember(dto => dto.EmployeesCount, opt => opt.MapFrom(src => src.Employees.Count));
            });
        }
    }
}
