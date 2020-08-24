using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NewEva.VM
{
    public static class TempFiles
    {
        public const string FirstPagePath = "FirstPageVM.json"; 
        public const string PrivatePersonPagePath = "PrivatePersonVM.json"; 
        public const string ReportPagePath = "ReportVM.json"; 
        public static string[] AllPathes => typeof(TempFiles)
            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
            .Where(fi => fi.IsLiteral && !fi.IsInitOnly).Select(fi => fi.GetRawConstantValue()?.ToString())
            .Where(v => v != null)
            .ToArray();
    }
}
