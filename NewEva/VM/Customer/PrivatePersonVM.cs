using NewEva.DbLayer;
using NewEva.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEva.VM.Customer
{
    public class PrivatePersonVM : PageVM
    {
        public PrivatePerson PrivatePerson { get; private set; }
        public Address Registration { get; private set; }
        public Address Actual { get; private set; }
        public IEnumerable<string> TypeDocs { get; }

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
        public PrivatePersonVM()
        {
            PrivatePerson = new PrivatePerson()
            {
                //SecondName = "Иванов",
                //FirstName = "Иван",
                //MiddleName = "Иванович",
                //Serial = "04 02",
                //Number = "245856",
                //Issued = "МВД г. Мухосранска",
                //Division = "025-046",
                DateIssued = DateTime.Today
            };
            TypeDocs = LocalStorage.TypeDocs;
            Registration = new Address()
            {
                //AddressFull = "662145, Российская Федерация, Смоленская область, Велижский район, г. Велиж, ул. Маяковского, д. 15, кв. 6",
                //Index = 662145,
                //Country = "Российская Федерация",
                //Region = "Смоленская область",
                //District = "Велижский район",
                //City = "Велиж",
                //Street = "Маяковского",
                //House = "15",
                //Room = "6"
            };
            Actual = new Address()
            {
                //AddressFull = "266542, Российская Федерация, Саратовская область, Аркадакский район, г. Аркадак, ул. Горького, д. 8, кв. 16",
                //Index = 266542,
                //Country = "Российская Федерация",
                //Region = "Саратовская область",
                //District = "Аркадакский район",
                //City = "Аркадак",
                //Street = "Горького",
                //House = "8",
                //Room = "16"
            };
        }

        private string isTypeDocs;
        public string IsTypeDocs
        {
            get => isTypeDocs;
            set => SetProperty(ref isTypeDocs, value);
        }

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

        public int UpdatePrivatePerson(Customers customer)
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
            return customer.Id;
        }
    }
}
