using NewEva.DbLayer;
using NewEva.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEva.VM.Customer
{
    public class OrganizationVM : PageVM
    {
        public Organization Organization { get; }
        public Director Director { get; }
        public Address Registration { get; }
        public Address Actual { get; private set; }
        public IEnumerable<string> TypeAttorney { get; }
        public IEnumerable<string> OrganizationForm { get; }

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

        public OrganizationVM()
        {
            Organization = new Organization()
            {
                TitleFull = "Общество с огараниченной ответственностью \"Рога и Копыта\"",
                TitleShort = "ООО \"Рога и Копыта\"",
                OGRN = 123,
                DateRegistration = DateTime.Today,
                INN = 123,
                KPP = 123,
                TitleBank = "Филиал в г. Владивосток ББР Банк",
                BIK = 123,
                PayAccount = 123,
                CorrAccount = 123
            };
            Director = new Director()
            {
                SecondName = "Петров",
                FirstName = "Петр",
                MiddleName = "Петрович",
                Position = "Генеральный директор",
                NumberAttorney = "123Д-2019",
                DateAttorney = DateTime.Today,
                DateAttorneyBefore = DateTime.Today
            };
            Registration = new Address()
            {
                AddressFull = "662145, Российская Федерация, Смоленская область, Велижский район, г. Велиж, ул. Маяковского, д. 15, пом. 6",
                Index = 662145,
                Country = "Российская Федерация",
                Region = "Смоленская область",
                District = "Велижский район",
                City = "Велиж",
                Street = "Маяковского",
                House = "15",
                Room = "6"
            };

            Actual = new Address()
            {
                AddressFull = "266542, Российская Федерация, Саратовская область, Аркадакский район, г. Аркадак, ул. Горького, д. 8, оф. 216",
                Index = 266542,
                Country = "Российская Федерация",
                Region = "Саратовская область",
                District = "Аркадакский район",
                City = "Аркадак",
                Street = "Горького",
                House = "8",
                Room = "216"
            };

            OrganizationForm = LocalStorage.OrganizationForm;
            TypeAttorney = LocalStorage.TypeAttorney;
        }

        private string isOrganizationForm;
        public string IsOrganizationForm
        {
            get => isOrganizationForm;
            set => SetProperty(ref isOrganizationForm, value);
        }
        private string isTypeAttorney;
        public string IsTypeAttorney
        {
            get => isTypeAttorney;
            set => SetProperty(ref isTypeAttorney, value);
        }

        public bool AddOrganization()
        {
            try
            {
                var customer = new Customers()
                {
                    TypeCustomer = false,
                    TitleFull = Organization.TitleFull,
                    TitleShort = Organization.TitleShort,
                    OrganizationForm = Organization.OrganizationForm,
                    OGRN = Organization.OGRN,
                    DateRegistration = Organization.DateRegistration,
                    INN = Organization.INN,
                    KPP = Organization.KPP,
                    TitleBank = Organization.TitleBank,
                    BIK = Organization.BIK,
                    PayAccount = Organization.PayAccount,
                    CorrAccount = Organization.CorrAccount,
                    Position = Director.Position,
                    SecondName = Director.SecondName,
                    FirstName = Director.FirstName,
                    MiddleName = Director.MiddleName,
                    TypeAttorney = Director.TypeAttorney,
                    NumberAttorney = Director.NumberAttorney,
                    DateAttorney = Director.DateAttorney,
                    DateAttorneyBefore = Director.DateAttorneyBefore,
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
                return true;

            }
            catch
            {
                return false;
            }
        }
    }
}
