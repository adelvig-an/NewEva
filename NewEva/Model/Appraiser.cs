using System;
using System.Collections.Generic;
using System.Text;

namespace NewEva.Model
{
    public class Appraiser
    {
        public int Id { get; set; }
        public string SecondName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
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
        //Информация о страховке
        public string TitleInsurance { get; set; }
        public string NumberInsurance { get; set; }
        public int SumInsurance { get; set; }
        public DateTime DateFromInsurance { get; set; }
        public DateTime DetaBeforeInsurance { get; set; }
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
