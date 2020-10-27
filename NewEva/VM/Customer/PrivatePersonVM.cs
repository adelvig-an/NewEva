﻿using NewEva.DbLayer;
using NewEva.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Input;

namespace NewEva.VM.Customer
{
    public class PrivatePersonVM : PageVM
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
                    ActualToRegistration();
                else
                    ActualToActual();
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
                    DateIssued = DateIssued,
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
        public void ActualToRegistration()
        {
            AddressFullActual = AddressFullRegistration;
            IndexActual = IndexRegistration;
            CountryActual = CountryRegistration;
            RegionActual = RegionRegistration;
            DistrictActual = DistrictRegistration;
            CityActual = CityRegistration;
            StreetActual = StreetRegistration;
            HouseActual = HouseRegistration;
            RoomActual = RoomRegistration;
        }
        public void ActualToActual()
        {
            AddressFullActual = "";
            IndexActual = "";
            CountryActual = "";
            RegionActual = "";
            DistrictActual = "";
            CityActual = "";
            StreetActual = "";
            HouseActual = "";
            RoomActual = "";
        }

        #region Свойства
        #region Properties PrivatePerson
        private string secondName;
        [Required(ErrorMessage = "Обязательно для заполнения")]
        [StringLength(20)]
        public string SecondName
        {
            get => secondName;
            set
            {
                ValidateProperty(value);
                SetProperty(ref secondName, value);
            }
        }
        private string firstName;
        [Required(ErrorMessage = "Обязательно для заполнения")]
        [StringLength(20)]
        public string FirstName
        {
            get => firstName;
            set {
                ValidateProperty(value);
                SetProperty(ref firstName, value);
            }
        }
        private string middleName;
        [Required(ErrorMessage = "Обязательно для заполнения")]
        public string MiddleName
        {
            get => middleName;
            set {
                ValidateProperty(value);
                SetProperty(ref middleName, value);
            }
        }
        private string serial;
        [Required(ErrorMessage = "Обязательно для заполнения")]
        [Range(0, int.MaxValue, ErrorMessage = "В серии пасорта только цифры")]
        [StringLength(4, ErrorMessage = "Должно быть 4 цифры")]
        public string Serial
        {
            get => serial;
            set
            {
                ValidateProperty(value);
                SetProperty(ref serial, value);
            }
        }
        private string number;
        [Required(ErrorMessage = "Обязательно для заполнения")]
        [Range(0, int.MaxValue, ErrorMessage = "В номере пасорта только цифры")]
        [StringLength(6, ErrorMessage = "Должно быть 6 цифр")]
        public string Number
        {
            get => number;
            set {
                ValidateProperty(value);
                SetProperty(ref number, value);
            }
        }
        private DateTime dateIssued = DateTime.Today;
        [Required(ErrorMessage = "Обязательно для заполнения")]
        public DateTime DateIssued
        {
            get => dateIssued;
            set {
                ValidateProperty(value);
                SetProperty(ref dateIssued, value);
            }
        }
        private string issued;
        [Required(ErrorMessage = "Обязательно для заполнения")]
        public string Issued
        {
            get => issued;
            set {
                ValidateProperty(value);
                SetProperty(ref issued, value);
            }
        }
        private string division;
        [Required(ErrorMessage = "Обязательно для заполнения")]
        public string Division
        {
            get => division;
            set {
                ValidateProperty(value);
                SetProperty(ref division, value);
            }
        }
        #endregion Properties PreivatePerson
        #region Properties Address Registration
        private string addressFullRegistration;
        [Required(ErrorMessage = "Обязательно для заполнения")]
        public string AddressFullRegistration
        {
            get => addressFullRegistration;
            set {
                ValidateProperty(value);
                SetProperty(ref addressFullRegistration, value);
            }
        }
        private string indexRegistration;
        [Required(ErrorMessage = "Обязательно для заполнения")]
        [Range(0, int.MaxValue, ErrorMessage = "В индексе адреса только цифры")]
        [StringLength(6, ErrorMessage = "Должно быть 6 цифр")]
        public string IndexRegistration
        {
            get => indexRegistration;
            set {
                ValidateProperty(value);
                SetProperty(ref indexRegistration, value);
            }
        }
        private string countryRegistration;
        [Required(ErrorMessage = "Обязательно для заполнения")]
        public string CountryRegistration
        {
            get => countryRegistration;
            set {
                ValidateProperty(value);
                SetProperty(ref countryRegistration, value);
            }
        }
        private string regionRegistration;
        [Required(ErrorMessage = "Обязательно для заполнения")]
        public string RegionRegistration
        {
            get => regionRegistration;
            set {
                ValidateProperty(value);
                SetProperty(ref regionRegistration, value);
            }
        }
        private string districtRegistration;
        [Required(ErrorMessage = "Обязательно для заполнения")]
        public string DistrictRegistration
        {
            get => districtRegistration;
            set {
                ValidateProperty(value);
                SetProperty(ref districtRegistration, value);
            }
        }
        private string cityRegistration;
        [Required(ErrorMessage = "Обязательно для заполнения")]
        public string CityRegistration
        {
            get => cityRegistration;
            set {
                ValidateProperty(value);
                SetProperty(ref cityRegistration, value);
            }
        }
        private string streetRegistration;
        [Required(ErrorMessage = "Обязательно для заполнения")]
        public string StreetRegistration
        {
            get => streetRegistration;
            set {
                ValidateProperty(value);
                SetProperty(ref streetRegistration, value);
            }
        }
        private string houseRegistration;
        [Required(ErrorMessage = "Обязательно для заполнения")]
        public string HouseRegistration
        {
            get => houseRegistration;
            set {
                ValidateProperty(value);
                SetProperty(ref houseRegistration, value);
            }
        }
        private string roomRegistration;
        [Required(ErrorMessage = "Обязательно для заполнения")]
        public string RoomRegistration
        {
            get => roomRegistration;
            set {
                ValidateProperty(value);
                SetProperty(ref roomRegistration, value);
            }
        }
        #endregion Properties Address Registration
        #region Properties Address Actual
        private string addressFullActual;
        [Required(ErrorMessage = "Обязательно для заполнения")]
        public string AddressFullActual
        {
            get => addressFullActual;
            set {
                ValidateProperty(value);
                SetProperty(ref addressFullActual, value);
            }
        }
        private string indexActual;
        [Required(ErrorMessage = "Обязательно для заполнения")]
        [Range(0, int.MaxValue, ErrorMessage = "В индексе адреса только цифры")]
        [StringLength(6, ErrorMessage = "Должно быть 6 цифр")]
        public string IndexActual
        {
            get => indexActual;
            set {
                ValidateProperty(value);
                SetProperty(ref indexActual, value);
            }
        }
        private string countryActual;
        [Required(ErrorMessage = "Обязательно для заполнения")]
        public string CountryActual
        {
            get => countryActual;
            set {
                ValidateProperty(value);
                SetProperty(ref countryActual, value);
            }
        }
        private string regionActual;
        [Required(ErrorMessage = "Обязательно для заполнения")]
        public string RegionActual
        {
            get => regionActual;
            set {
                ValidateProperty(value);
                SetProperty(ref regionActual, value);
            }
        }
        private string districtActual;
        [Required(ErrorMessage = "Обязательно для заполнения")]
        public string DistrictActual
        {
            get => districtActual;
            set {
                ValidateProperty(value);
                SetProperty(ref districtActual, value);
            }
        }
        private string cityActual;
        [Required(ErrorMessage = "Обязательно для заполнения")]
        public string CityActual
        {
            get => cityActual;
            set {
                ValidateProperty(value);
                SetProperty(ref cityActual, value);
            }
        }
        private string streetActual;
        [Required(ErrorMessage = "Обязательно для заполнения")]
        public string StreetActual
        {
            get => streetActual;
            set {
                ValidateProperty(value);
                SetProperty(ref streetActual, value);
            }
        }
        private string houseActual;
        [Required(ErrorMessage = "Обязательно для заполнения")]
        public string HouseActual
        {
            get => houseActual;
            set {
                ValidateProperty(value);
                SetProperty(ref houseActual, value);
            }
        }
        private string roomActual;
        [Required(ErrorMessage = "Обязательно для заполнения")]
        public string RoomActual
        {
            get => roomActual;
            set {
                ValidateProperty(value);
                SetProperty(ref roomActual, value);
            }
        }
        #endregion Properties Address Actual
        #endregion Свойства



        
    }
}
