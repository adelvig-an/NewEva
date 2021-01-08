using NewEva.DbLayer;
using PeterO.Cbor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
                Serial = Serial,
                Number = Number,
                Issued = Issued,
                DateIssued = DateIssued,
                AddressFullRegistration = AddressFullRegistration,
                AddressFullActual = AddressFullActual
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

        #region CBOR
        static CBORObject ToCBOR(PrivatePersonVM privatePersonVM)
        {
            return CBORObject.NewArray()
                .Add(privatePersonVM.Id)
                .Add(privatePersonVM.SecondName)
                .Add(privatePersonVM.FirstName)
                .Add(privatePersonVM.MiddleName)
                .Add(privatePersonVM.Serial)
                .Add(privatePersonVM.Number)
                .Add(privatePersonVM.DateIssued.HasValue
                ? CBORObject.NewArray().Add(true).Add(privatePersonVM.DateIssued.Value.ToBinary())
                : CBORObject.NewArray().Add(false))
                .Add(privatePersonVM.AddressFullRegistration)
                .Add(privatePersonVM.IndexRegistration)
                .Add(privatePersonVM.CountryRegistration)
                .Add(privatePersonVM.RegionRegistration)
                .Add(privatePersonVM.DistrictRegistration)
                .Add(privatePersonVM.CityRegistration)
                .Add(privatePersonVM.StreetRegistration)
                .Add(privatePersonVM.HouseRegistration)
                .Add(privatePersonVM.RoomRegistration)
                .Add(privatePersonVM.AddressFullActual)
                .Add(privatePersonVM.IndexActual)
                .Add(privatePersonVM.CountryActual)
                .Add(privatePersonVM.RegionActual)
                .Add(privatePersonVM.DistrictActual)
                .Add(privatePersonVM.CityActual)
                .Add(privatePersonVM.StreetActual)
                .Add(privatePersonVM.HouseActual)
                .Add(privatePersonVM.RoomActual);
        }
        static PrivatePersonVM FromCBOR(CBORObject cbor)
        {
            return new PrivatePersonVM()
            {
                Id = cbor[0].AsInt32(),
                SecondName = cbor[1].AsString(),
                FirstName = cbor[2].AsString(),
                MiddleName = cbor[3].AsString(),
                Serial = cbor[4].AsString(),
                Number = cbor[5].AsString(),
                DateIssued = cbor[6][0].AsBoolean()
                ? new DateTime?(DateTime.FromBinary(cbor[6][1].AsInt64()))
                : null,
                AddressFullRegistration = cbor[7].AsString(),
                IndexRegistration = cbor[8].AsString(),
                CountryRegistration = cbor[9].AsString(),
                RegionRegistration = cbor[10].AsString(),
                DistrictRegistration = cbor[11].AsString(),
                CityRegistration = cbor[12].AsString(),
                StreetRegistration = cbor[13].AsString(),
                HouseRegistration = cbor[13].AsString(),
                RoomRegistration = cbor[14].AsString(),
                AddressFullActual = cbor[15].AsString(),
                IndexActual = cbor[16].AsString(),
                CountryActual = cbor[18].AsString(),
                DistrictActual = cbor[19].AsString(),
                CityActual = cbor[20].AsString(),
                StreetActual = cbor[21].AsString(),
                HouseActual = cbor[22].AsString(),
                RoomActual = cbor[23].AsString()
            };
        }
        #endregion CBOR


    }
}
