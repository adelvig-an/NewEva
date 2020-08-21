using NewEva.DbLayer;
using NewEva.Model;
using System;
using System.Collections.Generic;
using System.Text;

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

        public ReportVM()
        {
            Report = new Report()
            {
                Number = NumberReport,
                DateVulation = new DateTime(2019, 04, 15),
                DateCompilation = new DateTime(2019, 04, 15)
            };

            DocsFoundation = new DocsFoundation()
            {
                Number = "001",
                DateFoundation = new DateTime(2019, 04, 10),
                Target = "Определение рыночной стоимости"
            };

            TypeCosts = ListStorage.TypeCosts;
            Appraisers = ListStorage.Appraisers;
        }

        private string text;
        public string NumberReport
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public void TextNumberReport(Report report)
        {
            report.Number = NumberReport;
            OnPropertyChanged(nameof(Report));
        }
    }
}
