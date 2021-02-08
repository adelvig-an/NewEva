using System;
using System.Collections.Generic;
using System.Text;

namespace NewEva.Model.Customer
{
    public enum TypeCustomer
    {
        PrivatePerson,
        Organization
    }
    public class Customer
    {
        public TypeCustomer TypeCustomer { get; set; }
    }
}
