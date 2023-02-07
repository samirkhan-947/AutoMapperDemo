// See https://aka.ms/new-console-template for more information
using AutoMapper;
using AutoMapper_Demo_Fourth.Entity;

Console.WriteLine("Hello, World!");
Address empAddres = new Address()
{
    City = "Mumbai",
    State = "Maharashtra",
    Country = "India"
};
Employee emp = new Employee();
emp.Name = "James";
emp.Salary = 20000;
emp.Department = "IT";
emp.City = "Mumbai";
emp.State = "Maharashtra";
emp.Country = "India";
emp.JobsName = "IT";
emp.Location = "New Delhi";


Jobs Empjob = new Jobs()
{ 
JobsName = "IT",
Location = "New Delhi"
};

var mapper = InitializeAutomapper();
var empDTO = mapper.Map<EmployeeDTO>(emp);

Console.WriteLine("Name:" + empDTO.Name + ", Salary:" + empDTO.Salary + ", Department:" + empDTO.Department);
Console.WriteLine("City:" + empDTO.address.City + ", State:" + empDTO.address.State + ", Country:" + empDTO.address.Country);
Console.WriteLine("JobsName:" + empDTO.job.JobsName + ", Location:" + empDTO.job.Location);

Console.ReadLine();

static Mapper InitializeAutomapper()
{
    var config = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<Employee, EmployeeDTO>()
        .ForMember(dest => dest.address, act => act.MapFrom(src => new Address()
        {
            City = src.City,
            State = src.State,
            Country = src.Country
        })).ForMember(dest => dest.job, act => act.MapFrom(src => new Jobs()
        {
            JobsName = src.JobsName,
            Location = src.Location
        }));
        //cfg.CreateMap<Employee, EmployeeDTO>()
        //.ForMember(dest => dest.job, act => act.MapFrom(src =>  new Jobs()
        //{
        //    JobsName = src.JobsName,
        //    Location = src.Location 
        //}));
    });
    var mapper = new  Mapper(config);
    return mapper;
} 