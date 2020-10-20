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
                    Index = customer.IndexRegistration.ToString(),
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
                    Index = customer.IndexActual.ToString(),
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
                    AddressFull = AddressFullRegistration,
                    Index = IndexRegistration,
                    Country = CountryRegistration,
                    Region = RegionRegistration,
                    District = DistrictRegistration,
                    City = CityRegistration,
                    Street = StreetRegistration,
                    House = HouseRegistration,
                    Room = RoomRegistration
                };
                Actual = new Address()
                {
                    AddressFull = AddressFullActual,
                    Index = IndexActual,
                    Country = CountryActual,
                    Region = RegionActual,
                    District = DistrictActual,
                    City = CityActual,
                    Street = StreetActual,
                    House = HouseActual,
                    Room = RoomActual
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
                SecondName = SecondName,
                FirstName = FirstName,
                MiddleName = MiddleName,
                TypePassport = IsTypeDocs,
                Serial = Serial,
                Number = Number,
                Issued = Issued,
                Division = Division,
                DateIssued = PrivatePerson.DateIssued,
                AddressFullRegistration = AddressFullRegistration,
                IndexRegistration = int.Parse(IndexRegistration),
                CountryRegistration = CountryRegistration,
                RegionRegistration = RegionRegistration,
                DistrictRegistration = DistrictRegistration,
                CityRegistration = CityRegistration,
                StreetRegistration = StreetRegistration,
                HouseRegistration = HouseRegistration,
                RoomRegistration = RoomRegistration,
                AddressMatch = IsAddressMatch,
                AddressFullActual = AddressFullActual,
                IndexActual = int.Parse(IndexActual),
                CountryActual = CountryActual,
                RegionActual = RegionActual,
                DistrictActual = DistrictActual,
                CityActual = CityActual,
                StreetActual = StreetActual,
                HouseActual = HouseActual,
                RoomActual = RoomActual
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

        #region Свойства
        #region Properties PrivatePerson
        private string secondName;
        public string SecondName
        {
            get => secondName;
            set => SetProperty(ref secondName, value);
        }
        private string firstName;
        public string FirstName
        {
            get => firstName;
            set => SetProperty(ref firstName, value);
        }
        private string middleName;
        public string MiddleName
        {
            get => middleName;
            set => SetProperty(ref middleName, value);
        }
        private string serial;
        public string Serial
        {
            get => serial;
            set => SetProperty(ref serial, value);
        }
        private string number;
        public string Number
        {
            get => number;
            set => SetProperty(ref number, value);
        }
        private string issued;
        public string Issued
        {
            get => issued;
            set => SetProperty(ref issued, value);
        }
        private string division;
        public string Division
        {
            get => division;
            set => SetProperty(ref division, value);
        }
        #endregion Properties PreivatePerson
        #region Properties Address Registration
        private string addressFullRegistration;
        public string AddressFullRegistration
        {
            get => addressFullRegistration;
            set => SetProperty(ref addressFullRegistration, value);
        }
        private string indexRegistration;
        public string IndexRegistration
        {
            get => indexRegistration;
            set => SetProperty(ref indexRegistration, value);
        }
        private string countryRegistration;
        public string CountryRegistration
        {
            get => countryRegistration;
            set => SetProperty(ref countryRegistration, value);
        }
        private string regionRegistration;
        public string RegionRegistration
        {
            get => regionRegistration;
            set => SetProperty(ref regionRegistration, value);
        }
        private string districtRegistration;
        public string DistrictRegistration
        {
            get => districtRegistration;
            set => SetProperty(ref districtRegistration, value);
        }
        private string cityRegistration;
        public string CityRegistration
        {
            get => cityRegistration;
            set => SetProperty(ref cityRegistration, value);
        }
        private string streetRegistration;
        public string StreetRegistration
        {
            get => streetRegistration;
            set => SetProperty(ref streetRegistration, value);
        }
        private string houseRegistration;
        public string HouseRegistration
        {
            get => houseRegistration;
            set => SetProperty(ref houseRegistration, value);
        }
        private string roomRegistration;
        public string RoomRegistration
        {
            get => roomRegistration;
            set => SetProperty(ref roomRegistration, value);
        }
        #endregion Properties Address Registration
        #region Properties Address Actual
        private string addressFullActual;
        public string AddressFullActual
        {
            get => addressFullActual;
            set => SetProperty(ref addressFullActual, value);
        }
        private string indexActual;
        public string IndexActual
        {
            get => indexActual;
            set => SetProperty(ref indexActual, value);
        }
        private string countryActual;
        public string CountryActual
        {
            get => countryActual;
            set => SetProperty(ref countryActual, value);
        }
        private string regionActual;
        public string RegionActual
        {
            get => regionActual;
            set => SetProperty(ref regionActual, value);
        }
        private string districtActual;
        public string DistrictActual
        {
            get => districtActual;
            set => SetProperty(ref districtActual, value);
        }
        private string cityActual;
        public string CityActual
        {
            get => cityActual;
            set => SetProperty(ref cityActual, value);
        }
        private string streetActual;
        public string StreetActual
        {
            get => streetActual;
            set => SetProperty(ref streetActual, value);
        }
        private string houseActual;
        public string HouseActual
        {
            get => houseActual;
            set => SetProperty(ref houseActual, value);
        }
        private string roomActual;
        public string RoomActual
        {
            get => roomActual;
            set => SetProperty(ref roomActual, value);
        }
        #endregion Properties Address Actual
        #endregion Свойства

        #region IDataErrorInfo
        public string this[string columnName]
        {
            get
            {
                string error = string.Empty;
                switch (columnName)
                {
                    case
                        "SecondName":
                        if (SecondName == null)
                            error = "\"Фамилия\": обязательно для заполнения";
                        break;
                    case
                        "FirstName":
                        if (FirstName == null)
                            error = "\"Имя\": обязательно для заполнения";
                        break;
                    case
                        "MiddleName":
                        if (MiddleName == null)
                            error = "\"Отчество\": обязательно для заполнения";
                        break;
                    case
                        "Serial":
                        if (Serial == null)
                            error = "\"Серия паспорта\": обязательно для заполнения";
                        else if (Serial.Length != 4)
                            error = "\"Серия паспорта\": состоит из 4 символов";
                        break;
                    case
                        "Number":
                        if (Number == null)
                            error = "\"Номер паспорта\": обязательно для заполнения";
                        else if (Number.Length != 6)
                            error = "\"Номер паспорта\": состоит из 6 символов";
                        break;
                    case
                        "Issued":
                        if (Issued == null)
                            error = "\"Кем выдан пастпорт\": обязательно для заполнения";
                        break;
                    case
                        "Division":
                        if (Division == null)
                            error = "\"Код подразделения\": обязательно для заполнения";
                        break;
                    case
                        "AddressFullRegistration":
                        if (AddressFullRegistration == null)
                            error = "\"Адрес регистрации\": обязательно для заполнения";
                        break;
                    case "IndexRegistration":
                        if (IndexRegistration == null)
                            error = "\"Индекс адреса регистрации\": обязательно для заполнения";
                        else if (IndexRegistration.Length != 6)
                            error = "\"Индекс адреса регистрации\": состоит из 6 символов";
                        break;
                    case
                        "CountryRegistration":
                        if (CountryRegistration == null)
                            error = "\"Страна адреса регистрации\": обязательно для заполнения";
                        break;
                    case
                        "RegionRegistration":
                        if (RegionRegistration == null)
                            error = "\"Субъект адреса регистрации\": обязательно для заполнения";
                        break;
                    case
                        "DistrictRegistration":
                        if (DistrictRegistration == null)
                            error = "\"Район адреса регистрации\": обязательно для заполнения";
                        break;
                    case
                        "CityRegistration":
                        if (CityRegistration == null)
                            error = "\"Город адреса регистрации\": обязательно для заполнения";
                        break;
                    case
                        "HouseRegistration":
                        if (HouseRegistration == null)
                            error = "\"Номер дома адреса регистрации\": обязательно для заполнения";
                        break;
                    case
                        "RoomRegistration":
                        if (RoomRegistration == null)
                            error = "\"Номер квартиры адреса регистрации\": обязательно для заполнения";
                        break;
                    case
                        "AddressFullActual":
                        if (AddressFullActual == null)
                            error = "\"Адрес фатического проживания\": обязательно для заполнения";
                        break;
                    case "IndexActual":
                        if (IndexActual == null)
                            error = "\"Индекс фатического проживания\": обязательно для заполнения";
                        else if (IndexActual.Length != 6)
                            error = "\"Индекс адреса регистрации\": состоит из 6 символов";
                        break;
                    case
                        "CountryActual":
                        if (CountryActual == null)
                            error = "\"Страна фатического проживания\": обязательно для заполнения";
                        break;
                    case
                        "RegionActual":
                        if (RegionActual == null)
                            error = "\"Субъект фатического проживания\": обязательно для заполнения";
                        break;
                    case
                        "DistrictActual":
                        if (DistrictActual == null)
                            error = "\"Район фатического проживания\": обязательно для заполнения";
                        break;
                    case
                        "CityActual":
                        if (CityActual == null)
                            error = "\"Город фатического проживания\": обязательно для заполнения";
                        break;
                    case
                        "HouseActual":
                        if (HouseActual == null)
                            error = "\"Номер дома фатического проживания\": обязательно для заполнения";
                        break;
                    case
                        "RoomActual":
                        if (RoomActual == null)
                            error = "\"Номер квартиры фатического проживания\": обязательно для заполнения";
                        break;
                }
                return error;
            }
        }
        public string Error => "";
        #endregion

        
    }
}
