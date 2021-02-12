using NewEva.DbLayer;
using NewEva.Model;
using PeterO.Cbor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewEva.VM
{
    public class ReportVM : PageVM
    {
        private PageVM currentPage;
        public PageVM CurrentPage
        {
            get => currentPage;
            set
            {
                currentPage?.WriteCBOR();
                SetProperty(ref currentPage, value);
            }
        }
        public bool IsEdit { get; }
        public Report Report { get; private set; }
        public IEnumerable<string> Appraisers { get; }

        public ReportVM(Report report = null)
        {
            if (IsEdit = report != null)
            {
                Id = report.Id;
                Number = report.Number;
                VulationDate = report.VulationDate;
                CompilationDate = report.CompilationDate;
                InspectionDate = report.InspectionDate;
            }
            Appraisers = LocalStorage.Appraisers;
            pages = new string[]
            {
                "ContractVM", 
                "ValidContractVM"
            };
            CurrentIndex = 0;
        }

        private string[] pages;
        public string[] Pages
        {
            get => pages;
            set
            {
                SetProperty(ref pages, value);
            }
        }

        private int currentIndex;
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
            if (pageName == "ContractVM")
                return new ContractVM();
            else if (pageName == "ValidContractVM")
                return new ValidContractVM();
            else
                return null;
        }

        #region Property
        private DateTime? vulationDate;
        private string number;
        private DateTime? compilationDate;
        private DateTime? inspectionDate;
        private string inspectionFeaures = "Отсутствуют";
        private string isAppraiser;
        
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указан номер отчета")]
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
        [Required(ErrorMessage = "Не указана дата оценки")]
        public DateTime? VulationDate
        { get => vulationDate;
            set
            {
                ValidateProperty(value);
                SetProperty(ref vulationDate, value);
            }
        }
        [Required(ErrorMessage = "Не указана дата составления отчета")]
        public DateTime? CompilationDate
        { get => compilationDate;
            set
            {
                ValidateProperty(value);
                SetProperty(ref compilationDate, value);
            }
        }
        [Required(ErrorMessage = "Не указан дата осмотра")]
        public DateTime? InspectionDate
        {
            get => inspectionDate;
            set
            {
                ValidateProperty(value);
                SetProperty(ref inspectionDate, value);
            }
        }
        [Required(ErrorMessage = "Обязательно для заполнения")]
        public string InspectionFeaures 
        { 
            get => inspectionFeaures;
            set
            {
                ValidateProperty(value);
                SetProperty(ref inspectionFeaures, value);
            }
        }
        [Required(ErrorMessage = "Не выбран оценщика исполнителя")]
        public string IsAppraiser
        {
            get => isAppraiser;
            set
            {
                ValidateProperty(value);
                SetProperty(ref isAppraiser, value);
            }
        }
        #endregion
        
        #region CBOR
        static CBORObject ToCBOR(ReportVM reportVM)
        {
            return CBORObject.NewArray()
                .Add(reportVM.CurrentIndex)
                .Add(reportVM.Id)
                .Add(reportVM.Number)
                .Add(reportVM.VulationDate.HasValue 
                ? CBORObject.NewArray().Add(true).Add(reportVM.VulationDate.Value.ToBinary()) 
                : CBORObject.NewArray().Add(false))
                .Add(reportVM.CompilationDate.HasValue
                ? CBORObject.NewArray().Add(true).Add(reportVM.CompilationDate.Value.ToBinary())
                : CBORObject.NewArray().Add(false))
                .Add(reportVM.InspectionDate.HasValue
                ? CBORObject.NewArray().Add(true).Add(reportVM.InspectionDate.Value.ToBinary())
                : CBORObject.NewArray().Add(false))
                .Add(reportVM.IsAppraiser);
        }
        void FromCBOR(CBORObject cbor)
        {
            CurrentIndex = cbor[0].AsInt32();
            Id = cbor[1].AsInt32();
            Number = cbor[2].AsString();
            VulationDate = cbor[3][0].AsBoolean()
            ? new DateTime?(DateTime.FromBinary(cbor[3][1].ToObject<long>()))
            : null;
            CompilationDate = cbor[4][0].AsBoolean()
            ? new DateTime?(DateTime.FromBinary(cbor[4][1].ToObject<long>()))
            : null;
            InspectionDate = cbor[5][0].AsBoolean()
            ? new DateTime?(DateTime.FromBinary(cbor[5][1].ToObject<long>()))
            : null;
            IsAppraiser = cbor[6].AsString();
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
