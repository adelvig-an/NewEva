using NewEva.DbLayer;
using NewEva.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace NewEva.VM.Customer
{
    public class PrivatePersonVM : PageVM
    {
        public PrivatePerson PrivatePerson { get; private set; }
        public Address Registration { get; private set; }
        public Address Actual { get; private set; }
        public IEnumerable<string> TypeDocs { get; }
        
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
                OnPropertyChanged(nameof(Actual));
            }
        }
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
                    DateIssued = DateTime.Today
                };
                TypeDocs = LocalStorage.TypeDocs;
                Registration = new Address()
                { };
                Actual = new Address()
                { };
            }

        }

        private string isTypeDocs;
        public string IsTypeDocs
        {
            get => isTypeDocs;
            set => SetProperty(ref isTypeDocs, value);
        }
        /// <summary>
        /// Метод сохранения Физического лица
        /// </summary>
        /// <returns></returns>
        public int AddPrivatePerson()
        {
            try
            {
                var customer = new Customers
                {
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
                DataBase.Write(customer);
                var newId = customer.Id;
                return newId;
            }
            catch
            {

                return -1;
            }
        }

        public bool UpdatePrivatePerson()
        {
            try
            {
                var customer = new Customers
                {
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
                DataBase.UpdateData(customer);
                return true;
            }
            catch
            {

                return false;
            }
        }


    }
}
