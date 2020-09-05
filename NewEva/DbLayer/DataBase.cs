using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NewEva.DbLayer
{
    public class DataBase
    {
        //Создание новой БД
        //public DataBase()
        //{
        //    DbConnection(string databasePath);
        //}

        public void DbConnection(string databasePath)
        {
            SQLiteConnection db = new SQLiteConnection(databasePath);
            db.CreateTable<Contracts>();
            db.CreateTable<Customers>();
            db.CreateTable<Reports>();
        }
    }
}
