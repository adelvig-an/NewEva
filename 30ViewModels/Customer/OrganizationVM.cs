using NewEva.DbLayer;
using NewEva.Model;
using PeterO.Cbor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NewEva.VM.Customer
{
    public class OrganizationVM : PageVM
    {
        public IEnumerable<string> TypeAttorney { get; }

        /// <summary>
        /// переменная которая будет явно показывать для чего предназначена OrganizationVM
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

        public OrganizationVM(Customers customer = null)
        {
            if (IsEdit = customer != null) // если редактировать
            {
                Id = customer.Id;
                NameFull = customer.NameFull;
                OGRN = customer.OGRN.ToString();
                INN = customer.INN.ToString();
                KPP = customer.KPP.ToString();
                NameBank = customer.NameBank;
                BIK = customer.BIK.ToString();
                PayAccount = customer.PayAccount.ToString();
                CorrAccount = customer.CorrAccount.ToString();
                Position = customer.Position;
                IsTypeAttorney = customer.TypeAttorney;
                NumberAttorney = customer.NumberAttorney;
                DateAttorney = customer.DateAttorney;
                DateAttorneyBefore = customer.DateAttorneyBefore;
                SecondName = customer.SecondName;
                FirstName = customer.FirstName;
                MiddleName = customer.MiddleName;
                AddressFullRegistration = customer.AddressFullRegistration;
                AddressFullActual = customer.AddressFullActual;
            }
            TypeAttorney = LocalStorage.TypeAttorney;  
        }
        private string isTypeAttorney;
        public string IsTypeAttorney
        {
            get => isTypeAttorney;
            set => SetProperty(ref isTypeAttorney, value);
        }
        public void ActualToRegistration()
        {
            AddressFullActual = AddressFullRegistration;
            //IndexActual = IndexRegistration;
            //CountryActual = CountryRegistration;
            //RegionActual = RegionRegistration;
            //DistrictActual = DistrictRegistration;
            //CityActual = CityRegistration;
            //StreetActual = StreetRegistration;
            //HouseActual = HouseRegistration;
            //RoomActual = RoomRegistration;
        }
        public void ActualToActual()
        {
            AddressFullActual = "";
            //IndexActual = "";
            //CountryActual = "";
            //RegionActual = "";
            //DistrictActual = "";
            //CityActual = "";
            //StreetActual = "";
            //HouseActual = "";
            //RoomActual = "";
        }

        public Customers ToCustomers()
        {
            var customer = new Customers
            {
                Id = Id,
                NameFull = NameFull,
                OGRN = long.Parse(OGRN),
                INN = int.Parse(INN),
                KPP = int.Parse(KPP),
                NameBank = NameBank,
                BIK = int.Parse(BIK),
                PayAccount = long.Parse(PayAccount),
                CorrAccount = long.Parse(CorrAccount),
                Position = Position,
                TypeAttorney = IsTypeAttorney,
                NumberAttorney = NumberAttorney,
                DateAttorney = DateAttorney,
                DateAttorneyBefore = DateAttorneyBefore,
                SecondName = SecondName,
                FirstName = FirstName,
                MiddleName = MiddleName,
                AddressFullRegistration = AddressFullRegistration,
                AddressFullActual = AddressFullActual,
        };
            return customer;
        }
        public int AddOrganization()
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
        public bool UpdateOrganization()
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

        #region Properties
        public int Id { get; set; }
        private string nameFull;
        private string nameShort;
        private string organizationForm;
        private string ogrn;
        private DateTime? dateRegisration;
        private string inn;
        private string kpp;
        private string nameBank;
        private string bik;
        private string payAccount;
        private string corrAccount;
        [Required(ErrorMessage = "Обязательно для заполнения")]
        public string NameFull{ 
            get=>nameFull;
            set
            {
                ValidateProperty(value);
                SetProperty(ref nameFull, value);
            }
        }
        [Required(ErrorMessage = "Обязательно для заполнения")]
        public string NameShort{ 
            get=>nameShort;
            set
            {
                ValidateProperty(value);
                SetProperty(ref nameShort, value);
            }
        } 
        public string OrganizationForm
        { 
            get=>organizationForm; 
            set 
            { 
                ValidateProperty(value);
                SetProperty(ref organizationForm, value);
            } 
        }
        [Required(ErrorMessage = "Обязательно для заполнения")]
        [Range(0, long.MaxValue, ErrorMessage = "В ОГРН только цифры")]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "Должно быть 13 цифр")]
        public string OGRN{ 
            get=>ogrn; 
            set
            {
                ValidateProperty(value);
                SetProperty(ref ogrn, value);
            }
        }
        [Required(ErrorMessage = "Обязательно для заполнения")]
        public DateTime? DateRegistration
        { 
            get=>dateRegisration;
            set
            {
                ValidateProperty(value);
                SetProperty(ref dateRegisration, value);
            }
        }
        [Required(ErrorMessage = "Обязательно для заполнения")]
        [Range(0, int.MaxValue, ErrorMessage = "В ИНН только цифры")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Должно быть 10 цифр")]
        //Если ИП - 12 цифр
        public string INN
        { 
            get=>inn;
            set 
            {
                ValidateProperty(value);
                SetProperty(ref inn, value);
            }
        }
        [Required(ErrorMessage = "Обязательно для заполнения")]
        [Range(0, int.MaxValue, ErrorMessage = "В КПП только цифры")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "Должно быть 9 цифр")]
        public string KPP
        { 
            get=>kpp; 
            set
            {
                ValidateProperty(value);
                SetProperty(ref kpp, value);
            }
        }
        [Required(ErrorMessage = "Обязательно для заполнения")]
        public string NameBank
        { 
            get=>nameBank; 
            set
            {
                ValidateProperty(value);
                SetProperty(ref nameBank, value);
            }
        }
        [Required(ErrorMessage = "Обязательно для заполнения")]
        [Range(0, int.MaxValue, ErrorMessage = "В БИК только цифры")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "Должно быть 9 цифр")]
        public string BIK
        { 
            get=>bik; 
            set
            {
                ValidateProperty(value);
                SetProperty(ref bik, value);
            }
        }
        [Required(ErrorMessage = "Обязательно для заполнения")]
        [Range(0, long.MaxValue, ErrorMessage = "В расчетном счете только цифры")]
        [StringLength(20, MinimumLength = 20, ErrorMessage = "Должно быть 20 цифр")]
        public string PayAccount
        { 
            get=>payAccount; 
            set
            {
                ValidateProperty(value);
                SetProperty(ref payAccount, value);
            }
        }
        [Required(ErrorMessage = "Обязательно для заполнения")]
        [Range(0, long.MaxValue, ErrorMessage = "В корреспондентском счете только цифры")]
        [StringLength(20, MinimumLength = 20, ErrorMessage = "Должно быть 20 цифр")]
        public string CorrAccount
        { 
            get=>corrAccount; 
            set
            {
                ValidateProperty(value);
                SetProperty(ref corrAccount, value);
            }
        }
        
        #region Director
        private string secondName;
        private string firstName;
        private string middleName;
        private string position;
        private string numberAttorney;
        private DateTime? dateAttorney;
        private DateTime? dateAttorneyBefore;
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
        [Required(ErrorMessage = "Обязательно для заполнения")]
        [StringLength(20)]
        public string FirstName
        {
            get => firstName;
            set
            {
                ValidateProperty(value);
                SetProperty(ref firstName, value);
            }
        }
        [Required(ErrorMessage = "Обязательно для заполнения")]
        [StringLength(20)]
        public string MiddleName
        {
            get => middleName;
            set
            {
                ValidateProperty(value);
                SetProperty(ref middleName, value);
            }
        }
        [Required(ErrorMessage = "Обязательно для заполнения")]
        public string Position
        {
            get => position;
            set
            {
                ValidateProperty(value);
                SetProperty(ref position, value);
            }
        }
        [Required(ErrorMessage = "Обязательно для заполнения")]
        public string NumberAttorney
        {
            get => numberAttorney;
            set
            {
                ValidateProperty(value);
                SetProperty(ref numberAttorney, value);
            }
        }
        [Required(ErrorMessage = "Обязательно для заполнения")]
        public DateTime? DateAttorney
        {
            get => dateAttorney;
            set
            {
                ValidateProperty(value);
                SetProperty(ref dateAttorney, value);
            }
        }
        [Required(ErrorMessage = "Обязательно для заполнения")]
        public DateTime? DateAttorneyBefore
        {
            get => dateAttorneyBefore;
            set
            {
                ValidateProperty(value);
                SetProperty(ref dateAttorneyBefore, value);
            }
        }
        #endregion
        #region Properties Address Registration
        private string addressFullRegistration;
        [Required(ErrorMessage = "Обязательно для заполнения")]
        public string AddressFullRegistration
        {
            get => addressFullRegistration;
            set
            {
                ValidateProperty(value);
                SetProperty(ref addressFullRegistration, value);
            }
        }
        #endregion      
        #region Properties Address Actual
        private string addressFullActual;
        [Required(ErrorMessage = "Обязательно для заполнения")]
        public string AddressFullActual
        {
            get => addressFullActual;
            set
            {
                ValidateProperty(value);
                SetProperty(ref addressFullActual, value);
            }
        }
        #endregion

        #endregion

        #region CBOR
        static CBORObject ToCBOR(OrganizationVM organizationVM)
        {
            return CBORObject.NewArray()
                .Add(organizationVM.Id)
                .Add(organizationVM.NameFull)
                .Add(organizationVM.NameShort)
                .Add(organizationVM.OrganizationForm)
                .Add(organizationVM.OGRN)
                .Add(organizationVM.INN)
                .Add(organizationVM.KPP)
                .Add(organizationVM.NameBank)
                .Add(organizationVM.BIK)
                .Add(organizationVM.PayAccount)
                .Add(organizationVM.CorrAccount)
                .Add(organizationVM.SecondName)
                .Add(organizationVM.FirstName)
                .Add(organizationVM.MiddleName)
                .Add(organizationVM.Position)
                .Add(organizationVM.NumberAttorney)
                .Add(organizationVM.DateAttorney.HasValue
                ? CBORObject.NewArray().Add(true).Add(organizationVM.DateAttorney.Value.ToBinary())
                : CBORObject.NewArray().Add(false))
                .Add(organizationVM.DateAttorneyBefore.HasValue
                ? CBORObject.NewArray().Add(true).Add(organizationVM.DateAttorneyBefore.Value.ToBinary())
                : CBORObject.NewArray().Add(false))
                .Add(organizationVM.AddressFullRegistration)
                .Add(organizationVM.AddressFullActual);
        }
        static OrganizationVM FromCBOR(CBORObject cbor)
        {
            return new OrganizationVM()
            {
                Id = cbor[0].AsInt32(),
                NameFull = cbor[1].AsString(),
                NameShort = cbor[2].AsString(),
                OrganizationForm = cbor[3].AsString(),
                OGRN = cbor[4].AsString(),
                INN = cbor[5].AsString(),
                KPP = cbor[6].AsString(),
                NameBank = cbor[7].AsString(),
                BIK = cbor[8].AsString(),
                PayAccount = cbor[9].AsString(),
                CorrAccount = cbor[10].AsString(),
                SecondName = cbor[11].AsString(),
                FirstName = cbor[12].AsString(),
                MiddleName = cbor[13].AsString(),
                Position = cbor[14].AsString(),
                NumberAttorney=cbor[15].AsString(),
                DateAttorney = cbor[16][0].AsBoolean()
                ? new DateTime?(DateTime.FromBinary(cbor[16][1].AsInt64()))
                : null,
                DateAttorneyBefore = cbor[17][0].AsBoolean()
                ? new DateTime?(DateTime.FromBinary(cbor[17][1].AsInt64()))
                : null,
                AddressFullRegistration = cbor[18].AsString(),
                AddressFullActual = cbor[19].AsString(),
            };
        }
        #endregion CBOR
    }
}
