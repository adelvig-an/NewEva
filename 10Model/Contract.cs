using System;


namespace NewEva.Model
{
    public enum Target
    {
        MarketValue,
        MarketAndLiquidationValue,
        LiquidationValue,
        InvestmentValue,
    }
    
    public class Contract
    {
        public int Id { get; set; }
        public string Number { get; set; } //Номер договора
        public DateTime? ContractDate { get; set; } //Дата договора
        public string Target { get; set; } //Цель оценки
        public string IntendedUse { get; set; } //Предполагаемый вид использования
    }
}
