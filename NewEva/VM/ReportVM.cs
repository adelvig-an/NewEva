using NewEva.Model;
using Newtonsoft.Json;
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
        public DocsFoundation DocsFoundation { get; }
        public IEnumerable<string> TypeCosts { get; }
        public IEnumerable<string> Appraisers { get; }
        public bool IsPrivatePerson { get; set; }
        public bool IsOrganization { get; set; }

        public override string Name => PageNames.ReportPage;

        public ReportVM()
        {
            Report = new Report()
            {
                //Number = "001",
                DateVulation = DateTime.Today,
                DateCompilation = DateTime.Today
            };

            DocsFoundation = new DocsFoundation()
            {
                //Number = "001",
                DateFoundation = DateTime.Today
                //Target = "Определение рыночной стоимости"
            };

            TypeCosts = ListStorage.TypeCosts;
            Appraisers = ListStorage.Appraisers;
        }
    }
}
