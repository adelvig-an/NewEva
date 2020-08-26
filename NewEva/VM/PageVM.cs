using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NewEva.VM
{
    public abstract class PageVM : ViewModelBase
    {
        public abstract string Name { get; }
        public static T Read<T>(string filePath) where T : PageVM
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return
                        JsonConvert.DeserializeObject<T>(json);
            }
            else
            {
                return null;
            }
        }

        public bool Write(string filePath)
        {
            try
            {
                string json = JsonConvert.SerializeObject(this);
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
