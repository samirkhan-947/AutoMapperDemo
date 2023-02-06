using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper_Demo_Third.AddressEnt
{
    public class Address
    {
        public string City { get; set; }
        public string Stae { get; set; }
        public string Country { get; set; }
    }



    public class AddressDTO
    {
        public string EmpCity { get; set; }
        public string EmpStae { get; set; }
        public string Country { get; set; }
    }
}
