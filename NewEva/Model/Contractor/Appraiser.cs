using System;
using System.Collections.Generic;
using System.Text;

namespace NewEva.Model
{
    public class Appraiser : Person
    {
        public DateTime GettingStarted { get; set; } //Год начала работы
        public int Experience { get; set; } //Опыт работы
        
        //Информация об образовании
        public string Diploma { get; set; } //Название специальности
        public string Serial { get; set; } //Сери диплома
        public int Number { get; set; } //Номер диплома
        public DateTime DateDiploma { get; set; } //Дата выдачи диплома
        public string Universety { get; set; } //Название Университета
        
        //Информация о СРО
        public string NameSRO { get; set; } //Название СРО
        public int NumberRegistry { get; set; } //Регистрационный номер
        public DateTime DateRegistry { get; set; } //Дата регистрации в СРО

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
