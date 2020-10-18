using NewEva.DbLayer;
using NewEva.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Input;

namespace NewEva.VM.Customer
{
    public class PrivatePersonVM : PageVM, IDataErrorInfo
    {
        public PrivatePerson PrivatePerson { get; private set; }
        public Address Registration { get; private set; }
        public Address Actual { get; private set; }
        public IEnumerable<string> TypeDocs { get; private set; }
        
        /// <summary>
        /// переменная которая будет явно показывать для чего предназначена PrivatePersonVM
        /// для редактирования или добавления
        /// </summary>
        public bool IsEdit { get; }

        private bool isAddressMatch;
        public bool IsAddressMatch
        {
            get => isAddressMatch;
            set
            {
                SetProperty(ref isAddressMatch, value);
                if (value == true)
                {
                    Actual = Registration;
                }
                else
                    Actual = new Address();
                OnPropertyChanged(nameof(Actual));
            }
        }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="customer"></param>
        public PrivatePersonVM(Customers customer = null)
        {
           if (IsEdit = customer != null) 
            {
                PrivatePerson = new PrivatePerson()
                {
                    Id = customer.Id,
                    SecondName = customer.SecondName,
                    FirstName = customer.FirstName,
                    MiddleName = customer.MiddleName,
                    TypePassport = customer.TypePassport,
                    Serial = customer.Serial,
                    Number = customer.Number,
                    Issued = customer.Issued,
                    Division = customer.Division,
                    DateIssued = customer.DateIssued
                };
                IsTypeDocs = customer.TypePassport;
                TypeDocs = LocalStorage.TypeDocs;
                Registration = new Address()
                {
                    AddressFull = customer.AddressFullRegistration,
                    Index = customer.IndexRegistration,
                    Country = customer.CountryRegistration,
                    Region = customer.RegionRegistration,
                    District = customer.DistrictRegistration,
                    City = customer.CityRegistration,
                    Street = customer.StreetRegistration,
                    House = customer.HouseRegistration,
                    Room = customer.RoomRegistration
                };
                IsAddressMatch = customer.AddressMatch;
                Actual = new Address()
                {
                    AddressFull = customer.AddressFullActual,
                    Index = customer.IndexActual,
                    Country = customer.CountryActual,
                    Region = customer.RegionActual,
                    District = customer.DistrictActual,
                    City = customer.CityActual,
                    Street = customer.StreetActual,
                    House = customer.HouseActual,
                    Room = customer.RoomActual
                };
            }
            else
            {
                PrivatePerson = new PrivatePerson()
                {
                    SecondName = SecondName,
                    FirstName = FirstName,
                    MiddleName = MiddleName,
                    Serial = Serial,
                    Number = Number,
                    DateIssued = DateTime.Today,
                    Issued = Issued,
                    Division = Division
                };
                TypeDocs = LocalStorage.TypeDocs;
                Registration = new Address()
                {
                    AddressFull = AddressFull,
                    Index = Index,
                    Country = Country,
                    Region = Region,
                    District = District,
                    City = City,
                    Street = Street,
                    House = House,
                    Room = Room
                };
                Actual = new Address()
                {
                    AddressFull = AddressFull,
                    Index = Index,
                    Country = Country,
                    Region = Region,
                    District = District,
                    City = City,
                    Street = Street,
                    House = House,
                    Room = Room
                };
            }
        }

        private string isTypeDocs;
        public string IsTypeDocs
        {
            get => isTypeDocs;
            set => SetProperty(ref isTypeDocs, value);
        }

        public Customers ToCustomers()
        {
            var customer = new Customers
            {
                Id = PrivatePerson.Id,
                TypeCustomer = true,
                SecondName = PrivatePerson.SecondName,
                FirstName = PrivatePerson.FirstName,
                MiddleName = PrivatePerson.MiddleName,
                TypePassport = IsTypeDocs,
                Serial = PrivatePerson.Serial,
                Number = PrivatePerson.Number,
                Issued = PrivatePerson.Issued,
                Division = PrivatePerson.Division,
                DateIssued = PrivatePerson.DateIssued,
                AddressFullRegistration = Registration.AddressFull,
                IndexRegistration = Registration.Index,
                CountryRegistration = Registration.Country,
                RegionRegistration = Registration.Region,
                DistrictRegistration = Registration.District,
                CityRegistration = Registration.City,
                StreetRegistration = Registration.Street,
                HouseRegistration = Registration.House,
                RoomRegistration = Registration.Room,
                AddressMatch = IsAddressMatch,
                AddressFullActual = Actual.AddressFull,
                IndexActual = Actual.Index,
                CountryActual = Actual.Country,
                RegionActual = Actual.Region,
                DistrictActual = Actual.District,
                CityActual = Actual.City,
                StreetActual = Actual.Street,
                HouseActual = Actual.House,
                RoomActual = Actual.Room
            };
            return customer;
        }

        /// <summary>
        /// Метод сохранения Физического лица
        /// </summary>
        /// <returns></returns>
        public int AddPrivatePerson()
        {
            try
            {
                var customer = ToCustomers();
                DataBase.Write(customer);
                var newId = customer.Id;
                return newId;
            }
            catch
            {

                return -1;
            }
        }
        /// <summary>
        /// Метод сохрания изменений Физического лица
        /// </summary>
        /// <returns></returns>
        public bool UpdatePrivatePerson()
        {
            try
            {
                var customer = ToCustomers();
                DataBase.UpdateData(customer);
                return true;
            }
            catch
            {

                return false;
            }
        }

        #region Реализация валидации данных
        public string Error => "";
        public string this[string columnName]
        {
            get
            {
                string error = string.Empty;
                switch(columnName)
                {
                    case
                        "Фамилия":
                        if (MiddleName == null)
                        {
                            error = "Поле \"Фамилия\": обязательно для заполнения";
                        }
                        break;
                    case
                        "Имя":
                        if (FirstName == null)
                        {
                            error = "Поле \"Имя\": обязательно для заполнения";
                        }
                        break;
                    case
                        "Отчество":
                        if (MiddleName == null)
                        {
                            error = "Поле \"Отчество\": обязательно для заполнения";
                        }
                        break;
                    case
                        "Серия":
                        if (Serial == null)
                        {
                            error = "Поле \"Отчество\": обязательно для заполнения";
                        }
                        break;
                    case
                        "Номер":
                        if (Number == null)
                        {
                            error = "Поле \"Отчество\": обязательно для заполнения";
                        }
                        break;
                    case
                        "Кем выдан":
                        if (Issued == null)
                        {
                            error = "Поле \"Отчество\": обязательно для заполнения";
                        }
                        break;
                    case
                        "Код подразделения":
                        if (Division == null)
                        {
                            error = "Поле \"Отчество\": обязательно для заполнения";
                        }
                        break;
                    case
                        "Адрес полностью":
                        if (AddressFull == null)
                        {
                            error = "Поле \"Отчество\": обязательно для заполнения";
                        }
                        break;
                    case
                        "Страна":
                        if (Country == null)
                        {
                            error = "Поле \"Отчество\": обязательно для заполнения";
                        }
                        break;
                    case
                        "Регион":
                        if (Region == null)
                        {
                            error = "Поле \"Отчество\": обязательно для заполнения";
                        }
                        break;
                    case
                        "Район":
                        if (District == null)
                        {
                            error = "Поле \"Отчество\": обязательно для заполнения";
                        }
                        break;
                    case
                        "Город":
                        if (City == null)
                        {
                            error = "Поле \"Отчество\": обязательно для заполнения";
                        }
                        break;
                    case
                        "Дом":
                        if (House == null)
                        {
                            error = "Поле \"Отчество\": обязательно для заполнения";
                        }
                        break;
                    case
                        "Комната":
                        if (Room == null)
                        {
                            error = "Поле \"Отчество\": обязательно для заполнения";
                        }
                        break;
                }
                return error;
            }
        }

        private string secondName = "";
        public string SecondName
        {
            get => secondName;
            set => SetProperty(ref secondName, value);
        }
        private string firstName = "";
        public string FirstName 
        {
            get => firstName;
            set => SetProperty(ref firstName, value);
        }
        private string middleName = "";
        public string MiddleName
        {
            get => middleName;
            set => SetProperty(ref middleName, value);
        }
        private string serial = "";
        public string Serial
        {
            get => serial;
            set => SetProperty(ref serial, value);
        }
        private string number = "";
        public string Number
        {
            get => number;
            set => SetProperty(ref number, value);
        }
        private string issued = "";
        public string Issued
        {
            get => issued;
            set => SetProperty(ref issued, value);
        }
        private string division = "";
        public string Division
        {
            get => division;
            set => SetProperty(ref division, value);
        }
        private string addressFull = "";
        public string AddressFull
        {
            get => addressFull;
            set => SetProperty(ref addressFull, value);
        }
        private int index;
        public int Index 
        {
            get => index;
            set => SetProperty(ref index, value); 
        }
        private string country = "";
        public string Country 
        {
            get => country;
            set => SetProperty(ref country, value); 
        }
        private string region = "";
        public string Region 
        {
            get => region;
            set => SetProperty(ref region, value); 
        }
        private string district = "";
        public string District 
        {
            get => district;
            set => SetProperty(ref district, value);
        }
        private string city = "";
        public string City 
        {
            get => city;
            set => SetProperty(ref city, value);
        }
        private string street = "";
        public string Street
        {
            get => street;
            set => SetProperty(ref street, value);
        }
        private string house = "";
        public string House
        {
            get => house;
            set => SetProperty(ref house, value);
        }
        private string room = "";
        public string Room
        {
            get => room;
            set => SetProperty(ref room, value);
        }

        #endregion Реализация валидации данных
    }
}
