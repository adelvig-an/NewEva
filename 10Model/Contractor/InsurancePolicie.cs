using System;


namespace NewEva.Model
{
    public class InsurancePolicie
    {
        public int InsurancePolicieId { get; set; }
        public string InsuranceCompany { get; set; } //Название страховой компании
        public string Number { get; set; } //Номер полиса
        public int InsuranceMoney { get; set; } //Страховое возмещение (Застрахованная сумма)
        public DateTime DateFrom { get; set; } //Дата "от"
        public DateTime DetaBefore { get; set; } //Дата "до"
    }
}
