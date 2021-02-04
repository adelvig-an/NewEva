using SQLite;
using System;

namespace NewEva.DbLayer
{
    class Qualification_certificates
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Number { get; set; } //Номер квалификационного аттестата
        public DateTime Date_from { get; set; } //Дата "от"
        public DateTime Date_before { get; set; } //Дата "до"
        public string Name { get; set; } //Наименование выдавшей организации
        [Indexed]
        public int Id_appraisers { get; set; }
    }
}
