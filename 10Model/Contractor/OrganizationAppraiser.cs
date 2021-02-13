using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewEva.Model.Contractor
{
    public class OrganizationAppraiser : Organization
    {
        public int InsurancePolicieId { get; set; }
        public virtual InsurancePolicie InsurancePolicie { get; set; }
        public virtual ICollection<Appraiser> Appraisers { get; private set; }
            = new ObservableCollection<Appraiser>();
    }
}
