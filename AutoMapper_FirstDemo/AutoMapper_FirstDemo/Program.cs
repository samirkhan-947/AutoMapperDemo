// See https://aka.ms/new-console-template for more information
using AutoMapper;
using AutoMapper_FirstDemo;

Console.WriteLine("Hello, World!");
//Initialize the mapper
var config = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeDTO>());

//Creating the source object
Employee emp = new Employee
{
    Name = "James",
    Salary = 20000,
    Address = "London",
    Department = "IT"
};

//Using Mapper
var mapper = new Mapper(config);
var empDTO = mapper.Map<EmployeeDTO>(emp);
//or 
//var empdto = mapper.Map<Employee,EmployeeDTO>(emp);

Console.WriteLine("Name:" + empDTO.Name + ", Salary:" + empDTO.Salary + ", Address:" + empDTO.Address + ", Department:" + empDTO.Department);
Console.ReadLine();
       
 