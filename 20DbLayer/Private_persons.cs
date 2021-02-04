using SQLite;
using System;

namespace NewEva.DbLayer
{
    public class Private_persons
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Serial { get; set; } //Серия документа
        public string Number { get; set; } //Номер документа
        public string Division { get; set; } //Кем выдан документ
        public string Division_code { get; set; } //Код подразделения
        public DateTime? Division_date { get; set; } //Дата выдачи
        [Indexed]
        public int Id_people { get; set; }
        [Indexed]
        public int Id_addresses_registration { get; set; }
        [Indexed]
        public int Id_addresses_actual { get; set; }
    }
}
