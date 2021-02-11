using NewEva.DbLayer;
using NewEva.Model;
using NewEva.VM.Customer;
using PeterO.Cbor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;

namespace NewEva.VM
{
    public class ContractVM : PageVM
    {
        private PageVM currentPage;
        private string[] pages;
        private int currentIndex;
        public PageVM CurrentPage
        {
            get => currentPage;
            set
            {
                currentPage?.WriteCBOR();
                SetProperty(ref currentPage, value);
            }
        }
        public IEnumerable<string> TypeCosts { get; }
        public bool IsEdit { get; }
        public ContractVM(Contract contract = null)
        {
            if (IsEdit = contract != null)
            {
                Id = contract.ContractId;
                Number = contract.Number;
                ContractDate = contract.ContractDate;
                IsTypeCost = contract.IntendedUse;
                //Target = contract.Target;
            }
            TypeCosts = LocalStorage.TypeCosts;
            Pages = new string[]
            {
                "PrivatePersonListVM",
                "OrganizationListVM"
            };
            CurrentIndex = 0;
            NewCustomerPage = new RelayCommand(_ => NewCustomerCommand());
            BackPage = new RelayCommand(_ => BackCommand());
            SaveBackPage = new RelayCommand(_ => SaveBackCommand(), _ => CurrentPage.IsValid);
        }
        public string[] Pages
        {
            get => pages;
            set
            {
                SetProperty(ref pages, value);
            }
        }
        public int CurrentIndex
        {
            get => currentIndex;
            set
            {
                CurrentPage = CreatePageByName(pages[value]);
                CurrentPage.ReadCBOR();
                SetProperty(ref currentIndex, value);
            }
        }
        public PageVM CreatePageByName(string pageName)
        {
            if (pageName == "PrivatePersonListVM")
                return new PrivatePersonListVM();
            else if (pageName == "OrganizationListVM")
                return new OrganizationListVM();
            else
                return null;
        }

        public ICommand NewCustomerPage { get; }
        public ICommand SaveBackPage { get; }
        public ICommand BackPage { get; }
        public void NewCustomerCommand()
        {
            if (CurrentPage is PrivatePersonListVM)
                CurrentPage = new PrivatePersonVM();
            else if (CurrentPage is OrganizationListVM)
                CurrentPage = new OrganizationVM();
        }
        //Обработчик команды сохранения данных в БД и возвращения к списку
        public void SaveBackCommand()
        {
            if (CurrentPage is PrivatePersonVM privatePersonVM)
            {
                privatePersonVM.Validate();
                if (!privatePersonVM.IsValid)
                {
                    return;
                }
                if (privatePersonVM.IsEdit)
                {
                    privatePersonVM.UpdatePrivatePerson();
                    var id = privatePersonVM.Id;
                    CurrentPage = new PrivatePersonListVM(id);
                }
                else
                {
                    var id = privatePersonVM.AddPrivatePerson();
                    CurrentPage = new PrivatePersonListVM(id);
                }

            }
            else if (CurrentPage is OrganizationVM organizationVM)
            {
                organizationVM.Validate();
                if (!organizationVM.IsValid)
                {
                    return;
                }
                if (organizationVM.IsEdit)
                {
                    organizationVM.UpdateOrganization();
                    var id = organizationVM.Id;
                    CurrentPage = new OrganizationListVM(id);
                }
                else
                {
                    var id = organizationVM.AddOrganization();
                    CurrentPage = new OrganizationListVM(id);
                }

            }
        }
        public void BackCommand()
        {
            if (CurrentPage is PrivatePersonVM)
                CurrentPage = new PrivatePersonListVM();
            else if (CurrentPage is OrganizationVM)
                CurrentPage = new OrganizationListVM();
        }

        #region Property
        public int Id { get; set; }
        private string number;
        [Required(ErrorMessage = "Не указан номер договора")]
        [StringLength(20)]
        public string Number 
        {
            get => number;
            set
            {
                ValidateProperty(value);
                SetProperty(ref number, value);
            }
        }
        private DateTime? contractDate;
        [Required(ErrorMessage = "Не указана дата договора")]
        public DateTime? ContractDate
        {
            get => contractDate;
            set
            {
                ValidateProperty(value);
                SetProperty(ref contractDate, value);
            }
        }
        private string isTypeCost;
        [Required(ErrorMessage = "Не выбран тип стоимости")]
        public string IsTypeCost
        {
            get => isTypeCost;
            set
            {
                ValidateProperty(value);
                SetProperty(ref isTypeCost, value);
            }
        }
        private string target;
        [Required(ErrorMessage = "Не указан цель оценки")]
        [StringLength(250)]
        public string Target
        {
            get => target;
            set
            {
                ValidateProperty(value);
                SetProperty(ref target, value);
            }
        }
        #endregion

        #region CBOR
        static CBORObject ToCBOR(ContractVM contractVM)
        {
            return CBORObject.NewArray()
                .Add(contractVM.CurrentIndex)
                .Add(contractVM.Id)
                .Add(contractVM.Number)
                .Add(contractVM.ContractDate.HasValue
                ? CBORObject.NewArray().Add(true).Add(contractVM.ContractDate.Value.ToBinary())
                : CBORObject.NewArray().Add(false))
                .Add(contractVM.Target)
                .Add(contractVM.IsTypeCost);
        }
        void FromCBOR(CBORObject cbor)
        {
            CurrentIndex = cbor[0].AsInt32();
            Id = cbor[1].AsInt32();
            Number = cbor[2].AsString();
            ContractDate = cbor[3][0].AsBoolean()
            ? new DateTime?(DateTime.FromBinary(cbor[3][1].ToObject<long>()))
            : null;
            Target = cbor[5].AsString();
            IsTypeCost = cbor[6].AsString();
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
