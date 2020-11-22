using NewEva.Model;
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

        //Создание столбцов в БД
        public static void Init()
        {
            db.CreateTable<TempData>();
            db.CreateTable<Contracts>();
            db.CreateTable<Customers>();
            db.CreateTable<Reports>();
        }
        //Временное сохранение
        public static void Write(TempData tempData) =>
            db.Insert(tempData);
        
        //Метод сохранения
        public static void Write(Customers customer) => 
            db.Insert(customer);
        public static void Write(Reports report) =>
            db.Insert(report);
        public static void Write(Contracts contract) =>
            db.Insert(contract);

        //Метод чтения одного объекта
        public static T Read<T>(object primaryKey) where T : new() =>
            db.Get<T>(primaryKey);

        //Метод чтения списка
        public static IEnumerable<T> ReadAll<T>() where T : new() => 
            db.Table<T>();
        
        //Преобразование Отчета (Report)
        public static Report ToReport(Reports reports)
        {
            return new Report
            {
                Id = reports.Id,
                Number = reports.Number,
                DateCompilation = reports.DateCompilation,
                DateOfInspection = reports.DateOfInspection,
                DateVulation = reports.DateVulation
            };
        }
        //Преобразование Договора (Contract)
        public static Contract ToContract(Contracts contracts)
        {
            return new Contract
            {
                Id = contracts.Id,
                Number = contracts.Number,
                DateContract = contracts.DateContract,
                Target = contracts.Target,
                TypeCost = contracts.TypeCost
            };
        }
        //Преобразование Заказчиков (Customers)
        public static PrivatePerson ToPrivatePerson(Customers customers)
        {
            return new PrivatePerson
            {
                Id = customers.Id,
                FullName = customers.SecondName + " " + customers.FirstName + " " + customers.MiddleName,
                SecondName = customers.SecondName,
                FirstName = customers.FirstName,
                MiddleName = customers.MiddleName,
                TypePassport = customers.TypePassport,
                Serial = customers.Serial,
                Number = customers.Number,
                Issued = customers.Issued,
                Division = customers.Division,
                DateIssued = customers.DateIssued,
                //AddressFull = customers.AddressFullRegistration,
                //Index = customers.IndexRegistration,
                //Country = customers.CountryRegistration,
                //Region = customers.RegionRegistration,
                //District = customers.DistrictRegistration,
                //City = customers.CityRegistration,
                //Street = customers.StreetRegistration,
                //House = customers.HouseRegistration,
                //Room = customers.RoomRegistration,
                //AddressFull = customers.AddressFullActual,
                //Index = customers.IndexActual,
                //Country = customers.CountryActual,
                //Region = customers.RegionActual,
                //District = customers.DistrictActual,
                //City = customers.CityActual,
                //Street = customers.StreetActual,
                //House = customers.HouseActual,
                //Room = customers.RoomActual
            };
        }
        public static Organization ToOrganization(Customers customers)
        {
            return new Organization
            {
                Id = customers.Id,
                NameFull = customers.NameFull,
                NameShort = customers.NameShort,
                OrganizationForm = customers.OrganizationForm,
                OGRN= customers.OGRN,
                DateRegistration = customers.DateRegistration,
                INN = customers.INN,
                KPP = customers.KPP,
                NameBank = customers.NameBank,
                BIK = customers.BIK,
                PayAccount = customers.PayAccount,
                CorrAccount = customers.CorrAccount
            };
        }

        //Чтение временно сохраненного
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
        //Удаление одного элемента
        public static int DeleteData<T>(object primaryKey) where T : new() =>
            db.Delete<T>(primaryKey);
        //Удаление всх элементов
        public static void DeleteTempData() =>
            db.DeleteAll<TempData>();

        //Изменение данных
        public static int UpdateData(object obj) =>
            db.Update(obj);

    }
}
