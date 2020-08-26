using System;
using System.Collections.Generic;
using System.Text;

namespace NewEva.Model
{
    public class Contractor : Organization
    {
        public string TitleInsurance { get; set; } //Название страховщика
        public string NumberPolis { get; set; } //Номер полиса
        public int InsuranceIndemnity { get; set; } //Страховое возмещение
        public DateTime DateFrom { get; set; } //Дата "от"
        public DateTime DetaBefore { get; set; } //Дата "до"
    }
}
