using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NewEva.VM
{
    public class PageVM : ViewModelBase
    {
        public static T Read<T>(string filePath) where T : PageVM
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return
                        JsonConvert.DeserializeObject<T>(json);
            }
            else
                return default;
        }

        public bool Write<T>(string filePath)
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


        //public PageVM Read(string filePath)
        //{
        //    string json = File.ReadAllText(filePath);
        //    return
        //        JsonConvert.DeserializeObject<PageVM>(json);
        //}

            //public bool Write(string filePath, PageVM pageVM)
            //{
            //    try
            //    {
            //        string json = JsonConvert.SerializeObject(pageVM);
            //        File.WriteAllText(filePath, json);
            //        return true;
            //    }
            //    catch
            //    {
            //        return false;
            //    }
            //}
        }
}
