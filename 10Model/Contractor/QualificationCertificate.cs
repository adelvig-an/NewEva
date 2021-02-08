using System;


namespace NewEva.Model
{
    public enum Speciality
    {
        EstateAppraisal, //оценка недвижимости
        ValuationOfMovableProperty, //оценка движимого имущества
        BusinessValuation //оцека бизнеса
    }
    public class QualificationCertificate
    {
        public int Number { get; set; } //Номер квалификационного аттестата
        public DateTime DateFrom { get; set; } //Дата "от"
        public DateTime DateBefore { get; set; } //Дата "до"
        public Speciality Speciality { get; set; } //Направление оценочной деятельности
        public string Name { get; set; } //Наименование выдавшей организации
    }
}
