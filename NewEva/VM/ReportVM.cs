using NewEva.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;

namespace NewEva.VM
{
    public class ReportVM : PageVM
    {
        public Report Report { get; private set; }
        public Contract Contract { get; }
        public IEnumerable<string> TypeCosts { get; }
        public IEnumerable<string> Appraisers { get; }
        public bool IsPrivatePerson { get; set; }
        public bool IsOrganization { get; set; }

        public override string Name => PageNames.ReportPage;

        public ReportVM()
        {
            Report = new Report()
            {
                DateVulation = DateTime.Today,
                DateCompilation = DateTime.Today
            };

            Contract = new Contract()
            {
                DateContract = DateTime.Today
            };

            TypeCosts = LocalStorage.TypeCosts;
            Appraisers = LocalStorage.Appraisers;
        }

        private string isTypeCost;
        public string IsTypeCost
        {
            get => isTypeCost;
            set => SetProperty(ref isTypeCost, value);
        }

        private string isAppraiser;
        public string IsAppraiser
        {
            get => isAppraiser;
            set => SetProperty(ref isAppraiser, value);
        }
    }
}
