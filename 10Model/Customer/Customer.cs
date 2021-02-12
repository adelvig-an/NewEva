using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(24)")]
        public TypeCustomer TypeCustomer { get; set; }
        public ICollection<Contract> Contracts { get; set; } 
        public int? PrivatePersonId { get; set; }
        public int? OrganizationId { get; set; }
    }
}
