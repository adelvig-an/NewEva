using System;
using SQLite;

namespace NewEva.DbLayer
{
    class Insurance_policies
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Insurance_company { get; set; } //Название страховой компании
        public string Number { get; set; } //Номер полиса
        public int Insurance_money { get; set; } //Страховое возмещение (Застрахованная сумма)
        public DateTime Date_from { get; set; } //Дата "от"
        public DateTime Deta_before { get; set; } //Дата "до"
    }
}
