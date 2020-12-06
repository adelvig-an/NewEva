using System;
using System.Collections.Generic;
using System.Text;

namespace NewEva.Model.Contractor
{
    enum TypeActvityQualification
    {
        EstateAppraisal, //оценка недвижимости
        ValuationOfMovableProperty, //оценка движимого имущества
        BusinessValuation //оцека бизнеса
    }

    public class Appraiser : Person
    {
        public int Id { get; set; }
        public DateTime? GettingStarted { get; set; } //Год начала работы
        public int Experience { get; set; } //Опыт работы
        //Информация об образовании
        public string Diplom { get; set; } //Название специальности
        public string Serial { get; set; } //Сери диплома
        public int Number { get; set; } //Номер диплома
        public DateTime? DateDiplom { get; set; } //Дата выдачи диплома
        public string Universety { get; set; } //Название Университета
        //Информация о СРО
        public string NameSRO { get; set; } //Название СРО
        public int NumberRegistry { get; set; } //Регистрационный номер
        public DateTime? DateRegistry { get; set; } //Дата регистрации в СРО
        //Информация о квалификационных аттестатах
        public string NameQualification { get; set; } //Название квалификационного аттестата
        public string NumberQualification { get; set; } //Номер квалификационного аттестата
        public DateTime? DateFromQualification { get; set; } //Дата выдачи квалификационного аттестата
        public DateTime? DateBeforeQualification { get; set; } //Окончание действия квалификационного аттестата
        public string NameOrganizationQualification { get; set; } //Наименование учреждения выдавшее квалификационный аттестат
        public string ActvityQualification { get; set; } //Направление деятельности квалификационного аттестата

        #region Перенести в AppraiserVM
        //Расчет опыта работы от даты рождения
        //public int ExperienceResult
        //{
        //    get
        //    {
        //        var age = DateTime.Now.Year - GettingStarted.Year;
        //        if (DateTime.Now.Month < GettingStarted.Month ||
        //           (DateTime.Now.Month == GettingStarted.Month && DateTime.Now.Day < GettingStarted.Day)) age--;
        //        return age;
        //    }
        //}
        #endregion Перенести в AppraiserVM
    }
}
