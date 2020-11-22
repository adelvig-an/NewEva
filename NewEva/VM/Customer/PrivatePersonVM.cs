using NewEva.DbLayer;
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
            if (IsEdit = customer != null) // если редактировать
            {
                Id = customer.Id;
                SecondName = customer.SecondName;
                FirstName = customer.FirstName;
                MiddleName = customer.MiddleName;
                Serial = customer.Serial;
                Number = customer.Number;
                Issued = customer.Issued;
                DateIssued = customer.DateIssued;
                
                IsTypeDocs = customer.TypePassport;

                AddressFullRegistration = customer.AddressFullRegistration;
                IndexRegistration = customer.IndexRegistration.ToString();
                CountryRegistration = customer.CountryRegistration;
                RegionRegistration = customer.RegionRegistration;
                DistrictRegistration = customer.DistrictRegistration;
                CityRegistration = customer.CityRegistration;
                StreetRegistration = customer.StreetRegistration;
                HouseRegistration = customer.HouseRegistration;
                RoomRegistration = customer.RoomRegistration;
                
                IsAddressMatch = customer.AddressMatch;

                AddressFullActual = customer.AddressFullActual;
                IndexActual = customer.IndexActual.ToString();
                CountryActual = customer.CountryActual;
                RegionActual = customer.RegionActual;
                DistrictActual = customer.DistrictActual;
                CityActual = customer.CityActual;
                StreetActual = customer.StreetActual;
                HouseActual = customer.HouseActual;
                RoomActual = customer.RoomActual;
                
            }
            
            TypeDocs = LocalStorage.TypeDocs;
        }

        private string isTypeDocs;
        public string IsTypeDocs
        {
            get => isTypeDocs;
            set => SetProperty(ref isTypeDocs, value);
        }

        //Для сохранения в базу данных
        public Customers ToCustomers()
        {
            var customer = new Customers
            {
                Id = Id,
                TypeCustomer = true,
                SecondName = SecondName,
                FirstName = FirstName,
                MiddleName = MiddleName,
                TypePassport = IsTypeDocs,
                Serial = Serial,
                Number = Number,
                Issued = Issued,
                DateIssued = DateIssued,
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

        #region Properties
        #region Properties PrivatePerson
        public int Id { get; set; }
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
        [Required]
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
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Должно быть 4 цифры")]
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
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Должно быть 6 цифр")]
        public string Number
        {
            get => number;
            set {
                ValidateProperty(value);
                SetProperty(ref number, value);
            }
        }
        private DateTime? dateIssued = DateTime.Today;
        [Required(ErrorMessage = "Обязательно для заполнения")]
        public DateTime? DateIssued
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
        public string IndexRegistration
        {
            get => indexRegistration;
            set {
                ValidateProperty(value);
                SetProperty(ref indexRegistration, value);
            }
        }
        private string countryRegistration;
        public string CountryRegistration
        {
            get => countryRegistration;
            set {
                ValidateProperty(value);
                SetProperty(ref countryRegistration, value);
            }
        }
        private string regionRegistration;
        public string RegionRegistration
        {
            get => regionRegistration;
            set {
                ValidateProperty(value);
                SetProperty(ref regionRegistration, value);
            }
        }
        private string districtRegistration;
        public string DistrictRegistration
        {
            get => districtRegistration;
            set {
                ValidateProperty(value);
                SetProperty(ref districtRegistration, value);
            }
        }
        private string cityRegistration;
        public string CityRegistration
        {
            get => cityRegistration;
            set {
                ValidateProperty(value);
                SetProperty(ref cityRegistration, value);
            }
        }
        private string streetRegistration;
        public string StreetRegistration
        {
            get => streetRegistration;
            set {
                ValidateProperty(value);
                SetProperty(ref streetRegistration, value);
            }
        }
        private string houseRegistration;
        public string HouseRegistration
        {
            get => houseRegistration;
            set {
                ValidateProperty(value);
                SetProperty(ref houseRegistration, value);
            }
        }
        private string roomRegistration;
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
        public string IndexActual
        {
            get => indexActual;
            set {
                ValidateProperty(value);
                SetProperty(ref indexActual, value);
            }
        }
        private string countryActual;
        public string CountryActual
        {
            get => countryActual;
            set {
                ValidateProperty(value);
                SetProperty(ref countryActual, value);
            }
        }
        private string regionActual;
        public string RegionActual
        {
            get => regionActual;
            set {
                ValidateProperty(value);
                SetProperty(ref regionActual, value);
            }
        }
        private string districtActual;
        public string DistrictActual
        {
            get => districtActual;
            set {
                ValidateProperty(value);
                SetProperty(ref districtActual, value);
            }
        }
        private string cityActual;
        public string CityActual
        {
            get => cityActual;
            set {
                ValidateProperty(value);
                SetProperty(ref cityActual, value);
            }
        }
        private string streetActual;
        public string StreetActual
        {
            get => streetActual;
            set {
                ValidateProperty(value);
                SetProperty(ref streetActual, value);
            }
        }
        private string houseActual;
        public string HouseActual
        {
            get => houseActual;
            set {
                ValidateProperty(value);
                SetProperty(ref houseActual, value);
            }
        }
        private string roomActual;
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
