using System;
using System.Collections.Generic;
using System.Text;

namespace NewEva.Model
{
    public class Insurance
    {
        public string NameInsurance { get; set; } //Название страховщика
        public string NumberPolis { get; set; } //Номер полиса
        public int InsuranceIndemnity { get; set; } //Страховое возмещение (Застрахованная сумма)
        public DateTime DateFrom { get; set; } //Дата "от"
        public DateTime DetaBefore { get; set; } //Дата "до"
    }
}
