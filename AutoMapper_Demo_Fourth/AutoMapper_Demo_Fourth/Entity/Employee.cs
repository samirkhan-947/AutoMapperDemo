using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper_Demo_Fourth.Entity
{
    public class Employee
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Department { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public string JobsName { get; set; }
        public string Location { get; set; }
    }
    public class Address
    {
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }

    public class Jobs
    {
        public string JobsName { get; set; }
        public string Location { get; set; }

    }

    public class EmployeeDTO
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Department { get; set; }
        public Address address { get; set; }
        public Jobs job { get; set; }

    }
}
