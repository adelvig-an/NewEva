using NewEva.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
                Number = "001",
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

        const string filePath = "temp.json";
        public static new ReportVM Read<ReportVM>(string filePath)
        {
            string json = File.ReadAllText(filePath);
            return
                JsonConvert.DeserializeObject<ReportVM>(json);
        }
        public new bool Write<ReportVM>(string filePath, ReportVM reportVM)
        {
            try
            {
                string json = JsonConvert.SerializeObject(reportVM);
                File.WriteAllText(filePath, json);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
