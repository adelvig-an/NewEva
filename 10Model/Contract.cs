using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public Target Target { get; set; }
        public string IntendedUse { get; set; } //Предполагаемый вид использования
        public virtual ICollection<Report> Reports { get; private set; } = new ObservableCollection<Report>();
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
