using System;
using System.Collections.Generic;
using System.Text;

namespace NewEva.Model
{
    public class Appraiser : Person
    {
        public int Experience { get; set; }
        //Информация об образовании
        public string TitleDiplom { get; set; }
        public string SerialDiplom { get; set; }
        public int NumberDiplom { get; set; }
        public DateTime DateDiplom { get; set; }
        public string TitleUniversety { get; set; }
        //Информация о СРО
        public string TitleSRO { get; set; }
        public int NumberRegistry { get; set; }
        public DateTime DateRegistry { get; set; }
        //Информация о страховщике и страховке
        public string TitleInsurance { get; set; } //Название страховщика
        public string NumberPolis { get; set; } //Номер полиса
        public int InsuranceIndemnity { get; set; } //Страховое возмещение
        public DateTime DateFrom { get; set; } //Дата "от"
        public DateTime DetaBefore { get; set; } //Дата "до"
        //Данные Квалификационного аттестата "Оценка недвижимости"
        public int NumberQCR { get; set; }
        public DateTime DateFromQCR { get; set; }
        public DateTime DateBeforeQCR { get; set; }
        //Данные квалификационного аттестата "Оценка движимого имущества"
        public int NumberQCM { get; set; }
        public DateTime DateFromQCM { get; set; }
        public DateTime DateBeforeQCM { get; set; }
        //Данные квалификационного аттестата "Оценка бизнеса"
        public int NumberQCB { get; set; }
        public DateTime DateFromQCB { get; set; }
        public DateTime DateBeforeQCB { get; set; }
    }
}
