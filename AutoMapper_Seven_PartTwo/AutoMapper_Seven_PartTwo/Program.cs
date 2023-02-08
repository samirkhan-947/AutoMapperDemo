// See https://aka.ms/new-console-template for more information
using AutoMapper;
using System.ComponentModel;
using static IgnoreNoMapExtensions;

Console.WriteLine("Hello, World!");

var mapper = InitializeAutomapper();
Employee employee = new Employee()
{
    ID = 101,
    Name = "James",
    Address = "Mumbai"
};
var empDTO = mapper.Map<Employee, EmployeeDTO>(employee);
Console.WriteLine("After Mapping : Employee");
Console.WriteLine("ID : " + employee.ID + ", Name : " + employee.Name + ", Address : " + employee.Address + ", Email : " + employee.Email);
Console.WriteLine();
Console.WriteLine("After Mapping : EmployeeDTO");
Console.WriteLine("ID : " + empDTO.ID + ", Name : " + empDTO.Name + ", Address : " + empDTO.Address + ", Email : " + empDTO.Email);
Console.ReadLine();
        
        static Mapper InitializeAutomapper()
{
    var config = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<Employee, EmployeeDTO>()
        .IgnoreNoMap(); ;
    });
    var mapper = new Mapper(config);
    return mapper;
}
public class NoMapAttribute : System.Attribute
{
}
public static class IgnoreNoMapExtensions
{
    public static IMappingExpression<TSource, TDestination> IgnoreNoMap<TSource, TDestination>(
        this IMappingExpression<TSource, TDestination> expression)
    {
        var sourceType = typeof(TSource);
        foreach (var property in sourceType.GetProperties())
        {
            PropertyDescriptor descriptor = TypeDescriptor.GetProperties(sourceType)[property.Name];
            NoMapAttribute attribute = (NoMapAttribute)descriptor.Attributes[typeof(NoMapAttribute)];
            if (attribute != null)
                expression.ForMember(property.Name, opt => opt.Ignore());
        }
        return expression;
    }
}
    public class Employee
{
    public int ID { get; set; }
    public string Name { get; set; }
    [NoMap]
    public string Address { get; set; }
    [NoMap]
    public string Email { get; set; }
}
public class EmployeeDTO
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
}