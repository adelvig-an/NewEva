using NewEva.DbLayer;
using NewEva.Model;
using PeterO.Cbor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
                
            }

            ConvertAddress = new RelayCommand(_ => ConvertAddressAction());
        }

        //Для сохранения в базу данных
        public Customers ToCustomers()
        {
            var customer = new Customers
            {
                Id = Id,
                //TypeCustomer = true,
                //Serial = Serial,
                //Number = Number,
                //Division = Division,
                //Division_date = DivisionDate,
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
            
        }
        public void ActualToActual()
        {
            AddressFullActual = "";

        }

        #region Properties
        private string secondName;
        private string firstName;
        private string middleName;
        private string serial;
        private string number;
        private string division;
        private DateTime? divisionDate = DateTime.Today;
        private string addressFullRegistration;
        private string addressFullActual;

        public int Id { get; set; }
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
            set {
                ValidateProperty(value);
                SetProperty(ref firstName, value);
            }
        }
        [Required]
        public string MiddleName
        {
            get => middleName;
            set {
                ValidateProperty(value);
                SetProperty(ref middleName, value);
            }
        }
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
        [Required(ErrorMessage = "Обязательно для заполнения")]
        public DateTime? DivisionDate
        {
            get => divisionDate;
            set {
                ValidateProperty(value);
                SetProperty(ref divisionDate, value);
            }
        }
        [Required(ErrorMessage = "Обязательно для заполнения")]
        public string Division
        {
            get => division;
            set {
                ValidateProperty(value);
                SetProperty(ref division, value);
            }
        } 
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
        #endregion Properties

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
                .Add(privatePersonVM.Division)
                .Add(privatePersonVM.DivisionDate.HasValue
                ? CBORObject.NewArray().Add(true).Add(privatePersonVM.DivisionDate.Value.ToBinary())
                : CBORObject.NewArray().Add(false))
                .Add(privatePersonVM.AddressFullRegistration)
                .Add(privatePersonVM.AddressFullActual);
        }
        void FromCBOR(CBORObject cbor)
        {
            Id = cbor[0].AsInt32();
            SecondName = cbor[1].AsString();
            FirstName = cbor[2].AsString();
            MiddleName = cbor[3].AsString();
            Serial = cbor[4].AsString();
            Number = cbor[5].AsString();
            Division = cbor[6].ToString();
            DivisionDate = cbor[7][0].AsBoolean()
            ? new DateTime?(DateTime.FromBinary(cbor[6][1].AsInt64()))
            : null;
            AddressFullRegistration = cbor[8].AsString();
            AddressFullActual = cbor[9].AsString();
        }
        public override byte[] GetCBOR()
        {
            return ToCBOR(this).EncodeToBytes();
        }
        public override void SetCBOR(byte[] b)
        {
            FromCBOR(CBORObject.DecodeFromBytes(b));
        }
        #endregion CBOR

        #region DadataService
        private Address selectedAddress;
        public Address SelectedAddress
        {
            get => selectedAddress;
            set 
            {
                if (SetProperty(ref selectedAddress, value))
                {
                    FillAddressRegistration(selectedAddress);
                }
            }
        }
        public void FillAddressRegistration(Address address)
        {
            AddressFullRegistration = address?.AddressFull;
        }
        public void FillAddressActual(Address address)
        {
            AddressFullActual = address?.AddressFull;
        }

        //Кнопка для теста
        public ICommand ConvertAddress { get; }
        public void ConvertAddressAction()
        {
            var result = DadataService.TypeGetAddress(AddressFullRegistration, out var address);
            if (result == true)
            {
                FillAddressRegistration(address);
            }
        }
        #endregion
    }
}
