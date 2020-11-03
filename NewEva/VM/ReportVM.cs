using NewEva.DbLayer;
using NewEva.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;
using System.Windows;

namespace NewEva.VM
{
    public class ReportVM : PageVM
    {
        public Report Report { get; private set; }
        public IEnumerable<string> Appraisers { get; }

        public ReportVM()
        {
            Appraisers = LocalStorage.Appraisers;
        }

        #region Property
        public int Id { get; set; }
        private string number;
        [Required(ErrorMessage = "Номер отчета обязателен")]
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
        [Required(ErrorMessage = "Дата оценки обязательна")]
        public DateTime? DateVulation
        { get => dateVulation;
            set
            {
                ValidateProperty(value);
                SetProperty(ref dateVulation, value);
            }
        }
        private DateTime? dateCompilation;
        [Required(ErrorMessage = "Дата составления отчета обязательна")]
        public DateTime? DateCompilation
        { get => dateCompilation;
            set
            {
                ValidateProperty(value);
                SetProperty(ref dateCompilation, value);
            }
        }
        private DateTime? dateOfInspection;
        [Required(ErrorMessage = "Дата осмотра обязательна")]
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
        [Required(ErrorMessage = "Необходимо выбрать оценщика исполнителя")]
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
