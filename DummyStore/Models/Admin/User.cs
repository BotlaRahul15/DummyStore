using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DummyStore.Models.Admin
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public Name name { get; set; }
        public Address address { get; set; }
        public string FullName { get; set; }
        public bool IsloggedIn { get; set; }
    }
    public class Name
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
    public class Address
    {
        public Geolocation geolocation { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Zipcode { get; set; }
    }
    public class Geolocation
    {
        public double Lat { get; set; }
        public double Long { get; set; }
    }
}
