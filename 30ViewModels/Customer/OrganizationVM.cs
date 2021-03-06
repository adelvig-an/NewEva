﻿using NewEva.DbLayer;
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

        public OrganizationVM(Model.Customer customer = null)
        {
            if (IsEdit = customer != null) // если редактировать
            {
                Id = customer.Id;

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
        }
        public void ActualToActual()
        {
            AddressFullActual = "";
        }

        #region Properties
        private string nameFullOpf;
        private string nameShortOpf;
        private string opf;
        private string ogrn;
        private DateTime? ogrnDate;
        private string inn;
        private string kpp;
        private string bank;
        private string bik;
        private string payAccount;
        private string corrAccount;
        private string secondName;
        private string firstName;
        private string middleName;
        private string position;
        private string powerOfAttorney;
        private DateTime? powerOfAttorneyDate;
        private DateTime? powerOfAttorneyDateBefore;
        private string addressFullRegistration;
        private string addressFullActual;

        public int Id { get; set; }
        [Required(ErrorMessage = "Обязательно для заполнения")]
        public string NameFullOpf{ 
            get=>nameFullOpf;
            set
            {
                ValidateProperty(value);
                SetProperty(ref nameFullOpf, value);
            }
        }
        [Required(ErrorMessage = "Обязательно для заполнения")]
        public string NameShortOpf
        { 
            get=> nameShortOpf;
            set
            {
                ValidateProperty(value);
                SetProperty(ref nameShortOpf, value);
            }
        } 
        public string Opf
        { 
            get=>opf; 
            set 
            { 
                ValidateProperty(value);
                SetProperty(ref opf, value);
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
        public DateTime? OGRNDate
        { 
            get=>ogrnDate;
            set
            {
                ValidateProperty(value);
                SetProperty(ref ogrnDate, value);
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
        public string Bank
        { 
            get=>bank; 
            set
            {
                ValidateProperty(value);
                SetProperty(ref bank, value);
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
        public string PowerOfAttorney
        {
            get => powerOfAttorney;
            set
            {
                ValidateProperty(value);
                SetProperty(ref powerOfAttorney, value);
            }
        }
        [Required(ErrorMessage = "Обязательно для заполнения")]
        public DateTime? PowerOfAttorneyDate
        {
            get => powerOfAttorneyDate;
            set
            {
                ValidateProperty(value);
                SetProperty(ref powerOfAttorneyDate, value);
            }
        }
        [Required(ErrorMessage = "Обязательно для заполнения")]
        public DateTime? PowerOfAttorneyDateBefore
        {
            get => powerOfAttorneyDateBefore;
            set
            {
                ValidateProperty(value);
                SetProperty(ref powerOfAttorneyDateBefore, value);
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
        #endregion

        #region CBOR
        static CBORObject ToCBOR(OrganizationVM organizationVM)
        {
            return CBORObject.NewArray()
                .Add(organizationVM.Id)
                .Add(organizationVM.NameFullOpf)
                .Add(organizationVM.NameShortOpf)
                .Add(organizationVM.Opf)
                .Add(organizationVM.OGRN)
                .Add(organizationVM.INN)
                .Add(organizationVM.KPP)
                .Add(organizationVM.Bank)
                .Add(organizationVM.BIK)
                .Add(organizationVM.PayAccount)
                .Add(organizationVM.CorrAccount)
                .Add(organizationVM.SecondName)
                .Add(organizationVM.FirstName)
                .Add(organizationVM.MiddleName)
                .Add(organizationVM.Position)
                .Add(organizationVM.PowerOfAttorney)
                .Add(organizationVM.PowerOfAttorneyDate.HasValue
                ? CBORObject.NewArray().Add(true).Add(organizationVM.PowerOfAttorneyDate.Value.ToBinary())
                : CBORObject.NewArray().Add(false))
                .Add(organizationVM.PowerOfAttorneyDateBefore.HasValue
                ? CBORObject.NewArray().Add(true).Add(organizationVM.PowerOfAttorneyDateBefore.Value.ToBinary())
                : CBORObject.NewArray().Add(false))
                .Add(organizationVM.AddressFullRegistration)
                .Add(organizationVM.AddressFullActual);
        }
        void FromCBOR(CBORObject cbor)
        {
            Id = cbor[0].AsInt32();
            NameFullOpf = cbor[1].AsString();
            NameShortOpf = cbor[2].AsString();
            Opf = cbor[3].AsString();
            OGRN = cbor[4].AsString();
            INN = cbor[5].AsString();
            KPP = cbor[6].AsString();
            Bank = cbor[7].AsString();
            BIK = cbor[8].AsString();
            PayAccount = cbor[9].AsString();
            CorrAccount = cbor[10].AsString();
            SecondName = cbor[11].AsString();
            FirstName = cbor[12].AsString();
            MiddleName = cbor[13].AsString();
                Position = cbor[14].AsString();
            PowerOfAttorney = cbor[15].AsString();
            PowerOfAttorneyDate = cbor[16][0].AsBoolean()
            ? new DateTime?(DateTime.FromBinary(cbor[16][1].AsInt64()))
            : null;
            PowerOfAttorneyDateBefore = cbor[17][0].AsBoolean()
            ? new DateTime?(DateTime.FromBinary(cbor[17][1].AsInt64()))
            : null;
            AddressFullRegistration = cbor[18].AsString();
            AddressFullActual = cbor[19].AsString();
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
    }
}
