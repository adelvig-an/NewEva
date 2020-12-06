using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEva.DbLayer
{
    class QualificationCertificates
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string NameQualification { get; set; } //Название квалификационного аттестата
        public string NumberQualification { get; set; } //Номер квалификационного аттестата
        public DateTime? DateFromQualification { get; set; } //Дата выдачи квалификационного аттестата
        public DateTime? DateBeforeQualification { get; set; } //Окончание действия квалификационного аттестата
        public string NameOrganizationQualification { get; set; } //Наименование учреждения выдавшее квалификационный аттестат
        public string ActvityQualification { get; set; } //Направление деятельности квалификационного аттестата
        //[Indexed]
        //public int AppraisersId { get; set; }
    }
}
