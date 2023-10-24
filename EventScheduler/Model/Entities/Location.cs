using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventScheduler.Model.Entities
{
    internal class Location
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; } 
        public string PostalCode { get; set; }

        public Location() { }

        public Location(string name, string address, string city, string state, string postalCode)
        {
            Name = name;
            Address = address;
            City = city;
            State = state;
            PostalCode = postalCode;
        }

        public override string ToString()
        {
            return "Name: "
                + Name
                + "\nAddress: "
                + Address
                + ", City: "
                + City
                + "\nState: "
                + State
                + ", PostalCode: "
                + PostalCode;
        }
    }
}
