using SQLite;
using System;

namespace NewEva.DbLayer
{
    public class Directors
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Position { get; set; } // Должность руководителя
        public string Power_of_attorney { get; set; } //Действующий на основании (Устав, Доверенность, Закон)
        public string Power_of_attorney_number { get; set; } //Номер доверенности
        public DateTime? Power_of_attorney_date { get; set; } //Дата доверения
        public DateTime? Power_of_attorney_date_before { get; set; } //Дата "действует до"
        [Indexed]
        public int Id_people { get; set; }
    }
}
