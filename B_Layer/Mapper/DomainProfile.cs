using AutoMapper;
using B_Layer.Models;
using DAL_Layer.Entity;
using DAL_Layer.Entity.Place;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_Layer.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<DepartmentVM, Department>();
            CreateMap<Department, DepartmentVM>();

            CreateMap<CountryVM, Country>();
            CreateMap<Country, CountryVM>();

            CreateMap<EmployeeVM, Employee>();
            CreateMap<Employee, EmployeeVM>();

            CreateMap<CityVM, City>();
            CreateMap<City, CityVM>();

            CreateMap<DistrictVM, District>();
            CreateMap<District, DistrictVM>();
        }
    }
}
