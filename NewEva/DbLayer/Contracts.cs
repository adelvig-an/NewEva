using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEva.DbLayer
{
    public class Contracts
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Number { get; set; } //Номер договора
        public DateTime? DateContract { get; set; } //Дата договора
        public string Target { get; set; } //Цель оценки
        public string TypeCost { get; set; } //Вид стоимости
        //[Indexed]
        //public int CustomersId { get; set; }
    }
}
