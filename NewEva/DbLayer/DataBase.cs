using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NewEva.DbLayer
{
    public class DataBase
    {
        readonly string connectionPath = @"Data Sourse=Database.db; Version=3";

        //Создание новой БД
        public DataBase()
        {
            DbConnection(connectionPath);
        }

        public void DbConnection(string databasePath)
        {
            SQLiteConnection db = new SQLiteConnection(databasePath);
            db.CreateTable<Contracts>();
            db.CreateTable<Customers>();
            db.CreateTable<Reports>();
        }
    }
}
