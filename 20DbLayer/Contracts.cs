using SQLite;
using System;

namespace NewEva.DbLayer
{
    public class Contracts
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Number { get; set; } //Номер договора
        public DateTime? Contract_date { get; set; } //Дата договора
        public string Target { get; set; } //Цель оценки
        public string Intended_use { get; set; } //Вид стоимости
        [Indexed]
        public int Id_customers { get; set; }
    }
}
