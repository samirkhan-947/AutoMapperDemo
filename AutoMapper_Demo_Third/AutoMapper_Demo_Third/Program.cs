// See https://aka.ms/new-console-template for more information
using AutoMapper;
using AutoMapper_Demo_Third.AddressEnt;
using AutoMapper_Demo_Third.EmployeeEnt;
using System.Net;

Console.WriteLine("Hello, World!");



Address empAddres = new Address()
{
    City = "Mumbai",
    Stae = "Maharashtra",
    Country = "India"
};
Employee emp = new Employee
{
    Name = "James",
    Salary = 20000,
    Department = "IT",
    address = empAddres
};

static Mapper Initializer()
{
    var config = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<Address, AddressDTO>()
        .ForMember(dest => dest.EmpCity, act => act.MapFrom(src => src.City))
        .ForMember(dest => dest.EmpStae, act => act.MapFrom(src => src.Stae));
        cfg.CreateMap<Employee, EmployeeDTO>()
        .ForMember(dest => dest.addressDTO, act => act.MapFrom(src => src.address));        
    });
    var mapper = new Mapper(config);
    return mapper;
};

var mapper = Initializer();
var empDTO = mapper.Map<EmployeeDTO>(emp);
Console.WriteLine("Name:" + empDTO.Name + ", Salary:" + empDTO.Salary + ", Department:" + empDTO.Department);
Console.WriteLine("City:" + empDTO.addressDTO.EmpCity + ", State:" + empDTO.addressDTO.EmpStae + ", Country:" + empDTO.addressDTO.Country);
Console.ReadLine();