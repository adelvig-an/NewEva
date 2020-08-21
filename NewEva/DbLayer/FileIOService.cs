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
        public abstract bool Write(string filePath, PageVM pageVM);
        public abstract PageVM Read(string filePaht);
    }
}
