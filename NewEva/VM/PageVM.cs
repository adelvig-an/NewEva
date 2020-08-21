using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NewEva.VM
{
    public class PageVM : ViewModelBase
    {
        public ReportVM Read(string filePath)
        {
            string json = File.ReadAllText(filePath);
            return
                JsonConvert.DeserializeObject<ReportVM>(json);
        }

        public bool Write(string filePath, ReportVM reportVM)
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
