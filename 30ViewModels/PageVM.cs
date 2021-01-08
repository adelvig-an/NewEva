using NewEva.DbLayer;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.IO;
using System.Text;
using System.Windows;

namespace NewEva.VM
{
    public abstract class PageVM : ValidationBase
    {
        public abstract byte[] GetCBOR();
        public abstract void SetCBOR(byte[] b);

        //Чтение данных
        public void ReadCBOR(byte[] b)
        {
            var primaryKey = GetType().Name;
            var tempData = DataBase.Read<TempData>(primaryKey);
            SetCBOR(tempData.CBOR);
        }
        public static T Read<T>() where T : PageVM
        {
            var primaryKey = typeof(T).Name;
            var json = DataBase.ReadJsonOrNull(primaryKey);
            if (json == null)
            {
                return null;
            }
            return JsonConvert.DeserializeObject<T>(json);
        }

        //Запись данных
        public bool WriteCBOR()
        {
            try
            {
                var cbor = GetCBOR();
                var tempData = new TempData
                {
                    Page = GetType().Name,
                    CBOR = cbor
                };
                DataBase.Write(tempData);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Write()
        {
            try
            {
                var json = JsonConvert.SerializeObject(this);
                var tempData = new TempData
                {
                    Page = GetType().Name,
                    Json = json
                };
                DataBase.Write(tempData);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
