using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
        public int Id { get; set; }
        public string Number { get; set; } //Номер договора
        public DateTime? ContractDate { get; set; } //Дата договора
        [Column(TypeName = "nvarchar(24)")]
        public Target Target { get; set; }
        public string IntendedUse { get; set; } //Предполагаемый вид использования
        public ICollection<Report> Reports { get; set; }
        public int CustomerId { get; set; }
    }
}
