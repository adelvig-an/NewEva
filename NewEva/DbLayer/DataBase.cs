using NewEva.VM;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NewEva.DbLayer
{
    public static class DataBase
    {
        public static readonly SQLiteConnection db;

        //Создание новой БД
        static DataBase()
        {
            db = new SQLiteConnection("Database.db");
            Init();
        }

        public static void Init()
        {
            db.CreateTable<TempData>();
            db.CreateTable<Contracts>();
            db.CreateTable<Customers>();
            db.CreateTable<Reports>();
        }

        public static void Write(TempData tempData) =>
            db.Insert(tempData);
        
        //Метод сохранения
        public static void Write(Customers customer) => 
            db.Insert(customer);

        //Метод чтения
        public static T Read<T>(object primaryKey) where T : new() =>
            db.Get<T>(primaryKey);

        public static string ReadJsonOrNull(object primaryKey)
        {
            try
            {
                return db.Get<TempData>(primaryKey).Json;
            }
            catch
            {
                return null;
            }
        }

        public static int DalateCustomers<T>(object primaryKey) where T : new() =>
            db.Delete<T>(primaryKey);

        public static void DeleteTempData() =>
            db.DeleteAll<TempData>();



    }
}
