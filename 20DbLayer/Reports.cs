using SQLite;
using System;

namespace NewEva.DbLayer
{
    public class Reports
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Number { get; set; } //Номер отчета
        public DateTime? Vulation_date { get; set; } //Дата оценки
        public DateTime? Compilation_date { get; set; } //Дата составления
        public DateTime? Inspection_date { get; set; } //Дата осмотра
        public string Inspection_feaures { get; set; } //Особенности проведения осмотра
        [Indexed]
        public int Id_contracts { get; set; }
        [Indexed]
        public int Id_appraisers { get; set; }
    }
}
