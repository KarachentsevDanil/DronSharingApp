using System;
using System.Collections.Generic;
using DSA.Domain.Drons;
using DSA.Domain.Rents;
using Microsoft.AspNetCore.Identity;

namespace DSA.Domain.Customers
{
    public class Customer : IdentityUser
    {
        public string FullName { get; set; }

        public Role Role { get; set; }

        public DateTime? DateOfBirthsday { get; set; }

        public ICollection<Dron> Drons { get; set; }

        public ICollection<Rent> Rents { get; set; }

        public Customer()
        {
            Drons = new List<Dron>();
            Rents = new List<Rent>();
        }
    }

    public enum Role
    {
        User,
        Admin
    }
}
