using NewEva.Model;
using SQLite;
using System.Collections.Generic;


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
                CompilationDate = reports.Compilation_date,
                InspectionDate = reports.Inspection_date,
                VulationDate = reports.Vulation_date,
                InspectionFeaures = reports.Inspection_feaures
            };
        }
        //Преобразование Договора (Contract)
        public static Contract ToContract(Contracts contracts)
        {
            return new Contract
            {
                Id = contracts.Id,
                Number = contracts.Number,
                ContractDate = contracts.Contract_date,
                Target = contracts.Target,
                IntendedUse = contracts.Intended_use
            };
        }


        public static Person ToPerson (People people)
        {
            return new Person
            {
                Id = people.Id,
                SecondName = people.Second_name,
                FirstName = people.First_name,
                MiddleName = people.Middle_name,
            };
        }

        public static PrivatePerson ToPrivatePerson(Private_persons privatePerson)
        {
            return new PrivatePerson
            {
                Id = privatePerson.Id,
                Serial = privatePerson.Serial,
                Number = privatePerson.Number,
                Division = privatePerson.Division,
                DivisionCode = privatePerson.Division_code,
                DivisionDate = privatePerson.Division_date
            };
        }
        public static Organization ToOrganization(Organizations organizations)
        {
            return new Organization
            {
                Id = organizations.Id,
                NameFullOpf = organizations.Name_full_opf,
                NameShortOpf = organizations.Name_short_opf,
                Opf = organizations.Opf,
                OGRN= organizations.OGRN,
                OGRNDate = organizations.OGRN_date,
                INN = organizations.INN,
                KPP = organizations.KPP,
                Bank = organizations.Bank,
                BIK = organizations.BIK,
                PayAccount = organizations.Pay_account,
                CorrAccount = organizations.Corr_account
            };
        }



        #region JSON
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
        #endregion
    }
}
