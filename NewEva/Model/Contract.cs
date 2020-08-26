using System;
using System.Collections.Generic;
using System.Text;

namespace NewEva.Model
{
    public class Contract
    {
        public string Number { get; set; } //Номер договора
        public DateTime DateContract { get; set; } //Дата договора
        public string Target { get; set; } //Цель оценки
        public string TypeCost { get; set; } //Вид стоимости
    }
}
