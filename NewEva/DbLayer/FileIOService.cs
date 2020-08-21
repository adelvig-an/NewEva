using NewEva.Model;
using NewEva.VM;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NewEva.DbLayer
{
    public abstract class FileIOService
    {
        public abstract bool Write(string filePath, ReportVM reportVM);
        public abstract ReportVM Read(string filePaht);
    }
}
