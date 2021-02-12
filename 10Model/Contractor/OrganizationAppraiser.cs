using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewEva.Model.Contractor
{
    [Table("OrganizationsAppraisers")]
    public class OrganizationAppraiser : Organization
    {
        public int InsurancePoliceId { get; set; }
        public virtual ICollection<Appraiser> Appraisers { get; private set; }
            = new ObservableCollection<Appraiser>();
    }
}
