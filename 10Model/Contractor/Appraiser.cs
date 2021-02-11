using System;

namespace NewEva.Model.Contractor
{
    public class Appraiser : Person
    {
        public DateTime? StartedDate { get; set; } //Год начала работы
        //Информация об образовании
        public string Diplom { get; set; } //Название специальности
        public string Serial { get; set; } //Сери диплома
        public int Number { get; set; } //Номер диплома
        public DateTime? DiplomDate { get; set; } //Дата выдачи диплома
        public string Universety { get; set; } //Название Университета
        //Информация о СРО
        public string SRO { get; set; } //Название СРО
        public int SRORegistry { get; set; } //Регистрационный номер
        public DateTime? SRORegistryDate { get; set; } //Дата регистрации в СРО

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
