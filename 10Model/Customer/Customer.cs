using System;
using System.Collections.Generic;
using System.Text;

namespace NewEva.Model
{
    public enum TypeCustomer
    {
        PrivatePerson,
        Organization
    }
    public class Customer
    {
        public int CustomerId { get; set; }
        public TypeCustomer TypeCustomer { get; set; }
        public List<Contract> Contracts { get; set; } = new List<Contract>();
        public int? PersonId { get; set; }
        public int? OrganizationId { get; set; }
    }
}
