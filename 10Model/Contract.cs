using System;
using System.Collections.Generic;

namespace NewEva.Model
{
    public enum Target
    {
        MarketValue,
        MarketAndLiquidationValue,
        ForMortgage,
        LiquidationValue,
        InvestmentValue,
    }
    
    public class Contract
    {
        public int ContractId { get; set; }
        public string Number { get; set; } //Номер договора
        public DateTime? ContractDate { get; set; } //Дата договора
        public Target Target { get; set; }
        public string IntendedUse { get; set; } //Предполагаемый вид использования
        public List<Report> Reports { get; set; } = new List<Report>();
        public int CustomerId { get; set; }
    }
}
