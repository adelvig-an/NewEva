using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

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
        public virtual ICollection<Contract> Contracts { get; private set; } = new ObservableCollection<Contract>();
        public int? PrivatePersonId { get; set; }
        public int? OrganizationId { get; set; }
    }
}
