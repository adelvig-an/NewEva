using NewEva.DbLayer;
using NewEva.Model;
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
                OGRN = int.Parse(OGRN),
                INN = int.Parse(INN),
                KPP = int.Parse(KPP),
                NameBank = NameBank,
                BIK = int.Parse(BIK),
                PayAccount = int.Parse(PayAccount),
                CorrAccount = int.Parse(CorrAccount),
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
        [Range(0, int.MaxValue, ErrorMessage = "В ОГРН только цифры")]
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
        [Range(0, int.MaxValue, ErrorMessage = "В расчетном счете только цифры")]
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
        [Range(0, int.MaxValue, ErrorMessage = "В корреспондентском счете только цифры")]
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
    }
}
