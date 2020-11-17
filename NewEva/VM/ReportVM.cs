using NewEva.DbLayer;
using NewEva.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;

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
                currentPage?.Write();
                SetProperty(ref currentPage, value);
            }
        }
        public bool IsEdit { get; }
        public Report Report { get; private set; }
        public IEnumerable<string> Appraisers { get; }

        public ReportVM(Reports report = null)
        {
            if (IsEdit = report != null)
            {
                Id = report.Id;
                Number = report.Number;
                DateVulation = report.DateVulation;
                DateCompilation = report.DateCompilation;
                DateOfInspection = report.DateOfInspection;
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
        public int Id { get; set; }
        private string number;
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
        private DateTime? dateVulation;
        [Required(ErrorMessage = "Не указана дата оценки")]
        public DateTime? DateVulation
        { get => dateVulation;
            set
            {
                ValidateProperty(value);
                SetProperty(ref dateVulation, value);
            }
        }
        private DateTime? dateCompilation;
        [Required(ErrorMessage = "Не указана дата составления отчета")]
        public DateTime? DateCompilation
        { get => dateCompilation;
            set
            {
                ValidateProperty(value);
                SetProperty(ref dateCompilation, value);
            }
        }
        private DateTime? dateOfInspection;
        [Required(ErrorMessage = "Не указан дата осмотра")]
        public DateTime? DateOfInspection
        {
            get => dateOfInspection;
            set
            {
                ValidateProperty(value);
                SetProperty(ref dateOfInspection, value);
            }
        }
        private string isAppraiser;
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
        
        /// <summary>
        /// Преобразование для использования в методах сохранения и редоктирования Db
        /// </summary>
        public Reports ToReports()
        {
            var report = new Reports
            {
                Id = Id,
                Number = Number,
                DateVulation = DateVulation,
                DateCompilation = DateCompilation,
                DateOfInspection = DateOfInspection
            };
            return report;
        }

        /// <summary>
        /// Сохранение в db
        /// </summary>
        public int AddReport()
        {
            try
            {
                var report = ToReports();
                DataBase.Write(report);
                var newId = report.Id;
                return newId;
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// Редактирование в db
        /// </summary>
        public bool UpdateReport()
        {
            try
            {
                var report = ToReports();
                DataBase.UpdateData(report);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
