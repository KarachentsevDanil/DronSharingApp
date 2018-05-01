using System;
using System.Collections.Generic;
using SAT.Domain.Rents;
using Microsoft.AspNetCore.Identity;
using SAT.Domain.AirTaxies;

namespace SAT.Domain.Customers
{
    public class Customer : IdentityUser
    {
        public string FullName { get; set; }

        public Role Role { get; set; }

        public DateTime? DateOfBirthsday { get; set; }

        public virtual ICollection<AirTaxi> Taxies { get; set; }

        public virtual ICollection<Rent> Rents { get; set; }

        public Customer()
        {
            Taxies = new List<AirTaxi>();
            Rents = new List<Rent>();
        }
    }

    public enum Role
    {
        User,
        Admin
    }
}
