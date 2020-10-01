using NewEva.DbLayer;
using NewEva.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEva.VM.Customer
{
    public class OrganizationVM : PageVM
    {
        public Organization Organization { get; private set; }
        public Director Director { get; private set; }
        public Address Registration { get; private set; }
        public Address Actual { get; private set; }
        public IEnumerable<string> TypeAttorney { get; }
        public IEnumerable<string> OrganizationForm { get; }

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

        public OrganizationVM(Customers customer = null)
        {
            if (IsEdit == true)
            {

            }
            else
            {
                Organization = new Organization()
                {
                    DateRegistration = DateTime.Today,
                };
                Director = new Director()
                {
                    DateAttorney = DateTime.Today,
                    DateAttorneyBefore = DateTime.Today
                };
                Registration = new Address()
                { };

                Actual = new Address()
                { };

                OrganizationForm = LocalStorage.OrganizationForm;
                TypeAttorney = LocalStorage.TypeAttorney;
            }
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

        public int AddOrganization()
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
                var newId = customer.Id;
                return newId;

            }
            catch
            {
                return -1;
            }
        }

        public int UpdateOrganization(Customers customer)
        {
            Organization = new Organization()
            {

            };
            Director = new Director()
            {

            };
            Registration = new Address()
            {

            };
            Actual = new Address()
            {

            };
            DataBase.UpdateData(customer);
            var updateId = customer.Id;
            return updateId;
        }
    }
}
